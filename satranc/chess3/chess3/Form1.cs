using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess3
{
    public partial class Form1 : Form
    {
        public Button[,] btnGrid = new Button[8, 8]; //8'e 8'lik buton düzeni oluşturmak için buton
        public Form1()
        {
            InitializeComponent();
            CreateGrid(); //Uygulama başlatılınca buton düzeninin otomatik gelmesi için Form1 constructor'ında çağırıyoruz.
        }
        public void ClearGrid() // Mümkün hamleler gösterildikten sonra diğer mümkün hamleler gösterilmeden önce tahtayı temizlemek için metod
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    btnGrid[i, j].BackColor = Color.Black;
                }
            }
        }
        public void CreateGrid()  //Satranç tahtası düzeni
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    btnGrid[i, j] = new Button(); // i ve j. butonlar için her seferinde yeni buton oluşturuluyor. 

                    panel1.Controls.Add(btnGrid[i, j]); //Butonların istenilen düzende durması için panelin içine yerleştiriyoruz

                    btnGrid[i, j].Height = 500 / 8; //8'e 8'lik buton düzeninde her butonun yüksekliği ve genişliği panel yüksekliği/ dikey buton sayısı 
                    btnGrid[i, j].Width = 500 / 8; // Panel genişliği/yatay buton sayısı
                    btnGrid[i, j].Location = new Point(i * 500 / 8, j * 500 / 8); //Konum- renk- text ayarı.
                    btnGrid[i, j].BackColor = Color.Black;
                    btnGrid[i, j].Text = i + "|" + j; 
                    btnGrid[i, j].Click += GridButton_Click; //Bütün buton click action'ları GridButton_Click metoduna ekliyoruz.
                }
            }
        }
        private void GridButton_Click(object sender, EventArgs e) //Seçilen butonun tıklanma eventi. 
        {
            Button clickedButton = (Button)sender;
            string[] clickedPosition = clickedButton.Text.Split('|'); //Button text'i splitleyip seçilen butonun x ve y konumlarını alıyoruz.
            int x = int.Parse(clickedPosition[0]); 
            int y = int.Parse(clickedPosition[1]);

            List<Pieces> pieces = new List<Pieces>(); 
            // Taşları Abstract Pieces listesine ekleyip tüm taşlar için
            // Pieces sınıfının nesnesini kullanarak upcasting yapıyoruz. (Polymorphism)

            King king = new King { BtnGrid = btnGrid, X = x, Y = y };
            pieces.Add(king);

            Queen queen = new Queen { BtnGrid = btnGrid, X = x, Y = y };
            pieces.Add(queen);

            Rook rook = new Rook { BtnGrid = btnGrid, X = x, Y = y };
            pieces.Add(rook);

            Bishop bishop = new Bishop { BtnGrid = btnGrid, X = x, Y = y };
            pieces.Add(bishop);

            Knight knight = new Knight { BtnGrid = btnGrid, X = x, Y = y };
            pieces.Add(knight);

            Pawn pawn = new Pawn { BtnGrid = btnGrid, X = x, Y = y };
            pieces.Add(pawn);

            ClearGrid();
            int selectedIndex = comboBox1.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < pieces.Count)
            {
                pieces[selectedIndex].Ability(); //comboBox1'deki index'e göre taş seçip o taşın ability'sini uygula.
            }
            else
            {
                MessageBox.Show("Lütfen listeden bir taş seçin."); //index seçilmemişse uyarı mesajı gönder.
            }
        }
    }
}
