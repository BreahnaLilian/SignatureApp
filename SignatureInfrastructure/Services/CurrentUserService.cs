using Microsoft.AspNetCore.Http;
using SignatureApplication.Common.Interfaces;
using SignatureInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SignatureInfrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            string userId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            bool isValidGuid = Guid.TryParse(userId, out Guid guid);
            if (isValidGuid)
            {
                UserId = guid;
                Firstname = userId;
                Firstname = httpContextAccessor.HttpContext?.User?.FindFirst("Firstname").Value;
                Lastname = httpContextAccessor.HttpContext?.User?.FindFirst("Lastname").Value;
                Email = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email).Value;
                MobilePhone = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.MobilePhone).Value;
                IsAuthenticated = isValidGuid;
            }

        }

        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Guid UserId { get; }
        public bool IsAuthenticated { get; }
    }
}
