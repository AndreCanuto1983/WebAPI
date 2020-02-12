using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Common.Exceptions;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class VehicleService
    {
        #region Insert/Update

        public async Task<VehicleModel> InsertOrUpdate(VehicleModel entity)
        {
            try
            {
                using (var context = new Context())
                {
                    context.Entry(entity).State = entity.id == 0 ? EntityState.Added : EntityState.Modified;
                    await context.SaveChangesAsync();
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new CustomErrorException("Error insert", ex);
            }
        }

        #endregion      

        #region Delete

        public async Task<int> DeleteVehicle(int id)
        {
            try
            {
                using (var context = new Context())
                {
                    VehicleModel vehicle = await context.AnuncioWebmotors.Where(a => a.id == id).FirstOrDefaultAsync();
                    context.Entry(vehicle).State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                    return id;
                }
            }
            catch (Exception ex)
            {
                throw new CustomErrorException("Error delete", ex);
            }
        }

        #endregion

        #region Get

        public async Task<IEnumerable<VehicleModel>> GetVehicle(int id)
        {
            try
            {
                using (var context = new Context())
                {
                    IEnumerable<VehicleModel> vehicle = null;
                    if (id > 0)
                    {
                        //retorno o id encontrado
                        vehicle = await context.AnuncioWebmotors.Where(a => a.id == id).ToListAsync();
                    }
                    else
                    {
                        //retorno uma lista de veículos
                        vehicle = await context.AnuncioWebmotors.Where(a => a.id > 0).ToListAsync();
                    }
                    return vehicle;
                }
            }
            catch (Exception ex)
            {
                throw new CustomErrorException("Error get", ex);
            }
        }

        #endregion      
    }
}