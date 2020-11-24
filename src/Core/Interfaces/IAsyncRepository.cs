using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using Core.Entities;

namespace Core.Interfaces
{
    /// <summary>
    /// IAsyncRepository App
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// Get By Id Entitiy 
        /// </summary>
        /// <param name="Id">Id entitiy</param>
        /// <returns>List Entities</returns>
        Task<T> GetByIdAsync(Guid Id);
        /// <summary>
        /// Get All of Entity
        /// </summary>
        /// <returns>Get All Entity</returns>
        Task<IReadOnlyList<T>> GetAllAsync();
        /// <summary>
        /// GetList for specific
        /// </summary>
        /// <param name="spec">Specification Modal x=> x.prop</param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> spec);
        /// <summary>
        /// Create Entitiy
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Entity</returns>
        Task<T> CreateAsync(T entity);
        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <returns>Entitiy</returns>
        Task<T> UpdateAsync(T entity);
        /// <summary>
        /// Count entities
        /// </summary>
        /// <param name="entity">entity model</param>
        /// <returns>Number count</returns>
        Task<int> CountAsync(ISpecification<T> spec);
        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity">Model entity</param>
        /// <param name="Id">Entity Id</param>
        /// <returns>Entity Model</returns>
        Task<T> DeleteAsync(T entity, Guid Id);
        /// <summary>
        /// First entity for specific Model
        /// </summary>
        /// <param name="spec"></param>
        /// <returns>Model entity</returns>
        Task<T> FirstAsync(ISpecification<T> spec);
        /// <summary>
        /// First or default Model entity
        /// </summary>
        /// <param name="spec">Model specific</param>
        /// <returns>Model entity o null</returns>
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec);
    }
}