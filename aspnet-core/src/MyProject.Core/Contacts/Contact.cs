using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Contacts
{
    public class Contact : Entity<int>, IHasCreationTime
    {

        public string Name { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
