using System;

namespace BucketCli
{
    public abstract class CliFunction
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public FunctionModifier[] Modifiers { get; set; }
        public abstract void Invoke(string[] modifiers = null);
        public CliFunction(string name, string description, FunctionModifier[] modifiers)
        {
            if (name.Contains(" "))
                throw new ArgumentException("Function name cannot contain a space container");
            
            Name = name;
            Description = description;
            Modifiers = modifiers;
        }
        protected void DisplayHelp()
        {
            Console.WriteLine();
            Console.WriteLine("Help:");
            Console.WriteLine($"  {Name}: {Description}");
            DisplayModifiers();
        }
        protected void DisplayModifiers()
        {
            Console.WriteLine();
            Console.WriteLine("  modifiers:");

            foreach (var i in Modifiers)
                Console.WriteLine($"\t-{i.ShortKey}/--{i.LongKey}: {i.Description}");
        }

    }
}