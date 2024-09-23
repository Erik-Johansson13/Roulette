
// Roulette Specs
// A Roulette game in which the user can bet certain amount of money
// on either red or black, odd or even, a specific number or green
// The user should be able to deposit or withdraw their money in a bank outsid of the game
// If the user goes bankrupt or makes enough money they will be able to exit, or they can give up
// Snake eyes mode with chance for 10* profit
// Loans that the user can take if they are bankrupt or close to bankruptcy
// with interest of 5% for every turn and they have to be paid back within 5 turns
// and user can't exit with an active loan without filing for bankruptcy

using System.Runtime.InteropServices;

int wallet = 100;
int bet = 0;
int account = 0;
int sum = 0;
int loan = 0;
string[] gossip = { };
string choice = "";
string deny = "There is no such choice";
string rColor = "";
string rColor2 = "";
int bankInput = 0;
bool bankrupt = false;
bool snakeEyes = false;
bool leave = false;
int[] red = { 32, 19, 21, 25, 34, 27, 36, 30, 23, 5, 16, 1, 14, 9, 18, 7, 12, 3 };
int[] black = { 15, 4, 2, 17, 6, 13, 11, 8, 10, 24, 33, 20, 31, 22, 29, 28, 35, 26 };
int greenMult = 36;
int redMult = 2;
int evenMult = 2;
int oddMult = 2;
int blackMult = 2;
int numMult = 36;
int betNum = 0;
int mult = 1;
int payOut = 0;

int randNum = -1;
int rouletteNum2 = -1;
int rouletteNum = -1;

bool single = false;
bool betRed = false;
bool betBlack = false;
bool even = false;
bool odd = false;
bool green = false;
bool win = false;
Random rand = new Random();

// The game
// Story and background
Console.WriteLine("Hello and welcome to the Lucifers casino!");
Console.WriteLine("You, who have bet your soul, are now in harsh debt");
Console.WriteLine("However, due to your unwavering tenacity, the lord has given you another chance");
Console.WriteLine("You have been locked to the roulette machines and are unable to free yourself");
Console.WriteLine("You have to gamble your way from 100 fragmented souls to 10 000 fragmented souls");
Console.WriteLine("If you manage this you are to be let go and freed");
Console.WriteLine("However, if you are to fail, you shall repent for a thousand years");
Console.WriteLine();

// Game loop
while (!bankrupt)
{
    leave = false;
    choice = "0";
    Console.WriteLine("A little imp bearing a luxurious tuxedo is situated at front the desk");
    Console.WriteLine("'Hello and welcome to Lucifers!'");
    Console.WriteLine("'What would you like to do?'");
    Console.WriteLine("You currently have " + wallet + " fragmented souls on hand");
    Console.WriteLine("and " + account + " fragmented souls in your account");

    while (choice != "1" && choice != "2" && choice != "3")
    {
        Console.WriteLine();
        Console.WriteLine("1. Go to the roulette table");
        Console.WriteLine("2. Go to account management");
        Console.WriteLine("3. Go to the bar");
        choice = Console.ReadLine();
        if (choice != "1" && choice != "2" && choice != "3")
        {
            Console.WriteLine(deny);
        }
    }
    // The roulette table
    if (choice == "1")
    {
        Console.WriteLine("");
        Console.WriteLine("'Welcome to the roulette table'");
        while (!leave)
        {
            choice = "0";
            Console.WriteLine();
            Console.WriteLine("'What would you like to do?'");
            Console.WriteLine("You currently have " + wallet + " fragmented souls");
            Console.WriteLine();
            while (choice != "1" && choice != "2")
            {
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Go back");
                choice = Console.ReadLine();
                if (choice != "1" && choice != "2")
                {
                    Console.WriteLine(deny);
                }
            }
            if (choice == "1")
            {
                choice = "0";
                // The roulette game
                Console.WriteLine("'You want to try your luck eh?'");
                while (!leave)
                {
                    Console.WriteLine("'First of all, you should decide on what gamemode you want to play'");
                    Console.WriteLine("'We offer either normal mode, which is just usual roulette, or snake eyes'");
                    Console.WriteLine("'In snake eyes you use 2 roulette wheels instead of 1, and if both come up to be true in line with your guess, your win multiplier is squared'");
                    Console.WriteLine();
                    while (choice != "1" && choice != "2" && choice != "3")
                    {
                        Console.WriteLine("1. Normal");
                        Console.WriteLine("2. Snake eyes");
                        Console.WriteLine("3. Leave");
                        choice = Console.ReadLine();
                        if (choice != "1" && choice != "2" && choice != "3")
                        {
                            Console.WriteLine(deny);
                        }
                    }
                    //Normal roulette
                    if (choice == "1")
                    {
                        Console.WriteLine("Time to play");
                        while (!leave)
                        {
                            choice = "0";
                            Console.WriteLine();
                            Console.WriteLine("What do you want to bet on?");
                            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6")
                            {
                                Console.WriteLine();
                                Console.WriteLine("1. Even 1:1");
                                Console.WriteLine("2. Odd 1:1");
                                Console.WriteLine("3. Red 1:1");
                                Console.WriteLine("4. Black 1:1");
                                Console.WriteLine("5. Single 35:1");
                                Console.WriteLine("6. Green 35:1");
                                choice = Console.ReadLine();
                                if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6")
                                {
                                    Console.WriteLine(deny);
                                }
                            }
                            if (choice == "1")
                            {
                                even = true;
                            }
                            if (choice == "2")
                            {
                                odd = true;
                            }
                            if (choice == "3")
                            {
                                betRed = true;
                            }
                            if (choice == "4")
                            {
                                betBlack = true;
                            }
                            if (choice == "5")
                            {
                                single = true;
                                while (true)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("'Which number?'");
                                    try
                                    {
                                        betNum = Convert.ToInt32(Console.ReadLine());
                                        if (betNum != 0)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("'If you want to bet on green then bet on green!'");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("'Please bet on a valid number'");
                                    }
                                }
                            }
                            if (choice == "6")
                            {
                                green = true;
                            }

                            choice = "0";
                            Console.WriteLine();
                            Console.WriteLine("How many souls would you like to bet?");
                            Console.WriteLine();
                            while (!leave)
                            {
                                while (true)
                                {
                                    try
                                    {
                                        bet = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("'You know you can only bet souls, right?'");
                                    }
                                }
                                if (bet > 0 && bet <= wallet)
                                {
                                    Console.WriteLine("'You have successfully made a bet of " + bet + " fragmented souls'");
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("'Initiate the spin, my lucky fellow'");
                                        Console.ReadLine();
                                        Console.WriteLine("Spinning...");
                                        Console.ReadLine();
                                        randNum = rand.Next(0, 37);
                                        if (randNum < 19 && randNum > 0)
                                        {
                                            rColor = "red";
                                        }
                                        else if (randNum == 0)
                                        {
                                            rColor = "green";
                                        }
                                        else
                                        {
                                            rColor = "black";
                                        }
                                        if (rColor.Equals("red"))
                                        {
                                            randNum = rand.Next(0, red.Length + 1);
                                            rouletteNum = red[randNum];
                                        }
                                        else if (rColor.Equals("black"))
                                        {
                                            randNum = rand.Next(0, black.Length + 1);
                                            rouletteNum = black[randNum];
                                        }
                                        else
                                        {
                                            rouletteNum = 0;
                                        }
                                        Console.WriteLine(randNum);
                                        Console.WriteLine(rColor);

                                        // Checking what user has bet on
                                        if (even)
                                        {
                                            if (randNum % 2 == 0 && randNum != 0)
                                            {
                                                win = true;
                                                mult = evenMult;
                                            }
                                        }
                                        if (odd)
                                        {
                                            if (randNum % 2 != 0 && randNum != 0)
                                            {
                                                win = true;
                                                mult = oddMult;
                                            }

                                        }
                                        if (betRed)
                                        {
                                            if (rColor == "red")
                                            {
                                                win = true;
                                                mult = redMult;
                                            }
                                        }
                                        if (betBlack)
                                        {
                                            if (rColor == "black")
                                            {
                                                win = true;
                                                mult = blackMult;
                                            }
                                        }
                                        if (single)
                                        {
                                            if (betNum == randNum)
                                            {
                                                win = true;
                                                mult = numMult;
                                            }
                                        }
                                        if (green)
                                        {
                                            if (rColor == "green")
                                            {
                                                win = true;
                                                mult = greenMult;
                                            }
                                        }

                                        // Checking if the user has won and calculating loss or profit
                                        if (win)
                                        {
                                            payOut = bet * mult - bet;
                                            Console.WriteLine();
                                            Console.WriteLine("You win!");
                                            Console.WriteLine("You have won " + (payOut) + " fragmented souls");
                                            Console.WriteLine();
                                            wallet += payOut;
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("You lose!");
                                            Console.WriteLine("You have lost " + bet + " fragmented souls");
                                            Console.WriteLine();
                                            wallet -= bet;
                                        }

                                        single = false;
                                        betRed = false;
                                        betBlack = false;
                                        even = false;
                                        odd = false;
                                        green = false;
                                        win = false;
                                        mult = 0;
                                        payOut = 0;
                                        bet = 0;

                                        Console.WriteLine("'Would you like to play again?'");
                                        Console.WriteLine();
                                        Console.WriteLine("You currently have " + wallet + " fragmented souls on hand");
                                        while (choice != "1" && choice != "2")
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("1. Play again");
                                            Console.WriteLine("2. Go to the lobby");
                                            choice = Console.ReadLine();
                                            if (choice != "1" && choice != "2")
                                            {
                                                Console.WriteLine(deny);
                                            }
                                        }
                                        if (choice == "1")
                                        {
                                            break;
                                        }
                                        if (choice == "2")
                                        {
                                            leave = true;
                                        }
                                    }
                                }
                                else if (bet == 0)
                                {
                                    Console.WriteLine("You regret your decisions last minute and leave");
                                    Console.WriteLine();
                                    Console.WriteLine("You coward");
                                    Console.WriteLine();
                                    leave = true;
                                }
                                else
                                {
                                    Console.WriteLine("'You do know that this is an impossible amount considering your current balance, right?'");
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                    //Snake eyes roulette
                    if (choice == "2")
                    {
                        Console.WriteLine("Feeling lucky are we?");
                        while (!leave)
                        {
                            choice = "0";
                            Console.WriteLine();
                            Console.WriteLine("What do you want to bet on?");
                            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6")
                            {
                                Console.WriteLine();
                                Console.WriteLine("1. Even 1:1");
                                Console.WriteLine("2. Odd 1:1");
                                Console.WriteLine("3. Red 1:1");
                                Console.WriteLine("4. Black 1:1");
                                Console.WriteLine("5. Single 35:1");
                                Console.WriteLine("6. Green 35:1");
                                choice = Console.ReadLine();
                                if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6")
                                {
                                    Console.WriteLine(deny);
                                }
                            }
                            if (choice == "1")
                            {
                                even = true;
                            }
                            if (choice == "2")
                            {
                                odd = true;
                            }
                            if (choice == "3")
                            {
                                betRed = true;
                            }
                            if (choice == "4")
                            {
                                betBlack = true;
                            }
                            if (choice == "5")
                            {
                                single = true;
                                while (true)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("'Which number?'");
                                    try
                                    {
                                        betNum = Convert.ToInt32(Console.ReadLine());
                                        if (betNum != 0)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("'If you want to bet on green then bet on green!'");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("'Please bet on a valid number'");
                                    }
                                }
                            }
                            if (choice == "6")
                            {
                                green = true;
                            }

                            choice = "0";
                            Console.WriteLine();
                            Console.WriteLine("How many souls would you like to bet?");
                            Console.WriteLine();
                            while (!leave)
                            {
                                while (true)
                                {
                                    try
                                    {
                                        bet = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    }
                                    catch
                                    {
                                        Console.WriteLine("'You know you can only bet souls, right?'");
                                    }
                                }
                                if (bet > 0 && bet <= wallet)
                                {
                                    Console.WriteLine("'You have successfully made a bet of " + bet + " fragmented souls'");
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("'Initiate the spin, my lucky fellow'");
                                        Console.ReadLine();
                                        Console.WriteLine("Spinning...");
                                        Console.ReadLine();
                                        // The first wheel spin
                                        randNum = rand.Next(0, 37);
                                        if (randNum < 19 && randNum > 0)
                                        {
                                            rColor = "red";
                                        }
                                        else if (randNum == 0)
                                        {
                                            rColor = "green";
                                        }
                                        else
                                        {
                                            rColor = "black";
                                        }
                                        if (rColor.Equals("red"))
                                        {
                                            randNum = rand.Next(0, red.Length + 1);
                                            rouletteNum = red[randNum];
                                        }
                                        else if (rColor.Equals("black"))
                                        {
                                            randNum = rand.Next(0, black.Length + 1);
                                            rouletteNum = black[randNum];
                                        }
                                        else
                                        {
                                            rouletteNum = 0;
                                        }

                                        // The second wheel spin
                                        randNum = rand.Next(0, 37);
                                        if (randNum < 19 && randNum > 0)
                                        {
                                            rColor2 = "red";
                                        }
                                        else if (randNum == 0)
                                        {
                                            rColor2 = "green";
                                        }
                                        else
                                        {
                                            rColor2 = "black";
                                        }
                                        if (rColor2.Equals("red"))
                                        {
                                            randNum = rand.Next(0, red.Length);
                                            rouletteNum2 = red[randNum];
                                        }
                                        else if (rColor2.Equals("black"))
                                        {
                                            randNum = rand.Next(0, black.Length);
                                            rouletteNum2 = black[randNum];
                                        }
                                        else
                                        {
                                            rouletteNum2 = 0;
                                        }
                                        Console.WriteLine(rouletteNum);
                                        Console.WriteLine(rColor);
                                        Console.WriteLine();
                                        Console.WriteLine("And");
                                        Console.WriteLine();
                                        Console.WriteLine(rouletteNum2);
                                        Console.WriteLine(rColor2);

                                        // Checking what user has bet on
                                        if (even)
                                        {
                                            if (rouletteNum % 2 == 0 && rouletteNum != 0 && rouletteNum2 % 2 == 0 && rouletteNum2 != 0)
                                            {
                                                win = true;
                                                mult = evenMult * evenMult;
                                            }
                                        }
                                        if (odd)
                                        {
                                            if (rouletteNum % 2 != 0 && rouletteNum != 0 && rouletteNum2 % 2 != 0 && rouletteNum2 != 0)
                                            {
                                                win = true;
                                                mult = oddMult * oddMult;
                                            }

                                        }
                                        if (betRed)
                                        {
                                            if (rColor == "red" && rColor2 == "red")
                                            {
                                                win = true;
                                                mult = redMult * redMult;
                                            }
                                        }
                                        if (betBlack)
                                        {
                                            if (rColor == "black" && rColor2 == "black")
                                            {
                                                win = true;
                                                mult = blackMult * blackMult;
                                            }
                                        }
                                        if (single)
                                        {
                                            if (betNum == rouletteNum && betNum == rouletteNum2)
                                            {
                                                win = true;
                                                mult = numMult * numMult;
                                            }
                                        }
                                        if (green)
                                        {
                                            if (rColor == "green" && rColor2 == "green")
                                            {
                                                win = true;
                                                mult = greenMult * greenMult;
                                            }
                                        }

                                        // Checking if the user has won and calculating loss or profit
                                        if (win)
                                        {
                                            payOut = bet * mult - bet;
                                            Console.WriteLine();
                                            Console.WriteLine("You win!");
                                            Console.WriteLine("You have won " + (payOut) + " fragmented souls");
                                            Console.WriteLine();
                                            wallet += payOut;
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("You lose!");
                                            Console.WriteLine("You have lost " + bet + " fragmented souls");
                                            Console.WriteLine();
                                            wallet -= bet;
                                        }

                                        single = false;
                                        betRed = false;
                                        betBlack = false;
                                        even = false;
                                        odd = false;
                                        green = false;
                                        win = false;
                                        mult = 0;
                                        payOut = 0;
                                        bet = 0;

                                        Console.WriteLine("'Would you like to play again?'");
                                        Console.WriteLine();
                                        Console.WriteLine("You currently have " + wallet + " fragmented souls on hand");
                                        while (choice != "1" && choice != "2")
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("1. Play again");
                                            Console.WriteLine("2. Go to the lobby");
                                            choice = Console.ReadLine();
                                            if (choice != "1" && choice != "2")
                                            {
                                                Console.WriteLine(deny);
                                            }
                                        }
                                        if (choice == "1")
                                        {
                                            break;
                                        }
                                        if (choice == "2")
                                        {
                                            leave = true;
                                        }
                                    }
                                }
                                else if (bet == 0)
                                {
                                    Console.WriteLine("You regret your decisions last minute and leave");
                                    Console.WriteLine();
                                    Console.WriteLine("You coward");
                                    Console.WriteLine();
                                    leave = true;
                                }
                                else
                                {
                                    Console.WriteLine("'You do know that this is an impossible amount considering your current balance, right?'");
                                    Console.WriteLine();
                                }
                            }
                            if (choice == "3")
                            {
                                Console.WriteLine();
                                Console.WriteLine("You coward");
                                Console.WriteLine();
                                leave = true;
                            }

                        }
                    }
                    if (choice == "3")
                    {
                        Console.WriteLine();
                        Console.WriteLine("You coward");
                        Console.WriteLine();
                        choice = "0";
                        leave = true;
                    }
                }
            }
        }
    }
    leave = false;
    // Account managing
    if (choice == "2")
    {
        Console.WriteLine("'Welcome to the account managing'");
        Console.WriteLine("'Would you like to make a deposit?'");
        Console.WriteLine("You currently have " + wallet + " fragmented souls on hand");
        Console.WriteLine("and " + account + " fragmented souls in your account");
        choice = "0";

        while (choice != "1" && choice != "2" && choice != "3" && choice != "4")
        {
            Console.WriteLine();
            Console.WriteLine("1. Make a deposit");
            Console.WriteLine("2. Make a withdrawal");
            Console.WriteLine("3. Make a loan");
            Console.WriteLine("4. Go back");
            Console.WriteLine();
            choice = Console.ReadLine();
            if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
            {
                Console.WriteLine(deny);
            }
        }
        if (choice == "1")
        {
            while (!leave)
            {
                Console.WriteLine("'How much would you like to deposit?'");
                Console.WriteLine();
                try
                {
                    bankInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("'You know you can only deposit souls, right?'");
                }
                if (bankInput > 0 && bankInput <= wallet)
                {
                    wallet -= bankInput;
                    account += bankInput;
                    Console.WriteLine("'You have successfully made a deposit of " + bankInput + " fragmented souls'");
                    break;
                }
                else if (bankInput == 0)
                {
                    Console.WriteLine("You regret your decisions last minute and leave");
                    Console.WriteLine();
                    leave = true;
                }
                else
                {
                    Console.WriteLine("'You do know that this is an impossible amount considering your current balance, right?'");
                    Console.WriteLine();
                }
            }
        }
        if (choice == "2")
        {
            while (!leave)
            {
                Console.WriteLine("'How much would you like to withdraw?'");
                Console.WriteLine();
                try
                {
                    bankInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("'You know you can only withdraw souls, right?'");
                }
                if (bankInput > 0 && bankInput <= account)
                {
                    wallet += bankInput;
                    account -= bankInput;
                    Console.WriteLine("'You have successfully made a withrawal of " + bankInput + " fragmented souls'");
                    break;
                }
                else if (bankInput == 0)
                {
                    Console.WriteLine("You regret your decisions last minute and leave");
                    Console.WriteLine();
                    leave = true;
                }
                else
                {
                    Console.WriteLine("'You do know that this is an impossible amount considering your current balance, right?'");
                    Console.WriteLine();
                }
            }
        }
        if (choice == "3")
        {
            /*
            while (!leave)
            {
                Console.WriteLine("'How much would you like to deposit?'");
                Console.WriteLine();
                try
                {
                    bankInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("'You know you can only deposit souls, right?'");
                }
                if (bankInput > 0 && bankInput <= wallet)
                {
                    wallet -= bankInput;
                    account += bankInput;
                    Console.WriteLine("'You have successfully made a deposit of " + bankInput + "' fragmented souls'");
                    break;
                }
                else if (bankInput == 0)
                {
                    Console.WriteLine("You regret your decisions last minute and leave");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("'You do know that this is an impossible amount considering your current balance, right?'");
                    Console.WriteLine();
                }
            }
            */
        }
        if (choice == "4")
        {
            Console.WriteLine("You return back to the lobby");
            leave = true;
        }

    }
    leave = false;
    // The bar
    if (choice == "3")
    {
        Console.WriteLine("'Welcome to the bar my lost friend, could I perhaps influence you with a drink?'");
        choice = "0";
        while(!leave) {
            while (choice != "1" && choice != "2" && choice != "3")
            {
                Console.WriteLine();
                Console.WriteLine("1. Buy a drink");
                Console.WriteLine("2. Leave");
                Console.WriteLine("3. Listen to the gossip and rumors");
                choice = Console.ReadLine();
                if (choice != "1" && choice != "2" && choice != "3")
                {
                    Console.WriteLine(deny);
                }
            }
            while (!leave) {
                if (choice == "1")
                {
                    choice = "0";
                    Console.WriteLine();
                    Console.WriteLine("Its red face starts turning and twisting into a wicked smile");
                    Console.WriteLine();
                    Console.WriteLine("'So, what can I get for you?'");
                    while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6")
                    {
                        Console.WriteLine();
                        Console.WriteLine("1. Boiled blood, 3 souls");
                        Console.WriteLine("2. Marrow margherita, 5 souls");
                        Console.WriteLine("3. Locust special, 10 souls");
                        Console.WriteLine("4. Arsenic shot, 20 souls");
                        Console.WriteLine("5. Cold desire, 50 souls");
                        Console.WriteLine("6. A water, 0 souls");
                        choice = Console.ReadLine();
                        if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6")
                        {
                            Console.WriteLine(deny);
                        }
                    }
                    Console.WriteLine("");
                    if (choice == "1")
                    {
                        choice = "0";
                    }
                    if (choice == "2")
                    {
                        choice = "0";
                    }
                    if (choice == "3")
                    {
                        choice = "0";
                    }
                    if (choice == "4")
                    {
                        choice = "0";
                    }
                    if (choice == "5")
                    {
                        choice = "0";
                    }
                    if (choice == "6")
                    {
                        choice = "0";
                    }

                }
                if (choice == "2")
                {
                    choice = "0";
                    Console.WriteLine();
                    Console.WriteLine("In a moment of clarity, you decide that this is not the best course of action for the situation you're in");
                    Console.WriteLine();
                    leave = true;
                }
                if (choice == "3")
                {
                    // Choosing tips to tell to the user
                    choice = "0";
                    randNum = rand.Next(0, gossip.Length);
                    Console.WriteLine("Its small pupils start dotting around the room");
                    Console.WriteLine();
                    Console.WriteLine("'This is just something I've heard from our guests here, but I heard that " + gossip[randNum] + "'");
                    Console.WriteLine();
                    randNum = -1;
                    break;
                }
            }
        }
    }
    sum = account + wallet;
    // Ending game if end conditions are met
    if (sum <= 0)
    {
        bankrupt = true;
        break;
    }
    if (sum >= 10000)
    {
        break;
    }
}
// Deciding ending based on users accomplishments
if (bankrupt)
{
    Console.WriteLine("You are officially bankrupt");
    Console.WriteLine();
    Console.WriteLine("You are going to regret your choices...");
    Console.WriteLine();
    Console.WriteLine("GAME OVER");
}
else
{
    Console.WriteLine("You have made it to 10 000 fragmented souls");
    Console.WriteLine("...");
    Console.WriteLine();
    Console.WriteLine("You wake up");
    Console.WriteLine("Was it all a dream?");
    Console.WriteLine();
    Console.WriteLine("YOU WIN");
}