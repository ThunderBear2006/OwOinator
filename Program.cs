namespace FiksHomeWork;

static class Program
{
    public static bool Safety = true;
    public static int HeadsCut = 1;
    public static readonly Form1[] Heads = Array.Empty<Form1>();
    public static readonly Random random = new();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        if (args.Contains("-safe"))
            Safety = true;

        OwOinator.Init();
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}