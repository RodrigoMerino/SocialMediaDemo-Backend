
using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infraestructure.Repositories
{
    public class PostRepository : BaseRepository<Post>,IPostRepository
    {
        public PostRepository(SocialMediaContext context):base(context) {   }
         
        public async Task<IEnumerable<Post>> GetPostsByUser(int userId)
        {
            //calling users
            return await _Entities.Where(x => x.UserId== userId).ToListAsync();
        }
        //public readonly SocialMediaContext _Context;
        //public PostRepository(SocialMediaContext Context)
        //{
        //    _Context = Context;
        //}

        //public async Task CreatePost(Post post)
        //{
        //    _Context.Add(post);
        //   await _Context.SaveChangesAsync();
        //}

        //public async Task<bool> DeletePost(int id)
        //{
        //    var post = await GetPost(id);
        //    _Context.Posts.Remove(post);
        // int rows = await   _Context.SaveChangesAsync();

        //    return rows > 0;
        //}

        //public async Task<Post> GetPost(int id)
        //{
        //    var post = await  _Context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
        //    return post;

        //}

        //public async Task<IEnumerable<Post>> GetPosts()
        //{
        //    var posts = await _Context.Posts.ToListAsync();
        //    return posts;
        //}

        //public async Task<bool> UpadatePost(Post post)
        //{
        //    var CurrentPost = await GetPost(post.PostId);
        //    CurrentPost.Date = post.Date;
        //    CurrentPost.Description= post.Description;
        //    CurrentPost.Image = post.Image;
        // int rows =  await _Context.SaveChangesAsync();
        //    return rows > 0;


        //}


    }
}
