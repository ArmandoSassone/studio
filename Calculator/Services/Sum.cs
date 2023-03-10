using Calculator.Models;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Services
{
    public class Sum : IOperation
    {
        public string OperationType => "Sum";
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
