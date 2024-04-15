using System.Text.Json.Serialization;

namespace Tic_tac_toe.Data.Accounts;

public class VipAccount:BaseAccount
{
    
    [JsonConstructor]
     public VipAccount(string name, int score, int gamesCount, int wins):base(name,score,gamesCount,wins)
     {
     }
     
    public VipAccount(string name):base(name)
    {
    }

    public override void WinGame(int rating)
    {
        Wins++;
        GamesCount++;
        Score += rating*2;
    }
                 
    public override void LoseGame(int rating)
    {
        GamesCount++;
        Score -= rating - rating/2;
    }
    
    public override void DrawGame()
    {
        GamesCount++; 
    }
}