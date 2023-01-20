using Calculator.Helpers;
using Calculator.Models;
using Calculator.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Services
{
    /// <summary>
    /// Division
    /// </summary>
    public class Division : IOperation
    {
        public string OperationType => "Division";
        private IOperationRepository repository;
        public Division(IOperationRepository repository)
        {
            //devo passarmi il repo dal costruttore in modo che sia lo stesso per tutte le operation che creo
            this.repository = repository; 
        }
        public double ExecuteOperation(Operands operands)
        {
            var error = Validate(operands);
            if (error.Count()> 0)
            {
                throw new Exception(error.FirstOrDefault()?.ErrorMessage);
            }
            var result = operands.A / operands.B;
            return result;
        }
        public IEnumerable<ValidationResult> Validate(Operands operands)
        {
            var validationResults = new List<ValidationResult>();
            
            if (operands.B == 0)
            {
                var error = new ValidationResult("The value can't be = 0");
                validationResults.Add(error);
            }
            return validationResults;
        }
    }
}
