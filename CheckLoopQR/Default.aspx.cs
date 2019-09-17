using System;
using System.Drawing;
using System.IO;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using System.Web.UI.WebControls;

namespace CheckLoopQR
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string code = txtQRCode.Text;
            long num = Convert.ToInt64(code);

            int i;

            for (i = 1; i < 11; i++)
            {
                num += i;
                CheckBox1.Items.Add(new ListItem(" " + num));
            }
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
			if (CheckBox1.SelectedItem == null)
            {
                Response.Redirect("Default.aspx");
            }
			
            string code = CheckBox1.SelectedItem.Text;

            CheckBox1.Visible = false;

            QrCodeEncodingOptions options = new QrCodeEncodingOptions();

            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 150,
                Height = 150,
                Margin = 0,
            };

            var barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            barcodeWriter.Options = options;

            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;

            using (Bitmap bitMap = barcodeWriter.Write(code))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
                PlaceHolder1.Controls.Add(imgBarCode);
            }
        }
    }
}