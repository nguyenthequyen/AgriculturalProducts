using AgriculturalProducts.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Infrastructure.Identity;

namespace AgriculturalProducts.Repository
{
    public class UserClientRepository : BaseRepository<User>, IUserClientRepository
    {
        public ApplicationContext _applicationContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public UserClientRepository(UserManager<AppUser> userManager, IMapper mapper, ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
            _mapper = mapper;
        }

        public void UpdateUserClient(List<User> user)
        {
            throw new NotImplementedException();
        }

        public int UserStatisticsClient()
        {
            throw new NotImplementedException();
        }

        public void CreatedUserClient(List<User> user)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateUserResponse> Create(User userModel)
        {
            var appUser = new AppUser { Email = userModel.Email, UserName = userModel.UserName };
            var identityResult = await _userManager.CreateAsync(appUser);
            if (!identityResult.Succeeded)
            {
                return new CreateUserResponse(appUser.Id, false, identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
            }
            var user = new User();
            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.IdentityId = appUser.Id;
            user.UserName = appUser.UserName;

            _applicationContext.Users.Add(user);
            return new CreateUserResponse(appUser.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
        }

        public override bool Equals(object obj)
        {
            var repository = obj as UserClientRepository;
            return repository != null &&
                   EqualityComparer<ApplicationContext>.Default.Equals(_applicationContext, repository._applicationContext) &&
                   EqualityComparer<UserManager<AppUser>>.Default.Equals(_userManager, repository._userManager) &&
                   EqualityComparer<IMapper>.Default.Equals(_mapper, repository._mapper);
        }
    }
}

