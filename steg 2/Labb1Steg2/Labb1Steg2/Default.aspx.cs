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

            //visa stora bilden efter vilken querystring som är aktuell
            var query = Request.QueryString["name"];
            if (query != null)
            {
                BigImage.ImageUrl = "img/" + query;
            }

            //markera motsvarande thumb
            //var thumb = thumbsRepeater.FindControl("ThumbImage");
            //var url = thumb.ImageUrl;

            //if (query != null)
            //{
            //    if (url.Contains(query))
            //    {
            //        thumb.CssClass = "marked";
            //    }
            //}
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

                    var imageFN = pic.SaveImage(content, name);

                    //felmeddel vid uppladdning som misslyckas
                        var validator = new CustomValidator();
                        validator.Text = "Ett fel inträffade vid uppladdningen";
                        Validators.Add(validator);

                    //BigImage.ImageUrl = "img/" + imageFN;

                    //visa rättmeddelande vid uppladdning
                    SuccessPlaceHolder.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "fadeOut()", true);

                    //markera thumb

                    
                    //ladda om sidan med ny url
                    Response.Redirect("?name=" + imageFN);
                }

            }
        }

        protected void thumbsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        //    var thumb = e.Item.FindControl("ThumbImage") as Image;
        //    var url = thumb.ImageUrl;
        //    var query = Request.QueryString["name"];

        //    if (url.Contains(query))
        //    {
        //        thumb.CssClass = "marked";
        //    }            
            
        //    //var url = ThumbImage.ImageUrl;

        //    //if (e.CommandName == "bigger")
        //    //{
        //    //    var thumb = e.Item.FindControl("ImageButton") as Image;

        //    //    //markera thumben
        //    //    thumb.CssClass = "marked";

        //    //    BigImage.ImageUrl = "img/" + thumb.ImageUrl;

        //    //}
        }


        protected void thumbsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var thumb = e.Item.FindControl("ThumbImage") as Image;
            var url = thumb.ImageUrl;
            var query = Request.QueryString["name"];

            //thumb.CssClass = "marked";

            //om tom = sidan laddas för 1a gången med dock.jpg
            if (query == null)
            {
                query = "Dock.jpg";                
            }

            if (url.Contains(query))
            {
                thumb.CssClass = "marked";
            }
        }
    }
}