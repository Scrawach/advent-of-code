namespace Day02.CubeConundrum.Common;

public class GameSetParser
{
    public GameSet Parse(string line)
    {
        var splits = line.Split(":");
        var gameId = int.Parse(splits[0].Split(" ")[1]);
        var content = ParseContent(splits[1]);
        return new GameSet(gameId, content);
    }

    private static Game[] ParseContent(string line)
    {
        var games = line.Split(";");
        return games.Select(ParseGame).ToArray();
        }

    private static Game ParseGame(string line)
    {
        char[] delimiterChars = { ' ', ',', ';' };
        var content = new Dictionary<string, int>()
        {
            ["red"] = 0,
            ["blue"] = 0,
            ["green"] = 0
        };
        
        var items = line.Split(delimiterChars);
        for (var i = 0; i < items.Length; i++)
        {
            if (items[i] == "")
            {
                continue;
            }
            
            var count = items[i];
            var type = items[i + 1];
            i++;
            content[type] += int.Parse(count);
        }

        return new Game(content["red"], content["blue"], content["green"]);
    }
}