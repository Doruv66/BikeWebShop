using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BikeClassLibrary;

namespace UniverseBikeHome
{
	public partial class UpdateBikeForm : Form
	{
		public Bike bike;

		public UpdateBikeForm(Bike _bike)
		{
			InitializeComponent();
			bike = _bike;
			SetUp();
		}

		public void SetUp()
		{
			lblName.Text = bike.GetBrand();
			txtPrice.Text = bike.GetPrice().ToString();
			txtStock.Text = bike.GetStock().ToString();
			pbNewBike.Image = ConvertBytesToImage(bike.GetImageData());
		}

		public byte[] ConvertImageToBytes(Image image)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				Bitmap bm = new Bitmap(image);
				bm.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
				return ms.ToArray();
			}
			
		}

		public Image ConvertBytesToImage(byte[] imageData)
		{
			using (MemoryStream ms = new MemoryStream(imageData))
			{
				return Image.FromStream(ms);
			}
		}

		private void txtImage_DoubleClick(object sender, EventArgs e)
		{
			using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files|*.png", Multiselect = false })
			{
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					pbNewBike.Image = Image.FromFile(ofd.FileName);
					txtImage.Text = ofd.FileName;
				}
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			HomePage.dbhelper.UpdateBike(bike.GetId(),
				Convert.ToDouble(txtPrice.Text),
				Convert.ToInt32(txtStock.Text),
				ConvertImageToBytes(pbNewBike.Image));
			MessageBox.Show("Updated");
			this.Close();
		}
	}
}
