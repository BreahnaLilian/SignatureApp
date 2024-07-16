using AutoMapper;
using SignatureApplication.Organizations.ViewModels;
using SignatureApplication.Users.ViewModels;
using SignatureDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureApplication
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, CreateUserViewModel>();
            CreateMap<CreateUserViewModel, User>();
            
            CreateMap<User, UpdateUserViewModel>();
            CreateMap<UpdateUserViewModel, User>();
            
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<Organization, CreateOrganizationViewModel>();
            CreateMap<CreateOrganizationViewModel, Organization>();
        }
    }
}
