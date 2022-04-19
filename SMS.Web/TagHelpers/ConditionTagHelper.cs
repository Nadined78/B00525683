using System.Security.Claims;
using Microsoft.AspNetCore.Razor.TagHelpers;

// AMC - a simple tag helper to display content based on condition
namespace SMS.Web.TagHelpers
{
    [HtmlTargetElement(Attributes = "asp-condition")] //nameof(Condition))]
    public class ConditionTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-condition")]
        public bool Condition { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!Condition)
            {
                output.SuppressOutput();
            }
        }
    }
    
}
