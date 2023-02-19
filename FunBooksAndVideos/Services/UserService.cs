using AutoMapper;
using FunBooksAndVideos.Models;
using FunBooksAndVideos.Repositories.Interfaces;
using FunBooksAndVideos.Services.Interfaces;

namespace FunBooksAndVideos.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            ILogger<UserService> logger,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            _logger.LogInformation(new EventId(1), $"{nameof(GetAllUsers)} - retrieving items");

            var users = await _userRepository.GetUsers();
            var mappedUsers = _mapper.Map<List<UserModel>>(users);

            _logger.LogInformation(new EventId(2), $"{nameof(GetAllUsers)} - items retrieved");

            return mappedUsers;
        }

        public async Task<UserModel> GetUserById(int userId)
        {
            _logger.LogInformation(new EventId(3), $"{nameof(GetUserById)} - retrieving item by id {userId}");

            var user = await _userRepository.GetUserById(userId);
            var mappedUser = _mapper.Map<UserModel>(user);

            _logger.LogInformation(new EventId(4), $"{nameof(GetUserById)} - item retrieved");

            return mappedUser;
        }
    }
}
