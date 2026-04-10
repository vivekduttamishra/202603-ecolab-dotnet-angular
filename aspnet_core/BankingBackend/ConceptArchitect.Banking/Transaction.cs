using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public enum TransactionType { Debit, Credit }
    public enum TransactionStatus { Success, Failed, Disputed, Resolved, Reversed}
    public class TransactionInfo
    {
        public Guid Id { get; set; }

        public Guid? RefTransactionId { get; set; } 

        public int AccountNumber { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }  

        public DateTime Date { get; set; }

        public TransactionType Type { get; set; }

        public TransactionStatus Status { get; set; }
    }

    public class TransactionInput
    {
       
        public string TransactionName { get; set; }
        public int AccountNumber { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Date { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }

        public int? OtherAccountNumber { get; set; }
    }

    

    public abstract class  Transaction
    {
        public virtual bool AuthenticationRequired => false;

        public TransactionInfo From(TransactionInput input, TransactionType type)
        {
            return new TransactionInfo
            {
                Id = Guid.NewGuid(), // 👈 fix
                AccountNumber = input.AccountNumber,
                Description = input.Description,
                Amount = input.Amount,
                Type = type,
                Date = input.Date ?? DateTime.UtcNow
            };
        }
        public abstract Task<List<TransactionInfo>> Advice(TransactionInput input);       
        
    }

    public class Deposit : Transaction
    {
        public override async Task<List<TransactionInfo>> Advice(TransactionInput input)
        {
            var info = From(input, TransactionType.Credit);
            return new List<TransactionInfo> { info };
        }
    }

    public class Withdraw : Transaction
    {
        public override bool AuthenticationRequired => true;
        public override async Task<List<TransactionInfo>> Advice(TransactionInput input)
        {
            var info = From(input, TransactionType.Debit);
            return new List<TransactionInfo> { info };
        }
    }

    public class Transfer : Transaction
    {
        public override bool AuthenticationRequired => true;
        public override async Task<List<TransactionInfo>> Advice(TransactionInput input)
        {
            var t1 = From(input, TransactionType.Debit);
            var t2= From(input, TransactionType.Credit);
            if(input.OtherAccountNumber!=null)
                t2.AccountNumber = (int) input.OtherAccountNumber;

            t1.RefTransactionId = t2.Id;
            t2.RefTransactionId = t1.Id;

            return new List<TransactionInfo> { t1,t2 };
        }
    }

    public class TransactionManager
    {
        private readonly Dictionary<string, Transaction> transactions = new();

        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly ITransactionRepository _transactionRepo;
        private readonly ICurrentUserService _currentUser;

        public TransactionManager(
            IAccountService accountService,
            IUnitOfWork unitOfWork,
           // ITransactionRepository transactionRepo,
            ICurrentUserService currentUser)
        {
            _accountService = accountService;
            _unitOfWork = unitOfWork;
           // _transactionRepo = transactionRepo;
            _currentUser = currentUser;

            AddTransaction(new Deposit());
            AddTransaction(new Withdraw());
            AddTransaction(new Transfer());
        }

        private void AddTransaction(Transaction transaction)
        {
            transactions[transaction.GetType().Name] = transaction;
        }

        public async Task<List<TransactionInfo>> ExecuteTransaction(TransactionInput input)
        {
            if (!transactions.ContainsKey(input.TransactionName))
                throw new InvalidOperationException($"Invalid Transaction {input.TransactionName}");

            var transaction = transactions[input.TransactionName];

            
            if (transaction.AuthenticationRequired)
            {
                var account = await _accountService.GetAccount(input.AccountNumber);

                //if (input.a != _currentUser.UserId)
                //    throw new Exception("Unauthorized access");
            }

            var transactionInfos = await transaction.Advice(input);

            var rootId = Guid.NewGuid();

            await _unitOfWork.BeginAsync();

            try
            {
                foreach (var txn in transactionInfos)
                {
                    txn.Id = Guid.NewGuid();
                    

                    var account = await _accountService.GetAccount(txn.AccountNumber);

                    if (txn.Type == TransactionType.Credit)
                        _accountService.Credit(account, txn.Amount);

                    else
                        _accountService.Debit(account, txn.Amount);

                    txn.Status = TransactionStatus.Success;

                   // _transactionRepo.Add(txn);
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

                return transactionInfos;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();

                foreach (var txn in transactionInfos)
                    txn.Status = TransactionStatus.Failed;

                throw;
            }
        }
    }


}
