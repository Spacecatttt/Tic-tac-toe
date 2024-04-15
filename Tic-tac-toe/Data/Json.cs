using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tic_tac_toe.Data.Accounts;
using Tic_tac_toe.Data.Games;
using Tic_tac_toe.Forms;
namespace Tic_tac_toe.Data;

public static class Json
{
    private static readonly JsonSerializerOptions Options = new()
        { ReferenceHandler = ReferenceHandler.IgnoreCycles, WriteIndented = true};
    
    
    private const string UsersFilePath =
        @"Data\Users.json";
    
    private const string GameInfoPath =
        @"Data\GameInfo.json";
    

    // Fill out DataBase with deserialized object from users.file
    public static void Load()
    {
        var json = File.ReadAllText(UsersFilePath);
        MainGameWindow.DataBase.Users = JsonSerializer.Deserialize<List<BaseAccount>>(json);

        json = File.ReadAllText(GameInfoPath);
        MainGameWindow.DataBase.GameInfo = JsonSerializer.Deserialize<List<BaseGame>>(json);
    }

    // rewrite our json file 
    public static void Save(DataBase dataBase)
    {
        var jsonString = JsonSerializer.Serialize(dataBase.Users, Options);
        File.WriteAllText(UsersFilePath,jsonString);
        
        jsonString = JsonSerializer.Serialize(dataBase.GameInfo,Options);
        File.WriteAllText(GameInfoPath,jsonString);
    }
}