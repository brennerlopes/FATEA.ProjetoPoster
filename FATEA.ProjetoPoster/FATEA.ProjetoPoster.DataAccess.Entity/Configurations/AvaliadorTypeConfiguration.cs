using FATEA.DataAccess.Entity.Common;
using FATEA.ProjetoPoster.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.ProjetoPoster.DataAccess.Entity.Configurations
{
    class AvaliadorTypeConfiguration : FATEATypeConfiguration<Avaliador>
    {
        public override void ConfigureFields()
        {
            Property(a => a.Area)
                .HasColumnName("AVA_AREA")
                .HasMaxLength(200)
                .IsRequired();
        }

        public override void ConfigureForeignKeys()
        {
            ;
        }

        public override void ConfigureOthers()
        {
            
        }

        public override void ConfigurePrimaryKeys()
        {
           
        }

        public override void ConfigureTableName()
        {
            ToTable("AVA_AREA");
        }
    }
}
