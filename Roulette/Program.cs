
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
int loanTime = 0;
bool loanActive = false;
int drunkTime = 0;
string[] gossip = {"I heard that someone got slammed down boiled blood and marrow margaritas and then went and won all night long at the roulette table" , "Apparently someone died after downing five straight shots of arsenic. That sounds like total bull, of course" ,  "Apparently, according to something that I've heard from a friend of a friend, the imp at the reception has a special code that only vips are allowed to use"};
string choice = "";
string deny = "There is no such choice";
string rColor = "";
string rColor2 = "";
int bankInput = 0;
bool bankrupt = false;
bool snakeEyes = false;
bool leave = false;
bool hasLoan = false;
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
int payTotal = 0;
int lossTotal = 0;

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
bool secret = false;
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
Console.WriteLine("PRESS ANY BUTTON TO CONTINUE");
Console.ReadKey();

// Game loop
while (!bankrupt && loanTime >= 0)
{
    Console.Clear();

    leave = false;
    choice = "0";
    Console.WriteLine("A little imp bearing a luxurious tuxedo is situated at the front desk");
    Console.WriteLine("'Hello and welcome to Lucifers!'");
    Console.WriteLine("'What would you like to do?'");
    if (hasLoan)
    {
        Console.WriteLine("You currently have an active loan of " + loan + " souls with " + loanTime + " rounds left");
    }
    else
    {
        Console.WriteLine("You currently don't have an active loan");
    }
    Console.WriteLine("You currently have " + wallet + " fragmented souls on hand");
    Console.WriteLine("and " + account + " fragmented souls in your account");

    while (choice != "1" && choice != "2" && choice != "3" && choice != "13")
    {
        Console.WriteLine();
        Console.WriteLine("1. Go to the roulette table");
        Console.WriteLine("2. Go to account management");
        Console.WriteLine("3. Go to the bar");
        choice = Console.ReadLine();
        if (choice != "1" && choice != "2" && choice != "3" && choice != "13")
        {
            Console.WriteLine(deny);
        }
    }
    // Secret
    if (choice == "13" && !secret)
    {
        choice = "0";
        Console.WriteLine();
        Console.WriteLine("His eyebrows start shifting a little");
        while (choice != "1" && choice != "2" && choice != "3")
        {
            choice = Console.ReadLine();
            if (choice != "1" && choice != "2" && choice != "3")
            {
                break;
            }
        }
        if (choice == "666")
        {
            choice = "0";
            secret = true;
            Console.WriteLine();
            Console.WriteLine("His pupils widen");
            Console.WriteLine("'Here you are'");
            Console.WriteLine("He gives you a small bottle that with a lable written in a language you can't understand");
            Console.WriteLine("The only thing you can somewhat read is a tiny number in the bottom left corner");
            Console.WriteLine("Looks to be... 99% alcohol?");
            Console.WriteLine("Sweet!");
            Console.WriteLine("...");
            Thread.Sleep(10000);
            Console.WriteLine("Damn, everything you can see has a identical twin of an identical twin");
            Thread.Sleep(3000);
            drunkTime = int.MaxValue;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("The imp starts snickering at you");
            Console.WriteLine("'You don't seem to really know what you are doing'");
            Thread.Sleep(5000);
        }
        continue;
    }
    // The roulette table
    if (choice == "1")
    {
        Console.Clear();
        Console.WriteLine("A man cast in a dark silhouette stands at the table");
        Console.WriteLine("A weird heat is emenating from him");
        Console.WriteLine("'Welcome to the roulette table'");
        while (!leave)
        {
            choice = "0";
            Console.WriteLine();
            Console.WriteLine("'What would you like to do?'");
            Console.WriteLine("You currently have " + wallet + " fragmented souls on hand");
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
                Console.Clear();

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
                        Console.Clear();
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
                            while (!leave)
                            {
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("'How many souls would you like to bet?'");
                                        Console.WriteLine("You currently have " + wallet + " fragmented souls on hand");
                                        if (hasLoan)
                                        {
                                            Console.WriteLine("And an active loan of " + loan + " souls with a time of " + loanTime + " left");
                                        }
                                        bet = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    }
                                    catch
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("'You know you can only bet souls, right?'");
                                    }
                                }
                                if (bet > 0 && bet <= wallet)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("'You have successfully made a bet of " + bet + " fragmented souls'");
                                    // Spin
                                    {
                                        // Checking if user has drank and applying bonuses
                                        if(drunkTime > 0)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("You feel slightly tipsy, and slighty lucky");
                                            drunkTime -= 1;
                                            if (betBlack)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (!black.Contains(randNum))
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (betRed)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (!red.Contains(randNum))
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (odd)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (randNum % 2 == 0)
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (even)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (randNum % 2 != 0)
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (green)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (randNum != 0)
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (single)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (betNum != randNum)
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("You're more sober than a rock");
                                            randNum = rand.Next(0, 37);
                                        }
                                        if (red.Contains(randNum))
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
                                        Console.WriteLine();
                                        Console.WriteLine("'Initiate the spin, my lucky fellow'");
                                        Console.WriteLine();
                                        Console.ReadKey();
                                        Console.Write("Spinning");
                                        Thread.Sleep(500);
                                        Console.Write(".");
                                        Thread.Sleep(500);
                                        Console.Write(".");
                                        Thread.Sleep(500);
                                        Console.WriteLine(".");
                                        Thread.Sleep(500);
                                        rouletteNum = randNum;
                                        Console.WriteLine();
                                        Console.WriteLine(rouletteNum);
                                        Console.WriteLine(rColor);
                                        Thread.Sleep(1000);

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
                                            payTotal += payOut;
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("You lose!");
                                            Console.WriteLine("You have lost " + bet + " fragmented souls");
                                            Console.WriteLine();
                                            wallet -= bet;
                                            lossTotal += bet;
                                        }
                                        if (hasLoan)
                                        {
                                            loanTime -= 1;
                                            loan += loan/20;
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
                                        if (wallet <= 0 || loanTime < 0)
                                        {
                                            Console.WriteLine("You suddenly feel the ground under your feet getting softer");
                                            Console.WriteLine("Before you realize you are sinking under the ground, and any resistance would be futile");
                                            Thread.Sleep(3000);
                                            leave = true;
                                            continue;
                                        }

                                        Console.WriteLine("'Would you like to play again?'");
                                        Console.WriteLine();
                                        Console.WriteLine("You currently have " + wallet + " fragmented souls on hand");
                                        if (hasLoan) 
                                        {
                                        Console.WriteLine("And an active loan of " + loan + " souls with a time of " + loanTime + " left");
                                        }
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
                                            choice = "0";
                                            Thread.Sleep(200);
                                            Console.Clear();
                                            break;
                                        }
                                        if (choice == "2")
                                        {
                                            choice = "0";
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
                                    Thread.Sleep(1000);
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
                        Console.Clear();
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
                            while (!leave)
                            {
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("How many souls would you like to bet?");
                                        Console.WriteLine("You currently have " + wallet + " fragmented souls on hand");
                                        if (hasLoan)
                                        {
                                            Console.WriteLine("And an active loan of " + loan + " souls with a time of " + loanTime + " left");
                                        }
                                        bet = Convert.ToInt32(Console.ReadLine());
                                        break;
                                    }
                                    catch
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("'You know you can only bet souls, right?'");
                                    }
                                }
                                if (bet > 0 && bet <= wallet)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("'You have successfully made a bet of " + bet + " fragmented souls'");
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("'Initiate the spin, my lucky fellow'");
                                        // The first wheel spin
                                        // Checking if user has drank and applying bonuses
                                        if (drunkTime > 0)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("You feel slightly tipsy, and slighty lucky");
                                            if (betBlack)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (!black.Contains(randNum))
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (betRed)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (!red.Contains(randNum))
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (odd)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (randNum % 2 == 0)
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (even)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (randNum % 2 != 0)
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (green)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (randNum != 0)
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (single)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (betNum != randNum)
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            randNum = rand.Next(0, 37);
                                        }
                                        if (red.Contains(randNum))
                                        {
                                            rColor = "red";
                                            rouletteNum = randNum;
                                        }
                                        else if (randNum == 0)
                                        {
                                            rColor = "green";
                                            rouletteNum = 0;
                                        }
                                        else
                                        {
                                            rColor = "black";
                                            rouletteNum = randNum;
                                        }

                                        // The second wheel spin
                                        if (drunkTime > 0)
                                        {
                                            drunkTime -= 1;
                                            if (betBlack)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (!black.Contains(randNum))
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (betRed)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (!red.Contains(randNum))
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (odd)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (randNum % 2 == 0)
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (even)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (randNum % 2 != 0)
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (green)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (randNum != 0)
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                            else if (single)
                                            {
                                                randNum = rand.Next(0, 37);
                                                if (betNum != randNum)
                                                {
                                                    randNum = rand.Next(0, 37);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            randNum = rand.Next(0, 37);
                                        }
                                        if (red.Contains(randNum))
                                        {
                                            rColor2 = "red";
                                            rouletteNum2 = randNum;
                                        }
                                        else if (randNum == 0)
                                        {
                                            rColor2 = "green";
                                            rouletteNum2 = 0;
                                        }
                                        else
                                        {
                                            rColor2 = "black";
                                            rouletteNum2 = randNum;
                                        }
                                        Console.WriteLine();
                                        Console.ReadKey();
                                        Console.Write("Spinning");
                                        Thread.Sleep(500);
                                        Console.Write(".");
                                        Thread.Sleep(500);
                                        Console.Write(".");
                                        Thread.Sleep(500);
                                        Console.WriteLine(".");
                                        Thread.Sleep(500);
                                        Console.WriteLine(rouletteNum);
                                        Console.WriteLine(rColor);
                                        Console.WriteLine();
                                        Thread.Sleep(1000);
                                        Console.WriteLine("And");
                                        Thread.Sleep(1000);
                                        Console.WriteLine();
                                        Console.WriteLine(rouletteNum2);
                                        Console.WriteLine(rColor2);
                                        Thread.Sleep(1000);

                                        // Checking what user has bet on
                                        if (even)
                                        {
                                            if (rouletteNum % 2 == 0 && rouletteNum != 0 && rouletteNum2 % 2 == 0 && rouletteNum2 != 0)
                                            {
                                                win = true;
                                                mult = evenMult * evenMult;
                                            }
                                        }
                                        else if (odd)
                                        {
                                            if (rouletteNum % 2 != 0 && rouletteNum != 0 && rouletteNum2 % 2 != 0 && rouletteNum2 != 0)
                                            {
                                                win = true;
                                                mult = oddMult * oddMult;
                                            }

                                        }
                                        else if (betRed)
                                        {
                                            if (rColor == "red" && rColor2 == "red")
                                            {
                                                win = true;
                                                mult = redMult * redMult;
                                            }
                                        }
                                        else if (betBlack)
                                        {
                                            if (rColor == "black" && rColor2 == "black")
                                            {
                                                win = true;
                                                mult = blackMult * blackMult;
                                            }
                                        }
                                        else if (single)
                                        {
                                            if (betNum == rouletteNum && betNum == rouletteNum2)
                                            {
                                                win = true;
                                                mult = numMult * numMult;
                                            }
                                        }
                                        else if (green)
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
                                            payTotal += payOut;
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("You lose!");
                                            Console.WriteLine("You have lost " + bet + " fragmented souls");
                                            Console.WriteLine();
                                            wallet -= bet;
                                            lossTotal += bet;
                                        }

                                        if (hasLoan)
                                        {
                                            loanTime -= 1;
                                            loan += loan / 20;
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

                                        if (wallet <= 0 || loanTime < 0)
                                        {
                                            Console.WriteLine("You suddenly feel the ground under your feet getting softer");
                                            Console.WriteLine("Before you realize you are sinking under the ground, and any resistance would be futile");
                                            Thread.Sleep(3000);
                                            leave = true;
                                            continue;
                                        }

                                        Console.WriteLine("'Would you like to play again?'");
                                        Console.WriteLine();
                                        Console.WriteLine("You currently have " + wallet + " fragmented souls on hand");
                                        if (hasLoan)
                                        {
                                            Console.WriteLine("And an active loan of " + loan + " souls with a time of " + loanTime + " left");
                                        }
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
                                            choice = "0";
                                            Console.Clear();
                                            break;
                                        }
                                        if (choice == "2")
                                        {
                                            choice = "0";
                                            leave = true;
                                        }
                                    }
                                }
                                else if (bet == 0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("You regret your decisions last minute and leave");
                                    Console.WriteLine();
                                    Console.WriteLine("You coward");
                                    Thread.Sleep(1000);
                                    leave = true;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("'You do know that this is an impossible amount considering your current balance, right?'");
                                    Console.WriteLine();
                                }
                            }
                            if (choice == "3")
                            {
                                Console.WriteLine();
                                Console.WriteLine("You coward");
                                Console.WriteLine();
                                Thread.Sleep(1000);
                                leave = true;
                            }

                        }
                    }
                    if (choice == "3")
                    {
                        Console.WriteLine();
                        Console.WriteLine("You coward");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        choice = "0";
                        leave = true;
                    }
                }
            }
            else if (choice == "2")
            {
                choice = "0";
                leave = true;
            }
        }
    }
    leave = false;
    // Account managing
    if (choice == "2")
    {
        Console.Clear();
        Console.WriteLine("A beast with an unnerving stare stands besides the sign reading 'Accounts and loans'");
        Console.WriteLine("Without blinking once the creature starts looking at you and stares for a couple seconds");
        Console.WriteLine("Suddenly the eyes snap to a point behind you, and its mouth starts moving");
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
            Console.Clear();

            while (!leave)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("'How much would you like to deposit?'");
                    bankInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("'You know you can only deposit souls, right?'");
                    continue;
                }
                if (bankInput > 0 && bankInput <= wallet)
                {
                    wallet -= bankInput;
                    account += bankInput;
                    Console.WriteLine();
                    Console.WriteLine("'You have successfully made a deposit of " + bankInput + " fragmented souls'");
                    Thread.Sleep(1000);
                    break;
                }
                else if (bankInput == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("You regret your decisions last minute and leave");
                    leave = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("'You do know that this is an impossible amount considering your current balance, right?'");
                }
            }
        }
        else if (choice == "2")
        {
            Console.Clear();

            while (!leave)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("'How much would you like to withdraw?'");
                    bankInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("'You know you can only withdraw souls, right?'");
                    continue;
                }
                if (bankInput > 0 && bankInput <= account)
                {
                    wallet += bankInput;
                    account -= bankInput;
                    Console.WriteLine();
                    Console.WriteLine("'You have successfully made a withrawal of " + bankInput + " fragmented souls'");
                    Thread.Sleep(1000);
                    break;
                }
                else if (bankInput == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("You regret your decisions last minute and leave");
                    leave = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("'You do know that this is an impossible amount considering your current balance, right?'");
                }
            }
        }
        if (choice == "3")
        {
            choice = "0";
            Console.Clear();
            while (!leave)
            {
                Console.WriteLine("Loans are a mechanic meant to help you if you're ever in the situation of almost going bankrupt");
                Console.WriteLine("You pay off your loans here, and the loans only last the set amount of time given on them");
                Console.WriteLine("If you pay your loan off before the due time you only need to pay what the loan has amounted to then");
                Console.WriteLine("But be wary, if you don't pay them off in time you will be punished for it, and harshly at that");
                while (!leave)
                {
                    Console.WriteLine();
                    Console.WriteLine("'Which loan do you want?'");
                    Console.WriteLine();
                    Console.WriteLine("1. 100 souls, + 5% interest for every roulette game, up to 5 games");
                    Console.WriteLine("2. 150 souls, + 5% interest for every roulette game, up to 6 games");
                    Console.WriteLine("3. 200 souls, + 5% interest for every roulette game, up to 7 games");
                    Console.WriteLine("4. Pay your current loan of " + loan + " back");
                    Console.WriteLine("5. Go back");
                    while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
                    {
                        choice = Console.ReadLine();
                        if (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
                        {
                            Console.WriteLine(deny);
                        }
                    }
                    if (choice == "1" || choice == "2" || choice == "3")
                    {
                        if (hasLoan)
                        {
                        choice = "0";
                        Console.WriteLine("You already have a loan");
                        Thread.Sleep(1000);
                        leave = true;
                        }
                    }
                    if (choice == "1" && !hasLoan)
                    {
                        choice = "0";
                        hasLoan = true;
                        loan = 100;
                        loanTime = 5;
                        Console.WriteLine();
                        Console.WriteLine("You've successfully made a loan of " + loan + " fragmented souls");
                        wallet += loan;
                        Console.WriteLine("You now have " + wallet + " souls on hand");
                        Console.WriteLine("You return to the lobby with some anxiety");
                        Thread.Sleep(3000);
                        leave = true;
                    }
                    else if (choice == "2" && !hasLoan)
                    {
                        choice = "0";
                        hasLoan = true;
                        loan = 150;
                        loanTime = 6;
                        Console.WriteLine();
                        Console.WriteLine("You've successfully made a loan of " + loan + " fragmented souls");
                        wallet += loan;
                        Console.WriteLine("You now have " + wallet + " souls on hand");
                        Console.WriteLine("You return to the lobby with some anxiety");
                        Thread.Sleep(3000);
                        leave = true;
                    }
                    else if (choice == "3" && !hasLoan)
                    {
                        choice = "0";
                        hasLoan = true;
                        loan = 200;
                        loanTime = 7;
                        Console.WriteLine();
                        Console.WriteLine("You've successfully made a loan of " + loan + " fragmented souls");
                        wallet += loan;
                        Console.WriteLine("You now have " + wallet + " souls on hand");
                        Console.WriteLine("You return to the lobby with some anxiety");
                        Thread.Sleep(3000);
                        leave = true;
                    }
                    else if (choice == "4")
                    {
                        choice = "0";
                        if (hasLoan)
                        {
                            if(wallet > loan)
                            {
                                wallet -= loan;
                                hasLoan = false;
                                leave = true;
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough money on hand to pay off your loan");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You currently don't have an active loan");
                            continue;
                        }
                    }
                }
            }
        }
        if (choice == "4")
        {
            choice = "0";
            Console.WriteLine("You return back to the lobby");
            leave = true;
        }
    }
    leave = false;
    // The bar
    if (choice == "3")
    {
        Console.Clear();

        Console.WriteLine("A crazed demon stands at the neat looking minibar in the middle of the casino");
        Console.WriteLine();
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
                    Console.Clear();

                    choice = "0";
                    Console.WriteLine("His chilling face starts turning and twisting into a wicked smile");
                    Console.WriteLine();
                    Console.WriteLine("'So, what can I get for you?'");
                    Console.WriteLine("You currently have " + wallet + " fragmented souls on hand");
                    while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6")
                    {
                        Console.WriteLine();
                        Console.WriteLine("1. Boiled blood, 3 souls");
                        Console.WriteLine("2. Marrow margarita, 5 souls");
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
                        Console.Clear();

                        choice = "0";
                        if (wallet > 3)
                        {
                            Console.WriteLine("'Coming right up!'");
                            Console.WriteLine();
                            wallet -= 3;
                            Console.WriteLine("In a flurry of different bottles and ice cubes, the demon shakes up a vicious cocktail sporting a deep red color with lines of black inside");
                            Console.WriteLine("'I hope you enjoy it!' He says with a deeply unsetteling smile");
                            Thread.Sleep(500);
                            Console.WriteLine("...");
                            Thread.Sleep(500);
                            Console.WriteLine("Tastes like iron");
                            if (drunkTime < 1)
                            {
                                drunkTime = 1;
                            }
                        }
                    }
                    else if (choice == "2")
                    {
                        Console.Clear();

                        choice = "0";
                        if (wallet > 5)
                        {
                            Console.WriteLine("'Coming right up!'");
                            Console.WriteLine();
                            wallet -= 5;
                            Console.WriteLine("In a flurry of different bottles and ice cubes, the demon shakes up a abominable drink with a pinkish red blend of colors");
                            Console.WriteLine("'I hope you enjoy it!' He says with a deeply unsetteling smile");
                            Thread.Sleep(500);
                            Console.WriteLine("...");
                            Thread.Sleep(500);
                            Console.WriteLine("Yum, strawberries");
                            if (drunkTime < 2)
                            {
                                drunkTime = 2;
                            }
                        }
                    }
                    else if (choice == "3")
                    {
                        Console.Clear();

                        choice = "0";
                        if (wallet > 10)
                        {
                            Console.WriteLine("'Coming right up!'");
                            Console.WriteLine();
                            wallet -= 10;
                            Console.WriteLine("In a flurry of different bottles and ice cubes, the demon shakes up a vomit green colored drink with a horrible smell");
                            Console.WriteLine("'I hope you enjoy it!' He says with a deeply unsetteling smile");
                            Thread.Sleep(500);
                            Console.WriteLine("...");
                            Thread.Sleep(500);
                            Console.WriteLine("Yuck, thick with lumps");
                            if (drunkTime < 4)
                            {
                                drunkTime = 4;
                            }
                        }
                    }
                    else if (choice == "4")
                    {
                        Console.Clear();

                        choice = "0";
                        if (wallet > 20)
                        {
                            Console.WriteLine("'Coming right up!'");
                            Console.WriteLine();
                            wallet -= 20;
                            Console.WriteLine("In a flurry of different bottles and ice cubes, the demon pours up a tiny amount of what looks like liquid mercury in a shotglass");
                            Console.WriteLine("'I hope you enjoy it!' He says with a deeply unsetteling smile");
                            Thread.Sleep(500);
                            Console.WriteLine("...");
                            Thread.Sleep(500);
                            Console.WriteLine("At least it cleared my headache");
                            if(drunkTime < 8)
                            {
                            drunkTime = 8;
                            }
                        }
                    }
                    else if (choice == "5")
                    {
                        Console.Clear();

                        choice = "0";
                        if (wallet > 50)
                        {
                            Console.WriteLine("'Coming right up!'");
                            Console.WriteLine();
                            wallet -= 50;
                            Console.WriteLine("In a flurry of different bottles and ice cubes, the demon shakes up a highly attractive mix between blue and purple");
                            Console.WriteLine("Just looking at it gives you chills");
                            Console.WriteLine("'I hope you enjoy it!' He says with a deeply unsetteling smile");
                            Thread.Sleep(500);
                            Console.WriteLine("...");
                            Thread.Sleep(500);
                            Console.WriteLine("Minty fresh breath");
                            if (drunkTime < 20)
                            {
                                drunkTime = 20;
                            }
                        }
                    }
                    else if (choice == "6")
                    {
                        Console.Clear();

                        choice = "0";
                        if (wallet > 0)
                        {
                            Console.WriteLine("With a face of disappointment, the demon grabs a bottle of water from a small freezer in the corner and gives it to you");
                            Thread.Sleep(500);
                            Console.WriteLine("...");
                            Thread.Sleep(500);
                            Console.WriteLine("Refreshing");
                        }
                    }
                    break;

                }
                else if (choice == "2")
                {
                    choice = "0";
                    Console.WriteLine();
                    Console.WriteLine("In a moment of clarity, you decide that this is not the best course of action for the situation you're in");
                    Console.WriteLine();
                    leave = true;
                }
                else if (choice == "3")
                {
                    // Choosing tips to tell to the user
                    choice = "0";
                    randNum = rand.Next(0, gossip.Length);
                    Console.WriteLine("His small pupils start dotting around the room");
                    Console.WriteLine();
                    Console.WriteLine("'" + gossip[randNum] + "'");
                    Console.WriteLine();
                    randNum = -1;
                    break;
                }
            }
        }
    }
    sum = account + wallet;
    // Ending game if end conditions are met
    if (sum <= 0 || loanTime < 0)
    {
        bankrupt = true;
        break;
    }
    if (sum >= 10000 && !hasLoan)
    {
        break;
    }
}
Console.Clear();
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
// Game stats
Console.WriteLine();
Console.WriteLine("You won a total of " + payTotal + " souls and lost a total of " + lossTotal + " souls");