using System.Diagnostics;

namespace FiksHomeWork;

static class Util
{
    public static string GetRandomString(string[] strings) {
        return strings[Program.random.Next(0, strings.Length - 1)];
    }

    public async static void OpenProgram(string path) {
        ProcessStartInfo startInfo = new();
        startInfo.FileName = path;

        using (Process proc = Process.Start(startInfo))
        await proc.WaitForExitAsync();
    }

    public static string GetOurFolder() {
        try {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            return Path.GetDirectoryName(path);
        } catch (Exception) {
            return @"C:\";
        }
    }
}