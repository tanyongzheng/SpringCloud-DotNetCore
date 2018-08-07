using System.Collections.Generic;
using System.Threading.Tasks;
using Steeltoe.CircuitBreaker.Hystrix;

namespace OrderService.Controllers
{
    public class UsergetAllCommand : HystrixCommand<List<User>>
    {
        private IUserService _userService;
        public UsergetAllCommand(IHystrixCommandOptions options,IUserService userService)
            : base(options)
        {
            _userService = userService;
            IsFallbackUserDefined = true;
        }
        public async Task<List<User>> getAll()
        {
            return await ExecuteAsync();
        }
        protected override async Task<List<User>> RunAsync()
        {
            var result = await _userService.getAll();
            return result;
        }

        /// <summary>
        /// 回退方法
        /// </summary>
        /// <returns></returns>
        protected override async Task<List<User>> RunFallbackAsync()
        {
            return null;
        }
    }
}