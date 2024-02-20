using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Emailing;
using Volo.Abp.Users;

namespace IssueTracking.Organizations
{
    public class OrganizationManager : DomainService
    {
        private readonly IRepository<Organization, Guid> _organizationRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IAuthorizationService _authorizationService;
        private readonly IEmailSender _emailSender;

        public OrganizationManager(IRepository<Organization, Guid> organizationRepository, ICurrentUser currentUser, IAuthorizationService authorizationService, IEmailSender emailSender)
        {
            _authorizationService = authorizationService;
            _emailSender = emailSender;
            _currentUser = currentUser;
            _organizationRepository = organizationRepository;
        }

        public async Task<Organization> CreateAsync(string name)
        {
            if (await _organizationRepository.AnyAsync(x => x.Name == name))
            {
                throw new BusinessException("IssueTracking:DuplicateOrganizationName");
            }

            // await _authorizationService.CheckAsync("OrganizationCreatePermission"); NOT in Domain layer

            // Logger.LogDebug($"Creating organization {name} by {_currentUser.UserName}"); NOT in Domain layer

            var organization = new Organization();

            // await _emailSender.SendAsync("systemadmin@gmail.com", "New Organization", $"A new organization with name {name} created."); NOT in Domain layer
            return organization;
        }

        public async Task InsertAsync(Organization organization)
        {
            var insertedOrganization = await _organizationRepository.InsertAsync(organization, autoSave:true);
        }
    }
}