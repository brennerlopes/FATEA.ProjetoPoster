using FATEA.DataAccess.Entity.Common;
using FATEA.ProjetoPoster.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.ProjetoPoster.DataAccess.Entity.Configurations
{
    public class CursoTypeConfiguration : FATEATypeConfiguration<Curso>

    {
        public override void ConfigureFields()
        {
            Property(c => c.Id)
                   .HasColumnName("CUR_ID")
                   .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                   .IsRequired();

            Property(c => c.Nome)
                .HasColumnName("CUR_NOME")
                .HasMaxLength(150)
                .IsRequired();

            Property(c => c.Area)
                .HasColumnName("CUR_AREA")
                .HasMaxLength(100)
                .IsRequired();              
        }

        public override void ConfigureForeignKeys()
        {

        }

        public override void ConfigureOthers()
        {

        }

        public override void ConfigurePrimaryKeys()
        {
            HasKey(pk => pk.Id);
        }

        public override void ConfigureTableName()
        {
            ToTable("CUR_CURSOS");
        }
    }
}
