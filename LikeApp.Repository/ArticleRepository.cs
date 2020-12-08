using LikeApp.Repository.Context;
using LikeApp.Repository.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LikeApp.Repository
{
    public class ArticleRepository : CoreRepository<Article, LikeAppDbContext>
    {
        LikeAppDbContext _context;
        public ArticleRepository(LikeAppDbContext context) : base(context) {
            _context = context;
        }

        public Article GetArticle()
        {
            return _context.Articles.FirstOrDefault();
        }
    }
}
