using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCoreTask.BLL
{
    public interface ICommentService
    {
        Task<IReadOnlyCollection<Comment>> GetCommentsAsync();

        Comment GetCommentById(int id);

        Task<Comment> CreateCommentAsync(Comment comment);

        Comment UpdateComment(Comment comment);

        Task DeleteComment(Comment comment);
    }
}
