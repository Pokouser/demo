using System;
using System.Windows.Forms;
using PolesieUsersApp.forms;

namespace PolesieUsersApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new main());
        }
    }
}
