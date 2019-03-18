using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface ICommentRepository : IBaseRepository<Comments>
    {
        void CreatedComment(Comments comments);
        IEnumerable<Comments> GetAllComments(Guid id);
    }
}
