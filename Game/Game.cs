namespace NumberGuesser.Game
{
    class Game
    {
        private readonly Random _random = new Random();
        private int _randomNumber;
        private int _guessCount;
        private readonly int _maxNumber;

        public Game(int maxNumber)
        {
            _maxNumber = maxNumber;
        }

        public void Start()
        {
            do
            {
                GenerateRandomNumber();
                PlayGame();

                Console.Write("Play again? (Y/N): ");
            } while (Console.ReadLine().Trim().ToUpper() == "Y");
        }

        private void GenerateRandomNumber()
        {
            _randomNumber = _random.Next(1, _maxNumber + 1);
        }

        private void PlayGame()
        {
            _guessCount = 0;

            while (true)
            {
                Console.Write($"Make a guess (between 1 and {_maxNumber}): ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int guess) || guess < 1 || guess > _maxNumber)
                {
                    Console.WriteLine($"Invalid input. Please enter a number between 1 and {_maxNumber}.");
                    continue;
                }

                _guessCount++;

                if (guess == _randomNumber)
                {
                    Console.WriteLine($"Congratulations! You guessed the correct number ({_randomNumber})!");
                    Console.WriteLine($"It took you {_guessCount} guesses.");
                    break;
                }
                else if (guess < _randomNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else
                {
                    Console.WriteLine("Too high! Try again.");
                }
            }
        }
    }
}