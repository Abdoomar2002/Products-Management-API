﻿using Microsoft.EntityFrameworkCore;
using Products_Management_API.Server.Data;

namespace Products_Management_API.Server.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context; 
        protected readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); 
        }

        public async Task<T?> GetById(Guid id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();

        public async Task Add(T entity) => await _dbSet.AddAsync(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task SaveChanges() => await _context.SaveChangesAsync();
    }

}
