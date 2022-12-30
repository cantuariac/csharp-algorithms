using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PathFinding
{
    class GrayScale12
    {
        static ConsoleColor[] colorScale = { ConsoleColor.DarkGray, ConsoleColor.Gray, ConsoleColor.White };
        static string[] fillScale = { "░░", "▒▒", "▓▓", "██" };
        static public void PrintPixel(short value)
        {
            if (value == 0)
            {
                Console.Write("  ");
            }
            else
            {
                var color = (value - 1) % colorScale.Length;
                var fill = (value - 1) / colorScale.Length;
                Console.ForegroundColor = colorScale[color];
                Console.Write(fillScale[fill]);

            }
        }
    }
    enum Surface
    {
        Obstacle, ShallowWater, DeepWater, Vegetation, Grass, Path, Paved
    }
    readonly struct Dimensions
    {
        public short Length { get; init; }
        public short Width { get; init; }
        public Dimensions(short length, short widht) => (Length, Width) = (length, widht);
    }

    internal class GridMap
    {
        public Dimensions Dimensions { get; }
        public short[] Height { get; set; }
        public Surface[,] Surface { get; set; }

        [JsonConstructorAttribute]
        public GridMap(Dimensions dimensions, short[] height)
        {
            if (height.Length != dimensions.Length * dimensions.Width)
            {
                throw new ArgumentException("Dimensions do not match height map array's length");
            }
            Dimensions = dimensions;
            Height = height;
        }
        public GridMap(short length, short width)
        {
            Dimensions = new Dimensions(length, width);
            Height = new short[length * width];
        }

        public short HeightAt(short x, short y)
        {
            if (x < 0 || x > Dimensions.Length || y < 0 || y > Dimensions.Width)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }
            return Height[x * Dimensions.Length + y];
        }

        public void Print()
        {
            for (short i = 0; i < Dimensions.Length; i++)
            {
                for (short j = 0; j < Dimensions.Width; j++)
                {
                    GrayScale12.PrintPixel(HeightAt(i, j));
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }

}
