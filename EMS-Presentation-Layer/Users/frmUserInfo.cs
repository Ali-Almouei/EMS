using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS_Presentation_Layer.Classes;

namespace EMS_Presentation_Layer.Users
{
    public partial class frmUserInfo : Form
    {
        private int _UserID;
        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            if(!clsGlobal.CurrentUser.IsAdmin)
            {
               if ((clsGlobal.CurrentUser.Permissions & 1) != 1)
               {
                    ctrlUserCardInfo1.HideEditLabel();
               }

            }
            
            ctrlUserCardInfo1.LoadUserInfo(_UserID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
