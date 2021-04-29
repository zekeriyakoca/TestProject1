using System.Linq;
using AutoMapper;
using Abp.Authorization;
using Abp.Authorization.Roles;
using MyProject.Authorization.Roles;

namespace MyProject.Contacts.Dto
{
    public class ContactMapProfile : Profile
    {
        public ContactMapProfile()
        {
            CreateMap<ContactDto, Contact>().ReverseMap();
            CreateMap<ContactListDto, Contact>().ReverseMap();
            CreateMap<CreateContactDto, Contact>().ReverseMap();
        }
    }
}
