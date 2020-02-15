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

        /// <summary>
        /// Service para inserir e atualizar
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
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

        #region Partial Update

        /// <summary>
        /// Service para inserir e atualizar
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<VehicleModel> PartialUpdate(VehicleModel entity)
        {
            try
            {
                IEnumerable<VehicleModel> vehicleList = await GetVehicle(entity.id);
                VehicleModel vehicle = vehicleList.Where(v => v.id == entity.id).FirstOrDefault();

                vehicle.marca = entity.marca;
                vehicle.modelo = entity.modelo;
                vehicle.ano = entity.ano;
                vehicle.UpdateDate = DateTime.UtcNow;

                using (var context = new Context())
                {
                    context.Entry(vehicle).State = EntityState.Modified;
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

        /// <summary>
        /// Service para excluir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteVehicle(int id)
        {
            try
            {
                using (var context = new Context())
                {
                    VehicleModel vehicle = await context.Vehicle.Where(a => a.id == id).FirstOrDefaultAsync();
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

        /// <summary>
        /// Service para buscar um Id específico ou uma lista
        /// Passe id > 0 para buscar item específico e id = 0 para retornar uma lista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                        vehicle = await context.Vehicle.Where(a => a.id == id).ToListAsync();
                    }
                    else
                    {
                        //retorno uma lista de veículos
                        vehicle = await context.Vehicle.Where(a => a.id > 0).ToListAsync();
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