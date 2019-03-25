using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class ManagerUserService : BaseService<User>, IManagerUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IManagerUserRepository _reponsitory;
        public ManagerUserService(IUnitOfWork unitOfWork, IManagerUserRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public PageList<object> GetListUsers(PagingParams pagingParams)
        {
            if (string.IsNullOrEmpty(pagingParams.SearchString))
            {
                var providersdb = _reponsitory.GetListUsers();
                List<object> providers = providersdb.ToList();
                var query = providers.AsQueryable();
                return new PageList<object>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
            else
            {
                var providersdb = _reponsitory.GetListUsersSearchString(pagingParams.SearchString);
                List<object> providers = providersdb.ToList();
                var query = providers.AsQueryable();
                return new PageList<object>(query, pagingParams.PageNumber, pagingParams.PageSize);
            }
        }
    }
}
