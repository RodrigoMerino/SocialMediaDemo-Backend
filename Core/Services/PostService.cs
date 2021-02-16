using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PostService : IPostService
    {
        //private readonly IBaseRepository<Post> _UnitOfWork;
      //  private readonly IBaseRepository<User> _UserRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        public  IEnumerable<Post> GetPosts()
        {
            return _UnitOfWork.PostRepository.GetAll();
        }

        public async Task<Post> GetPost(int id)
        {
            return await _UnitOfWork.PostRepository.GetById(id);
        }

        public async Task CreatePost(Post post)
        {
            var user = await _UnitOfWork.UserRepository.GetById(post.UserId);
            

            if (user == null)
            {
                throw new BusinessException("User does not exist");
            }
            var getByUsers = await _UnitOfWork.PostRepository.GetPostsByUser(post.UserId);
            if (getByUsers.Count() < 10)
            {
                var lastPost = getByUsers.OrderByDescending(x => x.Date).FirstOrDefault();
                if ((DateTime.Now - lastPost.Date).TotalDays < 7)
                {
                    throw new BusinessException("youre no able no publish");

                }

            }
            if (post.Description.Contains("sexo"))
            {
                throw new BusinessException("the word sex cant be in the description");
            }
            await _UnitOfWork.PostRepository.Create(post);
            await _UnitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpadatePost(Post post)
        {

            _UnitOfWork.PostRepository.Update(post);
            await _UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePost(int id)
        {
            await _UnitOfWork.PostRepository.Delete(id);
            return true;
        }

        public async Task<IEnumerable <Post>>  GetPostsByUser(int id)
        {
         return  await _UnitOfWork.PostRepository.GetPostsByUser(id);

        }
    }
}
