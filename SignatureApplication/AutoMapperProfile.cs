using AutoMapper;
using SignatureApplication.Organizations.Query.GetOrganizationList;
using SignatureApplication.Organizations.ViewModels;
using SignatureApplication.Users.Query.GetUserList;
using SignatureApplication.Users.ViewModels;
using SignatureDomain.Entities;

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
            
            CreateMap<User, DetailsUserViewModel>();
            CreateMap<DetailsUserViewModel, User>();
            
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
            
            CreateMap<User, UserVm>();
            CreateMap<UserVm, User>();

            CreateMap<Organization, CreateOrganizationViewModel>();
            CreateMap<CreateOrganizationViewModel, Organization>();
            
            CreateMap<Organization, DetailsOrganizationViewModel>();
            CreateMap<DetailsOrganizationViewModel, Organization>();
            
            CreateMap<Organization, DetailsOrganizationViewModel>();
            CreateMap<DetailsOrganizationViewModel, Organization>();
            
            CreateMap<Organization, UpdateOrganizationViewModel>();
            CreateMap<UpdateOrganizationViewModel, Organization>();
            
            CreateMap<Organization, OrganizationVm>();
            CreateMap<OrganizationVm, Organization>();
        }
    }
}
