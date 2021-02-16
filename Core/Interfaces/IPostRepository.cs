using Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPostRepository:IBaseRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostsByUser(int userId);

        //Task<Post> GetPost(int id);

        // Task CreatePost(Post post);

        //Task<bool> UpadatePost(Post post);

        //Task<bool> DeletePost(int id);

    }
}
