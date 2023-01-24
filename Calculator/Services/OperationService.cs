using Calculator.Helpers;
using Calculator.Models;
using Calculator.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Services
{
    public class OperationService : IOperationService
    {
        private IOperationRepository repository;
        public OperationService(IOperationRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ValidationResult> Save(Operation operation)//passare solo entity
        {
            if (operation == null) throw new ArgumentNullException(nameof(operation));

            var errors = repository.Validate(operation);
            if (errors.Any())
            {
                return errors;
            }

            return repository.Save(operation);
        }

        public IList<Operation> Fetch()
        {
            return repository.Fetch();
        }

        public Operation GetById(Guid? id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            return repository.GetById(id);
        }

        public void Delete(Operation entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            repository.Delete(entity);
        }
    }
}
