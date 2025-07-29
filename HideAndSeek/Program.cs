namespace HideAndSeek
{
    internal class Program
    {
        private string DescribeDirection(Direction d)
            {
                switch (d)
                {
                    case Direction.Up:
                        return "Up";
                    case Direction.Down:
                        return "Down";
                    case Direction.In:
                        return "In";
                    case Direction.Out:
                        return "Out";
                    default:
                        return $"to the {d}";
                }
            }
        static void Main(string[] args)
        {
            GameController gameController = new GameController();
            while (true)
            {
                Console.WriteLine(gameController.Status);
                Console.Write(gameController.Prompt);
                Console.WriteLine(gameController.ParseInput(Console.ReadLine()));
            }
            Console.WriteLine("Hello, World!");
        }
    }
}
