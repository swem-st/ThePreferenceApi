// namespace ThePreference.Aplication.UseCases_Handler_CHECKNAME.User.Queries
// {
//     public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
//     {
//         private readonly IUserRepositoryAsync userRepository;
//
//         public GetUserByIdQueryValidator(IUserRepositoryAsync userRepository)
//         {
//             this.userRepository = userRepository;
//             RuleFor(p => p.UserId)
//                .NotEmpty().WithMessage("{PropertyName} is required.")
//                .NotNull()
//                .MustAsync(IsUserExists).WithMessage("{PropertyName} not exists.");
//         }
//
//         private async Task<bool> IsUserExists(Guid UserId, CancellationToken cancellationToken)
//         {
//             var userObject = (await userRepository.FindByCondition(x => x.UserId.Equals(UserId)).ConfigureAwait(false)).AsQueryable().FirstOrDefault();
//             if (userObject != null)
//             {
//                 return true;
//             }
//             return false;
//         }
//     }
// }