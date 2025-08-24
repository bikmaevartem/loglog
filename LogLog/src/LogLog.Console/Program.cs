using LogLog.Domain.Entities;

namespace LogLog.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            var isExit = false;
            var command = string.Empty;

            do
            {
                ClearConsole();
                ShowCommands();
                DoCommand(command);

                command = ReadCommand();

                isExit = IsExitCommand(command);
            } while (!isExit);
        }


        private static void ShowCommands()
        {
            System.Console.WriteLine("Commands");
            System.Console.WriteLine("exit, list, start <id>, stop <id>");
            System.Console.WriteLine("create <name> <description>");
            System.Console.WriteLine("createstart <name> <description>");
            System.Console.WriteLine("");
        }

        private static void ClearConsole()
        {
            System.Console.Clear();
        }

        private static string ReadCommand()
        {
            System.Console.WriteLine();
            System.Console.Write("Type command: ");

            var command = System.Console.ReadLine() ?? string.Empty;
            return command;
        }

        private static void DoCommand(string command)
        {
            var commandAndArgs = command.Split(' ');

            switch (commandAndArgs[0].ToLower())
            {
                case "list":
                    CommandList();
                    break;
                case "create":
                    CommandCreate(commandAndArgs);
                    break;


                case "start":
                    break;
                case "stop":
                    break;
            }
        }

        private static bool IsExitCommand(string command)
        {
            return command.ToLower().Trim().IndexOf("exit") == 0;
        }



        private static void CommandCreate(string[] args)
        {
        }


        private static void CommandList()
        {
        }

    }
}