using System;
using System.IO;

namespace AristaAPI.Utilities
{
    public static class EnvLoader
    {
        public static void LoadEnv()
        {
            var envFilePath = Path.Combine(Directory.GetCurrentDirectory(), ".env");

            if (!File.Exists(envFilePath))
                return;

            foreach (var line in File.ReadAllLines(envFilePath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var parts = line.Split('=', 2);
                if (parts.Length == 2)
                {
                    Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
                }
            }
        }
    }
}
