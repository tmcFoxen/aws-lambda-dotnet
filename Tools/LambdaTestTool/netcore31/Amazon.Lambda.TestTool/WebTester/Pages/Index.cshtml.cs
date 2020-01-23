using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Amazon.Lambda.TestTool.Services;
using Amazon.Lambda.TestTool.WebTester.SampleRequests;

namespace Amazon.Lambda.TestTool.WebTester.Pages
{
    public class IndexModel : PageModel
    {
        public LocalLambdaOptions LambdaOptions { get; set; }

        public IList<string> AWSProfiles { get; set; }
        
        public IDictionary<string, IList<LambdaRequest>> SampleRequests { get; set; }


        public IndexModel(LocalLambdaOptions lambdaOptions)
        {
            this.LambdaOptions = lambdaOptions;

            var externalManager = new AWSServiceImpl();
            this.AWSProfiles = externalManager.ListProfiles();
        }

        public void OnGet()
        {
            this.SampleRequests = new SampleRequestManager(LambdaOptions.PreferenceDirectory).GetSampleRequests();
        }
    }
}