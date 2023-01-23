using Calculator.Models;

namespace Calculator.ConsoleApp.View
{
    public class UserInterface
    {
        /// <summary>
        /// Print the UI menu 
        /// </summary>
        public void PrintMenu()
        {
            Console.WriteLine("______________________________________________");
            Console.WriteLine("\nChoose the operation you want to execute:");
            Console.WriteLine("______________________________________________\n");
            Console.WriteLine("1 - Sum\n");
            Console.WriteLine("2 - Subtraction\n");
            Console.WriteLine("3 - Multiplication\n");
            Console.WriteLine("4 - Division\n");
            Console.WriteLine("5 - Operation list\n");
            Console.WriteLine("6 - Get an operation by Id\n");
            Console.WriteLine("7 - Delete an operation\n");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("______________________________________________");
        }

        /// <summary>
        /// Get user's choice of menu options
        /// </summary>
        /// <returns>Returns an int that represents user's choice</returns>
        public int GetChoise()
        {
            int choice = GetNumber();
            while (choice < 0 || choice > 7)
            {
                Console.WriteLine("Invalid number \n");
                choice = GetNumber();
            }
            Console.WriteLine("\nYou chose the " + choice + "° option\n");
            return choice;
        }

        /// <summary>
        /// Get operands of the operation
        /// </summary>
        /// <returns>Returns operands of the operation</returns>
        public Operands GetOperands()
        {
            Console.Write("Insert the first  number: ");
            var firstNumber = GetNumber();
            Console.Write("Insert the second number: ");
            var secondNumber = GetNumber();
            Operands operands = new Operands(firstNumber, secondNumber);
            return operands;
        }

        /// <summary>
        /// Get user's input numbers to perform the operation
        /// </summary>
        /// <returns>An int to perform the operation</returns>
        public int GetNumber()
        {
            while (true)
            {
                string? x = Console.ReadLine();
                try
                {
                    return Convert.ToInt32(x);
                }
                catch (Exception)
                {
                    Console.Write("Insert a valid number: ");
                }
            }
        }

        /// <summary>
        /// Get a Guid
        /// </summary>
        /// <returns>Returns the Guid you're searching for</returns>
        public Guid GetGuidId()
        {
            var guid = Console.ReadLine();
            var isValid = Guid.TryParse(guid, out var id);

            while (!isValid)
            {
                Console.WriteLine("\nThe ID you're searching for doesn't exist or it's wrong, retry:");
                guid = Console.ReadLine();
                isValid = Guid.TryParse(guid, out id);
            }
            return id;
        }

        public void PrintOperation(Operation item)
        {
            Console.WriteLine("ID: " + item.OperationId.ToString() + ", Type: " + item.OperationType + " | First operand: " 
                             + item.FirstOperand + ", Second operand: " + item.SecondOperand + " | Result: " + item.Result + "\n");
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
