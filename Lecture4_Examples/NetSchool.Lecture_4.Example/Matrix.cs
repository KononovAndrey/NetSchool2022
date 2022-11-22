using System;

namespace NetSchool.Lecture_4.Example
{
    /// <summary>
    /// Filling array by circles
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// Vector of filling
        /// </summary>
        public enum Vector
        {
            toRight,
            toDown,
            toLeft,
            toUp
        }

        private readonly int rowCount;
        private readonly int colCount;

        public int[,] data { get; set; }


        /// <summary>
        /// Constructor for matrix
        /// </summary>
        /// <param name="rowCount">Count of rows</param>
        /// <param name="colCount">Count of columns</param>
        public Matrix(int rowCount, int colCount)
        {
            this.rowCount = rowCount;
            this.colCount = colCount;

            if (rowCount <= 0 || colCount <= 0)
                throw new ArgumentException("rowCount or colCount must be greater than zero");

            data = new int[rowCount, colCount];
        }

        /// <summary>
        /// Fill array
        /// </summary>
        public void Fill(int startFrom = 0)
        {
            int value = startFrom;

            var cellCount = colCount * rowCount;
            var cellCounter = 0;

            var currentRow = 0;
            var currentColumn = 0;

            var vector = Vector.toRight;
            var limits = new int[4] { 1, colCount - 1, rowCount - 1, 0 };

            while (cellCounter < cellCount)
            {
                data[currentRow, currentColumn] = value++;
                cellCounter++;
                switch (vector)
                {
                    case Vector.toRight:
                        if (currentColumn == limits[1])
                        {
                            limits[1]--;
                            vector = Vector.toDown;
                            currentRow++;
                        }
                        else
                            currentColumn++;
                        break;

                    case Vector.toDown:
                        if (currentRow == limits[2])
                        {
                            limits[2]--;
                            vector = Vector.toLeft;
                            currentColumn--;
                        }
                        else
                            currentRow++;
                        break;

                    case Vector.toLeft:
                        if (currentColumn == limits[3])
                        {
                            limits[3]++;
                            vector = Vector.toUp;
                            currentRow--;
                        }
                        else
                            currentColumn--;
                        break;

                    case Vector.toUp:
                        if (currentRow == limits[0])
                        {
                            limits[0]++;
                            vector = Vector.toRight;
                            currentColumn++;
                        }
                        else
                            currentRow--;
                        break;
                }
            }

        }

        /// <summary>
        /// Output array
        /// </summary>
        public void Print()
        {
            Console.WriteLine("--------------------------------------");

            for (int r = 0; r < rowCount; r++)
            {
                Console.WriteLine();
                for (int c = 0; c < colCount; c++)
                {
                    Console.Write($"{data[r, c]}".PadLeft(10));
                }
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------");

        }
    }
}