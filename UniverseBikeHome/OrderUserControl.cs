using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeLibrary.BLL.Interfaces;
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
        private readonly IAccountService service;
        private Order order;
        private readonly IOrderService orderService;

        public OrderUserControl(Order order)
        {
            InitializeComponent();
            this.service = Program.ServiceProvider.GetRequiredService<IAccountService>(); 
            this.orderService = Program.ServiceProvider.GetRequiredService<IOrderService>();



            this.order = order;
            
            SetUp();
        }

        public void SetUp()
        {
            Account acc = service.GetAccountByid(order.GetAccid());
            acc = service.GetShippingInformation(acc);
            if(order.GetStatus() == "shipped")
            {
                btnComplete.Hide();
            }
            lblOrder.Text = order.GetId().ToString();
            lblAddrress.Text = acc.GetShippingInfo().Address;
            lblPostal.Text = acc.GetShippingInfo().PostalCode;
            lblName.Text = acc.GetShippingInfo().Name;
            lblLastName.Text = acc.GetShippingInfo().LastName;
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
            orderService.UpdateStatus(order);
			Orders home = (Orders)this.ParentForm;
			home.FillOrders();
		}

    }
}
