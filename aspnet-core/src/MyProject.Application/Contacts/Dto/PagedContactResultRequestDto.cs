using Abp.Application.Services.Dto;

namespace MyProject.Contacts.Dto
{
    public class PagedContactResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

