using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        var rng = new Random(1);
        bool firstTick = true;

        string? line;
        while ((line = Console.ReadLine()) != null)
        {
            JsonDocument? doc = null;
            try { doc = JsonDocument.Parse(line); } catch { continue; }

            if (firstTick)
            {
                var root = doc.RootElement;
                string w = "?";
                string h = "?";
                if (root.TryGetProperty("config", out var cfg))
                {
                    if (cfg.TryGetProperty("width", out var we) && we.ValueKind == JsonValueKind.Number)  w = we.ToString();
                    if (cfg.TryGetProperty("height", out var he) && he.ValueKind == JsonValueKind.Number) h = he.ToString();
                }
                Console.Error.WriteLine($"Random walker (C#) launching on a {w}x{h} map");
            }

            string[] moves = { "N", "S", "E", "W" };
            Console.WriteLine(moves[rng.Next(4)]);
            Console.Out.Flush();

            firstTick = false;
            doc?.Dispose();
        }
    }
}
