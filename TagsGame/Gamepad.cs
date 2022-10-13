using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsGame
{
    class Gamepad
    {
        public Gamepad() { }
        public void press_key(ref Table table,KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up: 
                    {
                        table.findZero();
                        if(table.zero.x == 0)
                        {
                            break;
                        }
                        else
                        {
                            table.arr[table.zero.x, table.zero.y] = table.arr[table.zero.x - 1, table.zero.y];
                            table.arr[table.zero.x-1,table.zero.y] = 0;
                        }
                    }break;
               case Keys.Down: 
                    {
                        table.findZero();
                        if (table.zero.x == 3)
                        {
                            break;
                        }
                        else
                        {
                            table.arr[table.zero.x, table.zero.y] = table.arr[table.zero.x + 1, table.zero.y];
                            table.arr[table.zero.x + 1, table.zero.y] = 0;
                        }
                    }
                    break;
                    case Keys.Left:
                    {
                        table.findZero();
                        if (table.zero.y == 0)
                        {
                            break;
                        }
                        else
                        {
                            table.arr[table.zero.x, table.zero.y] = table.arr[table.zero.x , table.zero.y-1];
                            table.arr[table.zero.x, table.zero.y-1] = 0;
                        }
                    }
                    break;
                case Keys.Right: {
                        table.findZero();
                        if (table.zero.y == 3)
                        {
                            break;
                        }
                        else
                        {
                            table.arr[table.zero.x, table.zero.y] = table.arr[table.zero.x, table.zero.y + 1];
                            table.arr[table.zero.x, table.zero.y + 1] = 0;
                        }
                    }
                    break;
            }
        }
    }
}
