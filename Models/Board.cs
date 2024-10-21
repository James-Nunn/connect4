using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace CSharp.Models;
public class Board
{
    private readonly List<string> _board;
    const char emptyPiece = '-';
    public string edge = "|";
    const int boardSize = 8;

    public Board()
    {
        _board = NewCleanBoard();
    }

    public Board(List<string> board)
    {
        _board = board;
    }

    public List<string> GetBoard()
    {
        return _board;
    }

    private static List<string> NewCleanBoard()
    {
        List<string> board = [];

        for (int i = 0; i < boardSize; i++)
        {
            var row = new char[boardSize];
            for (int j = 0; j < boardSize; j++)
            {
                row[j] = emptyPiece;
            }
            board.Add(new string(row));
        }
        return board;
    }

    public bool IsColumnFull(int column)
    {
        column--;
        if (_board[column].Contains(emptyPiece))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool CheckWin(char playerPiece)
    {
        // Check horizontal
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col <= boardSize - 4; col++)
            {
                if (_board[row][col] == playerPiece &&
                    _board[row][col + 1] == playerPiece &&
                    _board[row][col + 2] == playerPiece &&
                    _board[row][col + 3] == playerPiece)
                {
                    return true;
                }
            }
        }

        // Check vertical
        for (int col = 0; col < boardSize; col++)
        {
            for (int row = 0; row <= boardSize - 4; row++)
            {
                if (_board[row][col] == playerPiece &&
                    _board[row + 1][col] == playerPiece &&
                    _board[row + 2][col] == playerPiece &&
                    _board[row + 3][col] == playerPiece)
                {
                    return true;
                }
            }
        }

        // Check diagonal (top-left to bottom-right)
        for (int row = 0; row <= boardSize - 4; row++)
        {
            for (int col = 0; col <= boardSize - 4; col++)
            {
                if (_board[row][col] == playerPiece &&
                    _board[row + 1][col + 1] == playerPiece &&
                    _board[row + 2][col + 2] == playerPiece &&
                    _board[row + 3][col + 3] == playerPiece)
                {
                    return true;
                }
            }
        }

        // Check diagonal (bottom-left to top-right)
        for (int row = 3; row < boardSize; row++)
        {
            for (int col = 0; col <= boardSize - 4; col++)
            {
                if (_board[row][col] == playerPiece &&
                    _board[row - 1][col + 1] == playerPiece &&
                    _board[row - 2][col + 2] == playerPiece &&
                    _board[row - 3][col + 3] == playerPiece)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void AddPiece(int column, char piece)
    {
        column--;
        int index = FindBottom(_board[column]);
        string before = _board[column][..index++];
        string after = _board[column][index..];
        string newColumn = before + piece + after;
        _board[column] = newColumn;

    }

    private static int FindBottom(string column)
    {
        for (int i = 0; i < boardSize; i++)
        {
            if (column[i] != emptyPiece)
            {
                return i - 1;
            }
        }
        return 7;
    }
}


