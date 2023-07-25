using System.Drawing;
using System.Windows.Forms;
using TikTakToeGame.Properties;

namespace TikTakToeGame
{
    public partial class Form1 : Form
    {
        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.player1;
        enum enPlayer
        {
            player1,
            player2,
        }
        enum enWinner
        {
            player1,
            player2,
            drow,
            gameInProgress
        }
        struct stGameStatus
        {
            public enWinner winner;
            public bool gameOver;
            public short playCount;
        }
        public Form1()
        {
            InitializeComponent();
        }
        void EndGame()
        {

            lblTurn.Text = "GAME OVER";
            switch ( GameStatus.winner )
            {

                case enWinner.player1:

                    lblWinner.Text = " PLAYER 1";
                    break;

                case enWinner.player2:

                    lblWinner.Text = " PLAYER 2";
                    break;

                default:

                    lblWinner.Text = " Draw";
                    break;

            }

            MessageBox.Show( "GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information );
            RestartGame();
        }
        public bool CheckValues( Button btn1, Button btn2, Button btn3 )
        {
            if ( btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString() )
            {

                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if ( btn1.Tag.ToString() == "X" )
                {
                    GameStatus.winner = enWinner.player1;
                    GameStatus.gameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.winner = enWinner.player2;
                    GameStatus.gameOver = true;
                    EndGame();
                    return true;
                }

            }

            GameStatus.gameOver = false;
            return false;
        }
        public void checkWinner()
        {
            //checked rows
            //check Row1
            if ( CheckValues( button1, button2, button3 ) )
                return;

            //check Row2
            if ( CheckValues( button4, button5, button6 ) )
                return;

            //check Row3
            if ( CheckValues( button7, button8, button9 ) )
                return;

            //checked cols
            //check col1
            if ( CheckValues( button1, button4, button7 ) )
                return;

            //check col2
            if ( CheckValues( button2, button5, button8 ) )
                return;

            //check col3
            if ( CheckValues( button3, button6, button9 ) )
                return;

            //check Diagonal

            //check Diagonal1
            if ( CheckValues( button1, button5, button9 ) )
                return;

            //check Diagonal2
            if ( CheckValues( button3, button5, button7 ) )
                return;
        }
        public void changeImage( Button btn )
        {
            if ( btn.Tag.ToString() == "?" )
            {
                switch ( PlayerTurn )
                {
                    case enPlayer.player1:
                        btn.Image = Resources.X;
                        btn.Tag = "X";
                        lblPlayer.Text = "Player 2";
                        GameStatus.playCount++;
                        PlayerTurn = enPlayer.player2;
                        checkWinner();
                        break;
                    case enPlayer.player2:
                        btn.Image = Resources.O;
                        btn.Tag = "O";
                        lblPlayer.Text = "Player 1";
                        GameStatus.playCount++;
                        PlayerTurn = enPlayer.player1;
                        checkWinner();
                        break;
                }
            }
            else

            {
                MessageBox.Show( "Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

            if ( GameStatus.playCount == 9 )
            {
                GameStatus.gameOver = true;
                GameStatus.winner = enWinner.drow;
                EndGame();
            }
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
        private void RestButton( Button btn )
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;

        }
        private void RestartGame()
        {

            RestButton( button1 );
            RestButton( button2 );
            RestButton( button3 );
            RestButton( button4 );
            RestButton( button5 );
            RestButton( button6 );
            RestButton( button7 );
            RestButton( button8 );
            RestButton( button9 );

            PlayerTurn = enPlayer.player1;
            lblPlayer.Text = " Player 1";
            GameStatus.playCount = 0;
            GameStatus.gameOver = false;
            GameStatus.winner = enWinner.gameInProgress;
            lblWinner.Text = "IN PROGRESS";



        }

        private void button_Click( object sender, System.EventArgs e )
        {
            changeImage( ( Button ) sender );
        }
        private void btnReset_Click( object sender, System.EventArgs e )
        {
            RestartGame();
        }
    }
}
