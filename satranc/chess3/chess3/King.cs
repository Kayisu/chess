using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess3
{
    public class King : Pieces
    {
        List<Tuple<int, int>> legalMoves = new List<Tuple<int, int>>(); //Mümkün hamleleri listeye eklemesi için Tuple

        public override void Ability()
        {
            MoveKing();
            ShowLegalMoves();
        }

        private void MoveKing()
        {
            // x ve y cinsinden şahın olası hamleleri

            int[] dx = { 1, 1, 1, 0, 0, -1, -1, -1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++) //Tüm mümkün hamleler için döngü
            {
                // Seçilen noktanın x ve y cinsinden konumları
                int newX = X + dx[i];
                int newY = Y + dy[i];

                // Yeni konum satranç tahtası sınırlarının içerisinde olmazsa out of range olacağı için sınırları belirliyoruz
                if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8) 
                {
                    legalMoves.Add(new Tuple<int, int>(newX, newY)); //olası hamlelerin butondaki yerlerini listeye ekliyoruz
                }
            }
        }

        public override void ShowLegalMoves() //Listeye eklediğimiz konumlar butonda yerine konularak rengini değiştiriyor 
        {
            foreach (var move in legalMoves)
            {
                BtnGrid[move.Item1, move.Item2].BackColor = Color.DarkSlateBlue;
            }
        }
    }

}
