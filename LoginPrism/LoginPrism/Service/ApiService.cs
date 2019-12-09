using LoginPrism.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LoginPrism.Service
{
    public class ApiService
    {
        private String url= "http://loginapicds.azurewebsites.net/api/";
        private HttpClient cliente;
        public async Task<ObservableCollection<T>> GetAll<T>(String controller)
        {
            cliente = new HttpClient();
            try
            {
                var resp = await cliente.GetAsync(url + controller);
                var json = await resp.Content.ReadAsStringAsync();
                ObservableCollection<T> collection = JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
                return collection;

            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return null;
            }
        }
        public async Task<bool> Post<T>(String controller,T item)
        {
            cliente = new HttpClient();
            Interface1 it;
            if (item.GetType()==typeof(Login))
            {
                it = item as Login;
            }
            else
            {
                it = item as Materia;
            }
            StringContent content = new StringContent(JsonConvert.SerializeObject(it), Encoding.UTF8, "application/json");
            var resp = await cliente.PostAsync(url + controller, content);
            if (resp.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> LoginValidate(String user,String clave)
        {
            cliente = new HttpClient();
            Login l = new Login
            {
                usu = user,
                passw = clave
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(l),Encoding.UTF8,"application/json");
            var resp = await cliente.PostAsync(url+ "Login/",content);
            if (resp.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
