using Calculator.Models;
using Calculator.Repositories;
using Calculator.Repository;
using System.ComponentModel.DataAnnotations;

namespace Calculator.MOCK.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class MockOperationRepository : IOperationRepository
    {
        private MockList mockList = new MockList();

        /// <summary>
        /// Fetch operations 
        /// </summary>
        /// <returns>Operations list</returns>
        public IList<Operation> Fetch()
        {
            return mockList.Operations;
        }

        public Operation GetOperationById(int id)
        {
            var entity = mockList.Operations.SingleOrDefault(e => e.OperationId == id);
            return entity;
        }

        /// <summary>
        /// Save new operation 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>List of ValidationResult</returns>
        public void Save(Operation entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            //if (mockList.Operations.Count() == 10)
            //{
            //    var firstOperation = mockList.Operations.First();
            //    mockList.Operations.Remove(firstOperation);
            //}
             mockList.Operations.Add(entity);
        }

        /// <summary>
        /// Update an existing operation
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns the new added operation </returns>
        public Operation Update(Operation entity)
        {
            //private bool esempio(Operation e)
            //{
            //    bool condition = e.OperationId == entity.OperationId;
            //    return condition;
            //}
            var oldEntity = mockList.Operations.SingleOrDefault(e => e.OperationId == entity.OperationId);

            if (oldEntity == null)
            {
                //Console.WriteLine("The " + oldEntity?.OperationId + " doesn't correspond to any existing IDs");
                return null;
            } 
            else
            {
                mockList.Operations.Remove(oldEntity);
                mockList.Operations.Add(entity);
                return entity;
            }
        }        

        public Operation Delete(Operation entity)
        {
            var entityToRemove = mockList.Operations.SingleOrDefault(e => e.OperationId == entity.OperationId);
            if (entityToRemove == null)
            {
                return null;
            }
            else
            {
                mockList.Operations.Remove(entityToRemove);
                return entityToRemove;
            }
        }
    }
}
