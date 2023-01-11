using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_AsfiCredito
{
    [Table("Tasks")]
    public class TaskSchedule
    {
        [Key]
        [ForeignKey("FK_Client")]
        public Client Client { get; set; }
        public String IdClient { get; set; }

        [Key]
        [ForeignKey("FK_Area")]
        public Area Area { get; set; }
        public String IdArea { get; set; }

        [Key]
        [ForeignKey("FK_Activity")]
        public Activity Activity { get; set; }
        public String IdActivity { get; set; }

        [Key]
        [ForeignKey("FK_DateTask")]
        public DateTask DateTask { get; set; }
        public String IdDateTask { get; set; }

        public String Description { get; set; }
        public TimeOnly hour { get; set; }

        public Boolean State { get; set; }
    }
}
