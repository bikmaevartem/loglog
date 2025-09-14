using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLog.Console.Commands.Executors.Group
{
    public class GroupCommandExecutor : BaseCommandExecutor, IGroupCommandExecutor
    {
        public override async Task ExecuteAsync(Command command)
        {
            
            switch (command.Type)
            {
                case CommandType.Create:
                    ShowStub();
                    break;

                case CommandType.CreateAndStart:
                    ShowStub();
                    break;

                case CommandType.Open:
                    ShowStub();
                    break;

                case CommandType.Start:
                    ShowStub();
                    break;

                case CommandType.Stop:
                    ShowStub();
                    break;

                case CommandType.Delete:
                    ShowStub();
                    break;

                case CommandType.Back:
                    ExecuteBackCommand();
                    break;

                case CommandType.List:
                    ShowStub();
                    break;

                case CommandType.Unknown:
                    ShowStub();
                    break;

                default:
                    break;
            }
        }

        private void ShowStub()
        {
            System.Console.WriteLine("Unsupported command.");
        }
    }
}
