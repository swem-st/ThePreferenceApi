// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
//
// namespace ThePreference.Api.Controllers;
//
// [Route("api/accounts")]
// [ApiController]
// public class AccountsController : ControllerBase
// {
//     private readonly UserManager<User> _userManager; 
//     private readonly IMapper _mapper;
//
//     public AccountsController(UserManager<User> userManager, IMapper mapper) 
//     {
//         _userManager = userManager;
//         _mapper = mapper;
//     }
//
//     [HttpPost("Registration")] 
//     public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDTO userForRegistration) 
//     {
//         if (userForRegistration == null || !ModelState.IsValid) 
//             return BadRequest(); 
//             
//         var user = _mapper.Map<User>(userForRegistration);
//
//         var result = await _userManager.CreateAsync(user, userForRegistration.Password); 
//         if (!result.Succeeded) 
//         { 
//             var errors = result.Errors.Select(e => e.Description); 
//                 
//             return BadRequest(new RegistrationResponseDto { Errors = errors }); 
//         }
//             
//         return StatusCode(201); 
//     }
//     
//     [HttpPost("Login")] 
//     public async Task<IActionResult> RegisterUser(UserForLoginDTO userForLogin) 
//     {
//         if (userForRegistration == null || !ModelState.IsValid) 
//             return BadRequest(); 
//             
//         var user = _mapper.Map<User>(userForRegistration);
//
//         var result = await _userManager.CreateAsync(user, userForRegistration.Password); 
//         if (!result.Succeeded) 
//         { 
//             var errors = result.Errors.Select(e => e.Description); 
//                 
//             return BadRequest(new RegistrationResponseDto { Errors = errors }); 
//         }
//             
//         return StatusCode(201); 
//     }
// }