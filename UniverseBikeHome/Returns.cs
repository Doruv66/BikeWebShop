using BikeLibrary.BLL;
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
    public partial class Returns : Form
    {
        public ReturnService ReturnService { get; set; }
        public Returns()
        {
            InitializeComponent();
            ReturnService = new ReturnService(Program.ServiceProvider.GetRequiredService<IReturnRepository>());
            FillReturns();
        }

        public void FillReturns()
        {
            ReturnUserControl ucreturn;
            ReturnPanel.Controls.Clear();
            foreach (var ret in ReturnService.GetAllReturns())
            {

                ucreturn = new ReturnUserControl(ret);
                ReturnPanel.Controls.Add(ucreturn);

            }
        }
    }
}
