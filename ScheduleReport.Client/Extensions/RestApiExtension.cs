using Newtonsoft.Json;
using ScheduleReport.DB;
using ScheduleReport.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleReport.Client.Extensions
{
    /// <summary>
    /// Простой (не универсальный) класс обмена
    /// Без таймаутов
    /// Без обработчиков
    /// Лучше использовать какую-нибудь готовый REST клиент вместо текущей реализации
    /// </summary>
    public static class RestApiExtension
    {
        public const string URL = "https://localhost:44342";
        public const string KEY_HEADER = "ApiKey";
        public const string KEY_VALUE = "secretkey";

        /// <summary>
        /// Получить список объектов
        /// </summary>
        public static List<MonitoringObject> GetObjects()
        {
            return GetJson<List<MonitoringObject>>("/monitoringobject");
        }

        /// <summary>
        /// Получить список отчётов
        /// </summary>
        public static List<Report> GetReports()
        {
            return GetJson<List<Report>>("/report");
        }

        /// <summary>
        /// Добавить новый отчёт
        /// </summary>
        public static bool AddReport(Report viewModel)
        {
            return PostJson("/report/create", viewModel);
        }

        /// <summary>
        /// Удалить отчёт по идентификатору
        /// </summary>
        public static bool DeleteReport(Guid id)
        {
            return Delete($"/report/delete/{id}",
                (result) => (bool)Convert.ChangeType(result, typeof(bool)))
                .Result;
        }

        #region Расширенные вспомогательные методы отправки

        private static T GetJson<T>(string path)
        {
            // Отправить GET запрос
            return Send(path,
                // Преобразовать параметры обратно
                (result) => JsonConvert.DeserializeObject<T>(result))
                // Получить результат синхронно
                .Result;
        }
        private static bool PostJson<T>(string path, T data)
        {
            return Post(path,
                data,
                (request) => {
                    var d = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    return d;

                },
                (result) => (bool)Convert.ChangeType(result, typeof(bool)))
                .Result;
        }
        #endregion


        #region Вспомогательные етоды отправки
        private static async Task<T> Send<T>(string path, Func<string, T> convert)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Add(KEY_HEADER, KEY_VALUE);

                HttpResponseMessage response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return convert.Invoke(result);
                }
                else
                {
                    throw new Exception($"{response.StatusCode} ({response.ReasonPhrase})");
                }
            }
        }

        private static async Task<T> Post<TIn, T>(string path, TIn data, Func<TIn, string> convertTo, Func<string, T> convertFrom)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Add(KEY_HEADER, KEY_VALUE);
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var stringContent = new StringContent(convertTo.Invoke(data), UnicodeEncoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(path, stringContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return convertFrom.Invoke(result);
                }
                else
                {
                    throw new Exception($"{response.StatusCode} ({response.ReasonPhrase})");
                }
            }
        }

        private static async Task<T> Delete<T>(string path, Func<string, T> convertFrom)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Add(KEY_HEADER, KEY_VALUE);

                HttpResponseMessage response = client.DeleteAsync(path).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return convertFrom.Invoke(result);
                }
                else
                {
                    throw new Exception($"{response.StatusCode} ({response.ReasonPhrase})");
                }
            }
        }
        #endregion
    }
}
