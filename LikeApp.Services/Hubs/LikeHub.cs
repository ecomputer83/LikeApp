using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using LikeApp.Repository;
using LikeApp.Repository.Objects;
using System.Linq;

namespace LikeApp.Services
{
    public class LikeHub : Hub
    {
        ArticleLikeRepository _repository;
        public LikeHub(ArticleLikeRepository repository)
        {
            _repository = repository;
        }
        public Task Like(string postId)
        {
            var likePost = Save(postId);
            return Clients.All.SendAsync("LikeArticle", likePost);
        }

        public int Save(string Id)
        {
            var postId = int.Parse(Id);
            var ipAddress = Context.GetHttpContext().Request.HttpContext.Connection.RemoteIpAddress.ToString();

            var Likes = _repository.GetByArticleId(postId);
            var liked = new ArticleLike
            {
                IPAddress = ipAddress,
                ArticleId = postId,
                UserLike = true
            };

            var exist = Likes.FirstOrDefault(c => c.IPAddress == liked.IPAddress);

            if (exist == null)
            {
                _repository.Add(liked).Wait();
            }
            else
            {
                exist.UserLike = !exist.UserLike;
                _repository.Update(exist).Wait();
            }

            Likes = _repository.GetByArticleId(postId);

            return Likes.Count(e => e.UserLike);
        }
    }
}
