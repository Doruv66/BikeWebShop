using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeLibrary.BLL.Interfaces;
using BikeLibrary.DBL;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly OrderService orderService;

        public OrderUserControl(Order order)
        {
            InitializeComponent(); 
            this.orderService = new OrderService(Program.ServiceProvider.GetRequiredService<IOrderRepository>());
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
            lblAddrress.Text = order.GetShipping().GetAddrress();
            lblPostal.Text = order.GetShipping().GetPostalCode();
            lblName.Text = order.GetShipping().GetName();
            lblLastName.Text = order.GetShipping().GetLastName();
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
            orderService.UpdateStatus(order.GetId(), "shipped");
			Orders home = (Orders)this.ParentForm;
			home.FillOrders();
		}

    }
}
