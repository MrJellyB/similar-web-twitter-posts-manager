using PostManager.DAL.Contexts;
using PostManager.DAL.Services;

namespace PostManager.DAL.Factories
{
    public interface IPostsRepositoryFactory
    {
        IPostsRepository Create(FeedContext context);
    }

    public class PostsRepositoryFactory : IPostsRepositoryFactory
    {
        public IPostsRepository Create(FeedContext context)
        {
            return new PostsRepository(context);
        }
    }
}
