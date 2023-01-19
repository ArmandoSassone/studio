using Calculator.ConsoleApp.Helpers;
using Calculator.ConsoleApp.Services;
using Calculator.ConsoleApp.View;
using Calculator.MOCK.Repository;
using Calculator.Models;
using Calculator.Repositories;

var ui = new UserInterface();
IOperation operation = null;
IOperationRepository repository = new MockOperationRepository();

while (true)
{
    ui.PrintMenu();
    var res = ui.GetChoise();
    switch (res)
    {
        case 0:
            return;
        case 1:
            operation = new Sum();  
            break;
        case 2:
            operation = new Subtraction();
            break;
        case 3:
            operation = new Multiplication();
            break;
        case 4:
            operation = new Division();
            break;
        case 5:
            var operationList = repository.Fetch();
            foreach (var item in operationList)
            {
                ui.PrintMessage("ID: " + item.OperationId + ", Type: " + item.OperationType + " | First operand: " + item.FirstOperand + ", Second operand: " 
                    + item.SecondOperand + " | Result: " + item.Result + "\n");                
            }
            ui.PrintMessage("Total operations: " + operationList.Count());
            continue;
        case 6:
            ui.PrintMessage("Insert the operation ID you want to update: ");
            var id = ui.GetNumber();
            var oldEntity = repository.GetOperationById(id);
            if (oldEntity == null)
            {                
                ui.PrintMessage("\nThe ID you searched for doesn't exist\n");
                continue;
            }
            var newEntity = ui.CreateOperation(id);
            var updated = repository.Update(newEntity);
            if (updated != null)
            {
                ui.PrintMessage("\nNew operation added\n");
            }
            continue;
        case 7:
            ui.PrintMessage("Insert the operation ID you want to delete: ");
            var entityToDeleteID = ui.GetNumber();
            var entityToDelete = repository.GetOperationById(entityToDeleteID);
            if (entityToDelete == null)
            {
                ui.PrintMessage("\nThe ID you searched for doesn't exist\n");
                continue;
            }
            var deletedOperation = repository.Delete(entityToDelete);
            ui.PrintMessage("\nOperation removed with success!");
            ui.PrintMessage("You removed the ID " + entityToDelete.OperationId + " operation.\n");
            continue;
    }

    var operands = ui.GetOperands();
    double result = operation.ExecuteOperation(operands);
    Console.WriteLine("\nThe result of the operation you chose is " + result + ".");
    Operation entity = OperationHelper.CreateOperation(operands, operation, result);
    var validationResults = repository.Save(entity);
}

/*creare progetto di business, progetto di repository. per ciascun input e output devo salvare tutto nel repo
per semplificare, salverò tutto in memoria. Una volta che l'utente ha inserito 1 e 2 operatore, fatto l'operazione
salverò tutto in memoria e mostrerò le ultime n operazioni
unico project che conosce tutte le entità è il program(calculator)*/
