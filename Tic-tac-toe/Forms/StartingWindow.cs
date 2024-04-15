using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tic_tac_toe.Data;
using Tic_tac_toe.Data.Accounts;
using Tic_tac_toe.Data.Games;

namespace Tic_tac_toe.Forms
{
    public partial class StartingWindow : Form
    {
        public static StartingWindow StartWindow;
        public ComboBox FirstComboBox;
        public ComboBox SecondComboBox;
        
        public StartingWindow()
        {
            InitializeComponent();
            MainGameWindow.DataBase = new DataBase(new List<BaseAccount>() ,new List<BaseGame>());
            Json.Load();
            
            B_StarGame.Enabled = false;
            StartWindow = this;
            AddUserToComboBox();

            FirstComboBox = this.FirstOpponent;
            SecondComboBox = this.SecondOpponent;
        }


        //take all users from DataBase List of Users and transmits them to ComboBoxes
        private void AddUserToComboBox()
        {
            foreach (var user in MainGameWindow.DataBase.Users)
            {
                FirstOpponent.Items.Add(user.Name);
                SecondOpponent.Items.Add(user.Name);
            }
        }

        private void B_StarGame_Click(object sender, EventArgs e)
        {
            MainGameWindow window = new MainGameWindow();
            window.Show();
            Visible = false;
        }

        private void FirstOpponent_Click(object sender, EventArgs e)
        {
            if (FirstOpponent.SelectedIndex > -1 && SecondOpponent.SelectedIndex > -1 )  B_StarGame.Enabled = true;
        }

        private void SecondOpponent_Click(object sender, EventArgs e)
        {
            if (SecondOpponent.SelectedIndex > -1 && FirstOpponent.SelectedIndex > -1)  B_StarGame.Enabled = true;
            
        }

        private void B_CreateUser_Click(object sender, EventArgs e)
       {
             //create user obj from textBOX UserName
              BaseAccount user = new UsualAccount(UserName.Text);
              MainGameWindow.DataBase.Users.Add(user);
              
              //adding created user to ComboBox
              FirstOpponent.Items.Add(user.Name);
              SecondOpponent.Items.Add(user.Name);
              UserName.Text = "";
              
              Json.Save(MainGameWindow.DataBase);
       }

        private void B_History_Click(object sender, EventArgs e)
        {
            History historyWindow = new History();
            historyWindow.Show();
            Visible = false;
        }

        private void create_Vip_Account_Click(object sender, EventArgs e)
        {
            BaseAccount user = new VipAccount(UserName.Text);
            MainGameWindow.DataBase.Users.Add(user);
              
            //adding created user to ComboBox
            FirstOpponent.Items.Add(user.Name);
            SecondOpponent.Items.Add(user.Name);
            UserName.Text = "";
              
            Json.Save(MainGameWindow.DataBase);
        }
    }
}