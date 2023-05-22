using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChargingAleart
{
    public partial class Tray : Form
    {
        NotifyIcon notifyIcon;
        Alert alert;
        public Tray()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.SetComponents();

            Timer timer = new Timer();
            timer.Tick += new EventHandler(CheckControle);
            timer.Interval = 1000;
            timer.Start();
        }

        private void Tray_Load(object sender, EventArgs e)
        {
            
        }

        private void SetComponents()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon(@"./favicon.ico");
            notifyIcon.Visible = true;
            notifyIcon.Text = "ChargingAlert";

            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            
            ToolStripMenuItem MenuItem_Exit = new ToolStripMenuItem();
            MenuItem_Exit.Text = "Exit";
            MenuItem_Exit.Click += MenuItemExit_Click;
            contextMenuStrip.Items.Add(MenuItem_Exit);

            ToolStripMenuItem MenuItem_TestBoot = new ToolStripMenuItem();
            MenuItem_TestBoot.Text = "Alert Test";
            MenuItem_TestBoot.Click += TestBoot_Click;
            contextMenuStrip.Items.Add(MenuItem_TestBoot);

            notifyIcon.ContextMenuStrip = contextMenuStrip;
        }

        public void CheckControle(object sender, EventArgs e)
        {
            if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline)
            {
                if(this.alert == null)
                {
                    this.alert = new Alert();
                    this.alert.Show();
                }
            }
            else if(alert != null)
            {
                this.alert.Close();
                this.alert = null;
            }
        }

        private void TestBoot_Click(object sender, EventArgs e)
        {
            Alert alert = new Alert();
            alert.Show();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
