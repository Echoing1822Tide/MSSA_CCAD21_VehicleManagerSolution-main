using System.Text;

namespace ConsoleHelpers
{
    public static class MenuGenerator
    {
        // Simple 4-parameter version used everywhere
        public static string GenerateMenu(string menuHeader, string menuPrompt, string[] menuLines, int lineLength)
        {
            var sb = new StringBuilder();
            sb.AppendLine(new string('*', lineLength));
            sb.AppendLine($"* {menuHeader}".PadRight(lineLength - 1) + "*");
            sb.AppendLine(new string('*', lineLength));
            sb.AppendLine($"* {menuPrompt}".PadRight(lineLength - 1) + "*");
            sb.AppendLine($"*{new string('-', lineLength - 2)}*");
            for (int i = 0; i < menuLines.Length; i++)
            {
                sb.AppendLine($"* {i + 1}) {menuLines[i]}".PadRight(lineLength - 1) + "*");
            }
            sb.AppendLine(new string('*', lineLength));
            return sb.ToString();
        }

        public static string GenerateMenu(string menuHeader, string menuPrompt, System.Collections.Generic.List<string> menuOptions, int lineLength)
            => GenerateMenu(menuHeader, menuPrompt, menuOptions.ToArray(), lineLength);
    }
}
