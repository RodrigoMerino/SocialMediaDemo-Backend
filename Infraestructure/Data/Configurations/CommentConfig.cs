using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Configurations
{
    class CommentConfig : IEntityTypeConfiguration<Comment>
    {


        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("IdComentario");

            builder.Property(e => e.PostId)
              .HasColumnName("IdPublicacion");

            builder.Property(e => e.UserId)
              .HasColumnName("IdUsuario");

            builder.Property(e => e.Description)
                .HasColumnName("Descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false);

            builder.Property(e => e.Date)
                .HasColumnName("Fecha")
                .HasColumnType("datetime");

            builder.Property(e => e.IsActived)
               .HasColumnName("Activo");

            builder.HasOne(d => d.PostIdNavigation)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(d => d.PostId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Comentario_Publicacion");

            builder.HasOne(d => d.UserIdNavigation)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(d => d.UserId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Comentario_Usuario");
        }

    }
}
