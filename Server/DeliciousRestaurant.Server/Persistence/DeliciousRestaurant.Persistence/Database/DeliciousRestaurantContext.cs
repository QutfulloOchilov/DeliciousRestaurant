using DeliciousRestaurant.Application.Interfaces;
using DeliciousRestaurant.Domain.Entities;
using DeliciousRestaurant.Domain.Interfaces;
using DeliciousRestaurant.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeliciousRestaurant.Persistence.Database
{
    public class DeliciousRestaurantContext : DbContext, IContext
    {
        public DeliciousRestaurantContext(BaseDeliciousRestaurantContextOptionBuilder optionBuilder) : base(optionBuilder.Options)
        {
            OptionBuilder = optionBuilder;
        }

        public BaseDeliciousRestaurantContextOptionBuilder OptionBuilder { get; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public Guid Id { get; set; }
        public int? CommandTimeout
        {
            get => this.Database.GetCommandTimeout();
            set => this.Database.SetCommandTimeout(value);
        }

        /// <summary>
        /// Add new entity to context
        /// </summary>
        public void AddToContext<T>(T entity) where T : IEntity
        {
            Entry(entity as EntityBase).State = EntityState.Added;
        }

        /// <summary>
        /// Change a state of entity to deleted
        /// </summary>
        public void MarkDelete<T>(T entity) where T : IEntity
        {
            var entityBase = entity as EntityBase;
            if (ChangeTracker.Entries().FirstOrDefault(e =>
            {
                var serverEntityBase = e.Entity as EntityBase;
                return serverEntityBase != null && serverEntityBase.Id == entityBase.Id;
            })?.State == EntityState.Deleted)
            {
                throw new Exception("BaseStatus of serverEntity already is deleted");
            }
            Entry(entityBase).State = EntityState.Deleted;
        }

        /// <summary>
        /// Get entities from context
        /// </summary>
        public new IQueryable<T> Set<T>() where T : class, IEntity
        {
            return base.Set<T>();
        }

        /// <summary>
        /// Get entity by guid
        /// </summary>
        public T Get<T>(Guid guid) where T : class, IEntity
        {
            return this.Find<T>(guid);
        }

        /// <summary>
        /// Update en entity
        /// </summary>
        public void Update<T>(Guid id, T entity) where T : class, IEntity
        {
            var oldEntity = Find<T>(id);
            Entry(oldEntity).CurrentValues.SetValues(entity);
        }

        /// <summary>
        /// Delete entity from context
        /// </summary>
        public void Delete<T>(T entity) where T : class, IEntity
        {
            this.Remove(entity);
        }

        public bool HasChange()
        {
            return ChangeTracker.HasChanges();
        }

        public void UndoChanges()
        {
            RollBack();
        }

        void RollBack()
        {
            var changedEntries = ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<EntityBase>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
        }

        [Obsolete]
        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return this.Database.ExecuteSqlCommand(sql, parameters);
        }

        [Obsolete]
        public Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return this.Database.ExecuteSqlCommandAsync(sql, parameters);
        }
    }
}