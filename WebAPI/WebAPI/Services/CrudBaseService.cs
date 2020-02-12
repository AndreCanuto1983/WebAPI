using System;
using System.Data.Entity;
using System.Threading.Tasks;
using WebAPI.Common.Exceptions;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class CrudBaseService<TContext, TEntity> : IDisposable
        where TContext : DbContext
        where TEntity : ModelBase
    {
        #region Construtores

        public CrudBaseService()
        {
        }

        public CrudBaseService(TContext context) : this()
        {
            Context = context;
        }

        public TContext Context { get; set; }

        #endregion

        #region Insert

        /// <summary>
        /// Insert into database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> Insert(TEntity entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Added;
                await Context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new CustomErrorException("Error insert", ex);
            }

        }

        #endregion

        #region Update

        /// <summary>
        /// Update or Set to delete object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                //entity.UpdateDate = DateTime.UtcNow.ToLocalTime();
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new CustomErrorException("Error update", ex);
            }

        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete object to database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Delete(TEntity entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Deleted;
                var result = await Context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new CustomErrorException("Error deleted", ex);
            }

        }

        #endregion

        #region Dispose

        /// <summary>
        /// free memory
        /// </summary>
        public virtual void Dispose()
        {
            Context.Dispose();
        }

        #endregion

    }
}