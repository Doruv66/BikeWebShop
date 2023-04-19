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
    public partial class Orders : Form
    {
        public IOrderService orderService;
        public Orders()
        {
            InitializeComponent();
            orderService = Program.ServiceProvider.GetRequiredService<IOrderService>();
            cbStatus.SelectedIndex = 0;
            FillOrders();
        }

        public void FillOrders()
        {
            OrderUserControl ucorder;
            OrderPanel.Controls.Clear();
            foreach (var order in orderService.GetOrdersByStatus((string)cbStatus.SelectedItem))
            {

                ucorder = new OrderUserControl(order);
                OrderPanel.Controls.Add(ucorder);
                
            }
        }

		private void Orders_Load(object sender, EventArgs e)
		{
            FillOrders();
		}

		private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			FillOrders();
		}
	}
}
