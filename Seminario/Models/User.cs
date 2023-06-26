using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Seminario.Models
{
    public class User
    {
        public string idUser { get; set; }
        public string passwordUser { get; set; }
        public string firstName { get; set; }
        public string surName { get; set; }
        public string secondSurName { get; set; }
        public string direction { get; set; }
        public string phoneNumber { get; set; }
        public string dni { get; set; }
        public string email { get; set; }
        public string businessName { get; set; }
        public string nit { get; set; }
        public string idRol { get; set; }
        public string statusUser { get; set; }
        public string rolName { get; set; }
        public string userName { get; set; }
        public string statusName { get; set; }
    }
}