using Newtonsoft.Json;
using System.Text;
using System;

namespace NetRestaurantAPI.Services
{
    public class PushNotificationService
    {
        private static string urlExpoNotificationServices = "https://exp.host/--/api/v2/push/send";
        public static void SendPushNotifications(string[] devicesIds, string title, string body)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var content = new 
            {
                to = devicesIds,
                title = title,
                body = body,
            };

            string serializeContent = JsonConvert.SerializeObject(content);

            HttpContent httpContent = new StringContent(serializeContent, Encoding.UTF8, "application/json");
            var response = client.PostAsync(urlExpoNotificationServices, httpContent).Result;

            if(response.StatusCode != System.Net.HttpStatusCode.OK) 
            {
                throw new ApplicationException(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
