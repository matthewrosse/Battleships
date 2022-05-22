using BattleshipsGameEngine.Entities;
using BattleshipsGameEngine.Enums;

namespace BattleshipsConsoleApp;

public class BattleshipsGame
{
    private static BattleshipsGame _instance;
    private Player[] _listOfPlayers = new Player[2];
    private bool _isGameEnded = false;
    private GameMode _gameMode;
    public byte BoardSize { get; } = 10;

    private BattleshipsGame(GameMode gameMode)
    {
        switch (gameMode)
        {
            case GameMode.HumanComputer:
                _listOfPlayers[0] = new HumanPlayer(10, 7, "Mateusz");
                _listOfPlayers[1] = new ComputerPlayer(BoardSize, 7);
                break;
            case GameMode.TwoHumans:
                _listOfPlayers[0] = new HumanPlayer(10, 7, "Mateusz");
                _listOfPlayers[1] = new HumanPlayer(10, 7, "Krystian");
                break;
            default:
                throw new ArgumentException("Invalid game mode!");
        }

        _gameMode = gameMode;
        for (int i = 0; i < _listOfPlayers.Length; i++)
        {
            _listOfPlayers[i].PlaceShipsRandomly();
        }
    }


    public static BattleshipsGame GetInstance(GameMode gameMode)
    {
        return _instance ?? (_instance = new BattleshipsGame(gameMode));
    }

    public void StartGame()
    {
        (byte x, byte y)? target;

        while (!_isGameEnded)
        {
            for (int i = 0; i < _listOfPlayers.Length; i++)
            {
                Console.Clear();
                _printFleetAndHits(_listOfPlayers[i]);
                Console.WriteLine();
                Console.WriteLine();

                byte x, y;
                do
                {
                    x = 1;
                    y = 1;
                    if (_gameMode is GameMode.HumanComputer && i == 0 || _gameMode is GameMode.TwoHumans)
                    {
                        Console.WriteLine("Coords:");
                        string[] coords = Console.ReadLine().Trim().Split(',');
                        x = byte.Parse(coords[0]);
                        y = byte.Parse(coords[1]);
                    }

                    target = _listOfPlayers[i].Shoot(x, y);
                } while (target is null);

                _listOfPlayers[i].Hits[target.Value.x, target.Value.y] = _listOfPlayers[1 - i].Fleet.MarkShot(target.Value.x, target.Value.y);
                _listOfPlayers[1 - i].Fleet.ExecuteShot(target.Value.x, target.Value.y);

                if (_listOfPlayers[1 - i].AreAllShipsSunk())
                {
                    Console.WriteLine($"{_listOfPlayers[i].Name} has won!");
                    return;
                }
            }
        }
    }

    private void _printFleetAndHits(Player player)
    {
        Console.WriteLine($"Fleet: {player.Name}");
        PrintFleet(player);
        Console.WriteLine($"Hits: {player.Name}");
        PrintHits(player);
    }

    public void PrintFleet(Player player)
    {
        // getLength + 1, bo ABC i 123...
        Console.Write("[+]");
        for (int i = 0; i < player.Fleet.BoardCells.GetLength(0) + 1; i++)
        {
            for (int j = 0; j < player.Fleet.BoardCells.GetLength(1) + 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;
                else if (i == 0 && j != 0)
                    Console.Write($"[{j - 1}]");
                else if (i != 0 && j == 0)
                    Console.Write($"[{i - 1}]"); // jak i == 1, to i + 64 = 'A' w ascii.
                else
                {
                    switch (player.Fleet.BoardCells[i - 1, j - 1].CellStatus)
                    {
                        case BoardCellStatus.Present:
                        {
                            ConsoleColor currentColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("[X]");
                            Console.ForegroundColor = currentColor;
                            break;
                        }
                        case BoardCellStatus.Empty:
                        {
                            ConsoleColor currentColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("[~]");
                            Console.ForegroundColor = currentColor;
                            break;
                        }
                        case BoardCellStatus.Hit:
                        {
                            ConsoleColor currentColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[*]");
                            Console.ForegroundColor = currentColor;
                            break;
                        }
                        case BoardCellStatus.Miss:
                        {
                            ConsoleColor currentColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("[_]");
                            Console.ForegroundColor = currentColor;
                            break;
                        }
                        case BoardCellStatus.Occupied:
                        {
                            ConsoleColor currentColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("[#]");
                            Console.ForegroundColor = currentColor;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine();
        }
    }

    public void PrintHits(Player player)
    {
        // getLength + 1, bo ABC i 123...
        Console.Write("[+]");
        for (int i = 0; i < player.Hits.BoardCells.GetLength(0) + 1; i++)
        {
            for (int j = 0; j < player.Hits.BoardCells.GetLength(1) + 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;
                else if (i == 0 && j != 0)
                    Console.Write($"[{j - 1}]");
                else if (i != 0 && j == 0)
                    Console.Write($"[{i - 1}]"); // jak i == 1, to i + 64 = 'A' w ascii.
                else
                {
                    switch (player.Hits.BoardCells[i - 1, j - 1].CellStatus)
                    {
                        case BoardCellStatus.Present:
                        {
                            ConsoleColor currentColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("[X]");
                            Console.ForegroundColor = currentColor;
                            break;
                        }
                        case BoardCellStatus.Empty:
                        {
                            ConsoleColor currentColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("[~]");
                            Console.ForegroundColor = currentColor;
                            break;
                        }
                        case BoardCellStatus.Hit:
                        {
                            ConsoleColor currentColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[*]");
                            Console.ForegroundColor = currentColor;
                            break;
                        }
                        case BoardCellStatus.Miss:
                        {
                            ConsoleColor currentColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("[_]");
                            Console.ForegroundColor = currentColor;
                            break;
                        }
                        case BoardCellStatus.Occupied:
                        {
                            ConsoleColor currentColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("[#]");
                            Console.ForegroundColor = currentColor;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine();
        }
    }
}