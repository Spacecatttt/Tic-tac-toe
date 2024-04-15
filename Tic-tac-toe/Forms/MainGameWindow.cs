using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Tic_tac_toe.Data;
using Tic_tac_toe.Data.Accounts;
using Tic_tac_toe.Data.Games;

namespace Tic_tac_toe.Forms
{
    public partial class MainGameWindow : Form
    {
        private bool _turn = true; // if true -> it is X's turn, else O's
        private int _turnCount;
        private int _gameType;

        public static DataBase DataBase;
        private BaseAccount _playerX;
        private BaseAccount _playerO;

        public MainGameWindow()
        {
            InitializeComponent();
            AddUsers();
            FillLabels();
            DisableButtuns();
        }

        public void AddUsers()
        {
            //find User object in list users (all exists users) with same name as First and Second Combo Box
            _playerX = DataBase.Users.Find(x => x.Name.Equals(StartingWindow.StartWindow.FirstComboBox.Text));
            _playerO = DataBase.Users.Find(x => x.Name.Equals(StartingWindow.StartWindow.SecondComboBox.Text));
        }

        public void FillLabels()
        {
            firstName.Text = _playerX.Name;
            FirstGames.Text = _playerX.GamesCount.ToString();
            FirstWins.Text = _playerX.Wins.ToString();
            FirstScore.Text = _playerX.Score.ToString();

            SecondName.Text = _playerO.Name;
            SecondGames.Text = _playerO.GamesCount.ToString();
            SecondWins.Text = _playerO.Wins.ToString();
            SecondScore.Text = _playerO.Score.ToString();
        }

        public void DisableButtuns()
        {
            foreach (Control x in Controls)
            {
                if (x is Button && ReferenceEquals(x.Tag, "play"))
                {
                    ((Button)x).Enabled = false; // change them all back to enabled or clickable
                    ((Button)x).Text = ""; // set the text to question mark
                    ((Button)x).BackColor = Color.Gray; // change the background colour to default button colors
                    _turnCount = 0;
                }
            }
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (_turn)
            {
                if (b != null) b.Text = @"X";
            }
            else
            {
                if (b != null) b.Text = @"O";
            }

            if (b != null)
            {
                b.BackColor = Color.Silver;
                b.Enabled = false;
            }

            ++_turnCount;
            Winner();
            _turn = !_turn;
            
        }

        // check winner of game
        public void Winner()
        {
            bool isWinner = false;

            if ((ButtonA1.Text == ButtonA2.Text) && (ButtonA2.Text == ButtonA3.Text) && (!ButtonA1.Enabled))
                isWinner = true;

            else if ((ButtonB1.Text == ButtonB2.Text) && (ButtonB2.Text == ButtonB3.Text) && (!ButtonB1.Enabled))
                isWinner = true;
            else if ((ButtonC1.Text == ButtonC2.Text) && (ButtonC2.Text == ButtonC3.Text) && (!ButtonC1.Enabled))
                isWinner = true; // verticals


            else if ((ButtonA1.Text == ButtonB1.Text) && (ButtonB1.Text == ButtonC1.Text) && (!ButtonA1.Enabled))
                isWinner = true;
            else if ((ButtonA2.Text == ButtonB2.Text) && (ButtonB2.Text == ButtonC2.Text) && (!ButtonA2.Enabled))
                isWinner = true;
            else if ((ButtonA3.Text == ButtonB3.Text) && (ButtonB3.Text == ButtonC3.Text) && (!ButtonA3.Enabled))
                isWinner = true; //horizontal


            else if ((ButtonA1.Text == ButtonB2.Text) && (ButtonB2.Text == ButtonC3.Text) && (!ButtonA1.Enabled))
                isWinner = true;
            else if ((ButtonA3.Text == ButtonB2.Text) && (ButtonB2.Text == ButtonC1.Text) && (!ButtonA3.Enabled))
                isWinner = true; //diagonals

            //create game after one side winning. Add game to game History and Fill labels of MainGameWindow
            
            string winnerAccount = "";
            if (_turnCount == 9 && isWinner == false)
            {
                winnerAccount = "Nobody";
                DisableButtuns();

                BaseGame currentGame;
                if (_gameType == 1)
                {
                    currentGame = new UsualGame(10, _playerX, _playerO, winnerAccount);
                    currentGame.PlayGame(_playerX, _playerO);
                    DataBase.GameInfo.Add(currentGame);
                    Json.Save(DataBase);

                }
                else if (_gameType == 0)
                {
                    currentGame = new TrainingGame(0, _playerX, _playerO, winnerAccount);
                    currentGame.PlayGame(_playerX, _playerO);
                    DataBase.GameInfo.Add(currentGame);
                    Json.Save(DataBase);
                }

                FillLabels();
                MessageBox.Show(@"The winnner is " + winnerAccount);
                B_BackToStart.Enabled = true;
                
            }
            if (isWinner)
            {
                if (_turn && winnerAccount != "Nobody")
                {
                    winnerAccount = _playerX.Name;
                }
                else winnerAccount = _playerO.Name;

                DisableButtuns();

                BaseGame currentGame;
                if (_gameType == 1)
                {
                    currentGame = new UsualGame(10, _playerX, _playerO, winnerAccount);
                    currentGame.PlayGame(_playerX, _playerO);
                    DataBase.GameInfo.Add(currentGame);
                    Json.Save(DataBase);

                }
                else if (_gameType == 0)
                {
                    currentGame = new TrainingGame(0, _playerX, _playerO, winnerAccount);
                    currentGame.PlayGame(_playerX, _playerO);
                    DataBase.GameInfo.Add(currentGame);
                    Json.Save(DataBase);
                    
                }

                FillLabels();
                MessageBox.Show(@"The winnner is " + winnerAccount);
                B_BackToStart.Enabled = true;
            }
        }
        
        private void resetGame_Click(object sender, EventArgs e)
        {
            _gameType = 1;
           EnableButton();
        }

        private void B_startTraining_Click(object sender, EventArgs e)
        {
            _gameType = 0;
            EnableButton();
        }

        private void EnableButton()
        {
            B_BackToStart.Enabled = false;
            foreach (Control x in this.Controls)
            {
                if (x is Button && ReferenceEquals(x.Tag, "play"))
                {
                    ((Button)x).Enabled = true; // change them all back to enabled or clickable
                    ((Button)x).Text = ""; // set the text to question mark
                    ((Button)x).BackColor = default; // change the background colour to default button colors
                    _turnCount = 0;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            button_click(sender, e);
        }

        private void gameButton1_Click(object sender, EventArgs e)
        {
            button_click(sender, e);
        }

        private void gameButton2_Click(object sender, EventArgs e)
        {
            button_click(sender, e);
        }

        private void gameButton3_Click(object sender, EventArgs e)
        {
            button_click(sender, e);
        }

        private void gameButton4_Click(object sender, EventArgs e)
        {
            button_click(sender, e);
        }

        private void gameButton5_Click(object sender, EventArgs e)
        {
            button_click(sender, e);
        }

        private void gameButton6_Click(object sender, EventArgs e)
        {
            button_click(sender, e);
        }

        private void gameButton7_Click(object sender, EventArgs e)
        {
            button_click(sender, e);
        }

        private void gameButton8_Click(object sender, EventArgs e)
        {
            button_click(sender, e);
        }

        private void gameButton9_Click(object sender, EventArgs e)
        {
            button_click(sender, e);
        }

        private void exitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void B_BackToStart_Click(object sender, EventArgs e)
        {
            Visible = false; 
            Thread.Sleep(150);
            StartingWindow.StartWindow.Visible = true;
        }
    }
}