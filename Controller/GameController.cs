using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using CSharp.Views;
using CSharp.Models;

namespace CSharp.Controller;
public class GameController
{
    private Board _board;
    private readonly GameView _gameView;
    private char _activePlayer;
    private const char _player1 = 'X';
    private const char _player2 = 'O';

    public GameController()
    {
        _board = new Board();
        _gameView = new GameView();
        _activePlayer = _player1;
    }

    public void StartGame()
    {
        bool gameFinished = false;
        while (gameFinished == false)
        {
            PlayTurn();
            if (_board.CheckWin(_activePlayer))
            {
                _gameView.DisplayBoard(_board);
                _gameView.WinMessage(_activePlayer);
                gameFinished = PlayAgain();
                _board = new Board();
            }
            TogglePlayer();
        }
    }

    private bool PlayAgain()
    {
        while (true)
        {
            _gameView.PlayAgainMessage();
            string? input = Console.ReadLine();
            if (input == "y")
            {
                return false;
            }
            else if (input == "n")
            {
                return true;
            }
        }
    }

    private void PlayTurn()
    {
        _gameView.DisplayBoard(_board);
        _gameView.TurnMessage(_activePlayer);
        int input = GetInput();
        _board.AddPiece(input, _activePlayer);
    }
    private int GetInput()
    {
        while (true)
        {
            try
            {
                string userInput = Console.ReadLine()!;
                int column = int.Parse(userInput);

                if (column < 0 || column > 8)
                {
                    _gameView.ErrorMessage();
                    continue;
                }
                if (_board.IsColumnFull(column))
                {
                    _gameView.FullMessage(column);
                }
                else
                {
                    return column;
                }
            }
            catch (FormatException)
            {
                _gameView.ErrorMessage();
            }
            catch (OverflowException)
            {
                _gameView.ErrorMessage();
            }
        }
    }

    private void TogglePlayer()
    {
        _activePlayer = (_activePlayer == _player1) ? _player2 : _player1;
    }
}