using System.ComponentModel;

namespace Julgran_Loopar
{
    internal class Program
    {
        static Random Rnd = new Random();
        static ConsoleColor[] Colors = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Magenta, ConsoleColor.Cyan };
        static void Main(string[] args)
        {


            //Generate tree with size 16
            var tree = GenerateTree(16, true);

            RenderTree(tree, 3, true);


            Console.ReadLine();
        }


        /// <param name="size">Bottom width of triangle</param>
        /// <param name="decorations">Include decorations</param>
        /// <returns></returns>
        static string[] GenerateTree(int size, bool decorations)
        {
            string[] rows = new string[size];

            int row = 0;
            for (int i = size; i > 0; i--)
            {
                for (int j = i; j > 0; j--)
                {
                    rows[row] += " ";
                }
                for (int j = i; j < size; j++)
                {
                    if (j == i)
                    {
                        rows[row] += "*";
                    }
                    else
                    {
                        if (decorations && Rnd.Next(5) == 2)
                        {
                            rows[row] += "O*";

                        }
                        else
                        {
                            rows[row] += "**";
                        }
                    }
                }
                row++;
            }
            return rows;
        }


        /// <param name="tree">string[] with the rows of the tree</param>
        /// <param name="levels">how many "triangles"</param>
        /// <param name="star">include top star</param>
        static void RenderTree(string[] tree, int levels, bool star)
        {
            if (star)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                var starRows = GenerateTree(tree.Length / 2, false);
                int xPos = tree.Length / 2;
                int yPos = 0;

                for (int i = 0; i < starRows.Length; i++)
                {
                    foreach (char c in starRows[i])
                    {
                        if (c == ' ')
                        {
                            xPos++;
                        }
                        else
                        {
                            Console.SetCursorPosition(xPos, yPos);
                            xPos++;
                            Console.Write(c);
                        }
                    }
                    xPos = tree.Length / 2;
                    yPos++;
                }
                xPos = tree.Length / 2;
                yPos = starRows.Length / 2;
                for (int i = starRows.Length - 1; i > 0; i--)
                {
                    foreach (char c in starRows[i])
                    {
                        if (c == ' ')
                        {
                            xPos++;
                        }
                        else
                        {
                            Console.SetCursorPosition(xPos, yPos);
                            xPos++;
                            Console.Write(c);
                        }
                    }
                    xPos = tree.Length / 2;
                    yPos++;
                }
            }


            int start = 0;
            for (int k = 0; k < levels; k++)
            {
                for (int i = start; i < tree.Length; i++)
                {

                    for (int j = 0; j < tree[i].Length; j++)
                    {
                        if (tree[i][j] == 'O')
                        {
                            Console.ForegroundColor = Colors[Rnd.Next(Colors.Length)];
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write(tree[i][j]);
                    }
                    Console.Write("\n");
                }
                if (k == 0)
                {
                    start += tree.Length/2;
                }
            }
        }
    }
}
