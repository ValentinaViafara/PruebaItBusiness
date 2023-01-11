using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace Prueba_AsfiCredito.Database
{
    public class AreaCollection : IAreaCollection
    {

        internal MyDbContext dbContext = new MyDbContext();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        

        public async Task DeleteArea(String id)
        {
            await dbContext.Database.EnsureCreatedAsync();
            Area filter = dbContext.Areas.Single(a=> a.Id == id);
            try {
                dbContext.Areas.RemoveRange(filter);
                logger.Info("Info: The area has been deleted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The area could not be deleted, Error: " + e);
            }
        }

         public async Task<List<Area>> getAllAreas()
         {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                List<Area> areas = dbContext.Areas.ToList();
                logger.Info("Info: The areas have been obtained successfully");
                return areas;
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The areas could not be obtained successfully, Error: " + e);
                return null;
            }
        }

        public async Task InsertArea(Area area)
        {
            try
            {
                await dbContext.Database.EnsureCreatedAsync();
                dbContext.Add<Area>(area);
                await dbContext.SaveChangesAsync();
                logger.Info("Info: The area was inserted");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The area was not inserted, Error: " + e);
            }
        }

        public async Task UpdateArea(Area area)
        {
            await dbContext.Database.EnsureCreatedAsync();
            var filter = dbContext.Areas.Single(a=> a.Id == area.Id);
            try
            {
                dbContext.Areas.Update(area);
                await dbContext.SaveChangesAsync();
                logger.Info("Info: The area was updated");
            }
            catch (Exception e)
            {
                logger.Fatal("Fatal: The area was not updated, Error: " + e);
            }
        }


        public async Task InsertAreaTemporal()
        {
            try
            {
                List<Area> areas = new List<Area>(){
                    new Area(){Nombre= "Área Tecnologia", FechaCreacion = new DateTime(), FechaActualización = new DateTime(), Estado= true},
                    new Area(){Nombre= "Recursos Humanos", FechaCreacion = new DateTime(), FechaActualización = new DateTime(), Estado= true},
                    new Area(){Nombre= "Marketing", FechaCreacion = new DateTime(), FechaActualización = new DateTime(), Estado= true},
                };
                await dbContext.Database.EnsureCreatedAsync();
                await dbContext.Areas.AddRangeAsync(areas);
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
