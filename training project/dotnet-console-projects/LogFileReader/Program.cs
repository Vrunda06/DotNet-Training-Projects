using System;
using System.IO;
using System.Linq;

namespace LogFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var logPath = \"sample.log\";
            if (!File.Exists(logPath))
            {
                Console.WriteLine(\"Sample log not found. Creating sample.log...\");
                File.WriteAllLines(logPath, new[] {
                    \"2025-08-20 10:00:00 INFO Starting application\",
                    \"2025-08-20 10:01:05 WARN Low disk space\",
                    \"2025-08-20 10:02:10 ERROR Failed to connect to DB\",
                    \"2025-08-20 10:03:55 INFO Processing request\",
                    \"2025-08-20 10:04:01 ERROR Timeout occurred\"
                });
            }

            Console.WriteLine(\"Log File Reader - Filters: INFO, WARN, ERROR. Type 'q' to quit.\");

            while (true)
            {
                Console.Write(\"Enter filter (INFO/WARN/ERROR/ALL) or 'q': \");
                var input = Console.ReadLine()?.ToUpper();
                if (input == \"Q\") break;
                var lines = File.ReadAllLines(logPath);
                var filtered = input switch
                {
                    \"ALL\" => lines,
                    \"INFO\" => lines.Where(l => l.Contains(\"INFO\")).ToArray(),
                    \"WARN\" => lines.Where(l => l.Contains(\"WARN\")).ToArray(),
                    \"ERROR\" => lines.Where(l => l.Contains(\"ERROR\")).ToArray(),
                    _ => new string[0]
                };
                Console.WriteLine($\"\\n--- Showing {filtered.Length} lines ---\");
                foreach (var l in filtered) Console.WriteLine(l);
                Console.WriteLine();
            }
        }
    }
}
