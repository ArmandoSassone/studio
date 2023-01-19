using Calculator.Models;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOperationRepository
    {
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
        Operation GetOperationById(int id);

        /// <summary>
        /// Update an existing operation
        /// </summary>
        /// <param name="operation"></param>
        /// <returns>Returns the updated operation</returns>
        Operation Update(Operation entity);

        /// <summary>
        /// Delete an existing operation
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns the list without the deleted operation</returns>
        Operation Delete(Operation entity);

    }
}
