using Calculator.Services;
using Calculator.ConsoleApp.View;
using Calculator.MOCK.Repository;
using Calculator.Repositories;
using Calculator.Helpers;
using ConsoleTables;

var ui = new UserInterface();
IOperation? operation = null;
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
            var operationList = service.Fetch();
            var table = new ConsoleTable("ID", "Type", "First operand", "Second operand", "Result", "Date");
            foreach (var item in operationList)   
            {
                ui.PrintTable(item, table);
            }
            table.Write();
            continue;

        case 6:
            ui.PrintMessage("Insert the operation ID you want to get: ");
            var id = ui.GetGuidId();
            var e = service.GetById(id);
            if (e == null)
            {
                ui.PrintMessage("\nThe ID you searched for doesn't exist\n");
                continue;
            }
            ui.PrintMessage("\n");
            ui.PrintOperation(e);
            continue;

        case 7:
            ui.PrintMessage("Insert the operation ID you want to delete: ");
            var entityToDeleteId = ui.GetGuidId();
            var entityToDelete = service.GetById(entityToDeleteId);
            if (entityToDelete == null)
            {
                ui.PrintMessage("\nThe ID you searched for doesn't exist\n");
                continue;
            }
            service.Delete(entityToDelete);
            ui.PrintMessage("\nOperation removed with success!");
            ui.PrintMessage("You removed the ID " + entityToDelete.Id + " operation.\n");
            continue;
    }

    var operands = ui.GetOperands();
    double result = operation.ExecuteOperation(operands);
    var entity = OperationHelper.CreateOperation(operands, operation, result);

    var errors = service.Save(entity);
    if (errors.Any())
    {
        ui.PrintMessage("\nSaving operation failed\n");
    }
    ui.PrintMessage("\nThe result of the operation you chose is " + result + ".\n");
}

/*Creare progetto di business, progetto di repository. per ciascun input e output devo salvare tutto nel repo
per semplificare, salverò tutto in memoria. Una volta che l'utente ha inserito 1 e 2 operatore, fatto l'operazione
salverò tutto in memoria e mostrerò le ultime n operazioni
unico project che conosce tutte le entità è il program(calculator)*/

