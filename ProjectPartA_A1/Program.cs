using System;

namespace ProjectPartA_A1
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
        /// Bool that will be use'd to check if string can Parse to double.
        /// </summary>
        public static bool canParse;

        /// <summary>
        /// Varible that will be used to calculate VAT in total price.
        /// </summary>
        const decimal _vat = 0.25M;

        /// <summary>
        /// Will hold the value of how many article's the user whant's.
        /// </summary>
        static int nrArticles;

        /// <summary>
        /// Int that will controll the amount of character's the name can have.
        /// </summary>
        const int _maxArticleNameLength = 20;

        /// <summary>
        /// Int that will controll the amount of space the article's array will have.
        /// </summary>
        const int _maxNrArticles = 10;

        /// <summary>
        /// Creating a instens of the struct Article
        /// </summary>
        static Article[] articles = new Article[_maxNrArticles];

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            //Runs Martin's shoppping game. 
            Run();
        }

        #region Methods
        /// <summary>
        /// Runs Martin's shopping minigame.
        /// </summary>
        private static void Run()
        {
            ReadArticles();
            PrintReciept();    
        }

        /// <summary>
        /// Let's the user input article in the reciept.
        /// </summary>
        private static void ReadArticles()
        {
            //Print out Shop name.
            Console.WriteLine("Martin's Shop \n\n\n");
            
            //While incorect input....
            bool incorectInput = true;
            while (incorectInput)
            {
                //Ask the user for amount of article's.
                Console.WriteLine("How many articals do you whant? (1 - 10)");
                Console.Write("Input: ");

                //Check if input string can parse to int, if true save value.
                canParse = int.TryParse(Console.ReadLine(), out nrArticles);
                //if input can parse to int...
                if (canParse)
                {
                    
                    //if input number is between 1 - 10..
                    if(nrArticles >= 1 && nrArticles <= 10)
                    {                       
                        //Exit the loop.
                        incorectInput = false;

                    }//Else..
                    else
                    {
                        //Tell the user that input number is not between 1-10 and let user try agien.
                        Console.WriteLine("\nThe number enterd is not between 1 and 10!\n\n");
                    }
                }//Else....
                else
                {
                    //Inform the user that wrong input was enterd, and let them try agien.
                    Console.WriteLine("\nInvalid Input, not a number enterd!\n\n");
                }
            }

            //Do it as many times as articles chosen.
            for (int i = 0; i < nrArticles; i++)
            {
                //While wrong input...
                incorectInput = true;
                while (incorectInput)
                {
                    //Ask the user for a input.
                    Console.WriteLine($"\n\nPleas enter name and price for article {i + 1} in this format name; price (example Beer; 2,25)");
                    Console.Write    ("Input:");
                    
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
                                articles[i] = new Article
                                {
                                    Name = sSpliter[0],
                                    Price = validPrice
                                };
                                //And Break loop.
                                incorectInput = false;

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
        }

        /// <summary>
        /// Print out the Reciept of the artcles the user chose. 
        /// </summary>
        private static void PrintReciept()
        {
            //Clears the console.
            Console.Clear();

            //Print out how many items purchased.
            Console.WriteLine("\nReciept: Purchased Articles");
            Console.WriteLine($"Number of items purchased: {nrArticles}\n");
            Console.WriteLine("{0,0} {1,-20} {2,-20:C2}", "#", "Name", "Price");

            //Declare a decimal that will add upp the total price of the artical's. 
            decimal totalPrice = 0;
            //Do this as meny times as item's purchased...
            for (int i = 0; i < nrArticles; i++)
            {
                //Print out article Name and and price in a nice format.
                Console.WriteLine("{0,0} {1,-20} {2,-20:C2}", i + 1, articles[i].Name, articles[i].Price);
                //Add the price of the artical to the total price.
                totalPrice += articles[i].Price;
            }
            //Print out Total Price, Date and VAT cost.
            Console.WriteLine($"\nTotal Cost:\t       {totalPrice :C2}");
            Console.WriteLine($"Includes VAT~25%:\t{totalPrice * _vat :C2}");
            Console.WriteLine($"\nPurchase date: {DateTime.Now}\n\n");

            //Tell the user to press "Enter" to exit
            Console.WriteLine(@"Press ""Enter"" to exit.");
            Console.ReadLine();
        }
        #endregion
    }
}
