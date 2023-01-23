using Calculator.Helpers;
using Calculator.Models;
using Calculator.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Services
{
    /// <summary>
    /// Multiplication
    /// </summary>
    public class Multiplication : IOperation
    {
        public string OperationType => "Multiplication";
        public double ExecuteOperation(Operands operands)
        {
            var error = Validate(operands);
            if (error.Count() > 0)
            {
                throw new Exception(error.FirstOrDefault()?.ErrorMessage);
            }
            var result = operands.A * operands.B;
            return result;
        }
        
        public IEnumerable<ValidationResult> Validate(Operands operands)
        {
            return new List<ValidationResult>();
        }
    }
}
