

using Castle.DynamicProxy;
using Core;
using Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business 
{
    //for jwt
    public class SecuredOperation:MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccesor;

        public SecuredOperation(string roles)
        {
            _roles=roles.Split(',');
            _httpContextAccesor=ServiceTool.ServiceProvider.GetService<IHttpContextAccessor> ();
            
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccesor.HttpContext.User.ClaimRoles();
            foreach(var role in _roles)
            {
                if(roleClaims.Contains(role))
                    return;
            }
            throw new Exception(Messages.AuthorizationDeniedd);
        }
    }
}
