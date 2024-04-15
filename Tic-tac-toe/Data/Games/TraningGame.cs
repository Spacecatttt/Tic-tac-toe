using System.Text.Json.Serialization;
using Tic_tac_toe.Data.Accounts;

namespace Tic_tac_toe.Data.Games;

public class TrainingGame:BaseGame
{
    [JsonConstructor]
    public TrainingGame(int rating,BaseAccount player1, BaseAccount player2, string winner):base(rating,player1,player2,winner )
    {
    }
    
    public override void PlayGame(BaseAccount player1, BaseAccount player2)
    {
        if (Winner == Player1.Name)
        {
            Player1.WinGame(0);
            Player2.LoseGame(0);
        }
        if (Winner == Player2.Name)
        {
            Player2.WinGame(0);
            Player1.LoseGame(0);
        }
        if (Winner == "Nobody")
        {
            Player2.DrawGame();
            Player1.DrawGame();
        }
    }
}