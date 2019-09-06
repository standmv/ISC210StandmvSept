using System;
using System.Threading;

namespace TicTacToe
{
    public enum GameState
    {
        Menu,
        Starting,
        Playing,
        Gameover
    }

    public class Game
    {
        public GameState CurrentState { get; set; }
        public char[,] Board { get; set; }
        public bool CurrentPlayer { get; set; }
    }

    class Program
    {
        const int LEFTMARGIN = 4;
        const int TOPMARGIN = 2;
        const int FPSTIME = 33;
        public static Game CurrentGame;
        static Thread _inputThread;
        
        public static void InitializeGame()
        {
            CurrentGame = new Game();
            CurrentGame.Board = new short[3, 3];
            CurrentGame.CurrentState = GameState.Menu;
            _inputThread = new Thread(GetInput);
            _inputThread.Start();
        }

        public static void Main(string[] args)
        {
            InitializeGame();
            while(CurrentGame.CurrentState != GameState.Gameover)
            {
                switch (CurrentGame.CurrentState)
                {
                    case GameState.Menu:
                        ShowMenu();
                        break;
                    case GameState.Starting:
                        ShowFrame(true);
                        break;
                    case GameState.Playing:
                        ShowFrame(false);
                        ShowBoard();
                        break;
                   
                }
                Thread.Sleep(FPSTIME);
            }
            FinalizeGame();
            Console.ReadKey();
        }

        static void ShowFrame(bool isStarting)
        {
            Console.Clear();
            Console.WriteLine("  7  |  8  |  9  ");

            Console.WriteLine("     |     |     ");

            Console.WriteLine("_____|_____|_____");

            Console.WriteLine("  4  |  5  |  6  ");

            Console.WriteLine("     |     |     ");

            Console.WriteLine("_____|_____|_____");

            Console.WriteLine("  1  |  2  |  3  ");

            Console.WriteLine("     |     |     ");

            Console.WriteLine("     |     |     ");
            //Console.WriteLine($"\n{(isStarting ? "Presione una tecla para empezar con el jugador 1." : ("Le toca al jugador " + CurrentGame.CurrentPlayer ? "dos. : "uno. ")))}");
            Console.Write("Seleccione una casilla [1-9]");
        }

        static void ShowBoard()
        {
            int _counter = 0;
            foreach(char currentPiece in CurrentGame.Board)
            {
                Console.SetCursorPosition(_counter % 3 * LEFTMARGIN, _counter / 3 * TOPMARGIN);
                Console.Write(currentPiece);

                _counter++;
            }
        }
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Hola! vamo a juga' tic tac toe...");
            Console.Write("\nSeleccione una opción:");
            Console.WriteLine("\n\t1: Jugar");
            Console.WriteLine("\t2: Salir");
            Console.WriteLine("\n\tSeleccione: ");
        }

        static void GetInput()
        {
            string _currentInput;
            int i, j;
            while (true)
            {
                switch (CurrentGame.CurrentState)
                {
                    case GameState.Menu:
                        _currentInput = Console.ReadKey().KeyChar.ToString();
                        CurrentGame.CurrentState = _currentInput == "1" ? GameState.Starting : GameState.Gameover;
                        break;
                    case GameState.Starting:
                        _currentInput = Console.ReadKey().KeyChar.ToString();
                        CurrentGame.CurrentState = GameState.Playing;
                        break;
                    case GameState.Playing:
                        _currentInput = Console.ReadKey().KeyChar.ToString();
                        i = 0;
                        j = (Convert.ToInt32(_currentInput) - 1) % 3;
                        CurrentGame.Board[0,j] = CurrentGame.CurrentPlayer ? 'O' : 'x';
                        break;
                }
            }
        }

        static void FinalizeGame()
        {
            _inputThread.Abort();
            _inputThread.Join();
        }

     
    }
}
