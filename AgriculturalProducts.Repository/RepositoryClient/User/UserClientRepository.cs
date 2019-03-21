using AgriculturalProducts.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalProducts.Repository
{
    public class UserClientRepository : BaseRepository<User>, IUserClientRepository
    {
        private readonly ApplicationContext _applicationContext;
        public UserClientRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<User> CheckUserExists(string userName)
        {
            return _applicationContext.Users.FirstOrDefault(x => x.UserName == userName);
        }

        public void CreatedUserCliet(User user)
        {
            Add(user);
        }

        public async Task<User> FindClientUser(LoginDto login)
        {
            return _applicationContext.Users.FirstOrDefault(x => x.UserName == login.Username && x.Password == login.Password);
        }

        public int UsersStatistics()
        {
            return _applicationContext.Users.Count();
        }
    }
}

