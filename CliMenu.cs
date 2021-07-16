using System;
using System.Collections.Generic;
using System.Linq;

namespace BucketCli
{
    public abstract class CliMenu
    {
        public string Title { get; private set; }
        public List<CliMenu> SubMenus { get; private set; }
        public List<CliFunction> Functions { get; private set; }
        
        public CliMenu(string title, List<CliMenu> subMenus, List<CliFunction> functions)
        {
            Title = title;
            SubMenus = subMenus;
            Functions = functions;
        }

        private CliMenu Dig(string[] menus, int menuLevel)
        {
            CliMenu menu = null;
            if (menuLevel != menus.Length - 1)
            {
                var lowerLevel = SubMenus.Find(x => x.Title.ToLower() == menus[menuLevel + 1]);
                menu = lowerLevel.Dig(menus, menuLevel + 1);
            }
            else
                menu = this;
            
            return menu;
        }

        public void CallCommand(CliCommand command)
        {
            var menu = Dig(command.Menus.ToArray(), 0);

            var function = menu.Functions.FirstOrDefault(x => x.Name == command.Function);

            if (function == null)
                DisplayInvalidCommand(command.Function);

            else
                function.Invoke();
        }

        private void DisplayInvalidCommand(string functionName)
        {
            Console.WriteLine();
            Console.WriteLine($"function '{functionName}' is not recognized");
            DisplayHelp();
        }

        private void DisplayHelp()
        {
            if (SubMenus != null)
                DisplayMenus();

            if (Functions != null)
                DisplayFunctions();
        }

        private void DisplayFunctions()
        {
            Console.WriteLine();
            Console.WriteLine("available functions:");
            Console.WriteLine();
            foreach (var i in Functions)
            {
                Console.WriteLine($"\t- {i.Name}: {i.Description}");
            }
        }
        private void DisplayMenus()
        {
            Console.WriteLine();
            Console.WriteLine("sub-menus:");
            Console.WriteLine();
            foreach (var i in SubMenus)
            {
                Console.WriteLine($"\t- {i.Title}");
            } 
        }
    }
}