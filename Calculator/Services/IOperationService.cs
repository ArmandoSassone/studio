using Calculator.Models;
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
    public Task<IEnumerable<ValidationResult>> Save(Operation operation);

    /// <summary>
    /// Fetch list
    /// </summary>
    /// <returns>Returns operation list</returns>
    public IList<Operation> Fetch();

    /// <summary>
    /// Search and get an operation by its Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Return an operation</returns>
    public Operation GetById(Guid? id);

    /// <summary>
    /// Delete operation
    /// </summary>
    /// <param name="operation"></param>
    public Task Delete(Operation operation);
}