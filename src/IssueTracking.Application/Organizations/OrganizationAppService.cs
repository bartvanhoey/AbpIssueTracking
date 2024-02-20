using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IssueTracking.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;
using Volo.Abp.Emailing;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace IssueTracking.Organizations
{
    public class OrganizationAppService(OrganizationManager organizationManager, IPaymentService paymentService, IEmailSender emailSender) : ApplicationService, IOrganizationAppService
    {
        private readonly OrganizationManager organizationManager = organizationManager;
        private readonly IPaymentService paymentService = paymentService;
        private readonly IEmailSender emailSender = emailSender;

        [UnitOfWork(isTransactional: true)] 
        [Authorize(IssueTrackingPermissions.Organizations.Create)]
        public async Task<OrganizationDto> CreateAsync(CreateOrganizationDto input)
        {
            await paymentService.ChargeAsync(CurrentUser.Id, GetOrganizationPrice());
            var organization = await organizationManager.CreateAsync(input.Name);
            await organizationManager.InsertAsync(organization);
            await emailSender.SendAsync("systemadmin@gmail.com", "New Organization", $"A new organization with name {input.Name} created."); 
            return ObjectMapper.Map<Organization, OrganizationDto>(organization);
        }

        private double GetOrganizationPrice() => 42;
    }

    public interface IPaymentService
    {
        Task ChargeAsync(Guid? id, double value);
    }
}