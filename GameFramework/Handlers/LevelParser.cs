using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameFramework.Handlers
{
    public class LevelParser
    {
        public static string[,] ParseTxtFileToArray(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string firstLine = lines[0];
            int rows = lines.Length; // World Size X
            int cols = firstLine.Length; // World Size Y
            string[,] grid = new string[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                string line = lines[y];
                for (int x = 0; x < cols; x++)
                {
                    char currentChar = line[x];
                    grid[y, x] = currentChar.ToString();
                }
            }


            return grid;
        }
    }
}
