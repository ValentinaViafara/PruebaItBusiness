
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
public class TaskSceduleRequest {
   public TaskSchedule task {get; set;}
   public DateOnly dateTask {get; set;}
}

}