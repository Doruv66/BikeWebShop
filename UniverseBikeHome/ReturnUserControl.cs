using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeLibrary.DBL;
using BikeLibrary.DBL.Interfaces;
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
    public partial class ReturnUserControl : UserControl
    {
        public Return ret;
        public OrderService service;
        public ReturnService returnservice;
        public Order order;
        public ReturnUserControl(Return ret)
        {
            InitializeComponent();
            this.ret = ret;
            service = new OrderService(Program.ServiceProvider.GetRequiredService<IOrderRepository>());
            returnservice = new ReturnService(Program.ServiceProvider.GetRequiredService<IReturnRepository>());
            order = service.GetOrder(ret.GetOrderId());
            Setup();
        }

       
        public void Setup()
        {
            lblBike.Text = HomePage.shopInventory.GetBike(ret.GetBikeId()).GetBrand();
            lblReason.Text = ret.GetReason();
            lblComment.Text = ret.GetComment();
            foreach(var item in order.GetItems())
            {
                if(item.bikeid == ret.GetBikeId() && item.status != "requested")
                {
                    btnApprove.Hide();
                }
            }
            
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            returnservice.ApproveReturn(ret);
            Returns home = (Returns)this.ParentForm;
            home.FillReturns();
        }
    }
}
