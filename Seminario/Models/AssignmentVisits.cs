using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seminario.Models
{
    public class AssignmentVisits
    {
        public string idVisitAssigned { get; set; }
        public string idTechnical { get; set; }
        public string nameTechnical { get; set; }
        public string idClient { get; set; }
        public string nameClient { get; set; }
        public string ubication { get; set; }
        public string reasonVisit { get; set; }
        public string statusVisit { get; set; }
        public string nameStatusVisit { get; set; }
        public string visitSchedule { get; set; }
        public string idSupervisor { get; set; }
        public string nameSupervisor { get; set; } = string.Empty;
        public string arrivalVisit { get; set; }
        public string visitFinished { get; set; }
        public string registerDate { get; set; }
        public string registerTime { get; set; }
    } 
}