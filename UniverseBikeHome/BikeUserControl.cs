using BikeClassLibrary;
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

namespace UniverseBikeHome
{
	public partial class BikeUserControl : UserControl
	{
		public Bike bike;
		public BikeUserControl(Bike _bike)
		{
			InitializeComponent();
			bike = _bike;
		}

		private void BikeUserControl_Load(object sender, EventArgs e)
		{
			lblStock.Text = bike.GetStock().ToString();
			pbBike.Image = ConvertBytesToImage(bike.GetImageData());
			lblBrand.Text = bike.GetBrand();
			lblPrice.Text = bike.GetPrice().ToString();
		}

		public Image ConvertBytesToImage(byte[] imageData)
		{
			using (MemoryStream ms = new MemoryStream(imageData))
			{
				return Image.FromStream(ms);
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			HomePage.dbhelper.DeleteBike(bike.GetId());
			HomePage home = (HomePage)this.ParentForm;
			home.FillWithbikes(HomePage.nrOfPage);
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			UpdateBikeForm form = new UpdateBikeForm(bike);
			form.Show();
		}
	}
}
