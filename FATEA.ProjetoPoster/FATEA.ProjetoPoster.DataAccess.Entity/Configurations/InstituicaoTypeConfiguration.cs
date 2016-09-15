using FATEA.ProjetoPoster.Domain;
using FATEA.DataAccess.Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.ProjetoPoster.DataAccess.Entity.Configurations
{
   public class InstituicaoTypeConfiguration : FATEATypeConfiguration<Instituicao>
    {
        public override void ConfigureFields()
        {
            Property(i => i.Id)
                .HasColumnName("INS_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(i => i.Name)
                .HasColumnName("INS_NOME")
                .HasMaxLength(100)
                .IsRequired();

            Property(i => i.Cidade)
                .HasColumnName("INS_CIDADE")
                .HasMaxLength(50)
                .IsRequired();
        }

        public override void ConfigureForeignKeys()
        {
            throw new NotImplementedException();
        }

        public override void ConfigureOthers()
        {
            throw new NotImplementedException();
        }

        public override void ConfigurePrimaryKeys()
        {
            throw new NotImplementedException();
        }

        public override void ConfigureTableName()
        {
            ToTable("INS_INSTITUICAO");
        }
    }
}
