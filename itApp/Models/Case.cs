using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itApp.Models
{
    public class Case
    {
        private int ID { get; set; }
        private int Priority { get; set; }
        public String Title { get; set; }
        private String Description { get; set; }
        private String Category { get; set; }
        private String State { get; set; }
        private String Applicant { get; set; }
        private String Responsable { get; set; }
        private String CreationDate { get; set; }
        private String SolutionDate { get; set; }
        private String LimitDate { get; set; }

        public Case()
        {
        }
    }

   
}
