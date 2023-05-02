// namespace ThePreference.Aplication.UseCases_Handler_CHECKNAME.User.Queries
// {
//     public class GetAllUsersQuery : IRequest<Response<IEnumerable<UserViewModel>>>
//     {
//
//     }
//
//     public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Response<IEnumerable<UserViewModel>>>
//     {
//         private readonly IUserRepositoryAsync _userRepository;
//         private readonly IMapper _mapper;
//         public GetAllUsersQueryHandler(IUserRepositoryAsync userRepository, IMapper mapper = null)
//         {
//             _userRepository = userRepository;
//             _mapper = mapper;
//         }
//         public async Task<Response<IEnumerable<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
//         {
//             var usersList = (await _userRepository.GetAllAsync().ConfigureAwait(false)).AsQueryable().ToList();
//             return new Response<IEnumerable<UserViewModel>>(_mapper.Map<IEnumerable<UserViewModel>>(usersList));
//         }
//     }
// }