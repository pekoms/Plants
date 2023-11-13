using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Plants.Api.Infrastructure.TokenValidation
{
    public class AuthorizationAttributePut : HttpPutAttribute, IAuthorizeData
    {
        public string? Policy { get ; set ; }
        public string? Roles { get ; set ; }
        public string? AuthenticationSchemes { get; set; } = JwtBearerDefaults.AuthenticationScheme;

        public AuthorizationAttributePut(string Template):base(Template) { }
    }
}
