using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyProject.Contacts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Contacts
{
    public interface IContactAppService : IAsyncCrudAppService<ContactDto, int, PagedContactResultRequestDto, CreateContactDto, ContactDto>
    {
        Task<ListResultDto<ContactListDto>> GetContactsCustomAsync();
    }
}
