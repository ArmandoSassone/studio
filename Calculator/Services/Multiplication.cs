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
        private IOperationRepository repository;
        public Multiplication(IOperationRepository repository)
        {
            this.repository = repository;
        }
        public double ExecuteOperation(Operands operands)
        {
            var error = Validate(operands);
            if (error.Count() > 0)
            {
                throw new Exception(error.FirstOrDefault()?.ErrorMessage);
            }
            var result = operands.A * operands.B;
            var operation = OperationHelper.CreateOperation(operands, this, result);
            return result;
        }
        
        public IEnumerable<ValidationResult> Validate(Operands operands)
        {
            return new List<ValidationResult>();
        }
    }
}
