using System.Collections.Generic;
using System.Threading.Tasks;
using Steeltoe.CircuitBreaker.Hystrix;

namespace OrderService.Controllers
{
    public class UsergetPortCommand : HystrixCommand<string>
    {
        private IUserService _userService;
        public UsergetPortCommand(IHystrixCommandOptions options, IUserService userService)
            : base(options)
        {
            _userService = userService;
            IsFallbackUserDefined = true;
        }

        public async Task<string> getPort()
        {
            return await ExecuteAsync();
        }
        protected override async Task<string> RunAsync()
        {
            var result = await _userService.getPort();
            return result;
        }

        /// <summary>
        /// 回退方法
        /// </summary>
        /// <returns></returns>
        protected override async Task<string> RunFallbackAsync()
        {
            return await Task.FromResult("userservice服务断开，方法调用错误!");
        }
    }
}