using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2_TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool?[,] Game { get; set; } = new bool?[3, 3];
        public int Number { get; set; } = 0;
        public bool FirstMove { get; set; } = true;

        private void UpdateBoard()
        {
            if (Game[0, 0] == null)     B00.Text = "";
            if (Game[0, 0] == true)     B00.Text = "X";
            if (Game[0, 0] == false)    B00.Text = "O";
            
            if (Game[1, 0] == null)     B10.Text = "";
            if (Game[1, 0] == true)     B10.Text = "X";
            if (Game[1, 0] == false)    B10.Text = "O";
            
            if (Game[2, 0] == null)     B20.Text = "";
            if (Game[2, 0] == true)     B20.Text = "X";
            if (Game[2, 0] == false)    B20.Text = "O";
            
            if (Game[0, 1] == null)     B01.Text = "";
            if (Game[0, 1] == true)     B01.Text = "X";
            if (Game[0, 1] == false)    B01.Text = "O";
            
            if (Game[1, 1] == null)     B11.Text = "";
            if (Game[1, 1] == true)     B11.Text = "X";
            if (Game[1, 1] == false)    B11.Text = "O";
            
            if (Game[2, 1] == null)     B21.Text = "";
            if (Game[2, 1] == true)     B21.Text = "X";
            if (Game[2, 1] == false)    B21.Text = "O";
            
            if (Game[0, 2] == null)     B02.Text = "";
            if (Game[0, 2] == true)     B02.Text = "X";
            if (Game[0, 2] == false)    B02.Text = "O";
            
            if (Game[1, 2] == null)     B12.Text = "";
            if (Game[1, 2] == true)     B12.Text = "X";
            if (Game[1, 2] == false)    B12.Text = "O";
            
            if (Game[2, 2] == null)     B22.Text = "";
            if (Game[2, 2] == true)     B22.Text = "X";
            if (Game[2, 2] == false)    B22.Text = "O";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region BTNS
        private void B00_Click(object sender, EventArgs e) => MyTurn(0, 0, true);
        private void B10_Click(object sender, EventArgs e) => MyTurn(1, 0, true);
        private void B20_Click(object sender, EventArgs e) => MyTurn(2, 0, true);
        private void B01_Click(object sender, EventArgs e) => MyTurn(0, 1, true);
        private void B11_Click(object sender, EventArgs e) => MyTurn(1, 1, true);
        private void B21_Click(object sender, EventArgs e) => MyTurn(2, 1, true);
        private void B02_Click(object sender, EventArgs e) => MyTurn(0, 2, true);
        private void B12_Click(object sender, EventArgs e) => MyTurn(1, 2, true);
        private void B22_Click(object sender, EventArgs e) => MyTurn(2, 2, true);
        #endregion

        public void MyTurn(int i, int j, bool player)
        {
            Number++;

            if(Game[i, j] != null)
                return;

            Game[i, j] = player;

            try
            {
                UpdateBoard();
                var win = GameIsWin(Game);

                if (win != null)
                {
                    if (win == true) Win("Player");
                    else Win("Computer");
                    return;
                }
            }
            catch (Exception)
            {
                Win("Nobody");
                return;
            }

            if(player == true)
            {
                if(Number < 2)
                {
                    var availableMoves = _getMoves(Game);
                    var move = availableMoves[new Random().Next(0, availableMoves.Count)];
                    MyTurn(move.i, move.j, false);
                }
                else
                {
                    MiniMax(Game, false, 0, out (int i, int j) choise);
                    MyTurn(choise.i, choise.j, false);
                }
            }
        }

        public bool? GameIsWin(bool?[,] game)
        {
            int dp = 0,
                dc = 0,
                rp = 0,
                rc = 0,
                count = 0;

            for (int i = 0; i < 3; i++)
            {
                int hp = 0,
                    hc = 0,
                    vp = 0,
                    vc = 0;

                for (int j = 0; j < 3; j++)
                {
                    if (game[i, j] == true) hp++;
                    if (game[i, j] == false) hc++;
                    if (game[j, i] == true) vp++;
                    if (game[j, i] == false) vc++;

                    if(game[i, j] != null)
                        count++;
                }


                if (game[i, i] == true) dp++;
                if (game[i, i] == false) dc++;

                if (game[i, 2 - i] == true) rp++;
                if (game[i, 2 - i] == false) rc++;

                if (hp == 3 || vp == 3) return true;
                if (hc == 3 || vc == 3) return false;
            }

            if (dp == 3 || rp == 3) return true;
            if (dc == 3 || rc == 3) return false;

            if (count == 9)
                throw new Exception();

            return null;
        }

        public void Win(string who)
        {
            MessageBox.Show($"{who} WINS!");

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Game[i, j] = null;

            Number = 0;

            FirstMove = !FirstMove;
            if(FirstMove == false)
            {
                var availableMoves = _getMoves(Game);
                var move = availableMoves[new Random().Next(0, availableMoves.Count)];
                Game[move.i, move.j] = false;
                Number++;
            }

            UpdateBoard();
        }

        public int MiniMax(bool?[,] board, bool turn, int depth, out (int i, int j) choise)
        {
            try
            {
                choise = (0, 0);
                var score = GameIsWin(board);

                if(score != null)
                {
                    if (score == true) return 10 - depth;
                    if (score == false) return depth - 10;
                    return 0;
                }

            }
            catch (Exception)
            {
                choise = (0, 0);
                return 0;
            }

            var boardClone = _getClone(board);

            depth++;
            var scores = new List<int>();
            var moves = new List<(int i, int j)>();

            var availableMoves = _getMoves(boardClone);

            foreach (var item in availableMoves)
            {
                boardClone[item.i, item.j] = turn;
                scores.Add(MiniMax(boardClone, !turn, depth, out choise));
                boardClone[item.i, item.j] = null;
                moves.Add(item);
            }

            if(turn == true)
            {
                var maxScore = scores.IndexOf(scores.Max());
                choise = moves[maxScore];
                return scores[maxScore];
            }
            else
            {
                var minScore = scores.IndexOf(scores.Min());
                choise = moves[minScore];
                return scores[minScore];
            }
        }

        private List<(int i, int j)> _getMoves(bool?[,] game)
        {
            var list = new List<(int i, int j)>();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (game[i, j] == null) list.Add((i, j));

            return list;
        }

        private bool?[,] _getClone(bool?[,] board)
        {
            var newBoard = new bool?[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    newBoard[i, j] = board[i, j];
            return newBoard;
        }
    }
}
