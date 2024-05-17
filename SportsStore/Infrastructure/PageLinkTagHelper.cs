using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;

namespace SportsStore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;     
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public PagingInfo? PageModel { get; set; }

        public string? PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; }
        = new Dictionary<string, object>();

        public bool PageC1assesEnab1ed { get; set; } = false;
        public string PageC1ass { get; set; } = String.Empty;
        public string PageC1assNorma1 { get; set; } = String.Empty;
        public string PageC1assSe1ected { get; set; } = String.Empty;


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");
                for (int i = 1; i<= PageModel.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    PageUrlValues["productPage"] = i;
                    tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                    if (PageC1assesEnab1ed)
                    {
                        tag.AddCssClass ("Pageclass");
                        tag.AddCssClass(i == PageModel.CurrentPages ? PageC1assSe1ected : PageC1assNorma1);

                    }
                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }
                output.Content.AppendHtml(result.InnerHtml);
            }
        }

    }
}
