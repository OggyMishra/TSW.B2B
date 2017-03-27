namespace TSW.B2B.BusinessServices.Classes
{
    using System.Threading.Tasks;
    using BusinessObjects;
    using Common;
    using Interfaces;
    using Repositories.Interfaces;

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepo)
        {
            this.userRepository = userRepo;
        }

        public async Task AddNewUser(User user)
        {
            var newUser = EntityConverter.ConvertModelToEntity(user);
            await this.userRepository.AddNewUser(newUser);
        }

        public async Task<bool> UpdateUser(User user)
        {
            var newUser = EntityConverter.ConvertModelToEntity(user);
            return await this.userRepository.UpdateUser(newUser);
        }
    }
}
