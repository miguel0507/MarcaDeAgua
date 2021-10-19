using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarcaDeAguaWeb
{
    public partial class EjemploMarcaAgua : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Upload(object sender, EventArgs e)
        {
            string watermarkText = "Prueba - Marca de Agua";

            //Se obtiener el nombre del archivo
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

            //Se lee el archivo en un Bitmap
            using(Bitmap bmp = new Bitmap(FileUpload1.PostedFile.InputStream, false))
            {
                using(Graphics grp = Graphics.FromImage(bmp))
                {
                    //Se setea el color del texto de la marca de agua
                    Brush brush = new SolidBrush(Color.Black);

                    //Se setea la fuente y su tamaño
                    Font font = new Font("Courier New", 30, FontStyle.Bold, GraphicsUnit.Pixel);

                    //Determina el tamaño del texto de la marca de agua
                    SizeF textSize = new SizeF();
                    textSize = grp.MeasureString(watermarkText, font);

                    //Se asigna la posicion del texto en la imagen y se inserta
                    //Se pueden agregar distintas posiciones para el texto
                    Point position = new Point((bmp.Width - ((int)textSize.Width)), (bmp.Height - ((int)textSize.Height + 10)));
                    grp.DrawString(watermarkText, font, brush, position);

                    using(MemoryStream memoryStream= new MemoryStream())
                    {
                        //Se guarda la imagen con marca de agua en un memory stream
                        bmp.Save(memoryStream, ImageFormat.Jpeg);
                        memoryStream.Position = 0;

                        //Se convierte a base64 para insertar en etiqueta de imagen y se muestre en navegador
                        byte[] bytes;
                        bytes = memoryStream.ToArray();
                        string base64 = Convert.ToBase64String(bytes);
                        ImagenMarcaAgua.Visible = true;
                        ImagenMarcaAgua.ImageUrl = string.Concat("data:image/jpeg;base64,",
                            base64);
                    }
                }
            }
        }
    }
}