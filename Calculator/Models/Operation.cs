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
        //Devo dichiararlo nullable (con ?) perché altrimenti di default verrebbe impostato 0000-0000-0000-0000
        public Guid? Id { get; set; }

        /// <summary>
        /// Date
        /// </summary>

        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Type of operation
        /// </summary>
        [Required]
        [StringLength(100)]
        public string? Type { get; set; } //verificare che questa stringa sia valorizzata correttamente (sum, subtraction..)

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
