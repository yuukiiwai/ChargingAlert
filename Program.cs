using System;
using System.Windows.Forms;

namespace ChargingAleart
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            new Tray();
            Application.Run();
        }

        
    }
}
