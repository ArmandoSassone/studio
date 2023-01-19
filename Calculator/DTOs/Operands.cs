namespace Calculator.Models
{
    /// <summary>
    /// User's inputs
    /// </summary>
    public class Operands
    {
        /// <summary>
        /// First operand
        /// </summary>
        public int A { get; set; }

        /// <summary>
        /// Second operand
        /// </summary>
        public int B { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Operands(int a, int b)
        {
            A = a;
            B = b;
        }
    }
}
