using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SirensDiscordBot
{
    public class SirensApi
    {
        private  HttpClient _httpClient;
        private string _apiUrl = "https://sirens.in.ua/api/v1/";
        private Timer _timer;

        public delegate void SirensHandler(Dictionary<string, string> districts);
        public event SirensHandler? UpdateSirens;

        public SirensApi()
        {
            _httpClient = new HttpClient();
        }

        public void StartUpdate()
        {
            _timer = new Timer(new TimerCallback(GetDistricts), null, 0, 30000);
        }

        private async void GetDistricts(object state)
        {
            try 
            {
                HttpResponseMessage responseMessage = await _httpClient.GetAsync(_apiUrl);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                    Dictionary<string, string> districts = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonResponse);
                    UpdateSirens?.Invoke(districts);
                }
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
