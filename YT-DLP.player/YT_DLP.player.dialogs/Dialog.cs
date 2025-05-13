using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YT_DLP.player.dialogs
{
    public partial class Dialog : Form
    {
        public Dialog()
        {
            InitializeComponent();
        }

        private void Dialog_Load(object sender, EventArgs e)
        {
            label1.Text = this.Text;
        }

        private void dlpButtonHighlighted1_Click(object sender, EventArgs e)
        {

        }
    }
}
