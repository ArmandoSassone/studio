namespace Calculator.Models
{
    /// <summary>
    /// Operators
    /// </summary>
    public class Operation 
    {
        /// <summary>
        /// Operation Id
        /// </summary>
        public int OperationId { get; set; }

        /// <summary>
        /// Type of operation
        /// </summary>
        public string? OperationType { get; set; }

        /// <summary>
        /// First operand
        /// </summary>
        public int FirstOperand {get; set; }

        /// <summary>
        /// Second operand
        /// </summary>
        public int SecondOperand { get; set; }

        /// <summary>
        /// Operation result
        /// </summary>
        public double Result { get; set; }
    }
}
