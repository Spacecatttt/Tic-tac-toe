
using System.Text.Json.Serialization;
using Tic_tac_toe.Data.Accounts;

namespace Tic_tac_toe.Data.Games;
public class UsualGame:BaseGame
{
    [JsonConstructor]
    public UsualGame(int rating,BaseAccount player1, BaseAccount player2, string winner):base(rating,player1,player2,winner )
    {
    }
    
    public override void PlayGame(BaseAccount player1, BaseAccount player2)
    {
        if (Winner == Player1.Name)
        {
            Player1.WinGame(Rating);
            Player2.LoseGame(Rating);
        }
        if (Winner == Player2.Name)
        {
            Player2.WinGame(Rating);
            Player1.LoseGame(Rating);
        }
        if (Winner == "Nobody")
        {
            Player2.DrawGame();
            Player1.DrawGame();
        }
    }
}