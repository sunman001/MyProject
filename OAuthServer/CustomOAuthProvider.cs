using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace OAuthServer
{
    /// <summary>
    /// 重写客户端验证授权方法
    /// </summary>
    public class CustomOAuthProvider: OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId;
            string clientSecret;
            if (!context.TryGetBasicCredentials(out clientId,out clientSecret)) //通过TryGetBasicCredentials获取判断是否有值
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);//如没有，通过TryGetFormCredentials获取客户端信息
            }
            if (context.ClientId==null)//如ClientId为空
            {
                context.SetError("客户端信息为空", "客户端ID为空");
                return Task.FromResult<object>(null);
            }
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            Thread.Sleep(3000);

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);//集合标识和制定身份验证
            identity.AddClaim(new Claim(ClaimTypes.Name,"张三"));
            identity.AddClaim(new Claim("adm_id", "1"));
            identity.AddClaim(new Claim("adm_typ", "超级管理员"));

            var props = new AuthenticationProperties(
                new Dictionary<string, string>
                {
                    {"audience",context.ClientId??string.Empty },
                    {"secret_key","IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw" },
                    {"issuer","dunxingpay" }
                });
            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            return Task.FromResult<object>(null);
         }


    }
}