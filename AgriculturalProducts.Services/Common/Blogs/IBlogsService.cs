using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IBlogsService : IBaseService<Blogs>
    {
        void CreatedBlogs(Blogs blogs);
        IEnumerable<Blogs> GetBlogsTopNews();
    }
}
