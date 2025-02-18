﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BikeDataLibrary;
using BikeClassLibrary;


namespace UniverseBikeHome
{
	public partial class HomePage : Form
	{
		public static Inventory shopInventory;

		public static DBBikes dbhelper;

		public static int nrOfPage = 1;

		public HomePage()
		{
			InitializeComponent();
			dbhelper = new DBBikes();
			shopInventory = new Inventory();
			shopInventory.SetBikes(dbhelper.GetAllBikes());
			FillWithbikes(nrOfPage);
		}

		private void btnAddBike_Click(object sender, EventArgs e)
		{
			AddForm form = new AddForm();
			form.Show();
		}

		public void FillWithbikes(int nrofpage)
		{
			shopInventory.SetBikes(dbhelper.GetAllBikes());
			List<Bike> bikesforpage = shopInventory.GetBikesForPage(nrofpage);
			BikeUserControl ucbike;
			BikeContainer.Controls.Clear();
			if (bikesforpage != null)
			{
				for (int i = 0; i < bikesforpage.Count; i++)
				{
					ucbike = new BikeUserControl(bikesforpage[i]);
					BikeContainer.Controls.Add(ucbike);
				}
			}
			if (shopInventory.GetBikesForPage(nrOfPage + 1) == null)
			{
				btnNext.Hide();
			}
			else
			{
				btnNext.Show();
			}

			if(nrOfPage == 1)
			{
				btnPrevious.Hide();
			}	
		}

		private void btnRefreh_Click(object sender, EventArgs e)
		{
			FillWithbikes(nrOfPage);
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			nrOfPage++;
			FillWithbikes(nrOfPage);
			btnPrevious.Show();
		}

		private void btnPrevious_Click(object sender, EventArgs e)
		{
			nrOfPage--;
			FillWithbikes(nrOfPage);
			btnNext.Show();
		}
	}
}
