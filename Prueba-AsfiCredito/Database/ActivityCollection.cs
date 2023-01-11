using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace Prueba_AsfiCredito.Database
{
    public class ActivityCollection : IActivityCollection
    {

        internal MyDbContext dbContext = new MyDbContext();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        

        public async Task DeleteActivity(String id)
        {
            await dbContext.Database.EnsureCreatedAsync();
            Activity filter = dbContext.Activities.Single(a=> a.Id == id);
            try {
                dbContext.Activities.RemoveRange(filter);
                logger.Info("Info: The activity has been deleted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The activity could not be deleted, Error: " + e);
            }
        }

         public async Task<List<Activity>> getAllActivities()
         {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                List<Activity> activities = dbContext.Activities.ToList();
                logger.Info("Info: The activitys have been obtained successfully");
                return activities;
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The activities could not be obtained successfully, Error: " + e);
                return null;
            }
        }

        public async Task InsertActivity(Activity activity)
        {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                dbContext.Add<Activity>(activity);
                await dbContext.SaveChangesAsync();
                logger.Info("Info: The activity was inserted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The activity was not inserted, Error: " + e);
            }
        }

        public async Task UpdateActivity(Activity activity)
        {
            await dbContext.Database.EnsureCreatedAsync();
            var filter = dbContext.Activities.Single(a=> a.Id == activity.Id);
            try
            {
                dbContext.Activities.Update(activity);
                await dbContext.SaveChangesAsync();
                logger.Info("Info: The activity was updated");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The activity was not updated, Error: " + e);
            }
        }

        public async Task InsertActivityTemporal()
        {
            try
            {
                List<Activity> activities = new List<Activity>(){
                    new Activity(){Nombre= "Plan de trabajo anual", FechaCreacion = new DateTime(), FechaActualización = new DateTime(), Estado= true},
                    new Activity(){Nombre= "Capacitación empleados", FechaCreacion = new DateTime(), FechaActualización = new DateTime(), Estado= true},
                    new Activity(){Nombre= "Daily scrum", FechaCreacion = new DateTime(), FechaActualización = new DateTime(), Estado= true},
                };
                await dbContext.Database.EnsureCreatedAsync();
                await dbContext.Activities.AddRangeAsync(activities);
                await dbContext.SaveChangesAsync();
                logger.Info("Info: The area was inserted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The area was not inserted, Error: " + e);
            }
        }
    }
}
