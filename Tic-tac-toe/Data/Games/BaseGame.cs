using System.Text.Json.Serialization;
using Tic_tac_toe.Data.Accounts;

namespace Tic_tac_toe.Data.Games;
[JsonDerivedType(typeof(UsualGame), typeDiscriminator: "usualGame")]
[JsonDerivedType(typeof(TrainingGame), typeDiscriminator: "trainingGame")]

public abstract class BaseGame
{  
  
    public int Rating { get; set; }
    public BaseAccount Player1 { get; set; }
    public BaseAccount Player2 { get; set; }
    public string Winner { get; set; }
    
      [JsonConstructor]
        public BaseGame(int rating,BaseAccount player1, BaseAccount player2, string winner)
         {
             this.Rating = rating;
             this.Player1 = player1;
             this.Player2 = player2;
             this.Winner = winner;
         }
    public abstract void PlayGame(BaseAccount current,BaseAccount  opponent);
}