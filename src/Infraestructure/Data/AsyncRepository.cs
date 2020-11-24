using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Core.Entities;
using Core.Interfaces;
using Infraestructure.AppContext;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    /// <summary>
    /// Repository AppContext
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncRepository<T> : IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// Database context App
        /// </summary>
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="context"></param>
        public AsyncRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Conteo Async
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            var specification = ApplySpecification(spec);
            return await specification.CountAsync();
        }

        /// <summary>
        /// Crear Async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Eliminar ASync 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<T> DeleteAsync(T entity, Guid Id)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Obtener el primer async
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        public async Task<T> FirstAsync(ISpecification<T> spec)
        {
            var specification = ApplySpecification(spec);
            return await specification.FirstAsync();
        }

        /// <summary>
        /// Obtener el primero o el defecto de la entidad
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
        {
            var specification = ApplySpecification(spec);
            return await specification.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Obtener Todos los items 
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> spec)
        {
            var specification = ApplySpecification(spec);
            return await specification.ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            var evaluator = new SpecificationEvaluator<T>();
            return evaluator.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}