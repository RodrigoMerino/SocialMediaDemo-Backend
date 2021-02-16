using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPostService
    {
        Task CreatePost(Post post);
        Task<bool> DeletePost(int id);
        Task<Post> GetPost(int id);
        Task <IEnumerable <Post>>GetPostsByUser(int id);
        IEnumerable<Post> GetPosts();
        Task<bool> UpadatePost(Post post);
    }
}