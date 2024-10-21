using CSharp.Controller;
class Program
{
    static void Main(string[] args)
    {
        GameController gameController = new();
        gameController.StartGame();
    }
}