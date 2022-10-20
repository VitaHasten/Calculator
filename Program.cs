
    internal class Program
    {
        static void Main(string[] args)
        {

            // Pseudo kod
            // Välkomnande meddelande
            // En lista för att spara historik för räkningar
            // Användaren matar in tal och matematiska operation
            // OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!
            // Ifall användaren skulle dela 0 med 0 visa Ogiltig inmatning!
            // Lägga resultat till listan
            //Visa resultat
            //Fråga användaren om den vill visa tidigare resultat.
            //Visa tidigare resultat
            //Fråga användaren om den vill avsluta eller fortsätta.

            ///----------------------------------------------------------------------------------------------------------------------------------------------------------------
            ///
            /// KOMMENTARER FRÅN ROBIN 
            /// 
            /// Jag har valt att använda mig av metoder för att få koden överskådlig och "clean". Valde mellan if-satser eller switch-case för att utföra beräkningarna.
            /// Valde att köra på med if-satser. Har lagt på grundläggande felhantering för att fånga vanliga felinmatningar. Vid vidareutveckling så skulle man kunna utveckla
            /// det ännu mer för att fånga in ännu fler felinmatningar. Exempelvis för stora tal vid beräkningar.
            /// 
            /// ---------------------------------------------------------------------------------------------------------------------------------------------------------------


            string welcome = "Välkommen till Robins miniräknare!\n\n";  // Välkomstmeddelande, visas endast första gången.
            for (int i = 0; i < welcome.Length; i++)    // Loop med thread.sleep som presenterar välkomstmeddelandet med en bokstav i taget.
            {
                Thread.Sleep(50);
                Console.Write(welcome[i]);
            }

            int val = 0;                                // skapar några variabler som kommer användas av programmet.
            string exit = "";
            List<string> list = new List<string>();     // skapar listan som används för att visa de utförda beräkningarna.

            while (val != 3)        // En whilemeny som loopar om menyn tills användaren väljer alternativ 3
            {
                Welcome();      // Anropar texten "vad vill du göra som presenteras bokstav för bokstav med Thread.Sleep
                Meny();         // Anropar huvudmenyn

            InputOption:  // Label - Här hamnar vi om vi har matat in ett felaktigt värde.

                while (int.TryParse(Console.ReadLine(), out val) == false)      // Kontroll av att inmatningen är en siffra mellan 1-3
                {
                    Console.WriteLine("\nDu skrev inte in någon siffra. Försök igen.\n");
                }
                if (val <= 0 || val > 3)
                {
                    Console.WriteLine("\nDin inmatning måste vara 1, 2 eller 3.\n");
                    goto InputOption;
                }

                Console.Clear();    // Rensar skärmen

                switch (val)
                {
                    case 1:         // Val 1 vid huvudmenyn gör att du hamnar här.
                        {
                            Info();     // Anropar en guide för vilka beräkningar programmet klarar av 
                            string calculation = Console.ReadLine();    // Användarens beräkning tas emot här

                            while (calculation != "")       // En loop som fortsätter att ta emot användarens beräkningar tills dess att användaren inte matar något värde och trycker ENTER
                            {
                            Start:      // Label - Här hamnar du om du försökt beräkna 0/0.

                                if (calculation.Contains("+"))      // om beräkningen innehåller plustecknet så hamnar vi här
                                {
                                    plusCalc(calculation);          // anropar metoden för addition

                                }

                                else if (calculation.Contains("-")) // om beräkningen innehåller minustecknet så hamnar vi här
                                {
                                    minusCalc(calculation);         // anropar metoden för subtraktion
                                }

                                else if (calculation.Contains("/")) // om beräkningen innehåller divisionstecknet så hamnar vi här
                                {
                                    if (calculation == "0/0")   // if-sats som fångar upp om användaren försöker del 0 med 0.
                                    {
                                        Console.WriteLine("Felaktig inmatning, försök igen.");
                                        calculation = Console.ReadLine();   // Användaren får mata in en ny beräkning
                                        goto Start;     // Beräkningen skickas till waypointen Start och kontrolleras igen.
                                    }
                                    divisionCalc(calculation); // anropar metoden för division
                                }

                                else if (calculation.Contains("*")) // om berälningen innehåller multiplikationstecknet så hamnar vi här
                                {
                                    multiplicationCalc(calculation);    // anropar metoden för multiplikation
                                }
                                else           // fångar upp inmatningar som inte innehåller något av de fyra räknesättens tecken
                                {
                                    Console.WriteLine("Felaktig inmatning. Försök igen.");
                                }
                                calculation = Console.ReadLine(); // Användaren får mata in en beräkningen igen.

                            }
                            Console.Clear(); // användaren är klar och vi rensar skärmen
                            break;  // break tar oss ur case 1
                        }
                    case 2: // val 2 vid huvudmenyn gör att du hamnar här
                        {
                            {
                                Result();   // anropar metod som visar listan som skapats av dina beräkningar
                            }
                            break;  // break tar oss ur case 2
                        }
                }
            }

            void Welcome()  // Metod som vid anrop presenterar texten "vad vill du göra" bokstav för bokstav med Thread.Sleep 
            {
                string welcome = "Vad vill du göra?\n";
                for (int i = 0; i < welcome.Length; i++)
                {
                    Thread.Sleep(20);
                    Console.Write(welcome[i]);
                }
            }

            void Meny()     // Metod som vid anrop presenterar huvudmenyn 
            {
                Console.WriteLine("__________________________________\n");
                Thread.Sleep(200);
                Console.WriteLine("1. \tUtföra beräkningar.");
                Thread.Sleep(200);
                Console.WriteLine("2. \tSe tidigare beräkningar.");
                Thread.Sleep(200);
                Console.WriteLine("3. \tAvsluta programmet.");
                Console.WriteLine("__________________________________\n");
            }

            void Info()     // metod som vid anrop presenterar vilka beräkningar som programmet kan göra
            {
                Console.WriteLine("___________________________________________________________________________________________");
                Console.WriteLine("\nSkriv in en beräkning av två tal. Exempelvis \"17+12\". Programmet kan beräkna +,-,/,*.\n\n" +
                    "När du inte vill utföra ytterligare beräkningar så lämnar du fältet tomt och trycker ENTER.");
                Console.WriteLine("___________________________________________________________________________________________\n");
            }

            string plusCalc(string calculation)     // metod för att beräkna addition
            {
                int plus = calculation.IndexOf("+");    // hittar plustecknet i användarens beräkning
                string tal1 = calculation[..plus];  // skapar tal1 från beräkningen
                string tal2 = calculation[(plus + 1)..];    // skapar tal2 från beräkningen
                float tal1Plus = float.Parse(tal1); // omvandlar strängen för tal1 till en float
                float tal2Plus = float.Parse(tal2); // omvandlar strängen för tal2 till en float
                float calcSvarPlus = tal1Plus + tal2Plus; // räknar ut svaret på användarens beräkning
                string plustal = tal1Plus.ToString() + "+" + tal2Plus.ToString() + "=" + calcSvarPlus.ToString();   // konverterar hela beräkningen till en sträng
                list.Add(plustal);  // lägger till strängen i listan
                Console.Clear();    // rensar skärmen
                Info(); // anropar informationsrutan för att det inte ska se ut som att bakgrunden ändras.
                Console.WriteLine(tal1Plus + "+" + tal2Plus + "=" + calcSvarPlus);  // skriver ut beräkningen för användaren.
                return plustal;     // Returnerar sträng till list utanför metoden
            }

            string minusCalc(string calculation)    // Samma upplägg som medtoden plusCalc ovan. Se den för kommentarer.
            {
                int minus = calculation.IndexOf("-");
                string tal1 = calculation[..minus];
                string tal2 = calculation[(minus + 1)..];
                float tal1Minus = float.Parse(tal1);
                float tal2Minus = float.Parse(tal2);
                float calcSvarMinus = tal1Minus - tal2Minus;
                string minusTal = tal1Minus.ToString() + "-" + tal2Minus.ToString() + "=" + calcSvarMinus.ToString();
                list.Add(minusTal);
                Console.Clear();
                Info();
                Console.WriteLine(tal1Minus + "-" + tal2Minus + "=" + calcSvarMinus);
                return minusTal;
            }

            string divisionCalc(string calculation)     // Samma upplägg som medtoden plusCalc ovan. Se den för kommentarer.
            {
                int division = calculation.IndexOf("/");
                string tal1 = calculation[..division];
                string tal2 = calculation[(division + 1)..];
                float tal1Division = float.Parse(tal1);
                float tal2Division = float.Parse(tal2);
                float calcSvarDivision = tal1Division / tal2Division;
                string divisionTal = tal1Division.ToString() + "/" + tal2Division.ToString() + "=" + calcSvarDivision.ToString();
                list.Add(divisionTal);
                Console.Clear();
                Info();
                Console.WriteLine(tal1Division + "/" + tal2Division + "=" + calcSvarDivision);
                return divisionTal;
            }

            string multiplicationCalc(string calculation)       // Samma upplägg som medtoden plusCalc ovan. Se den för kommentarer.
            {
                int Multiplication = calculation.IndexOf("*");
                string tal1 = calculation[..Multiplication];
                string tal2 = calculation[(Multiplication + 1)..];
                float tal1Multiplication = float.Parse(tal1);
                float tal2Multiplication = float.Parse(tal2);
                float calcSvarMultiplication = tal1Multiplication * tal2Multiplication;
                string MultiplicationTal = tal1Multiplication.ToString() + "*" + tal2Multiplication.ToString() + "=" + calcSvarMultiplication.ToString();
                list.Add(MultiplicationTal);
                Console.Clear();
                Info();
                Console.WriteLine(tal1Multiplication + "*" + tal2Multiplication + "=" + calcSvarMultiplication);
                return MultiplicationTal;
            }

            void Result()   // metod som vid anrop presenterar utförda beräkningar och hur många beräkningar som användaren utförde
            {
                Console.Clear();    // rensar skärmen
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Antal utförda beräkningar: " + list.Count + " st"); // Count räknar hur många korrekta beräkningar som användaren utförde
                Console.WriteLine("--------------------------------");
                foreach (var checkList in list)
                {
                    Console.WriteLine(checkList);   // foreach för att presentera listan med beräkningar
                }
                Console.WriteLine("-------------------------------");
                Console.Write("\nTryck på valfri tangent för att återgå till huvudmenyn. ");
                Console.ReadKey();  // Readkey för att vi ska hinna se resultatet innan skärmen rensas
                Console.Clear();    // Rensar skärmen
            }

            Console.WriteLine("\nProgrammet avslutas...");  // avslutningsmeddelande när användaren valt alternativ 3 vid huvudmenyn
            Console.ReadKey();
        }
    }
