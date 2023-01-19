using Calculator.ConsoleApp.Models;
using System.ComponentModel.DataAnnotations;

namespace Calculator.ConsoleApp.Services
{
    /// <summary>
    /// Operation contract
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Operation type (sum, subtraction, multiplication, division)
        /// </summary>
        string OperationType { get; }

        /// <summary>
        /// Execute the chosen operation
        /// </summary>
        /// <param name="operands"></param>
        /// <returns>Returns a double of the operation result</returns>
        double ExecuteOperation(Operands operands);

        /// <summary>
        /// Method that validate user's input numbers
        /// </summary>
        /// <param name="operands"></param>
        /// <returns>IList of validation results</returns>
        public IEnumerable<ValidationResult> Validate(Operands operands);

    }
}
