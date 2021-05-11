/* This is an almost-complete translation of https://github.com/haarismemon/oware/ from Java to C#
*/
using System;

namespace Oware
{
    class Program
    {
        static void Main(string[] args)
        {
            Player one = new Player("Player 1");
            Player two = new Player("Player 2");
            IHouse[][] houses = new IHouse[2][];
            houses[0] = new IHouse[6];
            houses[1] = new IHouse[6];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    houses[i][j] = new House(i, j);
                }
            }
            Board b = new Board(one, two, houses);
            // rest left as exercise to reader!
        }
    }
}
