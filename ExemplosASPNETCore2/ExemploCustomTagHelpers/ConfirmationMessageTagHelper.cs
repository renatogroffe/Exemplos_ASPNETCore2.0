using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Html;

namespace ExemploCustomTagHelpers
{
    [HtmlTargetElement("a", Attributes = ConfirmationAttributeName)]
    public class ConfirmationMessageTagHelper : TagHelper
    {
        private const string ConfirmationAttributeName = "confirmation-message";

        [HtmlAttributeName(ConfirmationAttributeName)]
        public string ConfirmationMessage { get; set; }

        public override void Process(
            TagHelperContext context, TagHelperOutput output)
        {
            if (output.Attributes.Where(
                a => a.Name.ToLower() == "onclick").Count() == 0)
            {
                output.Attributes.Add("onclick",
                    new HtmlString(
                        $"return confirm('{this.ConfirmationMessage}');"));
            }
        }
    }
}