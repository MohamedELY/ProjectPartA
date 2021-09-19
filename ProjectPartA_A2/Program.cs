using System;

namespace ProjectPartA_A2
{
    class Program
    {
        /// <summary>
        /// The Article
        /// </summary>
        struct Article
        {
            public string Name;
            public decimal Price;
        }

        /// <summary>
        /// Will hold the value name of the article that the user whant's to delite
        /// </summary>
        public static string removerInput;

        /// <summary>
        /// Will make the game loop until the user whant's to exit the program.
        /// </summary>
        public static bool runProgram = true;

        /// <summary>
        /// a boolien that will check if the input was correct.
        /// </summary>
        public static bool incorrectInput;

        /// <summary>
        /// Will keep track off the total cost of all the active items.
        /// </summary>
        public static decimal totalPrice = 0;

        /// <summary>
        /// Will hold the value of how many article's the user whant's.
        /// </summary>
        const int _maxNrArticles = 10;

        /// <summary>
        /// Int that will controll the amount of character's the name can have.
        /// </summary>
        const int _maxArticleNameLength = 20;

        /// <summary>
        /// Varible that will be used to calculate VAT in total price.
        /// </summary>
        const decimal _vat = 0.25M;

        /// <summary>
        /// Creating a instens of the struct Article
        /// </summary>
        static Article[] articles = new Article[_maxNrArticles];

        /// <summary>
        /// This counder will hold the value of how many articles there is 
        /// </summary>
        static int nrArticlesCounter = 0;

        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Run();
            
        }

        /// <summary>
        /// The logic behind how the program shude operate. 
        /// </summary>
        static void Run()
        {
            //While true....
            while (runProgram)
            {
                //Print the front meny, takes a int that will display how many articals have been chosen.
                Print.FrontMeny(nrArticlesCounter);

                //Handle the meny execution's
                MenuExecution();

            }
        }

        public static void MenuExecution()
        {
            switch (Console.ReadLine())
            {
                //Enter a article
                case "1":
                    ReadAnArticle();
                    break;

                //Remove a article
                case "2":
                    RemoveAnArticle();
                    break;

                //Print receipte by price
                case "3":
                    PrintRecieptByPrice();
                    break;

                //Print receipte by name
                case "4":
                    break;

                //Quit programe
                case "5":
                    return;

                default:
                    Print.InvalidMessage();
                    break;
            }
        }

        //Let's the user input a article.
        private static void ReadAnArticle()
        {
            //While wrong input...
            incorrectInput = true;
            while (incorrectInput)
            {
                //Ask the user for a input.
                Console.WriteLine($"\n\nPleas enter name and price for the article in this format name; price (example Beer; 2,25)");
                Console.Write("Input:");
                
                string sArtical = Console.ReadLine();
                //If the input Contains a ';' character.
                if (sArtical.Contains(';'))
                {
                    //Split the string where the ';'char is located.
                    var sSpliter = sArtical.Split(';');

                    //If you can convert the the right side of the string into decimal, save value...
                    if (decimal.TryParse(sSpliter[1], out decimal validPrice))
                    {
                        //If the left side of the string is not emty and its not bigger then 20 char... 
                        if (sSpliter[0].Length != 0 && sSpliter[0].Length <= _maxArticleNameLength)
                        {
                            //Insert the values to the array class article's.
                            articles[nrArticlesCounter++] = new Article
                            {
                                Name = sSpliter[0],
                                Price = validPrice
                            };
                            //Add the sum too total price
                            totalPrice += validPrice;
                            
                            //And Break loop.
                            incorrectInput = false;

                        }//Else...
                        else
                        {
                            //Inform the user that the input did not contain a valid name.
                            Console.WriteLine("\nThe input did not contain a valid name! Try agien.");
                        }
                    }//Else...
                    else
                    {
                        //Inform the user that the input did not contain a valid number.
                        Console.WriteLine("\nThe input did not contain a valid number! Try agien.");
                    }
                }//else...
                else
                {
                    //Inform the user that the input didn't contain the ';' character and let them try agien.

                    Console.WriteLine("\nThe input did not contain a ';' character! Try agien.");
                }
            }
        }
        private static void RemoveAnArticle()
        {
            //Clear's the console
            Console.Clear();

            //If there is articles...
            if (nrArticlesCounter != 0)
            {
                //Ask what the user whant's to remove.             
                Console.WriteLine("Input the Article you whant to delite.");
                Console.Write("Input: ");

                //Get user input
                removerInput = Console.ReadLine();

                //go through the array and look for article that the user enterd.
                for (int i = 0, found = 0; i < articles.Length; i++)
                {
                    //if there is no item in the current slot...
                    if (articles[i].Equals(default(Article)))
                    {
                        //And if the item was found and deleted...
                        if (found == 1)
                        {
                            //Inform the user that that the article was deleted successfuly.
                            Console.Clear();
                            Console.WriteLine("Item deleted successfuly!\n");
                            Console.WriteLine(@"Press ""Enter"" to continue.");
                            Console.ReadLine();
                            break;
                        }
                        //Else...
                        else
                        {   //Inform the user that the item dose not exist.
                            Console.Clear();
                            Console.WriteLine("The item was not found.\n");
                            Console.WriteLine(@"Press ""Enter"" to continue.");
                            Console.ReadLine();
                            break;
                            
                        }
                    }
                    //if the article is not found yet.
                    if (found == 0)
                    {
                        //if the article was found...
                        if (articles[i].Name.CompareTo(removerInput) == 0)
                        {
                            //Remove the article, set the "article found" indicator to true. Delite 1 from counter and the price from total. 
                            totalPrice -= articles[i].Price;
                            articles[i] = new Article();                           
                            nrArticlesCounter--;
                            found = 1;

                        }

                    }
                    //If the article is already found and deleted...
                    else 
                    {                        
                        //The artical is a struct so we can set the artical in the previous slot to the article in the current slot.                        
                        articles[i - 1] = articles[i];
                        articles[i] = new Article();                                                
                    }                   
                }
            }//else...
            else
            {
                //Tell the user that there is no artical's
                Console.Clear();
                Console.WriteLine("There is no artical's!\n");
                Console.WriteLine(@"Press ""Enter"" to continue.");
                Console.ReadLine();
            }            
        }
        private static void PrintRecieptByPrice()
        {
            //Clears the console.
            Console.Clear();

            //Print out how many items purchased and font.
            Console.WriteLine("\nReciept: Purchased Articles\n");
            Console.WriteLine("{0,0} {1,-20} {2,-20:C2}", "#", "Name", "Price");

            //While the array is not sorted by price...
            bool notSorted = true;
            while (notSorted)
            {
                //Set loop to fals
                notSorted = false;
                //Go thrue all the array's variabel's.
                for (int i = 0; i < nrArticlesCounter-1; i++)
                {
                    //If the curent varieble is higher then the next...
                    if(articles[i].Price > articles[i + 1].Price)
                    {
                        //Switch place and activate the loop agien.
                        decimal temp = 0;
                        temp = articles[i].Price;
                        articles[i].Price = articles[i+1].Price;
                        articles[i + 1].Price = temp;
                        notSorted = true;
                    }                   
                }
            }

            //Do this as meny times as item's purchased...
            for (int i = 0; i < nrArticlesCounter; i++)
            {
                //Print out article Name and and price in a nice format.
                Console.WriteLine("{0,0} {1,-20} {2,-20:C2}", i + 1, articles[i].Name, articles[i].Price);
            }

            //Print out Total Price, Date and VAT cost.
            Console.WriteLine($"\nTotal Cost:\t       {totalPrice:C2}");
            Console.WriteLine($"Includes VAT~25%:\t{totalPrice * _vat:C2}");
            Console.WriteLine($"\nPurchase date: {DateTime.Now}\n\n");

            //Tell the user to press "Enter" to go back.
            Console.WriteLine(@"Press ""Enter"" to go back.");
            Console.ReadLine();
        }

        private static void SortArticles(bool sortByName = false)
        {
            //Your code to Sort. Either BubbleSort or SelectionSort
        }
    }
}
