using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChargingAleart
{
    public partial class Alert : Form
    {
        SoundPlayer simpleSound;
        public Alert()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            simpleSound = new SoundPlayer(@"./alertvoice.wav");
            simpleSound.PlayLooping();
        }

        private void Alert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline)
            {
                e.Cancel = true;
            }

            simpleSound.Stop();
            simpleSound = null;
        }
    }
}
