using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly SocialMediaContext _Context;
        //   private readonly IBaseRepository<Post> _PostRepository;
         private readonly IPostRepository _PostRepository;
        private readonly IBaseRepository<User> _UserRepository;
        private readonly IBaseRepository<Comment> _CommentRepository;
        public UnitOfWorkRepository(SocialMediaContext context)
        {
            _Context = context;
        }

        // public IBaseRepository<Post> PostRepository => _PostRepository ?? new BaseRepository<Post>(_Context);
         public IPostRepository PostRepository => _PostRepository ?? new PostRepository(_Context);

        public IBaseRepository<User> UserRepository => _UserRepository ?? new BaseRepository<User>(_Context);

        public IBaseRepository<Comment> CommentRepository => _CommentRepository ?? new BaseRepository<Comment>(_Context);

        public void Dispose()
        {
            if (_Context != null)
            {
                _Context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _Context.SaveChangesAsync();
        }

    }
}
