using Calculator.ConsoleApp.Models;
using Calculator.Models;
using System.ComponentModel.DataAnnotations;

namespace Calculator.ConsoleApp.Services
{
    /// <summary>
    /// Subtraction
    /// </summary>
    public class Subtraction : IOperation
    {
        public string OperationType => "Subtraction";
        public double ExecuteOperation(Operands operands)
        {
            var error = Validate(operands);
            if (error.Count() > 0)
            {
                throw new Exception(error.FirstOrDefault()?.ErrorMessage);
            }
            return operands.A - operands.B;
        }

        public IEnumerable<ValidationResult> Validate(Operands operands)
        {
            return new List<ValidationResult>();
        }
    }
}
