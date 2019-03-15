using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class BlogsRepository : BaseRepository<Blogs>, IBlogsRepository
    {
        private readonly ApplicationContext _applicationContext;
        public BlogsRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void CreatedBlogs(Blogs blogs)
        {
            Add(blogs);
        }

        public IEnumerable<Blogs> GetBlogsTopNews()
        {
            return _applicationContext.Blogs.Where(x => x.CreatedDate <= DateTime.Now).Take(3).ToList();
        }
    }
}
