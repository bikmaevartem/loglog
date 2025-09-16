namespace LogLog.Console.Shell
{
    public class PrintService
    {
        public static void PrintInfo(string value)
        {
            System.Console.Write(value);
        }

        public static void PrintInfoLn(string value)
        {
            System.Console.WriteLine(value);
        }

        public static void PrintWarning(string value)
        {
            System.Console.Write(value);
        }

        public static void PrintWarningLn(string value)
        {
            System.Console.WriteLine(value);
        }
    }
}
