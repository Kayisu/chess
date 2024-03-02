using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess3
{
    public class Knight : Pieces
    {
        List<Tuple<int, int>> legalMoves = new List<Tuple<int, int>>();

        public override void Ability()
        {
            AddLegalMoves();
            ShowLegalMoves();
        }
        private void AddLegalMoves()
        {
            int[] dx = { 1, 1, -1, -1, 2, 2, -2, -2 }; //x ve y cinsinden atın tüm olası hareketleri
            int[] dy = { 2, -2, 2, -2, 1, -1, 1, -1 };

            for (int i = 0; i < 8; i++)
            {
                int newX = X + dx[i];
                int newY = Y + dy[i];

                if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8)
                
                {
                    legalMoves.Add(new Tuple<int, int>(newX, newY));
                }
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
