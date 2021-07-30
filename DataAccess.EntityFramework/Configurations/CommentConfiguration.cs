using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.ParentId);
            builder.Property(u => u.Date).IsRequired();
            builder.Property(u => u.UserName).IsRequired();
            builder.Property(u => u.Text).IsRequired();
        }
    }
}
