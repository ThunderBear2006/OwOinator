namespace FiksHomeWork;

static class Program
{
    public static bool Safety = true;
    public static int HeadsCut = 1;
    public static readonly Random random = new();
    public static string DefaultURL = "https://us.rule34.xxx//samples/7796/sample_79712b63b53e08560b18ea40404c8195.jpg?8901861";
    public static System.Windows.Forms.Timer TickTimer = new System.Windows.Forms.Timer();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        if (args.Contains("-safe"))
            Safety = true;

        TickTimer.Interval = 1;

        OwOinator.Init();
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1(DefaultURL));
    }
}