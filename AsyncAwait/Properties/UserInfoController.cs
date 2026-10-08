using System.Text.Json;
using AsyncAwait.Models;
using Microsoft.AspNetCore.Mvc;

namespace AsyncAwait.Controllers;

[ApiController]
[Route("[controller]")]
public class UserInfoController : ControllerBase
{
    private const string USERS_FILE_PATH = "data/users.json";
    private const string LOCATIONS_FILE_PATH = "data/locations.json";
    private const string GAMES_FILE_PATH = "data/games.json";

    [HttpGet("user-info")]
    public ActionResult GetUserInfo()
    {
        var userId = GetRandomUserId();
        var location = GetUserLocationById(userId);
        var game = GetFavoriteUserGameById(userId);
        var result = $"{userId}: {location}, {game}, ";
        return Ok(result);
    }

    private int GetRandomUserId()
    {
        var userJson = System.IO.File.ReadAllText(USERS_FILE_PATH);
        Task.Delay(2000).Wait();
        
        var userData = JsonSerializer.Deserialize<UserData>(userJson) 
                       ?? throw new InvalidOperationException();

        return userData.Users.First().Id;
    }

    private string GetUserLocationById(int userId)
    {
        var locationJson = System.IO.File.ReadAllText(LOCATIONS_FILE_PATH);
        Task.Delay(2000).Wait();
        
        var locationData = JsonSerializer.Deserialize<LocationData>(locationJson) 
                           ?? throw new InvalidOperationException();

        return locationData.Locations.First(l => l.UserId == userId).LocationName;
    }

    private string GetFavoriteUserGameById(int userId)
    {
        var gameJson = System.IO.File.ReadAllText(GAMES_FILE_PATH);
        Task.Delay(2000).Wait();
        
        var gameData = JsonSerializer.Deserialize<GameData>(gameJson) 
                           ?? throw new InvalidOperationException();

        return gameData.Games.First(l => l.UserId == userId).FavoriteGame;
    }
}