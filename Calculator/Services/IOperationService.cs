using Calculator.Models;
using Calculator.Services;
using System.ComponentModel.DataAnnotations;

public interface IOperationService
{
    //chiedere getoperationbyId
    public IEnumerable<ValidationResult> Save(Operands operands, IOperation operation, double result);
    //public IEnumerable<ValidationResult> Update(Operation operation);
    public IList<Operation> Fetch();
    public Operation GetOperationById(Guid id);
    public void Delete(Operation operation);
}