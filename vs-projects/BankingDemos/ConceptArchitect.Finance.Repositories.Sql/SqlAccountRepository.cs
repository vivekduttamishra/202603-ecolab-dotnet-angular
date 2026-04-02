using ConceptArchitect.Finance.Exceptions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.Repositories.Sql
{
    

    public class SqlAccountRepository : IAccountRepository 
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\works\\corporate\\202603-ecolab-dotnet-angular\\vs-projects\\BankingDemos\\ConceptArchitect.Finance.Repositories.Sql\\bank.mdf;Integrated Security=True";
        //string connectionString = "Data Source=SHIVOHAM\\SQLEXPRESS;Initial Catalog=bankdb;Integrated Security=True;Trust Server Certificate=True";
        SqlConnection connection;

        public void AddAccount(BankAccount account)
        {

            try
            {
                connection = new SqlConnection() { ConnectionString = connectionString };
                connection.Open();
                var command = connection.CreateCommand();
                double odLimit = 0;
                if (account is OverdraftAccount)
                    odLimit = ((OverdraftAccount)account).OdLimit;

                command.CommandText = """
                    INSERT INTO [ACCOUNTS] ([NAME], [PASSWORD], [BALANCE], [ACCOUNT_TYPE], [OD_LIMIT])
                    VALUES (@Name, @Password, @Balance, @Type, @Limit);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);
                """;

                command.Parameters.Clear(); // Critical to avoid 'parameter already defined' errors
                command.Parameters.AddWithValue("@Name", account.Name);
                command.Parameters.AddWithValue("@Password", account.Password);
                command.Parameters.AddWithValue("@Balance", account.Balance);
                command.Parameters.AddWithValue("@Type", account.GetType().Name);
                command.Parameters.AddWithValue("@Limit", odLimit);



                //command.CommandText = """
                //    insert into accounts (name,password,balance,account_type)
                //    values('Vivek','hello', 20000, 'SavingsAccount' )
                //    """;


                Console.WriteLine(command.CommandText);
                var id = Convert.ToInt32(command.ExecuteScalar());

                account.AccountNumber = id;

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }
            }
        }

        public IEnumerable<BankAccount> GetAll()
        {
            
            try
            {
                connection = new SqlConnection() { ConnectionString = connectionString };
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "select * from accounts";

                var reader = command.ExecuteReader();
                List<BankAccount> accounts = new List<BankAccount>();
                while (reader.Read())
                {
                    accounts.Add(CreateAccount(reader));
                }

                return accounts;

            }
            finally
            {
                if(connection!=null)
                {
                    connection.Close();
                    connection = null;
                }    
            }
        }

        IAccountFactory factory = new SmartAccountFactory();
        private BankAccount CreateAccount(SqlDataReader reader)
        {
            int accountNumber = Convert.ToInt32(reader["ACCOUNT_NUMBER"]);
            var name = (String) reader["name"];
            var password=(String) reader["password"];
            var balance = Convert.ToDouble(reader["balance"]);
            var odLimit = Convert.ToDouble(reader["od_limit"]);
            var type = (String) reader["Account_Type"];


            var account= factory.Create(type, accountNumber, name, password, balance);
            if (account is OverdraftAccount)
                (account as OverdraftAccount).OdLimit = odLimit;

            return account;
        }

        public BankAccount GetById(int accountNumber)
        {
            try
            {
                connection = new SqlConnection() { ConnectionString = connectionString };
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"select * from accounts where ACCOUNT_NUMBER = {accountNumber}";

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var account = CreateAccount(reader);
                    return account;
                }
                else
                    throw new InvalidAccountException(accountNumber);


            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }
            }
        }

        public void Remove(int accountNumber)
        {
            try
            {
                connection = new SqlConnection() { ConnectionString = connectionString };
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"delete from accounts where ACCOUNT_NUMBER = {accountNumber}";

                command.ExecuteNonQuery();
                


            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }
            }
        }

        public void Save(BankAccount account)
        {
            try
            {
                connection = new SqlConnection() { ConnectionString = connectionString };
                connection.Open();

                double odLimit = 0;
                if(account is OverdraftAccount)
                {
                    odLimit=((OverdraftAccount)account).OdLimit;
                }
                var command = connection.CreateCommand();
                command.CommandText = $"""
                        update ACCOUNTS
                        set
                            balance={account.Balance},
                            password='{account.Password}',
                            name='{account.Name}',
                            od_limit={odLimit}
                        where
                            account_number={account.AccountNumber}
                    """;

                command.ExecuteNonQuery();



            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }
            }
        }
    }
}
