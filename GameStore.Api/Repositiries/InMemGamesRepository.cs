using GameStore.Api.Entities;

namespace GameStore.Api.Repositiries;

public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games = new()
    {
        new Game
        {
        Id = 1,
        Name = "Kozaccs",
        Genre = "Strategy",
        Price = 1.0m,
        ReleaseDate = new DateTime(1999, 1, 1),
        ImageUri = "https://placehold.co/100"
         },
         new Game
        {
        Id = 2,
        Name = "Catan",
        Genre = "Fighting",
        Price = 1.0m,
        ReleaseDate = new DateTime(1999, 1, 1),
        ImageUri = "https://placehold.co/100"
        },
         new Game
        {
        Id = 3,
        Name = "Monopoly",
        Genre = "Sport",
        Price = 1.0m,
        ReleaseDate = new DateTime(1999, 1, 1),
        ImageUri = "https://placehold.co/100"
        }

    };

    public IEnumerable<Game> GetAll() => games;

    public Game? Get(int id) => games.Find(x => x.Id == id);

    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(x => x.Id == updatedGame.Id);

        games[index] = updatedGame;

    }

    public void Delete(int id)
    {
        var index = games.FindIndex(x => x.Id == id);

        games.RemoveAt(index);
    }
}