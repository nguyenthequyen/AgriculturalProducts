using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public interface IBlogsRepository : IBaseRepository<Blogs>
    {
        void CreatedBlogs(Blogs blogs);
        IEnumerable<Blogs> GetBlogsTopNews();
    }
}
