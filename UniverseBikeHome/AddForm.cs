using BikeClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniverseBikeHome
{
	public partial class AddForm : Form
	{
		public AddForm()
		{
			InitializeComponent();
		}

		
		public byte[] ConvertImageToBytes(Image image)
		{
			using(MemoryStream ms = new MemoryStream())
			{
				image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
				return ms.ToArray();
			}
		}

		private void txtImage_DoubleClick(object sender, EventArgs e)
		{
			using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg)|*.jpg;*.jpeg", Multiselect = false })
			{
				if(ofd.ShowDialog() == DialogResult.OK)
				{
					pbNewBike.Image = Image.FromFile(ofd.FileName);
					txtImage.Text = ofd.FileName;
				}
			}
		}

		private void btnAddBike_Click(object sender, EventArgs e)
		{
			try
			{
					if (cbKind.SelectedIndex == 0)
					{
						HomePage.shopInventory.AddBike(new MountainBike(txtBrand.Text,
							Convert.ToDouble(txtPrice.Text),
							Convert.ToInt32(txtStock.Text),
							ConvertImageToBytes(pbNewBike.Image),
							Convert.ToInt32(txtSuspension.Text)));
					}
					if (cbKind.SelectedIndex == 1)
					{
						HomePage.shopInventory.AddBike(new ElectricBike(txtBrand.Text,
							Convert.ToDouble(txtPrice.Text),
							Convert.ToInt32(txtStock.Text),
							ConvertImageToBytes(pbNewBike.Image),
							Convert.ToInt32(txtBattery.Text)));
					}
					if (cbKind.SelectedIndex == 2)
					{
						HomePage.shopInventory.AddBike(new CityBike(txtBrand.Text,
							Convert.ToDouble(txtPrice.Text),
							Convert.ToInt32(txtStock.Text),
							ConvertImageToBytes(pbNewBike.Image),
							GetLights()));
					}
					if (cbKind.SelectedIndex == 3)
					{
						HomePage.shopInventory.AddBike(new TouringBike(txtBrand.Text,
							Convert.ToDouble(txtPrice.Text),
							Convert.ToInt32(txtStock.Text),
							ConvertImageToBytes(pbNewBike.Image),
							Convert.ToInt32(txtBags.Text)));
					}
					ClearText();
			
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public bool GetLights()
		{
			if(rbFalse.Checked)
			{
				return false;
			}
			else
			{
				return true;
			}	
		}

		private void cbKind_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbKind.SelectedIndex == 0)
			{
				lblSuspension.Show();
				txtSuspension.Show();
				lbBags.Hide();
				txtBags.Hide();
				lblBattery.Hide();
				txtBattery.Hide();
				lblLights.Hide();
				rbFalse.Hide();
				rbTrue.Hide();
			}
			if (cbKind.SelectedIndex == 1)
			{
				lblSuspension.Hide();
				txtSuspension.Hide();
				lbBags.Hide();
				txtBags.Hide();
				lblBattery.Show();
				txtBattery.Show();
				lblLights.Hide();
				rbFalse.Hide();
				rbTrue.Hide();
			}
			if (cbKind.SelectedIndex == 2)
			{
				lblSuspension.Hide();
				txtSuspension.Hide();
				lbBags.Hide();
				txtBags.Hide();
				lblBattery.Hide();
				txtBattery.Hide();
				lblLights.Show();
				rbFalse.Show();
				rbTrue.Show();
			}
			if (cbKind.SelectedIndex == 3)
			{
				lblSuspension.Hide();
				txtSuspension.Hide();
				lbBags.Show();
				txtBags.Show();
				lblBattery.Hide();
				txtBattery.Hide();
				lblLights.Hide();
				rbFalse.Hide();
				rbTrue.Hide();
			}
		}
		public void ClearText()
		{
			txtSuspension.Clear();
			txtStock.Clear();
			txtPrice.Clear();
			txtImage.Clear();
			txtBrand.Clear();
			txtBattery.Clear();
			txtBags.Clear();
			pbNewBike.Image = null;
		}
	}
}
