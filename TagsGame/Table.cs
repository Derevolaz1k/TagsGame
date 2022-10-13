using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsGame
{
    class Table
    {
        public Table()
        {
            Random random = new Random();
            int[] tmp = new int[16];
            for(int i = 0; i < 16; i++)
            {
                tmp[i] = i;
            }
            for (int i = tmp.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = tmp[j];
                tmp[j] = tmp[i];
                tmp[i] = temp;
            }
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[i, j] = tmp[counter];
                    counter++;
                }
            }
        }
        public Table(int[]tmp)
        {
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[i, j] = tmp[counter];
                    counter++;
                }
            }
        }
        public struct zeroPos
        {
            public int x;
            public int y;
        }
        public zeroPos zero;
        public void findZero()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (arr[i,j]==0)
                    {
                        zero.x = i;
                        zero.y = j;
                    }
                }
            }
        }
        public bool Sorted()
        {
            int[,] sortedArr = new int[4, 4] { { 1, 2, 3, 4 },{5,6,7,8 },{9,10,11,12 },{13,14,15,0 } };
            for(int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (arr[i, j] != sortedArr[i,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public int[,] arr = new int[4, 4];
        public int[,] getArr()
        {
            return arr;
        }
    }
}
