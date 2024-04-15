using System.Text.Json.Serialization;

namespace Tic_tac_toe.Data.Accounts
{
    public class UsualAccount:BaseAccount
    { 
        
        [JsonConstructor]
        public UsualAccount(string name, int score, int gamesCount, int wins):base(name,score,gamesCount,wins)
        {
            
        }
        public UsualAccount(string name):base(name)
        {
        }
        
        public override void WinGame(int rating)
         {
             Wins++;
             GamesCount++;
             Score += rating;
         }
                 
         public override void LoseGame(int rating)
         {
             GamesCount++;
             if (Score - rating < 0)
             {
                 Score = 0;
             }
             else Score -= rating;
         }

         public override void DrawGame()
         {
             GamesCount++; 
         }
    }
}