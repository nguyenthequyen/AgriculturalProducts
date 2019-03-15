using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class BlogsService : BaseService<Blogs>, IBlogsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlogsRepository _reponsitory;
        public BlogsService(IUnitOfWork unitOfWork, IBlogsRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public void CreatedBlogs(Blogs blogs)
        {
            blogs.CreatedDate = DateTime.Now;
            blogs.ModifyDate = DateTime.Now;
            Add(blogs);
            _unitOfWork.Commit();
        }

        public IEnumerable<Blogs> GetBlogsTopNews()
        {
            return _reponsitory.GetBlogsTopNews();
        }
    }
}
