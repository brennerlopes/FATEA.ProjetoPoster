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
    public class PosterTypeConfiguration : FATEATypeConfiguration<Poster>
    {
        public override void ConfigureTableName()
        {
            ToTable("POS_POSTER");
        }
        public override void ConfigureFields()
        {
            Property(a => a.Id)
                .HasColumnName("POS_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            Property(a => a.Titulo)
                .HasColumnName("POS_TITULO")
                .HasMaxLength(100)
                .IsRequired();
            Property(a => a.Modalidade)
                .HasColumnName("POS_MODALIDADE")
                .HasMaxLength(100)
                .IsRequired();
            Property(a => a.Resumo)
                .HasColumnName("POS_RESUMO")
                .HasMaxLength(450)
                .IsRequired();
            Property(a => a.PalavraChave)
                .HasColumnName("POS_PALAVRACHAVE")
                .HasMaxLength(80)
                .IsRequired();
            Property(a => a.NomeArquivo)
                .HasColumnName("POS_ARQUIVO")
                .HasMaxLength(80)
                .IsRequired();
            Property(a => a.Nota)
                .HasColumnName("POS_NOTA");

            Property(a => a.AvaliadoPor)
              .HasColumnName("POS_AVALIADOR");
            Property(a => a.Autores)
              .HasColumnName("POS_AUTORES")
                 .HasMaxLength(150)
                .IsRequired();
            Property(a => a.Area.Area)
              .HasColumnName("POS_AREA")
                 .HasMaxLength(80)
                .IsRequired();
        }

        public override void ConfigurePrimaryKeys()
        {

        }
        public override void ConfigureForeignKeys()
        {
            this.Property(t => t.Area.Area).HasColumnName("CUR_ID");
        }
        public override void ConfigureOthers()
        {

        }
    }
}
