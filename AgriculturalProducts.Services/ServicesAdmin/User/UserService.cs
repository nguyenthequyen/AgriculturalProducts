using AgriculturalProducts.Models;
using AgriculturalProducts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgriculturalProducts.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IUserRepository _userRepository;
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork, userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public void CreatedUserClient(List<User> user)
        {
            foreach (var item in user)
            {
                item.Id = new Guid();
                item.ModifyDate = DateTime.Now;
                item.CreatedDate = DateTime.Now;
                Add(item);
            }
            _unitOfWork.Commit();
        }

        public void CreatedUserAdmin(List<User> user)
        {
            foreach (var item in user)
            {
                item.Id = new Guid();
                item.ModifyDate = DateTime.Now;
                item.CreatedDate = DateTime.Now;
                Add(item);
            }
            _unitOfWork.Commit();
        }

        public void UpdateUserClient(List<User> user)
        {
            foreach (var item in user)
            {
                item.CreatedDate = DateTime.Now;
                Update(item);
            }
            _unitOfWork.Commit();
        }

        public void UpdateUserAdmin(List<User> user)
        {
            foreach (var item in user)
            {
                item.CreatedDate = DateTime.Now;
                Update(item);
            }
            _unitOfWork.Commit();
        }

        public void DeleteUserAdmin(List<User> user)
        {
            foreach (var item in user)
            {
                item.CreatedDate = DateTime.Now;
                Delete(item);
            }
            _unitOfWork.Commit();
        }

        public int UserStatisticsClient()
        {
            return UserStatisticsClient();
        }

        public async Task<User> FindUserById(Guid id)
        {
            return await _userRepository.GetFirstOrDefault(id);
        }
    }
}
