using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace IssueTracking
{
    public interface IOrganizationAppService : IApplicationService
    {
        Task<OrganizationDto> CreateAsync(CreateOrganizationDto input);

    }

    public class CreateOrganizationDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }

    public class OrganizationDto
    {
        public string? Name { get; set; }
    }
}