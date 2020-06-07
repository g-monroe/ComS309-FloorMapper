using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Floor_Plan_Mapper.Screens
{
    public partial class frmMapper : Form
    {
        public frmMapper()
        {
            InitializeComponent();
        }
        public Image img = null;
        public string buildingName = "Gilman";
        public string floor = "1";
        private void frmMapper_Load(object sender, EventArgs e)
        {
            studio.Image = img;
            studio.BuildingName = buildingName;
            studio.FloorNumber = floor;
        }
        
    }
}
