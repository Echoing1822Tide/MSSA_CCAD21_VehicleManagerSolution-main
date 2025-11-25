using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleHelpers
{
    public static class OutputHelpers
    {
        // Core: build a box with a title and multi-line body (returns a single string)
        public static string BuildBoxed(string title, string body, int width = 78)
        {
            if (width < 10) width = 10;                  // sanity
            int inner = width - 4;                       // account for "* " + " *"

            // split body into lines, no fancy wrap so it stays beginner-friendly
            var lines = (body ?? string.Empty).Replace("\r\n", "\n").Replace('\r', '\n').Split('\n');

            var sb = new StringBuilder();
            sb.AppendLine(new string('*', width));
            sb.AppendLine($"* {Trunc(title, inner).PadRight(inner)} *");
            sb.AppendLine(new string('-', width));

            foreach (var raw in lines)
            {
                var line = Trunc(raw ?? string.Empty, inner);
                sb.AppendLine($"* {line.PadRight(inner)} *");
            }

            sb.AppendLine(new string('*', width));
            return sb.ToString();

            static string Trunc(string s, int max) => s.Length <= max ? s : s[..max];
        }

        // Convenience: print the box directly (no extra Console.WriteLine around this!)
        public static void WriteBoxed(string title, string body, int width = 78)
            => Console.Write(BuildBoxed(title, body, width));

        // Menu-specific helper: numbers get aligned, long options truncated
        public static string BuildMenuBox(string title, IEnumerable<string> options, int width = 78)
        {
            if (width < 14) width = 14;
            int inner = width - 4;

            var sb = new StringBuilder();
            sb.AppendLine(new string('*', width));
            sb.AppendLine($"* {Trunc(title, inner).PadRight(inner)} *");
            sb.AppendLine(new string('-', width));

            int i = 1;
            foreach (var opt in options)
            {
                // Prefix "N) " takes 3–4 chars; pad the rest so the right edge lines up.
                string prefix = $"{i}) ";
                string text   = Trunc(opt ?? string.Empty, inner - prefix.Length);
                sb.AppendLine($"* {prefix}{text.PadRight(inner - prefix.Length)} *");
                i++;
            }

            sb.AppendLine(new string('*', width));
            return sb.ToString();

            static string Trunc(string s, int max) => s.Length <= max ? s : s[..max];
        }
    }
}
