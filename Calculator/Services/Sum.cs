using Calculator.Helpers;
using Calculator.Models;
using Calculator.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Services
{
    /// <summary>
    /// Sum
    /// </summary>
    public class Sum : IOperation
    {
        public string OperationType => "Sum";
        private IOperationRepository repository;
        public Sum(IOperationRepository repository)
        {
            this.repository = repository; //devo passarmi il repo dal costruttore in modo che sia lo stesso per tutte le operation che creo
        }
        public double ExecuteOperation(Operands operands)
        {           
            var error = Validate(operands);

            if (error.Count() > 0)
            {
                throw new Exception(error.FirstOrDefault()?.ErrorMessage);
            }
            var result = operands.A + operands.B;
            var operation = OperationHelper.CreateOperation(operands, this, result);
            repository.Save(operation);
            return result;
        }

        public IEnumerable<ValidationResult> Validate(Operands operands)
        {
            return new List<ValidationResult>();
        }
    }
}
