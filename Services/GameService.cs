using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IGameService
    {
        IEnumerable<Game> GetAll();
        Game GetById(int id);
        Game Create(Game game, string Title);
        void Update(Game game);
        void Delete(int id);
        IEnumerable<Game> GetByQuery(string q);
    }
    public class GameService : IGameService
    {
        private DataContext _context;

        public GameService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games;
        }

        public Game GetById(int id)
        {
            return _context.Games.Find(id);
        }

        public Game Create(Game game, string Title)
        {
            if (string.IsNullOrWhiteSpace(Title))
                throw new AppException("Title is required!");

            if(_context.Games.Any(x => x.Title == game.Title))
                throw new AppException("Game with title \"" + game.Title + "\" already exists");

            _context.Games.Add(game);
            _context.SaveChanges();

            return game;
        }

        public void Update(Game gameParam)
        {
            var game = _context.Games.Find(gameParam.Id);

            if (game == null)
                throw new AppException("Game not found");

            //Update title if it has changed
            if(!string.IsNullOrWhiteSpace(gameParam.Title) && gameParam.Title != game.Title)
            {
                //throw error if game with title exists
                if (_context.Games.Any(x => x.Title == gameParam.Title))
                    throw new AppException("Game " + gameParam.Title + " already exists");

                game.Title = gameParam.Title;
            }
            
            //Update other game properties if provided
            if (!string.IsNullOrWhiteSpace(gameParam.Production))
                game.Production = gameParam.Production;

            if (gameParam.CreatedTime != null)
                game.CreatedTime = gameParam.CreatedTime;

            //TO ADD: 2 ENUMS

            _context.Games.Update(game);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var game = _context.Games.Find(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Game> GetByQuery(string q)
        {
            var games = from m in _context.Games select m;

            if (!String.IsNullOrEmpty(q))
            {                
                games = games.Where(s => s.Title.Contains(q));
            }

            return games;
        }
    }
}
