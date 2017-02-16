using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsStore.Controls
{
    public class VInput : WebControl
    {
        public string NameSpace { get; set; } = "SportsStore.Models";
        public string Model { get; set; } = "Order";

        public string Property { get; set; }
        
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Id, Property.ToLower());
            output.AddAttribute(HtmlTextWriterAttribute.Name, Property.ToLower());

            var modelType = Type.GetType($"{NameSpace}.{Model}");
            var propertyInfo = modelType?.GetProperty(Property);

            var attr = propertyInfo.GetCustomAttribute<RequiredAttribute>(false);

            if (attr != null)
            {
                output.AddAttribute("data-val", "true");
                output.AddAttribute("data-val-required", attr.ErrorMessage);
            }

            output.RenderBeginTag("input");
            output.RenderEndTag();
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
        }
    }
}
