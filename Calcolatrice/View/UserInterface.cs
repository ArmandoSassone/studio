using Calculator.Models;
using ConsoleTables;

namespace Calculator.ConsoleApp.View
{
    /// <summary>
    /// UI
    /// </summary>
    public class UserInterface
    {
        /// <summary>
        /// Print the UI menu 
        /// </summary>
        public void PrintMenu()
        {
            Task.Delay(25).Wait();
            Console.WriteLine("______________________________________________");
            Task.Delay(25).Wait();
            Console.WriteLine("\nChoose the operation you want to execute:");
            Task.Delay(25).Wait();
            Console.WriteLine("______________________________________________\n");
            Task.Delay(25).Wait();
            Console.WriteLine("1 - Sum\n");
            Task.Delay(25).Wait();
            Console.WriteLine("2 - Subtraction\n");
            Task.Delay(25).Wait();
            Console.WriteLine("3 - Multiplication\n");
            Task.Delay(25).Wait();
            Console.WriteLine("4 - Division\n");
            Task.Delay(25).Wait();
            Console.WriteLine("5 - Operation list\n");
            Task.Delay(25).Wait();
            Console.WriteLine("6 - Get an operation by Id\n");
            Task.Delay(25).Wait();
            Console.WriteLine("7 - Delete an operation\n");
            Task.Delay(25).Wait();
            Console.WriteLine("0 - Exit");
            Task.Delay(25).Wait();
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
        public Guid? GetGuidId()
        {
            Console.WriteLine("(press X to go back in the menu)");
            var guid = Console.ReadLine();
            if (guid == "x") { return null; }

            var isValid = Guid.TryParse(guid, out var id);

            while (!isValid)
            {
                Console.WriteLine("\nThe ID you're searching for doesn't exist or it's wrong, retry or press X:");
                guid = Console.ReadLine();
                if (guid == "x") { return null; }
                isValid = Guid.TryParse(guid, out id);
            }

            return id;
        }

        /// <summary>
        /// Print operation details
        /// </summary>
        /// <param name="item"></param>
        public void PrintOperation(Operation item)
        {
            Console.WriteLine("ID: " + item.Id.ToString() + ", Type: " + item.Type + " | First operand: "
                             + item.FirstOperand + ", Second operand: " + item.SecondOperand + " | Result: " + item.Result + " | Date: " + item.Date + "\n");
        }

        /// <summary>
        /// Print table with operations details
        /// </summary>
        /// <param name="item"></param>
        /// <param name="table"></param>
        public void PrintTable(Operation item, ConsoleTable table)
        {
            table.AddRow(item.Id, item.Type, item.FirstOperand, item.SecondOperand, item.Result, item.Date);
        }

        /// <summary>
        /// Console writeline
        /// </summary>
        /// <param name="message"></param>
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        //ga<s

        /// <summary>
        /// Class for spinner to simulate loading status
        /// </summary>
        public class Spinner : IDisposable
        {
            private const string Sequence = @"/-\|_|\-/";
            private int counter = 0;
            private readonly int left;
            private readonly int top;
            private readonly int delay;
            private bool active;
            private readonly Thread thread;

            public Spinner(int left, int top, int delay = 100)
            {
                this.left = left;
                this.top = top;
                this.delay = delay;
                thread = new Thread(Spin);
            }

            public void Start()
            {
                active = true;
                if (!thread.IsAlive)
                    thread.Start();
            }

            public void Stop()
            {
                active = false;
                Draw(' ');
            }

            private void Spin()
            {
                while (active)
                {
                    Turn();
                    Thread.Sleep(delay);
                }
            }

            private void Draw(char c)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(c);
            }

            private void Turn()
            {
                Draw(Sequence[++counter % Sequence.Length]);
            }
            public void Dispose()
            {
                Stop();
            }
        }
    }
}
