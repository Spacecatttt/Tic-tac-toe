using System.Collections.Generic;
using System.Text.Json.Serialization;
using Tic_tac_toe.Data.Accounts;
using Tic_tac_toe.Data.Games;

namespace Tic_tac_toe.Data
{
    public class DataBase
    {
        public List<BaseAccount> Users { get; set; }
        public List<BaseGame> GameInfo { get; set; }

        [JsonConstructor]
        public DataBase(List<BaseAccount> users,List<BaseGame> gameInfo)
        {
            this.Users = users;
            this.GameInfo = gameInfo;
        }
    }
}