using LikeApp.Repository.Context;
using LikeApp.Repository.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LikeApp.Repository
{
    public class ArticleLikeRepository : CoreRepository<ArticleLike, LikeAppDbContext>
    {
        LikeAppDbContext _context;
        public ArticleLikeRepository(LikeAppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ArticleLike> GetByArticleId(int Id)
        {
            return _context.ArticleLikes.Where(c => c.ArticleId == Id).ToList();
        }

        public bool Exists(int Id, string ipAddress)
        {
            var resp = _context.ArticleLikes.FirstOrDefault(c => c.ArticleId == Id && c.IPAddress == ipAddress);

            return resp != null;
        }

        public int CountById(int articleId)
        {
            return _context.ArticleLikes.Where(c => c.ArticleId == articleId).Count();
        }
    }
}
