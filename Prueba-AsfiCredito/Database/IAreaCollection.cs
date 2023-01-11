using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_AsfiCredito.Database
{
    interface IAreaCollection
    {
        Task InsertArea(Area client);
        Task UpdateArea(Area client);
        Task DeleteArea(String id);
        Task<List<Area>> getAllAreas();
        Task InsertAreaTemporal();
    }
}
