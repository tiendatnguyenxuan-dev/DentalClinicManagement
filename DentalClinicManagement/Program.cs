using System;
using System.Windows.Forms;
using DentalClinicManagement;

namespace GUI_DCM
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormLogin());
        }
    }
}
