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
    
        public IEnumerable<ValidationResult> Save(Operands operands, IOperation operation, double result)
        {
            if (operation == null) throw new ArgumentNullException(nameof(operation));

            var op = OperationHelper.CreateOperation(operands, operation, result);            
            return repository.Save(op);
        }
        //public IEnumerable<ValidationResult> Update(Operation operation)
        //{
        //        throw new NotImplementedException();
        //}
        public IList<Operation> Fetch()
        {
            return repository.Fetch();
        }

        public Operation GetOperationById(Guid id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            return repository.GetOperationById(id);
        }

        public void Delete(Operation entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            repository.Delete(entity);
        }
    }
}
