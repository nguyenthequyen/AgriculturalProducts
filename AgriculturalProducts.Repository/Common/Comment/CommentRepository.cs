using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class CommentRepository : BaseRepository<Comments>, ICommentRepository
    {
        private readonly ApplicationContext _applicationContext;
        public CommentRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void CreatedComment(Comments comments)
        {
            Add(comments);
        }
    }
}
