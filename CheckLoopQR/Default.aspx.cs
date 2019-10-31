using System;
using System.Drawing;
using System.IO;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CheckLoopQR
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.checkTextAll.Text = " Check All";
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string code = txtQRCode.Text;
            long num = Convert.ToInt64(code);

            int i;

            for (i = 1; i < 4; i++)
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

            string[] texture = { "Selected Item Text1 : ", "Selected Item Text2 : ", "Selected Item Text3 : " };
            int a = 0;

            foreach (ListItem listItem in CheckBox1.Items)
            {
                if (listItem.Selected)
                {
                    a++;

                    string code = listItem.Text;

                    CheckBox1.Visible = false;
                    checkAll.Visible = false;
                    checkTextAll.Visible = false;

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

                    Label lblvalues = new Label();
                    lblvalues.Text += texture[a-1] + listItem.Text;
                    lblvalues.Font.Size = FontUnit.Large;
                    Label lblvalues2 = new Label();
                    lblvalues2.Text += texture[a-1] + listItem.Text;
                    lblvalues2.Font.Size = FontUnit.Large;
                    Label lblvalues3 = new Label();
                    lblvalues3.Text += texture[a-1] + listItem.Text;
                    lblvalues3.Font.Size = FontUnit.Large;

                    using (Bitmap bitMap = barcodeWriter.Write(code))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                        }
                        PlaceHolder1.Controls.Add(imgBarCode);
                        PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));
                        PlaceHolder1.Controls.Add(lblvalues);
                        PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));
                        PlaceHolder1.Controls.Add(lblvalues2);
                        PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));
                        PlaceHolder1.Controls.Add(lblvalues3);
                        PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));
                    }
                }
                else
                {
                    //do something else 
                }
            }
        }
    }
}