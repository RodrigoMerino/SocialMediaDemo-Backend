using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
 public   interface IUnitOfWork: IDisposable
    {
        IPostRepository PostRepository { get; }
        IBaseRepository<User> UserRepository { get; }
        IBaseRepository<Comment> CommentRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
