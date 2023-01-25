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

        public async Task<IEnumerable<ValidationResult>> Save(Operation operation)//passare solo entity
        {
            if (operation == null) throw new ArgumentNullException(nameof(operation));

            var errors = repository.Validate(operation);

            if (errors.Any())
            {
                return errors;
            }

            //if (operation.Id == null)
            //{
            //    var existing = await GetById();
            //    if (existing != null)
            //    {
            //        var mex = string.Format(operation.Id + " is already used");
            //        errors = errors.Append(new ValidationResult(mex, new List<string> { nameof(operation.Id) }));
            //        return errors;
            //    }
            //}

            return await repository.Save(operation);
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

        public Task Delete(Operation entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return repository.Delete(entity); // Perché qui non c'è bisogno di specificare task?
        }
    }
}
