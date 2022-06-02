using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirensDiscordBot
{
    public class Bot
    {

        private readonly Dictionary<string,DistrictStatus> Statuses = new Dictionary<string, DistrictStatus>(){
            { "null" ,DistrictStatus.NoSiren },
            { "full", DistrictStatus.EntireRegion },
            { "partial", DistrictStatus.PartOfRegion },
            { "no_data", DistrictStatus.NoData }
        };



        private SirensApi _api;

        public readonly Dictionary<string,District> Districts;

        public Bot()
        {
            Districts = new Dictionary<string, District>();
            Districts.Add("Mykolayiv", new District());
            Districts.Add("Chernihiv", new District());
            Districts.Add("Chernivtsi", new District());
            Districts.Add("Ivano-Frankivs'k", new District());
            Districts.Add("Khmel'nyts'kyy", new District());
            Districts.Add("L'viv", new District());
            Districts.Add("Ternopil", new District());
            Districts.Add("Transcarpathia", new District());
            Districts.Add("Volyn", new District());
            Districts.Add("Cherkasy", new District());
            Districts.Add("Kirovohrad", new District());
            Districts.Add("Kyiv", new District());
            Districts.Add("Odessa", new District());
            Districts.Add("Vinnytsya", new District());
            Districts.Add("Zhytomyr", new District());
            Districts.Add("Sumy", new District());
            Districts.Add("Dnipropetrovs'k", new District());
            Districts.Add("Donets'k", new District());
            Districts.Add("Kharkiv", new District());
            Districts.Add("Poltava", new District());
            Districts.Add("Zaporizhzhya", new District());
            Districts.Add("Kyiv City", new District());
            Districts.Add("Kherson", new District());
            Districts.Add("Luhans'k", new District());
            Districts.Add("Sevastopol", new District());
            Districts.Add("Crimea", new District());
            _api = new SirensApi();
            _api.UpdateSirens += OnDistrictsUpdate;
        }

        public void Start()
        {
            _api.StartUpdate();
        }


        private void OnDistrictsUpdate(Dictionary<string,string> districts)
        {
            foreach(KeyValuePair<string,string> kvp in districts)
            {
                District district;
                if (Districts.TryGetValue(kvp.Key,out district))
                {
                    string key = String.IsNullOrEmpty(kvp.Value) ? "null" : kvp.Value;
                    DistrictStatus newStatus = Statuses[key];
                    if (newStatus != district.CurrentStatus)
                    {
                        district.OldStatus = district.CurrentStatus;
                        district.CurrentStatus = newStatus;
                        Districts[kvp.Key] = district;
                        if (newStatus == DistrictStatus.EntireRegion)
                        {
                            Alarm?.Invoke(kvp.Key);
                        }
                        else if (newStatus == DistrictStatus.PartOfRegion)
                        {
                            PartialAlarm?.Invoke(kvp.Key);
                        }
                        else if (newStatus == DistrictStatus.NoSiren)
                        {
                            CancelAlarm?.Invoke(kvp.Key);
                        }
                    }
                }
            }
        }

        public delegate void AlarmDelegate(string name);
        public delegate void PartialAlarmDelegte(string name);
        public delegate void CancelAlarmDelegate(string name);

        public event AlarmDelegate? Alarm;
        public event PartialAlarmDelegte? PartialAlarm;
        public event CancelAlarmDelegate? CancelAlarm;
    }
}
