using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using MyProject.Authorization.Roles;

namespace MyProject.Contacts.Dto
{
    public class ContactDto : EntityDto<int>
    {
        public string Name { get; set; }

    }
}
