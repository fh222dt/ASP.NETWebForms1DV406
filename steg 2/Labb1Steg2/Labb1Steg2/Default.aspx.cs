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
            if (query == null)
            {
                BigImage.ImageUrl = "img/dock.jpg";
            }
            else if (query == "")
            {
                BigImage.ImageUrl = "img/dock.jpg";
            }
            else
            {
                BigImage.ImageUrl = "img/" + query;
            }

            //visa rättmeddelande om uppladdat
            if (Session["upload"] != null)
            {
                SuccessPlaceHolder.Visible = true;
                Session["upload"] = null;
            }

            //visa felmeddelande om uppladdning ej går igenom
            if (Session["fail"] != null)
            {
                var uploadError = new CustomValidator();
                uploadError.IsValid = false;
                uploadError.ErrorMessage = "Ett fel inträffade vid uppladdningen";
                Validators.Add(uploadError);

                Session["fail"] = null;
            }

        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //finns bild
                if (galleryFileUpload.HasFile)
                {
                    Gallery pic = new Gallery();
                    
                    //parametrar för att spara bild
                    var content = galleryFileUpload.FileContent;
                    var name = galleryFileUpload.FileName;
                    
                    //spara bild
                    var imageFN = pic.SaveImage(content, name);     

                    if (imageFN == "" ) 
                    {
                        //felmeddel vid uppladdning som misslyckas
                        Session["fail"] = true;
                        
                    }

                    else {
                        //rättmeddelande vid uppladdning                        
                        Session["upload"] = true;
                    }
                                                            
                    //ladda om sidan med ny url
                    Response.Redirect("?name=" + imageFN);
                }

            }
        }

        //protected void Page_Error(object sender, EventArgs e)
        //{
        //    // Get last error from the server
        //    Exception exc = Server.GetLastError();

        //    if (exc is ArgumentException)
        //    {
        //        //felmeddel vid uppladdning som misslyckas
        //        var uploadError = new CustomValidator();
        //        uploadError.ValidationGroup = "Main";
        //        uploadError.IsValid = false;
        //        uploadError.ErrorMessage = "Ett fel inträffade vid uppladdningen";
        //        Validators.Add(uploadError);

        //        // Clear the error from the server
        //        Server.ClearError();
        //    }

        //}


        protected void thumbsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var thumb = e.Item.FindControl("ThumbImage") as Image;
            var url = thumb.ImageUrl;
            var query = Request.QueryString["name"];

            //om tom = sidan laddas för 1a gången med dock.jpg
            if (query == null)
            {
                query = "Dock.jpg";                
            }

            //är query & thumbs samma
            if (url.Contains(query))
            {
                thumb.CssClass = "thumbs marked";
            }


        }
    }
}