using Calculator.ConsoleApp.Models;
using Calculator.Models;
using System.ComponentModel.DataAnnotations;

namespace Calculator.ConsoleApp.Services
{
    /// <summary>
    /// Division
    /// </summary>
    public class Division : IOperation
    {
        public string OperationType => "Division";
        public double ExecuteOperation(Operands operands)
        {
            var error = Validate(operands);
            if (error.Count()> 0)
            {
                throw new Exception(error.FirstOrDefault()?.ErrorMessage);
            }
            return operands.A / operands.B;
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
