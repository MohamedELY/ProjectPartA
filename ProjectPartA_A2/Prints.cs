using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartA_A1
{
    class Prints
    {
        //Clears the console and print's out the front meny.
        static public void FrontMeny()
        {
            Console.Clear();
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine("-_-     ~   ~  Meny  ~   ~    -_-");
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine(" [1] Enter a article             ");
            Console.WriteLine(" [2] Remove a article            ");
            Console.WriteLine(" [3] Print receipt by price      ");
            Console.WriteLine(" [4] Print receipt by name       ");
            Console.WriteLine(" [5] Quit                        ");
            Console.WriteLine(" ");
            Console.Write    ("Input: ");
        }

        //tell's the user that a invalid input was enterd
        static public void InvalidMessage()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Invalid Input was Enterd!");
            Console.WriteLine("Press \"Enter\" to continoue..");
            Console.ReadLine();
        }

        //Can be used later !!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /*
                switch (Console.ReadLine())
                {
                    //Enter a article
                    case "1":
                        break;
                    
                    //Remove a article
                    case "2":
                        ReadArticles();
                        break;
                    
                    //Print receipte by price
                    case "3":
                        break;

                    //Print receipte by name
                    case "4":
                        break;
                    
                    //Quit programe
                    case "5":
                        return;
    
                    default:
                        Prints.InvalidMessage();
                        break;
                }
        */
    }
}
