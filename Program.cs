int val = 0;
string exit = "";
List<string> list = new List<string>();

    while (val != 3)
    {
        Welcome();
        Meny();

        InputOption:

        while (int.TryParse(Console.ReadLine(), out val) == false)
        {
            Console.WriteLine("\nDu skrev inte in någon siffra. Försök igen.\n");
        }
        if (val <= 0 || val > 3)
        {
            Console.WriteLine("\nDin inmatning måste vara 1, 2 eller 3.\n");
            goto InputOption;
        }

        Console.Clear();

        switch (val)
        {
            case 1:
                {
                    Info();
                    string calculation = Console.ReadLine();

                    while (calculation != "")
                    {
                    Start:
                        if (calculation.Contains("+"))
                        {
                            int plus = calculation.IndexOf("+");
                            string tal1 = calculation[..plus];
                            string tal2 = calculation[(plus + 1)..];
                            float tal1Plus = float.Parse(tal1);
                            float tal2Plus = float.Parse(tal2);
                            float calcSvarPlus = tal1Plus + tal2Plus;
                            string plustal = tal1Plus.ToString() + "+" + tal2Plus.ToString() + "=" + calcSvarPlus.ToString();
                            list.Add(plustal);
                            Console.Clear();
                            Info();
                            Console.WriteLine(tal1Plus + "+" + tal2Plus + "=" + calcSvarPlus);

                        }

                        else if (calculation.Contains("-"))
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
                        }

                        else if (calculation.Contains("/"))
                        {
                            if (calculation == "0/0")
                            {
                                Console.WriteLine("Felaktig inmatning, försök igen.");
                                calculation = Console.ReadLine();
                                goto Start;
                            }

                            int division = calculation.IndexOf("/");
                            string tal1 = calculation[..division];
                            string tal2 = calculation[(division + 1)..];
                            float tal1Division = float.Parse(tal1);
                            float tal2Division = float.Parse(tal2);
                            float calcSvarDivision = tal1Division / tal2Division;
                            string DivisionTal = tal1Division.ToString() + "/" + tal2Division.ToString() + "=" + calcSvarDivision.ToString();
                            list.Add(DivisionTal);
                            Console.Clear();
                            Info();
                            Console.WriteLine(tal1Division + "/" + tal2Division + "=" + calcSvarDivision);
                        }

                        else if (calculation.Contains("*"))
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
                        }
                        calculation = Console.ReadLine();

                    }
                    break;
                }
            case 2:
                {
                    {
                        Result();
                    }
                    break;
                }
        }
    }



    void Welcome()
    {
        Console.Clear();
        string welcome = "Välkommen till Robins miniräknare!\n\nVad vill du göra?\n";
        for (int i = 0; i < welcome.Length; i++)
        {
            Thread.Sleep(50);
            Console.Write(welcome[i]);
        }
    }

    void Meny()
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

    void Info()
    {
        Console.WriteLine("___________________________________________________________________________________________");
        Console.WriteLine("\nSkriv in en beräkning av två tal. Exempelvis \"17+12\". Programmet kan beräkna +,-,/,*.\n\n" +
            "När du inte vill utföra ytterligare beräkningar så lämnar du fältet tomt och trycker ENTER.");
        Console.WriteLine("___________________________________________________________________________________________\n");
    }

    void Result()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Antal utförda beräkningar: " + list.Count + " st.");
        Console.WriteLine("--------------------------------");
        foreach (var checkList in list)
        {
            Console.WriteLine(checkList);
        }
        Console.WriteLine("-------------------------------");
        Console.Write("\nTryck på valfri tangent för att återgå till huvudmenyn. ");
        Console.ReadKey();
    }
    
Console.WriteLine("\nProgrammet avslutas...");
Console.ReadKey();