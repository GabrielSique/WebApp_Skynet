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

        //public ActionResult Register()
        //{
        //    return View();
        //}

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

                //obj_GetResApi = result.Content.ReadAsAsync<Aunthenticator>();
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

        //public async Task<ActionResult> RegisterUser()
        //{
        //    try
        //    {
        //        HttpResponseMessage result;
        //        User dataAuth = new User();

        //        dataAuth.passwordUser = Request.Form["passwordUser"];
        //        dataAuth.firstName = Request.Form["firstName"];
        //        dataAuth.surName = Request.Form["surName"];
        //        dataAuth.secondSurName = Request.Form["secondSurName"];
        //        dataAuth.direction = Request.Form["direction"];
        //        dataAuth.phoneNumber = Request.Form["phoneNumber"];
        //        dataAuth.dni = Request.Form["dni"];
        //        dataAuth.email = Request.Form["email"];
        //        dataAuth.businessName = Request.Form["businessName"];
        //        dataAuth.nit = Request.Form["nit"];
        //        dataAuth.idRol = Request.Form["idRol"];

        //        string url = "https://localhost:7168/api/Users/";
        //        //User obj_GetResApi;
        //        var client = new HttpClient();

        //        client.BaseAddress = new System.Uri(url);
        //        Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("AddUser", dataAuth);
        //        postTask.Wait();

        //        result = postTask.Result;
        //        string jsonResposne = result.Content.ReadAsStringAsync().Result;

        //        ResponseApi<User> resposne = JsonConvert.DeserializeObject<ResponseApi<User>>(jsonResposne);
        //        //obj_GetResApi = resposne.description;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Register", "Acceso");
        //        }
        //        else
        //        {
        //            return RedirectToAction("Error", "Home");
        //        }
        //    }
        //    catch (System.Exception)
        //    {
        //        return RedirectToAction("Error", "Home");
        //    }
        //}

    }
}