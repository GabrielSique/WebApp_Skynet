using Newtonsoft.Json;
using Seminario.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Seminario.Models.Permisos;
using System.Text;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Threading;
using System.Net.Http.Headers;

namespace Seminario.Controllers
{
    public class HomeController : Controller
    {
        [ValidarSesion]
        public ActionResult Index()
        {
            return View();
        }
        /***************************************Acciones para el usuario*********************************************************/

        public ActionResult Register()
        {
            return View();
        }

        public async Task<ActionResult> RegisterUser()
        {
            try
            {
                HttpResponseMessage result;
                User dataAuth = new User();

                dataAuth.idUser = "0";
                dataAuth.passwordUser = Request.Form["passwordUser"];
                dataAuth.firstName = Request.Form["firstName"];
                dataAuth.surName = Request.Form["surName"];
                dataAuth.secondSurName = Request.Form["secondSurName"];
                dataAuth.direction = Request.Form["direction"];
                dataAuth.phoneNumber = Request.Form["phoneNumber"];
                dataAuth.dni = Request.Form["dni"];
                dataAuth.email = Request.Form["email"];
                dataAuth.businessName = Request.Form["businessName"];
                dataAuth.nit = Request.Form["nit"];
                dataAuth.idRol = Request.Form["idRol"];

                string url = "https://localhost:7168/api/Users/";
                var client = new HttpClient();

                client.BaseAddress = new System.Uri(url);
                Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("AddUser", dataAuth);
                postTask.Wait();

                result = postTask.Result;
                string jsonResposne = result.Content.ReadAsStringAsync().Result;

                ResponseApi<User> resposne = JsonConvert.DeserializeObject<ResponseApi<User>>(jsonResposne);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Register", "Home");
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

        public async Task<ActionResult> LoadUsers()
        {
            try
            {

                HttpResponseMessage result;
                string url = "https://localhost:7168/api/Users/";
                var client = new HttpClient();
                client.BaseAddress = new System.Uri(url);
                Task<HttpResponseMessage> postTask = client.GetAsync("GetAllUsers");
                postTask.Wait();
                result = postTask.Result;
                List<User> obj_st_GetResApi;
                string jsonResposne = result.Content.ReadAsStringAsync().Result;
                ResponseApi<List<User>> resposne = JsonConvert.DeserializeObject<ResponseApi<List<User>>>(jsonResposne);
                obj_st_GetResApi = resposne.data;

                if (result.IsSuccessStatusCode)
                {
                    List<User> users = resposne.data;
                    return View(users);
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

        public ActionResult UpdateU(string idUser, string idRol, string statusUser, string email, string nit, string firstName, string surName, string secondSurName, string direction, string phoneNumber, string dni, string businessName)
        {
            User user = new User();
            user.idUser = idUser;
            user.firstName = firstName;
            user.surName = surName;
            user.secondSurName = secondSurName;
            user.direction = direction;
            user.phoneNumber = phoneNumber;
            user.dni = dni;
            user.email = email;
            user.nit = nit;
            user.businessName = businessName;
            user.idRol = idRol;
            user.statusUser = statusUser;

            return View(user);
        }

        public async Task<ActionResult> UpdateUser()
        {
            try
            {
                HttpResponseMessage result;
                User dataAuth = new User();
                dataAuth.idUser = Request.Form["idUser"];
                dataAuth.passwordUser = Request.Form["passwordUser"];
                dataAuth.firstName = Request.Form["firstName"];
                dataAuth.surName = Request.Form["surName"];
                dataAuth.secondSurName = Request.Form["secondSurName"];
                dataAuth.direction = Request.Form["direction"];
                dataAuth.phoneNumber = Request.Form["phoneNumber"];
                dataAuth.dni = Request.Form["dni"];
                dataAuth.email = Request.Form["email"];
                dataAuth.nit = Request.Form["nit"];
                dataAuth.businessName = Request.Form["businessName"];
                dataAuth.idRol = Request.Form["idRol"];
                dataAuth.statusUser = Request.Form["statusUser"];

                string url = "https://localhost:7168/api/Users/";
                var client = new HttpClient();

                client.BaseAddress = new System.Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> postTask = client.PutAsJsonAsync("UpdateUser", dataAuth);
                postTask.Wait();

                result = postTask.Result;
                string jsonResposne = result.Content.ReadAsStringAsync().Result;

                ResponseApi<User> resposne = JsonConvert.DeserializeObject<ResponseApi<User>>(jsonResposne);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("LoadUsers", "Home");
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


        /***************************************Acciones para el cliente*********************************************************/
        public ActionResult RegisterC()
        {
            return View();
        }

        public async Task<ActionResult> RegisterClient()
        {
            try
            {
                HttpResponseMessage result;
                Client dataAuth = new Client();
                dataAuth.idClient = "0";
                dataAuth.firstName = Request.Form["firstName"];
                dataAuth.surName = Request.Form["surName"];
                dataAuth.secondSurName = Request.Form["secondSurName"];
                dataAuth.direction = Request.Form["direction"];
                dataAuth.phoneNumber = Request.Form["phoneNumber"];
                dataAuth.dni = Request.Form["dni"];
                dataAuth.email = Request.Form["email"];
                dataAuth.businessName = Request.Form["businessName"];
                dataAuth.nit = Request.Form["nit"];

                string url = "https://localhost:7168/api/Client/";
                var client = new HttpClient();

                client.BaseAddress = new System.Uri(url);
                Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("AddClient", dataAuth);
                postTask.Wait();

                result = postTask.Result;
                string jsonResposne = result.Content.ReadAsStringAsync().Result;

                ResponseApi<Client> resposne = JsonConvert.DeserializeObject<ResponseApi<Client>>(jsonResposne);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("RegisterC", "Home");
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

        public async Task<ActionResult> LoadClients()
        {
            try
            {

                HttpResponseMessage result;
                string url = "https://localhost:7168/api/Client/";
                var client = new HttpClient();
                client.BaseAddress = new System.Uri(url);
                Task<HttpResponseMessage> postTask = client.GetAsync("GetAllClients");
                postTask.Wait();
                result = postTask.Result;
                List<Client> obj_st_GetResApi;
                string jsonResposne = result.Content.ReadAsStringAsync().Result;
                ResponseApi<List<Client>> resposne = JsonConvert.DeserializeObject<ResponseApi<List<Client>>>(jsonResposne);
                obj_st_GetResApi = resposne.data;

                if (result.IsSuccessStatusCode)
                {
                    List<Client> clients = resposne.data;
                    return View(clients);
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


        public ActionResult UpdateC(string idClient, string statusClient, string email, string nit, string firstName, string surName, string secondSurName, string direction, string phoneNumber, string dni, string businessName)
        {
            Client client = new Client();
            client.idClient = idClient;
            client.firstName = firstName;
            client.surName = surName;
            client.secondSurName = secondSurName;
            client.direction = direction;
            client.phoneNumber = phoneNumber;
            client.dni = dni;
            client.email = email;
            client.nit = nit;
            client.businessName = businessName;
            client.statusClient = statusClient;

            return View(client);
        }

        public async Task<ActionResult> UpdateClient()
        {
            try
            {
                HttpResponseMessage result;
                Client dataAuth = new Client();
                dataAuth.idClient = Request.Form["idClient"];
                dataAuth.firstName = Request.Form["firstName"];
                dataAuth.surName = Request.Form["surName"];
                dataAuth.secondSurName = Request.Form["secondSurName"];
                dataAuth.direction = Request.Form["direction"];
                dataAuth.phoneNumber = Request.Form["phoneNumber"];
                dataAuth.dni = Request.Form["dni"];
                dataAuth.email = Request.Form["email"];
                dataAuth.nit = Request.Form["nit"];
                dataAuth.businessName = Request.Form["businessName"];
                dataAuth.statusClient = Request.Form["statusClient"];

                string url = "https://localhost:7168/api/Client/";
                var client = new HttpClient();

                client.BaseAddress = new System.Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> postTask = client.PutAsJsonAsync("UpdateClient", dataAuth);
                postTask.Wait();

                result = postTask.Result;
                string jsonResposne = result.Content.ReadAsStringAsync().Result;

                ResponseApi<Client> resposne = JsonConvert.DeserializeObject<ResponseApi<Client>>(jsonResposne);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("LoadClients", "Home");
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

        /***************************************VISITAS*********************************************************/

        //public async Task<ActionResult> LoadTechnicals()
        //{
        //    try
        //    {

        //        //TECNICOS
        //        HttpResponseMessage result;
        //        string url = "https://localhost:7168/api/Users/";
        //        var client = new HttpClient();
        //        client.BaseAddress = new System.Uri(url);
        //        Task<HttpResponseMessage> postTask = client.GetAsync("GetAllTechnicals");
        //        postTask.Wait();
        //        result = postTask.Result;
        //        List<User> obj_st_GetResApi;
        //        string jsonResposne = result.Content.ReadAsStringAsync().Result;
        //        ResponseApi<List<User>> resposne = JsonConvert.DeserializeObject<ResponseApi<List<User>>>(jsonResposne);
        //        obj_st_GetResApi = resposne.data;

        //        List<SelectListItem> listTechnicals= new List<SelectListItem>();
        //        List<User> users = resposne.data;
        //        foreach (var item in users)
        //        {
        //            listTechnicals.Add(new SelectListItem { Text = item.userName, Value = item.idUser.ToString() });
        //        }
        //        ViewData["listTechnicals"] = new SelectList(listTechnicals.ToList(), "VALUE", "TEXT");

        //        //SUPERVISORES
        //        postTask = client.GetAsync("GetAllSupervisors");
        //        postTask.Wait();
        //        result = postTask.Result;
        //        obj_st_GetResApi = null;
        //        jsonResposne = result.Content.ReadAsStringAsync().Result;
        //        resposne = JsonConvert.DeserializeObject<ResponseApi<List<User>>>(jsonResposne);
        //        obj_st_GetResApi = resposne.data;

        //        List<SelectListItem> listSupervisores = new List<SelectListItem>();
        //        List<User> supervisores = resposne.data;
        //        foreach (var item in supervisores)
        //        {
        //            listSupervisores.Add(new SelectListItem { Text = item.userName, Value = item.idUser.ToString() });
        //        }
        //        ViewData["listSupervisors"] = new SelectList(listSupervisores.ToList(), "VALUE", "TEXT");

        //        return View();

        //    }
        //    catch (System.Exception)
        //    {
        //        return RedirectToAction("Error", "Home");
        //    }
        //}

        public async Task<ActionResult> RegisterV()
        {
            return View();
        }

        public async Task<ActionResult> RegisterVisits()
        {
            try
            {
                HttpResponseMessage result;
                AssignmentVisits dataAuth = new AssignmentVisits();
                dataAuth.idVisitAssigned = "0";
                dataAuth.statusVisit = Request.Form["statusVisit"];
                dataAuth.idTechnical = Request.Form["idTechnical"];
                dataAuth.idClient = Request.Form["idClient"];
                dataAuth.idSupervisor = Request.Form["idSupervisor"];
                dataAuth.ubication = Request.Form["ubication"];
                dataAuth.reasonVisit = Request.Form["reasonVisit"];
                dataAuth.visitSchedule = Request.Form["visitSchedule"];
                

                string url = "https://localhost:7168/api/AssignamentVisits/";
                var client = new HttpClient();

                client.BaseAddress = new System.Uri(url);
                Task<HttpResponseMessage> postTask = client.PostAsJsonAsync("AddVisit", dataAuth);
                postTask.Wait();

                result = postTask.Result;
                string jsonResposne = result.Content.ReadAsStringAsync().Result;

                ResponseApi<AssignmentVisits> resposne = JsonConvert.DeserializeObject<ResponseApi<AssignmentVisits>>(jsonResposne);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("RegisterV", "Home");
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

        public async Task<ActionResult> LoadVisits()
        {
            try
            {

                HttpResponseMessage result;
                string url = "https://localhost:7168/api/AssignamentVisits/";
                var client = new HttpClient();
                client.BaseAddress = new System.Uri(url);
                Task<HttpResponseMessage> postTask = client.GetAsync("GetAllVisits");
                postTask.Wait();
                result = postTask.Result;
                List<AssignmentVisits> obj_st_GetResApi;
                string jsonResposne = result.Content.ReadAsStringAsync().Result;
                ResponseApi<List<AssignmentVisits>> resposne = JsonConvert.DeserializeObject<ResponseApi<List<AssignmentVisits>>>(jsonResposne);
                obj_st_GetResApi = resposne.data;

                if (result.IsSuccessStatusCode)
                {
                    List<AssignmentVisits> visitas = resposne.data;
                    return View(visitas);
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


        /***************************************CERRAR SESION*********************************************************/
        public ActionResult CerrarSesion()
        {
            Session["email"] = null;
            return RedirectToAction("Login", "Acceso");
        }

    }
}