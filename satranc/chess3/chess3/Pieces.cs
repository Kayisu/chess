using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;
using System.Runtime.Remoting.Channels;

namespace chess3
{
    public abstract class Pieces : IPieces 
    {
        public Button[,] BtnGrid { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public abstract void Ability();
        public abstract void ShowLegalMoves();

    }
}
