using System;

namespace ProjectPartA_A2
{
    class Program
    {

        // The Article
        struct Article
        {
            public string Name;
            public decimal Price;
        }

        // Will hold the value name of the article that the user whant's to delite
        public static string removerInput;

        // Will make the programe loop until the user whant's to exit the program.
        public static bool runProgram = true;

        // A boolien that will check if the input was correct.
        public static bool incorrectInput;

        // Will keep track off the total cost of all the active items.
        public static decimal totalPrice = 0;

        // Will hold the value of how many article's are alowed.
        const int _maxNrArticles = 10;

        // Int that will controll the amount of character's the name can have.
        const int _maxArticleNameLength = 20;

        // Varible that will be used to calculate VAT in total price.
        const decimal _vat = 0.25M;

        // Creating a instens of the struct Article
        static Article[] articles = new Article[_maxNrArticles];

        // This counter will hold the value of how many articles there is 
        static int nrArticlesCounter = 0;

        // The entry point of the program.
        static void Main(string[] args)
        {
            //Run Program.
            Run();           
        }
        
        //The logic behind how the program shude operate. 
        static void Run()
        {
            //While true....
            while (runProgram)
            {
                //Print the front meny, takes a number that will display how many articals have been enterd.
                Print.FrontMeny(nrArticlesCounter);

                //Handle the meny execution's
                MenuExecution();

            }
        }

        //The diffrent many options.
        public static void MenuExecution()
        {
            //Try...
            try 
            {

                switch (Console.ReadLine())
                {
                    //Enter a article
                    case "1":
                        if( nrArticlesCounter >= _maxNrArticles)
                        {
                            Console.WriteLine("\nThe total amount of articles can not exided 10!");
                            Console.WriteLine("Press \"Enter\" to continoue..");
                            Console.ReadLine();
                        }
                        else
                        {
                            ReadAnArticle();
                        }
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
                        PrintRecieptByName();
                        break;

                    //Quit programe
                    case "5":
                        runProgram = false;
                        break;

                    default:
                        Print.InvalidMessage();
                        break;
                }
            }//Else catch and inform the user what the problem was.
            catch(Exception eMsg)
            {
                //Print what exception has acured. 
                Console.WriteLine(eMsg.Message);
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

        //Let's the user remove a article.
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
                            articles[i] = new Article();                           
                            found = 1;
                            nrArticlesCounter--;
                            totalPrice -= articles[i].Price;

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

        //Prints the existing articles by price.
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

        //Prints the existing articles by name.
        private static void PrintRecieptByName()
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
                for (int i = 0; i < nrArticlesCounter - 1; i++)
                {
                    //If the curent varieble is higher then the next...
                    if (articles[i].Name.ToLower()[0] > articles[i + 1].Name.ToLower()[0])
                    {
                        //Switch place and activate the loop agien.
                        string temp;
                        temp = articles[i].Name;
                        articles[i].Name = articles[i + 1].Name;
                        articles[i + 1].Name = temp;
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
    }
}
