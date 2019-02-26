using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;

namespace AgriculturalProducts.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository) : base(unitOfWork, categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public int CategoryStatistics()
        {
            return _categoryRepository.CategoryStatistics();
        }

        public void DeleteCategory(List<Category> category)
        {
            foreach (var item in category)
            {
                Delete(item);
            }
            _unitOfWork.Commit();
        }

        public async Task<Category> FindCategoryById(Guid id)
        {
            return await FindCategoryById(id);
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return GetAllRecords();
        }

        public PageList<Category> GetCategoryPageList(PagingParams pagingParams)
        {
            if (string.IsNullOrEmpty(pagingParams.SearchString))
            {
                var providersdb = _categoryRepository.GetAllRecords().OrderByDescending(x => x.ModifyDate);
                List<Category> providers = providersdb.ToList();
                var query = providers.AsQueryable();
                return new PageList<Category>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
            else
            {
                var providersdb = _categoryRepository.GetAllRecords().Where(x => x.Name.Contains(pagingParams.SearchString)).OrderByDescending(x => x.ModifyDate);
                List<Category> providers = providersdb.ToList();
                var query = providers.AsQueryable();
                return new PageList<Category>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
        }

        public void InsertCategory(List<Category> category)
        {
            foreach (var item in category)
            {
                item.Id = new Guid();
                item.CreatedDate = DateTime.Now;
                item.ModifyDate = DateTime.Now;
                Add(item);
            }
            _unitOfWork.Commit();
        }

        public void UpdateCategory(List<Category> category)
        {
            foreach (var item in category)
            {
                item.CreatedDate = DateTime.Now;
                Update(item);
            }
            _unitOfWork.Commit();
        }
    }
}
