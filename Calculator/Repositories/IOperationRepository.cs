using Calculator.Models;
using System.ComponentModel.DataAnnotations;
using VGC.Customers.Helpers;

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
        Operation GetOperationById(Guid id);

        IEnumerable<ValidationResult> Validate(Operation entity);
        void Delete(Operation entity);


    }
}
