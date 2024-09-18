
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
string choice = "";
int nChoice = 0;
bool bankrupt = false;
bool snakeEyes = false;
Random rand = new Random();

// The game
// Story and background
Console.WriteLine("Hello and welcome to the Lucifers casino!");
Console.WriteLine("You, who have bet your soul, are now in harsh debt");
Console.WriteLine("However, due to your unwavering tenacity, the lord has given you another chance");
Console.WriteLine("You have been locked to the roulette machines and are unable to free yourself");
Console.WriteLine("You have to gamble your way from 100 fragmented souls to 10000 fragmented souls");
Console.WriteLine("If you manage this you are to be let go and freed");
Console.WriteLine("However, if you are to fail, you shall repent for a thousand years");
Console.WriteLine();

// Game loop
while (!bankrupt)
{
    Console.WriteLine("A little imp bearing a luxurious tuxedo is situated at front the desk");
    Console.WriteLine("'Hello and welcome to Lucifers!'");
    Console.WriteLine("'What would you like to do?'");
    Console.WriteLine("You currently have " + wallet + " fragmented souls");
    Console.WriteLine();

    while (choice != "1" && choice != "2")
    {
        Console.WriteLine("1. Go to the roulette table");
        Console.WriteLine("2. Go to your bank account");
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
                    Console.WriteLine("There is no such choice");
                }
            }
            if(choice == "1")
            {
                // The roulette game
                Console.WriteLine("'You want to try your luck eh?'");
                while (true)
                {
                    Console.WriteLine();
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
        Console.WriteLine("'Welcome to the bank'");
        Console.WriteLine("'Would you like to make a deposit?'");
        Console.WriteLine();
        Console.WriteLine("1. Make a deposit");
        Console.WriteLine("2. Make a withdrawal");
        Console.WriteLine("3. Make a loan");
        Console.WriteLine("4. Go back");

    }
    if (wallet <= 0)
    {
        bankrupt = true;
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