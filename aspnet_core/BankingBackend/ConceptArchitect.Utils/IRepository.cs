
namespace ConceptArchitect.Utils
{
    public interface IRepository<Entity, Id> 
    {
        Task<Entity> Add(Entity customer);

        Task<IEnumerable<Entity>> GetAll();

        Task<IEnumerable<Entity>> FindAll(Func<Entity, bool> matcher);

        Task<Entity> FindOne(Func<Entity, bool> matcher);

        Task<Entity> GetById(Id Id);

        Task<Entity> Update(Entity customer, Action<Entity,Entity> mergeOldNew);

        Task DeleteById(Id Id);


        Task Save();
    }
}