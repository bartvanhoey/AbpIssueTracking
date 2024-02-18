using System;
using Volo.Abp;

namespace IssueTracking.Issues
{
    public class IssueStateException :  BusinessException
    {
        public IssueStateException(string code) : base(code) { }
    }
}