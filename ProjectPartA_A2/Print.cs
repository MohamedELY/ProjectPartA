using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartA_A2
{
    class Print
    {
        //Clears the console and print's out the front meny.
        static public void FrontMeny(int counter)
        {
            Console.Clear();
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine("-_-     ~   ~  Meny  ~   ~    -_-");
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine($"  ~ Articles enterd: {counter}\n");

            Console.WriteLine(" [1] Enter an article            ");
            Console.WriteLine(" [2] Remove an article           ");
            Console.WriteLine(" [3] Print receipt by price      ");
            Console.WriteLine(" [4] Print receipt by name       ");
            Console.WriteLine(" [5] Quit \n                     ");
     
            Console.Write("Input: ");
        }

        //tell's the user that a invalid input was enterd with a parameter
        static public void InvalidMessage(string input)
        {
            Console.WriteLine(" ");
            Console.WriteLine($"{input}\n");
            Console.WriteLine("Invalid Input was Enterd!");
            Console.WriteLine("Press \"Enter\" to continoue..");
            Console.ReadLine();
        }

        //tell's the user that a invalid input was enterd
        static public void InvalidMessage()
        {
            Console.WriteLine("\nInvalid Input was Enterd!");
            Console.WriteLine("Press \"Enter\" to continoue..");
            Console.ReadLine();
        }
    }
}
