using Newtonsoft.Json;
using Seminario.Models;
using Seminario.Models.Permisos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Seminario.Controllers
{

    public class AccesoController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public async Task<ActionResult> Authenticator()
        {
            try
            {
                HttpResponseMessage result;
                Authenticator dataAuth = new Authenticator();
                dataAuth.email = Request.Form["email"];
                dataAuth.password = Request.Form["password"];
                dataAuth.nameUser = "";
                dataAuth.rolName = "";

                string url = "https://skynetapiseminario.azurewebsites.net/api/Authenticator/";
                Authenticator obj_GetResApi;
                var client = new HttpClient();

                client.BaseAddress = new System.Uri(url);
                Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("Login", dataAuth);
                postTask.Wait();

                result = postTask.Result;
                string jsonResposne = result.Content.ReadAsStringAsync().Result;

                ResponseApi<Authenticator> resposne = JsonConvert.DeserializeObject<ResponseApi<Authenticator>>(jsonResposne);
                obj_GetResApi = resposne.data;

                if (result.IsSuccessStatusCode)
                {
                    if (obj_GetResApi.email != null && obj_GetResApi.email != "")
                    {
                        Session["email"] = obj_GetResApi.email;
                        Session["nameUser"] = obj_GetResApi.nameUser;
                        Session["rolName"] = obj_GetResApi.rolName;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            catch (System.Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }


    }
}