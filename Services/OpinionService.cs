using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IOpinionService
    {
        IEnumerable<Opinion> GetAll();
        Opinion Create(Opinion opinion);
        void Update(Opinion opinion);
        void Delete(int id);
        IEnumerable<Opinion> GetByGameId(int id);
    }
    public class OpinionService : IOpinionService
    {
        private DataContext _context;

        public OpinionService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Opinion> GetAll()
        {
            return _context.Opinions;
        }

        public Opinion Create(Opinion opinion)
        {
            _context.Opinions.Add(opinion);
            _context.SaveChanges();

            return opinion;
        }

        public void Update(Opinion opinionParam)
        {
            var opinion = _context.Opinions.Find(opinionParam.Id);

            if (opinion == null)
                throw new AppException("Opinion not found");

            //Updating title of review
            if(!string.IsNullOrWhiteSpace(opinionParam.Title))
            {
                opinion.Title = opinionParam.Title;
            }

            //Updating text of review
            if (!string.IsNullOrWhiteSpace(opinionParam.Text))
            {
                opinion.Text = opinionParam.Text;
            }

            _context.Opinions.Update(opinion);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var opinion = _context.Opinions.Find(id);
            if(opinion != null)
            {
                _context.Opinions.Remove(opinion);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Opinion> GetByGameId(int id)
        {
            var opinions = from m in _context.Opinions select m;

            opinions = opinions.Where(s => s.GameId.Equals(id));
            
            return opinions;
        }
    }
}
