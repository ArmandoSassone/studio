using Calculator.Services;
using Calculator.ConsoleApp.View;
using Calculator.MOCK.Repository;
using Calculator.Repositories;

var ui = new UserInterface();
IOperation operation = null;
IOperationRepository repository = new MockOperationRepository();
IOperationService service = new OperationService(repository);

while (true)
{
    ui.PrintMenu();
    var res = ui.GetChoise();
    switch (res)
    {
        case 0:
            return;
        case 1:
            operation = new Sum(repository);  
            break;
        case 2:
            operation = new Subtraction(repository);
            break;
        case 3:
            operation = new Multiplication(repository);
            break;
        case 4:
            operation = new Division(repository);
            break;
        case 5:
            var operationList = service.Fetch();
            foreach (var item in operationList)
            {
                ui.PrintOperation(item);                
            }
            ui.PrintMessage("Total operations: " + operationList.Count());
            continue;
        case 6:
            ui.PrintMessage("Insert the operation ID you want to get: ");
            var id = ui.GetGuidId();
            var entity = service.GetOperationById(id);
            if (entity == null)
            {                
                ui.PrintMessage("\nThe ID you searched for doesn't exist\n");
                continue;
            }
            ui.PrintOperation(entity);
            continue;
        case 7:
            ui.PrintMessage("Insert the operation ID you want to delete: ");
            var entityToDeleteId = ui.GetGuidId();
            var entityToDelete = service.GetOperationById(entityToDeleteId);
            if (entityToDelete == null)
            {
                ui.PrintMessage("\nThe ID you searched for doesn't exist\n");
                continue;
            }
            service.Delete(entityToDelete);
            ui.PrintMessage("\nOperation removed with success!");
            ui.PrintMessage("You removed the ID " + entityToDelete.OperationId + " operation.\n");
            continue;
    }

    var operands = ui.GetOperands();
    double result = operation.ExecuteOperation(operands);
    var errors = service.Save(operands, operation, result);
    if (errors.Any())
    {
        ui.PrintMessage("\nSaving operation failed\n");
    }
    ui.PrintMessage("\nThe result of the operation you chose is " + result + ".");
}

/*creare progetto di business, progetto di repository. per ciascun input e output devo salvare tutto nel repo
per semplificare, salverò tutto in memoria. Una volta che l'utente ha inserito 1 e 2 operatore, fatto l'operazione
salverò tutto in memoria e mostrerò le ultime n operazioni
unico project che conosce tutte le entità è il program(calculator)*/

// spostare la business logic (helper, dto, servizi) nel Calculator e non nel Calculator.ConsoleApp
// spostandola si cambieranno i namespaces
