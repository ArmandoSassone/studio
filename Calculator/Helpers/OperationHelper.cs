using Calculator.Models;
using Calculator.Services;

namespace Calculator.Helpers
{
    /// <summary>
    /// Operations helper 
    /// </summary>
    public class OperationHelper 
    {
        /// <summary>
        /// Create an operation
        /// </summary>
        /// <param name="operands"></param>
        /// <param name="operation"></param>
        /// <param name="result"></param>
        /// <returns>Returns the created operation</returns>        
        public static Operation CreateOperation(Operands operands, IOperation operation, double result)
        {
            /* Il metodo è statico perché in questo modo non ci sarà bisogno di creare un oggetto 
            per chiamarlo dove occorre */
            var op = new Operation();
            op.FirstOperand = operands.A;
            op.SecondOperand = operands.B;
            op.OperationType = operation.OperationType;
            op.Result = result;
            return op;
        }
    }
}
