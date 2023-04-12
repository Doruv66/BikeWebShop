using BikeClassLibrary;
using BikeLibrary.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniverseBikeHome
{
    public partial class OrderUserControl : UserControl
    {
        private Order order;
        public OrderUserControl(Order order)
        {
            InitializeComponent();
            this.order = order;
            SetUp();
        }

        public void SetUp()
        {
            if(order.GetStatus() == "shipped")
            {
                btnComplete.Hide();
            }
            lblOrder.Text = order.GetId().ToString();
            lblAddrress.Text = order.GetAddrress();
            lblPostal.Text = order.GetPostalCode();
            lblName.Text = order.GetFirstName();
            lblLastName.Text = order.GetLastName();
            lblStatus.Text = order.GetStatus();
            lblItems.Text = "";
            foreach(var item in order.GetItems())
            {
                Bike bike = HomePage.shopInventory.GetBike(item.bikeid);
                lblItems.Text += $"\r\n brand: {bike.GetBrand()}  quantity:{item.quantity}";
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            foreach(var item in order.GetItems())
            {
                Bike bike = HomePage.shopInventory.GetBike(item.bikeid);
                bike.DecreaseStock(item.quantity);
                HomePage.shopInventory.UpdateBike(bike.GetId(), bike.GetPrice(), bike.GetStock(), bike.GetImageData());
            }
            order.ChangeStatus("shipped");
            //change the status in the data base for the following order 
            OrderService service = new OrderService();
            service.UpdateStatus(order);
			Orders home = (Orders)this.ParentForm;
			home.FillOrders();
		}

    }
}
