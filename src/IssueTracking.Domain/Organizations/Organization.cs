using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace IssueTracking.Organizations
{
    public class Organization :  Entity<Guid>
    {
        public string Name { get; set; } = string.Empty;


    }
}