
// Roulette Specs
// A Roulette game in which the user can bet certain amount of money
// on either red or black, odd or even, a specific number or green
// The user should be able to deposit or withdraw their money in a bank outsid of the game
// If the user goes bankrupt or makes enough money they will be able to exit, or they can give up
// Snake eyes mode with chance for 10* profit
// Loans that the user can take if they are bankrupt or close to bankruptcy
// with interest of 5% for every turn and they have to be paid back within 5 turns
// and user can't exit with an active loan without filing for bankruptcy

int wallet = 100;
int bet = 0;
int account = 0;
int sum = 0;
string choice = "";
string deny = "There is no such choice";
int bankInput = 0;
bool bankrupt = false;
bool snakeEyes = false;
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
    choice = "0";
    Console.WriteLine("A little imp bearing a luxurious tuxedo is situated at front the desk");
    Console.WriteLine("'Hello and welcome to Lucifers!'");
    Console.WriteLine("'What would you like to do?'");
    Console.WriteLine("You currently have " + wallet + " fragmented souls on hand");
    Console.WriteLine("and " + account + " fragmented souls in your account");

    while (choice != "1" && choice != "2")
    {
        Console.WriteLine();
        Console.WriteLine("1. Go to the roulette table");
        Console.WriteLine("2. Go to account management");
        choice = Console.ReadLine();
        if (choice != "1" && choice != "2")
        {
            Console.WriteLine("There is no such choice");
        }
    }
    if (choice == "1")
    {
        Console.WriteLine("");
        Console.WriteLine("'Welcome to the roulette table'");
        while (true)
        {
            choice = "0";
            Console.WriteLine();
            Console.WriteLine("'What would you like to do?'");
            Console.WriteLine("You currently have " + wallet + " fragmented souls");
            Console.WriteLine();
            while(choice != "1" &&  choice != "2")
            {
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Go back");
                choice = Console.ReadLine();
                if(choice != "1" && choice != "2")
                {
                    Console.WriteLine(deny);
                }
            }
            if(choice == "1")
            {
                // The roulette game
                Console.WriteLine("'You want to try your luck eh?'");
                while (true)
                {
                    Console.WriteLine("'First of all, you should decide on what gamemode you want to play'");
                    Console.WriteLine("'We offer either normal mode, which is just usual roulette, or snakeeyes'");
                    Console.WriteLine("'In snakeyes you use 2 roulette wheels instead of 1, and if both come up to be true in line with your guess, your win is squared'");
                    Console.WriteLine();
                    Console.WriteLine("1. Normal");
                    Console.WriteLine("2. Snakeeyes");
                    Console.WriteLine("3. Leave");

                }
            }
            if(choice == "2")
            {
                Console.WriteLine();
                Console.WriteLine("You coward");
                Console.WriteLine();
                choice = "0";
                break;
            }
        }
    }
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
            if(choice != "1" && choice != "2" && choice != "3" && choice != "4")
            {
                Console.WriteLine(deny);
            }
        }
        if (choice == "1")
        {
            while (true)
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
                    break;
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
            while (true)
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
                    break;
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
            while (true)
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
        }

    }
    sum = account + wallet;
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