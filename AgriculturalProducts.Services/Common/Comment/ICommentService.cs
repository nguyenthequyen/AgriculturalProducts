using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface ICommentService : IBaseService<Comments>
    {
        void CreatedComment(Comments comments);
        IEnumerable<Comments> GetAllComments(Guid id);
    }
}
