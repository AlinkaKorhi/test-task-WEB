using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCoreTask.BLL
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            var commentRepository = _unitOfWork.GetRepository<Comment>();
            var dbComment = await commentRepository.CreateAsync(comment);

            await _unitOfWork.SaveAsync();

            return dbComment;
        }

        public async Task DeleteComment(Comment comment)
        {
            var commentRepository = _unitOfWork.GetRepository<Comment>();
            commentRepository.Delete(comment);

            await _unitOfWork.SaveAsync();
        }

        public Comment GetCommentById(int id)
        {
            var commentRepository = _unitOfWork.GetRepository<Comment>();
            var comment = commentRepository.GetEntityById(id);

            return comment;

        }

        public async Task<IReadOnlyCollection<Comment>> GetCommentsAsync()
        {
            var commentRepository = _unitOfWork.GetRepository<Comment>();
            var comments = await commentRepository.GetAllAsync();

            return comments;
        }

        public Comment UpdateComment(Comment comment)
        {
            var commentRepository = _unitOfWork.GetRepository<Comment>();
            var commentUpdate = commentRepository.Update(comment);

            _unitOfWork.SaveAsync();

            return commentUpdate;
        }
    }
}
