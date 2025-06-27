namespace AT_C__2.Utils
{
    public class Log
    {
        public static void LogToConsole(string mensagem)
        {
            Console.WriteLine($"[Console] {mensagem}");
        }

        public static void LogToFile(string mensagem)
        {
            File.AppendAllText("log.txt", $"[Arquivo] {DateTime.Now}: {mensagem}\n");
        }

        public static List<string> ListaDeLogs { get; } = new();
        public static void LogToMemory(string mensagem)
        {
            ListaDeLogs.Add($"[Memória] {DateTime.Now}: {mensagem}");
        }
    }
}
