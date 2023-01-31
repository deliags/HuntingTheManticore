internal class Program
{
    private static void Main(string[] args)
    {
        int cityHealth = 15, shipHealth = 10;
        int shipPosition = StartManticoreTurn();
        int turnCount = 0;

        Console.Write("\nPlayer 2, it is your turn.\n -------------------------------------");

        while (cityHealth > 0 && shipHealth > 0)
        {
            turnCount++;
            WriteTurnInfo(turnCount, cityHealth, shipHealth); // Displays the turn number, city and ship health

            // Apply damage to city every round
            cityHealth = ApplyDamage(1, cityHealth);

            Console.Write("\nEnter desired cannon range: ");
            int userTwoGuess = Convert.ToInt32(Console.ReadLine());

            CompareGuess(userTwoGuess, shipPosition); // gives feedback to user about their guess
        }


        // Display the outcome of the game.
        bool won = cityHealth > 0;
        DisplayWinOrLose(won);

        // ------------------------------- METHODS --------------------------------

        // Displays the result of the game.
        void DisplayWinOrLose(bool won)
        {
            if (won)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nThe Manticore has been destroyed! The city of Consolas has been saved!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe city has been destroyed. The Manticore and the Uncoded One have won.");
            }
        }

        int StartManticoreTurn()
        {
            Console.Write("\nPlayer 1: How far away from the city do you want to station the Manticore? ");
            int shipDistance = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return shipDistance;
        }

        void WriteTurnInfo(int turnCount, int currentCityHP, int currentShipHP)
        {
            Console.Write($"\nSTATUS: Round: {turnCount}  City: {currentCityHP}/15  Manticore: {currentShipHP}/10.");
        }

        int CalculateDamage(int turnCount)
        {
            int damage = 0;
            if (turnCount % 3 == 0 && turnCount % 5 == 0) damage = 10;
            else if (turnCount % 3 == 0 || turnCount % 5 == 0) damage = 3;
            else damage = 1;
            Console.Write($"The cannon is expected to deal {damage} this round.");
            return damage;
        }

        int ApplyDamage(int damage, int health)
        {
            int remainingHealth = health - damage;
            return remainingHealth;
        }

        void CompareGuess(int guess, int position)
        {
            if (guess == position)
            {
                int damage = CalculateDamage(turnCount);  // calculates the city damage based on the turn number
                shipHealth = ApplyDamage(damage, shipHealth); // applies the damage to the Manticore
                Console.Write("\nThe round was a DIRECT HIT.");
            }
            else if (guess > position) Console.Write("\nThe round OVERSHOT the target.");
            else Console.Write("\nThe round FEEL SHORT the target.");
        }

    }
}