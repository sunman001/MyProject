
using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly:OwinStartup(typeof(OAuthServer.Startup))]
namespace OAuthServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            ConfigurationOAuth(app);
            app.UseWebApi(config);
        }



        /// <summary>
        /// 提供控制授权服务器中间件行为所需的信息  OAuthAuthorizationServerOptions
        /// </summary>
        /// <param name="app"></param>
        public void ConfigurationOAuth(IAppBuilder app )
        {
            //Token生成配置
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
               AccessTokenExpireTimeSpan = TimeSpan.FromHours(8),//访问令牌在颁发后保持有效的时间段。 默认值为 20 分钟。 令牌过期后，客户端应用程序应刷新或获取新的访问令牌。
               AllowInsecureHttp=true,//若要允许授权和令牌请求到达 http URI 地址，并允许传入的 redirect_uri 授权请求参数具有 http URI 地址，则为 True。
               TokenEndpointPath= new PathString("/Token"),//客户端应用程序直接通过 OAuth 协议与之通信的请求路径
               //提供认证策略
                Provider =new CustomOAuthProvider(),
               AuthorizationCodeExpireTimeSpan =TimeSpan.FromMinutes(30),//授权代码在颁发后保持有效的时间段。 默认值为 5 分钟。 此时间跨度还必须考虑到 Web 场中服务器之间的时钟同步，因此值太小可能会导致令牌意外过期。
              // AccessTokenFormat = //用于保护访问令牌中所含信息的数据格式
            };
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
        }
    }
}