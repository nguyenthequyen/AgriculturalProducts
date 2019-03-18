using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class CommentService : BaseService<Comments>, ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommentRepository _reponsitory;
        public CommentService(IUnitOfWork unitOfWork, ICommentRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public void CreatedComment(Comments comments)
        {
            comments.CreatedDate = DateTime.Now;
            comments.ModifyDate = DateTime.Now;
            Add(comments);
            _unitOfWork.Commit();
        }
        public IEnumerable<Comments> GetAllComments(Guid id)
        {
            return _reponsitory.GetAllComments(id);
        }
    }
}
