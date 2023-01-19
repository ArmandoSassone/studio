using Calculator.Models;

namespace Calculator.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class MockList
    {
        /// <summary>
        /// Operations initialize
        /// </summary>
        public MockList()
        {
            Operations = new List<Operation>();
        }

        /// <summary>
        /// Operations list
        /// </summary>
        public IList<Operation> Operations { get; set; }
    }
}