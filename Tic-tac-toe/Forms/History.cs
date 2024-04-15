using System;
using System.Threading;
using System.Windows.Forms;
using ConsoleTables;

namespace Tic_tac_toe.Forms;

public partial class History : Form
{
    public History()
    {
        InitializeComponent();
        AddHistoryText();
    }

    private void AddHistoryText()
    {
        var table = new ConsoleTable("Index","First Player","Accaount Type", "Second Player","Accaount Type", "Winner", "Rating","FirstPlayer Score","SecondPlayer Score","Game Type");
        int i = 0;
        foreach (var item in MainGameWindow.DataBase.GameInfo)
        {
            table.AddRow($"{i++}",$"{item.Player1.Name,10}",$"{item.Player1.GetType().Name,18}",$"{item.Player2.Name,18}",$"{item.Player2.GetType().Name,18}",$"{item.Winner,18}",$"{item.Rating,18}",$"{item.Player1.Score,18}",$"{item.Player2.Score,15}",$"{item.GetType().Name,18}");
        }
        GameHistryArea.Text = table.ToMinimalString();
    }

    private void B_back_Click(object sender, EventArgs e)
    {
        Visible = false;
        Thread.Sleep(150);
        StartingWindow.StartWindow.Visible = true;
    }
}