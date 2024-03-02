using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess3
{
    public class Pawn : Pieces
    {
        List<Tuple<int, int>> legalMoves = new List<Tuple<int, int>>();

        public override void Ability()
        {
            MoveForward();
            ShowLegalMoves();
        }

        private void MoveForward()
        {
            int forwardDirection = -1; // Beyaz piyona göre ileri gitme hamlesi.

            int newX = X;
            int newY = Y + forwardDirection;

            // Varsayılan olarak piyon tek kare ilerler.
            if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8)
            {
                legalMoves.Add(new Tuple<int, int>(newX, newY));

                // İlk hamle için piyonlar varsayılan başlangıç konumlarından iki kare ileri gidebilirler.
                if (Y == 6)
                {
                    legalMoves.Add(new Tuple<int, int>(X, Y - 2));
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
