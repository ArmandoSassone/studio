using System.ComponentModel.DataAnnotations;

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
        [Required]
        public Guid? OperationId { get; set; }

        /// <summary>
        /// Type of operation
        /// </summary>
        [Required]
        [StringLength(100)]
        public string? OperationType { get; set; }

        /// <summary>
        /// First operand
        /// </summary>
        [Required]
        public int FirstOperand {get; set; }

        /// <summary>
        /// Second operand
        /// </summary>
        [Required]
        public int SecondOperand { get; set; }

        /// <summary>
        /// Operation result
        /// </summary>
        [Required]
        public double Result { get; set; }
    }
}
