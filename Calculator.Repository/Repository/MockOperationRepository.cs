using Calculator.Models;
using Calculator.Repositories;
using Calculator.Repository;
using System.ComponentModel.DataAnnotations;
using VGC.Customers.Helpers;

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

        public Operation GetOperationById(Guid? id)
        {
            var entity = mockList.Operations.SingleOrDefault(e => e.OperationId == id);
            if (entity == null)
            {
                Console.WriteLine("\nThe Id you searched for doesn't exist\n");
                return null;
            }
            return entity;
        }

        /// <summary>
        /// Save new operation 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>List of ValidationResult</returns>
        public IEnumerable<ValidationResult> Save(Operation entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            if (entity.OperationId == null)
            {
                entity.OperationId = Guid.NewGuid();
            }
            var errors = Validate(entity);
            if (errors.Any())
            {
                return errors;
            }

            if (mockList.Operations.Count() == 10)
            {
                var firstOperation = mockList.Operations.First();
                mockList.Operations.Remove(firstOperation);
            }
            mockList.Operations.Add(entity);

            return new List<ValidationResult>();
        }

        public void  Delete(Operation entity)
        {
            var entityToRemove = mockList.Operations.SingleOrDefault(e => e.OperationId == entity.OperationId);
            if (entityToRemove == null)
            {
                return;
            }
            mockList.Operations.Remove(entityToRemove);           
        }

        public IEnumerable<ValidationResult> Validate(Operation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return ModelValidatorHelper.Validate(entity);
        }
    }
}
