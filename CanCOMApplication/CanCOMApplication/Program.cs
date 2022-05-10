namespace CanCOMApplication
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
            Application.Run(new Form1());
            // Task task1 = Task.Factory.StartNew(() => Application.Run(new Form1()));
            //Task task2 = Task.Factory.StartNew(() => Application.Run(new Form2()));
            //Task.WaitAll(task1, task2);
        }
    }
}