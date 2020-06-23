using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing.Imaging;

namespace VentureRealEstateMockUp.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    int intSizeLimit = 1048576;

                    if (file.ContentLength <= intSizeLimit)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        string filePath = Path.Combine(Server.MapPath("~/tempImages"), fileName);

                        //Start image type validation
                        System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);
                        if (ImageFormat.Jpeg.Equals(img.RawFormat))
                        {
                            //Then it is a jpeg

                            ViewBag.type = "That was a jpeg file.";
                        }
                        else if (ImageFormat.Gif.Equals(img.RawFormat))
                        {
                            //Then it is a gif

                            ViewBag.type = "That was a gif file.";
                        }
                        else if (ImageFormat.Bmp.Equals(img.RawFormat))
                        {
                            //Then it is a bmp

                            ViewBag.type = "That was a bmp file.";
                        }
                        else if (ImageFormat.Png.Equals(img.RawFormat))
                        {
                            //Then it is a png

                            ViewBag.type = "That was a png file.";
                        }
                        else if (ImageFormat.Tiff.Equals(img.RawFormat))
                        {
                            //Then it is a tiff

                            ViewBag.type = "That was a tiff file.";
                        }
                        else
                        {
                            ViewBag.msg = "Nope...I don't like this...NOT A VALID IMAGE type";
                        }

                        file.SaveAs(filePath);
                        ViewBag.msg = "Uploaded file saved successfully";
                    }
                    else
                    {
                        ViewBag.msg = "Uploaded file exceeds size max.";
                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Uploaded File NOT Saved Successfully " + ex.Message;

                return View();
            }
        }

        [HttpGet]
        public ActionResult MoveFile()
        {
            getImages();
            return View();
        }

        [HttpPost]
        public ActionResult MoveFile(List<string> myList)
        {
            ViewBag.fileName = myList[0]; //get the selected item from the list

            return View("MoveFileDisplay"); //return a different view by name
        }

        public ActionResult ApproveFile(string fileToApprove, string looks)
        {
            if (!String.IsNullOrEmpty(fileToApprove) && looks == "good")
            {
                string sourceFile = Server.MapPath("~/tempImages/" + fileToApprove);
                string destinationFile = Server.MapPath("~/Content/images/") + fileToApprove;
                if (!System.IO.File.Exists(destinationFile))
                {
                    System.IO.File.Move(sourceFile, destinationFile);

                    ViewBag.Msg = "File Successfully Moved...";
                }
                else
                {
                    ViewBag.Msg = "File Exists with that name...please resolve the issue";
                }
            }
            else
            {
                string sourceFile = Server.MapPath("~/tempImages/" + fileToApprove);
                string destFile = Server.MapPath("~/filesToDelete/") + fileToApprove;

                System.IO.File.Move(sourceFile, destFile);
                // System.IO.File.Delete(sourceFile); //if you really wanted to delete it.
                ViewBag.Msg = "Ok, if it is that bad...we have scheduled it for deletion.";
            }
            return View("MoveFileDisplay");
        }

        private void getImages()
        {
            //pull out the images from the filesystem

            //Server.MapPath returns the full absolute path from a relative path
            string strFolderPath = Server.MapPath("~/tempImages");

            if (Directory.Exists(strFolderPath))
            {
                //create an array of the files found in the directory at the specified path
                string[] fileEntries = Directory.GetFiles(strFolderPath);

                // Process the list of files found in the directory.
                string fileName = null; //create this variable for later

                string[] myList = new string[fileEntries.Count()]; //make an array of the proper size
                int i = 0; //initialize counter

                foreach (string f in fileEntries)
                {
                    fileName = Path.GetFileName(f);
                    myList[i++] = fileName;
                }
                SelectList list = new SelectList(myList); //create a selectlist populated from array
                ViewBag.myList = list;
            }
            else
            {
                ViewBag.Msg = "Directory does not exist";
            }
        }
    }
}