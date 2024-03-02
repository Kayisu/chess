using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess3
{
    public class Queen : Pieces 
    {
        List<Tuple<int, int>> legalMoves = new List<Tuple<int, int>>();

        public override void Ability()
        {
            MoveStraightLines();
            MoveDiagonalLines();

            ShowLegalMoves();
        }
        private void MoveStraightLines()
        {
            //Yatay - dikey hamle algoritması. 
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if ((i == 0 || j == 0) && (i != 0 || j != 0)) 
                    {
                        AddLegalMoves(i, j);
                    }
                }
            }
        }
        private void MoveDiagonalLines()
        {
            // Çapraz hamle algoritması 
            for (int i = -1; i <= 1; i += 2)
            {
                for (int j = -1; j <= 1; j += 2)
                {
                    AddLegalMoves(i, j);
                }
            }
        }
        private void AddLegalMoves(int i, int j)
        {
            // Seçilen noktanın x ve y cinsinden konumları
            int newX = X + i;
            int newY = Y + j;

            // Yeni konum satranç tahtası sınırlarının içerisinde olmazsa out of range olacağı için sınırları belirliyoruz
            while (newX >= 0 && newX < 8 && newY >= 0 && newY < 8) 
            {
                legalMoves.Add(new Tuple<int, int>(newX, newY));//olası hamlelerin butondaki yerlerini listeye ekliyoruz

                newX += i;
                newY += j;
            }
        }
        public override void ShowLegalMoves()
        {
            foreach (var move in legalMoves)
            {
                BtnGrid[move.Item1, move.Item2].BackColor = Color.DarkSlateBlue;
            }
        }
    }

}
