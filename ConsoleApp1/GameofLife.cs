using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class GameofLife
    {
        private int[,] array;
        private int[,] tmp;
        private int counter;
        public GameofLife(int size)
        {
        array = new int[size, size];
        tmp = new int[size, size];
        counter = 0;
            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    array[i, j] = rnd.Next(0, 2);
                }
            }
        }

        public void displayBoard()
        {
            for (int i = 0; i < tmp.GetLength(0); ++i)
            {
                for (int j = 0; j < tmp.GetLength(1); ++j)
                {
                    if(array[i,j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    System.Console.Write(array[i, j]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.Write(" ");

                }
                System.Console.WriteLine();

            }
        }

        public void DropTheResult()
        {
            int counter = 0;
            for (int i = 0; i < array.GetLength(0); ++i)   //dla kazdego elementu tablicy
            {    
                for (int j = 0; j < array.GetLength(1); ++j)     //dla kazdego elementu tablicy
                {
                    for (int x = i - 1; x <= i + 1; ++x)    //dla kazdego z osmiu sasiadow
                    {  
                        for (int z = j - 1; z <= j + 1; ++z)   //dla kazdego z osmiu sasiadow
                        {
                            if ((x >= 0 && z >= 0 && x < array.GetLength(0) && z < array.GetLength(1)))  //warunki brzegowe
                            {
                                if (!(x == i && z == j))  //zeby nie liczyc samego siebie jako sąsiada
                                {
                                    if (array[x, z] == 1)
                                        ++counter;
                                }                                
                            }                           
                        }
                    }

                    if ((counter < 2 || counter > 3) && array[i, j] == 1)
                        tmp[i, j] = 0;
                    if (counter < 4 && counter > 1 && array[i, j] == 1)
                        tmp[i, j] = 1;
                    if (counter == 3 && array[i, j] == 0)
                        tmp[i, j] = 1;
                    if (counter != 3 && array[i, j] == 0)
                        tmp[i, j] = 0;

                    counter = 0;
                }
            }           
        }

        public void updateChanges()
        {
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    array[i, j] = tmp[i, j];

                }
            }
        }

        public void runTheGame()
        {
            while (true)
            {
                this.displayBoard();
                //System.Threading.Thread.Sleep(20);
                System.Console.Write("Press ENTER to next generation...");
                System.Console.ReadLine();
                Console.Clear();

                this.DropTheResult();
                this.updateChanges();

            }
        }

    }
}
