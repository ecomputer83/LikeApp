using System;
using System.Collections.Generic;
using System.Text;

namespace LikeApp.Repository.Objects
{
    public class ArticleLike : IEntity
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string IPAddress { get; set; }
        public bool UserLike { get; set; }

        public virtual Article Article { get; set; }
    }
}
