using System.Collections.Generic;
using System.Linq;

namespace BucketCli
{
    public class CliCommand
    {
        public List<string> Menus { get; set; } = new List<string>();
        public List<string> Modifiers { get; set; } = new List<string>();
        public string Function { get; set; }
        public CliCommand(string[] arguments) 
        {
            var modifierHit = false;

            foreach (var i in arguments)
            {
                if (i.Contains("-"))
                    modifierHit = true;

                if (modifierHit)
                    Modifiers.Add(i);

                else
                    Menus.Add(i);
            }

            Function = Menus.Last();

            Menus.Remove(Function);
        }
    }
}