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
                .HasColumnName("POS_NOTA")
                .IsOptional();
            Property(a => a.AvaliadoPor)
              .HasColumnName("POS_AVALIADOR")
             .IsOptional();
            Property(a => a.Autores)
              .HasColumnName("POS_AUTORES")
                 .HasMaxLength(150)
                .IsRequired();
            Property(a => a.IdCurso)
              .HasColumnName("POS_CURSO")
                .IsRequired();
            Property(a => a.IdEvento)
              .HasColumnName("POS_EVENTO")
                .IsRequired();

        }

        public override void ConfigurePrimaryKeys()
        {

        }
        public override void ConfigureForeignKeys()
        {
            HasRequired(r => r.Curso)
                .WithMany(m => m.Posters)
                .HasForeignKey(fk => fk.IdCurso)
                .WillCascadeOnDelete(false);
            HasRequired(r => r.Evento)
               .WithMany(m => m.Posters)
               .HasForeignKey(fk => fk.IdEvento)
               .WillCascadeOnDelete(false);
        }
        public override void ConfigureOthers()
        {

        }
    }
}
