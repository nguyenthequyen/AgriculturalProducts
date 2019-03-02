using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public class UserClientService : BaseService<User>, IUserClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserClientRepository _reponsitory;
        public UserClientService(IUnitOfWork unitOfWork, UserClientRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _reponsitory = reponsitory;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUserResponse> Create(User user)
        {
            throw new NotImplementedException();
            //await _reponsitory.Create(user);
            //_unitOfWork.Commit();
            //return ResolveEventHandler;
        }

        public void UpdateUserClient(List<User> user)
        {
            throw new NotImplementedException();
        }

        public int UserStatisticsClient()
        {
            throw new NotImplementedException();
        }
    }
}
