using AgriculturalProducts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationContext _applicationContext;
        public CategoryRepository(
            IUnitOfWork unitOfWork,
            ApplicationContext applicationContext
            ) : base(applicationContext)
        {
            _unitOfWork = unitOfWork;
            _applicationContext = applicationContext;
        }

        public int CategoryStatistics()
        {
            return _applicationContext.Categeries.Count();
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }

        public async Task<Category> FindCategoryById(Guid id)
        {
            return await GetFirstOrDefault(id);
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return GetAllRecords();
        }

        public void InsertCategory(Category category)
        {
            Add(category);
        }

        public void UpdateCategory(Category category)
        {
            Update(category);
        }
    }
}
