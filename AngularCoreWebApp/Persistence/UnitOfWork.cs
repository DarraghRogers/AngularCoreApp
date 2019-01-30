using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCoreWebApp.Persistence
{
        public class UnitOfWork : IUnitOfWork
        {
            private readonly AngularCoreWebAppDbContext context;

            public UnitOfWork(AngularCoreWebAppDbContext context)
            {
                this.context = context;
            }

            public async Task CompleteAsync()
            {
                await context.SaveChangesAsync();
            }
        }
    
}
