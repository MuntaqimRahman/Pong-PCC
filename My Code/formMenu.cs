using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong_PCC
{
    public partial class formMenu : Form
    {
        public formMenu()
        {
            InitializeComponent();
        }

        public void generatePlayForm()
        {
            //Opens play form
            formGame createGame = new formGame();
            createGame.ShowDialog();
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            //Tells form that singleplayer play is occuring and calls method to open new form
            formGame.singlePlayer = true;
            generatePlayForm();
        }

        private void btnTwoPlayer_Click(object sender, EventArgs e)
        {
            //Tells form that singleplayer play is not occuring and calls method to open new form
            formGame.singlePlayer = false;
            generatePlayForm();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            //Opens rules form
            formRules createRules = new formRules();
            createRules.ShowDialog();
        }
    }
}
