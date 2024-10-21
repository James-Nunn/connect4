using System.Diagnostics;
using System.Net;
using CSharp.Models;

namespace CSharp.Views;
public class GameView
{
    public GameView() { }
    public void DisplayBoard(Board board)
    {
        List<string> list = board.GetBoard();
        for (int i = 0; i < list.Count; i++)
        {
            foreach (string row in list)
            {
                Console.Write(board.edge + row[i]);
            }
            Console.WriteLine('|');
        }
        Console.WriteLine(" 1 2 3 4 5 6 7 8 ");
    }

    public void TurnMessage(char playerPiece)
    {
        Console.WriteLine($"{playerPiece}'s turn. Enter a digit from 1-8 to add piece:");
    }

    public void FullMessage(int column)
    {
        Console.WriteLine($"Column {column} is full. Try again");
    }

    public void WinMessage(char playerPiece)
    {
        Console.WriteLine($"{playerPiece} Wins. Congratulations");
    }

    public void PlayAgainMessage()
    {
        Console.WriteLine("Play again? Enter ('y' or 'n'):");
    }

    public void ErrorMessage()
    {
        Console.WriteLine("Invalid Command. Enter a single digit from 1-8. eg. '8'");
    }
}
