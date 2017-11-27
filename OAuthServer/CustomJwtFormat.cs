using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;

namespace OAuthServer
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        /// <summary>
        /// 用户属性键名
        /// </summary>
        private const string AudiencePropertyKey = "audience";

        /// <summary>
        /// 密钥键名
        /// </summary>
        private const string SecretKey = "secret_key";

        /// <summary>
        /// 发布者
        /// </summary>
        private const string Issuer = "issuer";
        /// <summary>
        /// 受保护的资源方法实现
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Protect(AuthenticationTicket data)
        {
            if (data==null)
            {
                throw  new ArgumentNullException("data");

            }
            var audienceId = data.Properties.Dictionary.ContainsKey(AudiencePropertyKey)
                ? data.Properties.Dictionary[AudiencePropertyKey]
                : null;
            if (string.IsNullOrWhiteSpace(audienceId))
            {
                throw new InvalidOperationException("audienceId is null ");
            }
            var secretKey = data.Properties.Dictionary.ContainsKey(SecretKey)
                ? data.Properties.Dictionary[AudiencePropertyKey]
                : null;
            if (string.IsNullOrWhiteSpace(secretKey))
            {
                throw new InvalidOperationException("secretKey is null");
            }
            var issuer = data.Properties.Dictionary.ContainsKey(Issuer) ? data.Properties.Dictionary[Issuer] : null;
            if (string.IsNullOrWhiteSpace(issuer))
            {
              throw new InvalidOperationException("issuer is null");  
            }
            return GetSignKey(data, secretKey, issuer);
        }
        /// <summary>
        /// 根据密钥生成签名字符串
        /// </summary>
        /// <param name="data">认证票据对象</param>
        /// <param name="secretKey">密钥</param>
        /// <param name="issuer">发布者</param>
        /// <returns></returns>
        public string GetSignKey(AuthenticationTicket data,string secretKey,string issuer)
        {
            var symmetricKeyAsBase64 = secretKey;
            var KeyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);
            var securityKey = new SymmetricSecurityKey(KeyByteArray);
            var signingCredentials=new SigningCredentials(
                securityKey,
                 SecurityAlgorithms.HmacSha256Signature
                );
            var audienceId = data.Properties.Dictionary.ContainsKey(AudiencePropertyKey)
                ? data.Properties.Dictionary[AudiencePropertyKey]
                : null;
            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;
            var tokenExpireHours = 8;
            try
            {
                tokenExpireHours = Convert.ToInt32(ConfigurationManager.AppSettings["TokenExpireHours"]);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            var token = new JwtSecurityToken(issuer,audienceId ,data.Identity.Claims,issued.Value.UtcDateTime ,expires.Value.UtcDateTime.AddHours(tokenExpireHours), signingCredentials);
            var handler=new JwtSecurityTokenHandler();
            var jwt = handler.WriteToken(token);
            return jwt;
        }
        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}