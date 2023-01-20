using Calculator.Models;
using System.ComponentModel.DataAnnotations;

namespace VGC.Customers.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelValidatorHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<ValidationResult> Validate<T>(T entity)
            where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            ICollection<ValidationResult> list = new List<ValidationResult>();
            IDictionary<object, object> items = new Dictionary<object, object>();
            ValidationContext validationContext = new ValidationContext(entity, null, items);
            Validator.TryValidateObject(entity, validationContext, list, validateAllProperties: true);
            return list;
        }
    }
}
