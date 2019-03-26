using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Services
{
    public class UserInforService : BaseService<UserInfor>, IUserInforService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInforRepository _reponsitory;
        public UserInforService(IUnitOfWork unitOfWork, IUserInforRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _unitOfWork = unitOfWork;
            _reponsitory = reponsitory;
        }

        public void CreatedUserInfor(UserInfor userInfor)
        {
            userInfor.Id = new Guid();
            Add(userInfor);
            _unitOfWork.Commit();
        }
    }
}
