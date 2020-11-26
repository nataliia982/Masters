using Socio.Data.Entities;
using Socio.Data.Repository;
using System;
using System.Data.Entity;

namespace Socio.Data.Repository
{
    public class DataInitialisation : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
        }
    }
}
