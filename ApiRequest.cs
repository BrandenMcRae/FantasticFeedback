using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlawlessFeedbackBranden
{
    // A static class created to centralise our API Requests
    public static class ApiRequest<T>
    {
        // Return a list of the given type
        public static List<T> GetList(HttpClient _client, string apiController)
        {
            HttpResponseMessage message = _client.GetAsync(apiController).Result;
        #if DEBUG
            message.EnsureSuccessStatusCode();
        #endif
            return message.Content.ReadAsAsync<List<T>>().Result;
        }

        // Return a single item of the given type

        public static T GetSingle(HttpClient _client, string apiController, int id)
        {
            HttpResponseMessage message = _client.GetAsync($"{apiController}/{id}").Result;
        #if DEBUG
            message.EnsureSuccessStatusCode();
        #endif
            return message.Content.ReadAsAsync<T>().Result;
        }

        // Post the specified entity to the API, return the created entity

        public static T Post(HttpClient _client, string apiController, T entity)
        {
            HttpResponseMessage message = _client.PostAsJsonAsync($"{apiController}", entity).Result;
        #if DEBUG
            message.EnsureSuccessStatusCode();
        #endif
            return message.Content.ReadAsAsync<T>().Result;
        }

        // send the modified entity to the API, return the updated entity
        public static T Put(HttpClient _client, string apiController, int id, T entity)
        {
            HttpResponseMessage message = _client.PutAsJsonAsync($"{apiController}/{id}", entity).Result;
        #if DEBUG
            message.EnsureSuccessStatusCode();
        #endif
            return message.Content.ReadAsAsync<T>().Result;
        }

        // Send a request to the APi to delete the specified entry
        public static T Delete(HttpClient _client, string apiController, int id)
        {
            HttpResponseMessage message = _client.DeleteAsync($"{apiController}/{id}").Result;
        #if DEBUG
            message.EnsureSuccessStatusCode();
        #endif
            return message.Content.ReadAsAsync<T>().Result;
        }
    }
}
