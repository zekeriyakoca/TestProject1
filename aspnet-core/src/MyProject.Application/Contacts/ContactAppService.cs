using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using MyProject.Contacts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;

namespace MyProject.Contacts
{
    [AbpAllowAnonymous()]
    public class ContactAppService : AsyncCrudAppService<Contact, ContactDto, int, PagedContactResultRequestDto, CreateContactDto, ContactDto>, IContactAppService
    {
        public ContactAppService(IRepository<Contact> repository)
           : base(repository)
        {


        }

        public async Task<ListResultDto<ContactListDto>> GetContactsCustomAsync()
        {
            var contacts = await Repository.GetAllListAsync();

            return new ListResultDto<ContactListDto>(ObjectMapper.Map<List<ContactListDto>>(contacts));
        }


        protected override IQueryable<Contact> CreateFilteredQuery(PagedContactResultRequestDto input)
        {
            var result = Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
            return result;
        }
    }
}
