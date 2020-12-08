using System;
using System.Collections.Generic;
using System.Text;

namespace LikeApp.Repository.Objects
{
    public class Article : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DatePublished { get; set; }

        public ICollection<ArticleLike> ArticleLikes { get; set; }
    }
}
