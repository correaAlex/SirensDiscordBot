using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SirensDiscordBot
{
    public static class BotLocalication
    {
        private static Dictionary<string, Dictionary<string, Dictionary<string, string>>> Languages;
        public static async Task LoadLanguages()
        {
            var json = await File.ReadAllTextAsync("Languages.json");
            Languages = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(json);
        }

        public static string GetMessage(string languageName,string key)
        {
            Dictionary<string,Dictionary<string, string>> languages;
            if (Languages.TryGetValue(languageName, out languages))
            {
                string message;
                if (languages["messages"].TryGetValue(key, out message))
                {
                    return message;
                }
                else
                    throw new ArgumentException();
            }
            else
                throw new ArgumentException();
        }

        public static Dictionary<string,string> GetDistricts(string languageName)
        {
            Dictionary<string, Dictionary<string, string>> language;
            if (Languages.TryGetValue(languageName, out language))
            {
                Dictionary<string, string> districts;
                if (language.TryGetValue("districts",out districts))
                    return districts;
                else
                    throw new ArgumentException();
            }
            else
                throw new ArgumentException();
        }
    }
}
