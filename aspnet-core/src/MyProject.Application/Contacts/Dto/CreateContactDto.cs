using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Roles;
using MyProject.Authorization.Roles;

namespace MyProject.Contacts.Dto
{
    public class CreateContactDto
    {
        [Required]
        public string Name { get; set; }

        public CreateContactDto()
        {
        }
    }
}
