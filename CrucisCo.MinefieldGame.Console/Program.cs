// See https://aka.ms/new-console-template for more information
using CrucisCo.MinefieldGame;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

// Build a config object, using env vars and JSON providers.
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var gameSettings = GetGameSettings(config);

new GameConsole(gameSettings).Run();



static GameSettings GetGameSettings(IConfiguration config)
{
    var gameSettingsSection = config.GetSection("GameSettings");

    int playerLives = int.Parse(gameSettingsSection["PlayerLives"]);
    int minefieldSize = int.Parse(gameSettingsSection["MinefieldSize"]);
    int numberOfMines = int.Parse(gameSettingsSection["NumberOfMines"]);

    return new GameSettings
    {
        PlayerLives = playerLives,
        MinefieldSize = minefieldSize,
        NumberOfMines = numberOfMines   
    };
}