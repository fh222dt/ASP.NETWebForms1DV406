using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Labb1Steg2.App_Code;

namespace Labb1Steg2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            //bind bilderna till repeatern
            var di = new DirectoryInfo(Gallery.PhysicalApplicationPath);
            var files = di.GetFiles();
            thumbsRepeater.DataSource = files;
            thumbsRepeater.DataBind();

            
        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //finns bild
                if (galleryFileUpload.HasFile)
                {
                    Gallery pic = new Gallery();

                    var content = galleryFileUpload.FileContent;
                    var name = galleryFileUpload.FileName;
                    var image = pic.SaveImage(content, name);

                    BigImage.ImageUrl = "img/" + image;

                    //visa rättmeddelande vid uppladdning
                    SuccessPlaceHolder.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "fadeOut()", true);

                    //markera thumb

                    //felmeddel vid uppladdning som misslyckas

                    //Response.Redirect();
                }

            }
        }
        protected void thumbsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "bigger")
            {
                var thumb = e.Item.FindControl("ImageButton") as Image;

                //markera thumben
                thumb.CssClass = "marked";

                BigImage.ImageUrl = "img/" + thumb.ImageUrl;

            }
        }
    }
}