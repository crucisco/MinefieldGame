using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CrucisCo.MinefieldGame
{
    internal class GameConsole
    {
        private const string MineChar = "* ";
        private const string PlayerChar = "P ";
        private const string SafeSpaceChar = "- ";


        private readonly Minefield _minefield;
        private readonly Player _player;
        private readonly List<Mine> _mines;
        private int _numMoves;
        private readonly int _mineCount;

        public GameConsole(GameSettings gameSettings)
        {
            _minefield = new Minefield(gameSettings.MinefieldSize, gameSettings.NumberOfMines);
            _player = new Player(0, 0, gameSettings.PlayerLives, gameSettings.MinefieldSize);
            _mines = new List<Mine>();
            _numMoves = 0;

            _mineCount = gameSettings.NumberOfMines;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Minefield Game!");
            Console.WriteLine("Use the arrow keys to move (UP, DOWN, LEFT, RIGHT).");
            Console.WriteLine("Avoid the mines and cross from the left side to the right side of the minefield.");
            Console.WriteLine();
            Console.WriteLine($"There are {_mineCount} mines in a grid {_minefield.Size}x{_minefield.Size}. You have {_player.Lives} lives!!");
            Console.WriteLine("Press any key to play...");
            Console.ReadKey(false);

            // Main game loop
            while (_player.PosX < _minefield.Size - 1)
            {
                DrawMinefield(false);
                ProcessInput();
                UpdateGameState();
            }

            // Game over
            DrawMinefield(true);
            Console.WriteLine("Congratulations! You made it to the other side!");
            Console.WriteLine($"Final score: {_numMoves} moves taken.");

            //TODO: Would be good to ask if the player want to reset the game and go again instead of exiting.
        }

        private void DrawMinefield(bool showMines)
        {
            Console.Clear();

            Console.WriteLine($"Lives: {_player.Lives}  Moves: {_numMoves}");
            Console.WriteLine();
            for (int y = 0; y < _minefield.Size; y++)
            {
                for (int x = 0; x < _minefield.Size; x++)
                {
                    if (_player.PosX == x && _player.PosY == y)
                    {
                        Console.Write(PlayerChar);
                    }
                    else if (showMines && _minefield.IsMineAt(x, y))
                    {
                        Console.Write(MineChar);
                    }
                    else
                    {
                        Console.Write(SafeSpaceChar);
                    }

                     
                    
                }
                Console.WriteLine();
            }
        }

        private void ProcessInput()
        {
            bool moved = false;

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    moved = _player.Move(Direction.Up);
                    break;
                case ConsoleKey.DownArrow:
                    moved = _player.Move(Direction.Down);
                    break;
                case ConsoleKey.LeftArrow:
                    moved = _player.Move(Direction.Left);
                    break;
                case ConsoleKey.RightArrow:
                    moved = _player.Move(Direction.Right);
                    break;
            }

            if (moved)
            {
                _numMoves++;
            }
        }

        private void UpdateGameState()
        {
            // Check for mine hit
            if (_minefield.IsMineAt(_player.PosX, _player.PosY))
            {
                _player.Lives--;

                // TODO: Replace the char - at the mine position with a * char on the board?

                if (_player.Lives <= 0)
                {
                    DrawMinefield(true);
                    Console.WriteLine();
                    Console.WriteLine("Game over! You hit a mine and have no lives left.");
                    Console.WriteLine($"Final score: {_numMoves} moves taken.");
                    Environment.Exit(0);

                    //TODO: Would be good to ask if the player want to reset the game and go again instead of exiting.
                }
                else
                {
                    Console.WriteLine("You hit a mine! Lose one life.");
                    _mines.Add(new Mine(_player.PosX, _player.PosY));
                }
            }
        }

    }
}
