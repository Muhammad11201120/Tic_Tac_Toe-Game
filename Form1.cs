using System.Drawing;
using System.Windows.Forms;

namespace TikTakToeGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint( object sender, PaintEventArgs e )
        {
            Color white = Color.FromArgb( 255, 255, 255, 255 );
            Pen pen = new Pen( white );
            pen.Width = 15;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            //drow horizental lines
            e.Graphics.DrawLine( pen, 670, 300, 1430, 300 );
            e.Graphics.DrawLine( pen, 670, 460, 1430, 460 );
            //drow vertical lines
            e.Graphics.DrawLine( pen, 930, 140, 930, 620 );
            e.Graphics.DrawLine( pen, 1190, 140, 1190, 620 );
        }
    }
}
