using Calculator.Models;
using Calculator.Repositories;
using Calculator.Repository;
using System.ComponentModel.DataAnnotations;
using VGC.Customers.Helpers;

namespace Calculator.MOCK.Repository
{
    public class MockOperationRepository : IOperationRepository
    {
        private MockList mockList = new MockList();

        public IList<Operation> Fetch()
        {
            return mockList.Operations.OrderByDescending(x => x.Date).ToList()/*.GetRange(0, 10)*/;
        }

        public Operation GetById(Guid? id)
        {
            var entity = mockList.Operations.SingleOrDefault(e => e.Id == id);
            if (entity == null)
            {
                Console.WriteLine("\nThe Id you searched for doesn't exist\n");
                return null;
            }

            return entity;
        }

        public Task<IEnumerable<ValidationResult>> Save(Operation entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            if (entity.Id == null)
            {
                entity.Id = Guid.NewGuid();
            }

            var errors = Validate(entity);

            if (errors.Any())
            {
                return Task.FromResult<IEnumerable<ValidationResult>>(errors);
            }

            mockList.Operations.Add(entity);

            return Task.FromResult<IEnumerable<ValidationResult>>(new List<ValidationResult>());
        }

        public Task Delete(Operation entity)
        {
            var entityToRemove = mockList.Operations.SingleOrDefault(e => e.Id == entity.Id);

            if (entityToRemove == null)
            {
                return null;
            }

            mockList.Operations.Remove(entityToRemove);
            
            return Task.CompletedTask;
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
