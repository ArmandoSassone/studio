using Calculator.Models;
using Calculator.Services;
using System.ComponentModel.DataAnnotations;

public interface IOperationService
{
    /// <summary>
    /// Operations save method
    /// </summary>
    /// <param name="operands"></param>
    /// <param name="operation"></param>
    /// <param name="result"></param>
    /// <return>Returns a list of validation results</returns>
    public IEnumerable<ValidationResult> Save(Operands operands, IOperation operation, double result);

    public IList<Operation> Fetch();

    /// <summary>
    /// Search and get an operation by its Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Return an operation</returns>
    public Operation GetOperationById(Guid id);
    public void Delete(Operation operation);
}