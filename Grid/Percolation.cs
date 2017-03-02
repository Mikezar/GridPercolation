using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridPercolation
{
    public class Percolation
    {
        public static int size = 20;
        public static char _open = 'O';
        public static char _blocked = 'X';



        static void Main(string[] args)
        {
            bool[,] _grid;
            GridGenerator(out _grid);
            Display(_grid);
            Console.WriteLine(Percolate(_grid));
            Console.ReadLine();
        }

        // Randomly generate matrix filling it with boolean values
        private static bool[,] GridGenerator(out bool[,] _grid)
        {
            _grid = new bool[size, size];

            Random _random = new Random();
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {

                    _grid[i, j] = Convert.ToBoolean(_random.Next(0,3)); 
                }
            }

            return _grid;
        }

        // Display the matrix on Console. All the "true" values are replaced by "O" meaning 'open' compared to those of being false by "X" meaning "blocked'
        private static void Display(bool [,] _grid)
        {
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    if (_grid[i, j])
                    {
                        Console.Write(_open + " ");
                    }

                    else
                    {
                        Console.Write(_blocked + " ");
                    }
                }
                Console.WriteLine("\n");
            }
        }

        //Check one by one the last row values on whether there are any sites connected to top
        public static bool Percolate(bool [,] _open)
        {
            int n = _open.GetLength(0);
            bool[,] _full = GoThrough(_open);
            for (int j = 0; j < n; j++)
            {
                if (_full[n - 1,j]) return true;
            }
            return false;
        }

        //Create a new boolean array as a representation of existing one.  List the one-by-one columns on reaching the open sites.
        public static bool[,] GoThrough(bool [,] _open)
        {
            int n = _open.GetLength(0);
            bool [,] _full = new bool [n,n];
            for (int j = 0; j < n; j++)
            {
                GoThrough(_open, _full, 0, j);
            };
            return _full;
        }

        //Search for so-called full sites connected to an open site in the top row via a chain of neighboring (left, right, up, down) open sites.
        public static void GoThrough(bool[,] _open, bool[,] _full, int i, int j)
        {
            int n = _open.GetLength(0);

            if (i < 0 || i >= n) return;    // invalid row
            if (j < 0 || j >= n) return;    // invalid column
            if (!_open[i,j]) return;      // blocked site
            if (_full[i,j]) return;       // already marked as full

            // Mark as an open site
            _full[i,j] = true;

            //Searching for neighboring open sites (down/right/left)
            GoThrough(_open, _full, i + 1, j);
            GoThrough(_open, _full, i, j + 1);
            GoThrough(_open, _full, i, j - 1);   
        }

    }
}

