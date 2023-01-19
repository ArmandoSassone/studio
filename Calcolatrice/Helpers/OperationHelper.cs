using Calculator.ConsoleApp.Models;
using Calculator.ConsoleApp.Services;
using Calculator.Models;

namespace Calculator.ConsoleApp.Helpers
{
    /// <summary>
    /// Operation helper 
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
            var random = new Random();
            op.OperationId = random.Next(111, 222);//Cercare un modo per evitare di generare 2 ID uguali
            op.FirstOperand = operands.A;
            op.SecondOperand = operands.B;
            op.OperationType = operation.OperationType;
            op.Result = result;
            Console.WriteLine(Convert.ToString("Operation ID: " + op.OperationId) + " | First operand: " + op.FirstOperand + 
                                               " | Second operand: " + op.SecondOperand + " | " + op.OperationType + " = " + op.Result);
            return op;
        }
    }
}
