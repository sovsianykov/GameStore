using GameStore.Api.Data;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Repositiries;

public class EntityFrameworkGamesRepository : IGamesRepository
{

    private readonly GameStoreContext _dbContext;

    public EntityFrameworkGamesRepository(GameStoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Game> GetAll()
    {
        return _dbContext.Games.AsNoTracking().ToList();
    }

    public Game? Get(int id)
    {
        return _dbContext.Games.Find(id);
    }
    public void Create(Game game)
    {
        _dbContext.Games.Add(game);
         _dbContext.SaveChanges();   
    }
    public void Update(Game updatedGame)
    {
        _dbContext.Games.Update(updatedGame);
        _dbContext.SaveChanges();
    }
    public void Delete(int id)
    {
        _dbContext.Games.Where(g => g.Id == id).ExecuteDelete();
    }
    
}