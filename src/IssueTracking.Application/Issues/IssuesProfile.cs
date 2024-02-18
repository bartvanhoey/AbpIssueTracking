using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace IssueTracking.Issues
{
    public class IssuesProfile : Profile
    {
        public IssuesProfile()
        {
            CreateMap<Issue, IssueDto>();
        }
    }
}