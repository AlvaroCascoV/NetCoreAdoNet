using NetCoreAdoNet.Forms;

namespace NetCoreAdoNet
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Forms.Form01PrimerAdo());
            //Application.Run(new Form02BuscadorEmpleados());
            //Application.Run(new Form03EliminarEnfermo());
            //Application.Run(new Form04EliminarPlantilla());
            Application.Run(new Form05UpdateSalas());
        }
    }
}