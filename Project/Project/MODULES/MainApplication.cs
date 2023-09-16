using Manage.Modules;
using Project.HELPERS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODULES
{
    internal class MainApplication
    {
        public async Task Start()
        {
            Console.Clear();

            Console.WriteLine("1. Manage Incomes     2. Manage Expenses     3. Manage Categories");
            int input = ConsoleHelper.GetOptionInput();

            switch (input)
            {
                
                case 3:
                    await CategoryModule.ShowOptionsAsync();
                    break;
                default:
                    return;
            }

        }
    }
}
