namespace YT_DLP.player
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.SetColorMode(SystemColorMode.Dark);
            using (var splash = new frm_Splash())
            {
                splash.Show();
                Application.DoEvents();
                Thread.Sleep(1000); // Additional time so winforms doesnt poo itself
                splash.Close();
                Application.Run(new Form1());
            }
        }
    }
}