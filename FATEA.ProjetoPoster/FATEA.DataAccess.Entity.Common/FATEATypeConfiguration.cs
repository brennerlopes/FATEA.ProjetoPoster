using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.DataAccess.Entity.Common
{
    public abstract class FATEATypeConfiguration<TEntitity> : EntityTypeConfiguration<TEntitity>
        where TEntitity : class
    {
        public  FATEATypeConfiguration()
            {
            ConfigureTableName();
            ConfigureFields();
            ConfigurePrimaryKeys();
            ConfigureForeignKeys();
            ConfigureOthers();
            
            }
        public abstract void ConfigureTableName();
        public abstract void ConfigureFields();
        public abstract void ConfigurePrimaryKeys();
        public abstract void ConfigureForeignKeys();
        public abstract void ConfigureOthers();
        
    }
}
