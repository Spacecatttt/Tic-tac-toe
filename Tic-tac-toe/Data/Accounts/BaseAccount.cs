using System.Text.Json.Serialization;
namespace Tic_tac_toe.Data.Accounts;

[JsonDerivedType(typeof(UsualAccount), typeDiscriminator: "usualAc")]
[JsonDerivedType(typeof(VipAccount), typeDiscriminator: "vipAc")]

public abstract class BaseAccount
{
    public string Name { get; set; }
    public int Score { get; set; }
    public int GamesCount { get; set; }
    public int Wins { get; set; }
    
    public BaseAccount(string name)
    {
        this.Name = name;
        this.Score = 10;
        this.GamesCount = 0;
        this.Wins = 0;
    }
    
    [JsonConstructor]
    public BaseAccount(string name, int score, int gamesCount, int wins)
    {
        this.Name = name;
        this.Score = score;
        this.GamesCount = gamesCount;
        this.Wins = wins;
    }

    public abstract void WinGame(int rating);
    public abstract void LoseGame(int rating);
    public abstract void DrawGame();
}