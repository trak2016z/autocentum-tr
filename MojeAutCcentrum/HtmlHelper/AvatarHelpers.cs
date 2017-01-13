using MojeAutCcentrum.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MojeAutCcentrum.HtmlHelper
{
    public static class AvatarHelpers
    {

        public static MvcHtmlString AvatarImg(this System.Web.Mvc.HtmlHelper html,
        string UserId)
        {

            StringBuilder result = new StringBuilder();
            Connection db = Connection.Create();
            var Avatar = db.Avatar.FirstOrDefault(x => x.UserId == UserId);
            if (Avatar != null)
            {
                var image = Convert.ToBase64String(Avatar.Fream, 0, Avatar.Fream.Length);
                TagBuilder tagdiv = new TagBuilder("div");
                TagBuilder tagImg = new TagBuilder("img");
                tagImg.MergeAttribute("src", "data:image/jpeg;base64," + image);
                tagImg.MergeAttribute("width", "30");
                tagImg.MergeAttribute("height", "30");
                tagdiv.InnerHtml = tagImg.ToString();
                tagdiv.AddCssClass("btn");
                tagdiv.MergeAttribute("style", "margin-top: 5px;");
                result.Append(tagdiv.ToString());
            }
            

            return MvcHtmlString.Create(result.ToString());
        }
    }
}