using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Utils
{
    public class InMemoryEntityRepository<Entity, Id> : IRepository<Entity, Id> where Entity: Entity<Id>
    {
        Dictionary<Id,Entity> store=new Dictionary<Id,Entity>();

        public async Task<Entity> Add(Entity entity)
        {
            await Task.CompletedTask;
            if (store.ContainsKey(entity.Id))
                throw new DuplicateEntityException($"Duplicate Id: {entity.Id}");


            store[entity.Id] = entity;

            return entity;

        }

        public async Task DeleteById(Id id)
        {
            await GetById(id);
            store.Remove(id);
        }

        public async Task<IEnumerable<Entity>> FindAll(Func<Entity, bool> matcher)
        {
            //LINQ
            return from entity in store.Values
                   where matcher(entity)
                   select entity;
        }

        public async Task<Entity> FindOne(Func<Entity, bool> matcher)
        {
            var qry = from entity in store.Values
                      where matcher(entity)
                      select entity;

            return qry.FirstOrDefault();
        }

        public async Task<IEnumerable<Entity>> GetAll()
        {
            return store.Values;
        }

        public async Task<Entity> GetById(Id id)
        {
            if (store.ContainsKey(id))
                return store[id];
            else
                throw new InvalidIdException<Id>(id);
        }

        

        public async Task Save()
        {
            
        }

        public async  Task<Entity> Update(Entity newEntity, Action<Entity,Entity> mergeOldNew)
        {
            var oldEntity= await GetById(newEntity.Id);
            mergeOldNew(oldEntity, newEntity);
            return oldEntity; //now contains new data
        }
    }
}
