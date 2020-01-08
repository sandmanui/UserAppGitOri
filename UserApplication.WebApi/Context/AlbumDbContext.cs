using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApplication.WebApi.Entities;

namespace UserApplication.WebApi.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Album> Albums { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries()
       .Where(p => p.State == EntityState.Modified).ToList();
            var now = DateTime.UtcNow;

            foreach (var change in modifiedEntities)
            {
                var entityName = change.Entity.GetType().Name;
                //var primaryKey = GetPrimaryKeyValue(change);

                foreach (var prop in change.OriginalValues.Properties)
                {
                    var originalValue = change.OriginalValues[prop].ToString();
                    var currentValue = change.CurrentValues[prop].ToString();
                    if (originalValue != currentValue) //Only create a log if the value changes
                    {
                        //Create the Change Log
                    }
                }
            }
            //return base.SaveChanges();
            return base.SaveChanges();
        }

        //object GetPrimaryKeyValue(EntityEntry entry)
        //{
        //    var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
        //    return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        //}
    }
}
