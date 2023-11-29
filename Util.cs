namespace FiksHomeWork;

static class Util
{
    public static string GetRandomString(string[] strings) {
        return strings[Program.random.Next(0, strings.Length - 1)];
    }
}