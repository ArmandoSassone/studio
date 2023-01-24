using Calculator.Models;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Repositories
{
    /// <summary>
    /// Operations repository
    /// </summary>
    public interface IOperationRepository
    {//I servizi devono essere async e task
        /// <summary>
        /// Save an operation in the operation list
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Saved operations list</returns>
        IEnumerable<ValidationResult> Save(Operation entity);

        /// <summary>
        /// Print the operation list
        /// </summary>
        /// <returns>Operations list</returns>
        IList<Operation> Fetch();

        /// <summary>
        /// Get operation by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns an operation</returns>
        Operation GetById(Guid? id);

        /// <summary>
        /// Validate for operations
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns a list of validation results</returns>
        IEnumerable<ValidationResult> Validate(Operation entity);

        /// <summary>
        /// Delete operations
        /// </summary>
        /// <param name="entity"></param>
        void Delete(Operation entity);
    }
}
