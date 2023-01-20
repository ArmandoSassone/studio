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
            //devo passarmi il repo dal costruttore in modo che sia lo stesso per tutte le operation che creo
            this.repository = repository; 
        }
        public double ExecuteOperation(Operands operands)
        {           
            var error = Validate(operands);

            if (error.Count() > 0)
            {
                throw new Exception(error.FirstOrDefault()?.ErrorMessage);
            }
            var result = operands.A + operands.B;
            return result;
        }

        public IEnumerable<ValidationResult> Validate(Operands operands)
        {
            return new List<ValidationResult>();
        }
    }
}
