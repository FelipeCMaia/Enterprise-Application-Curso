﻿using Microsoft.EntityFrameworkCore;
using NSE.Catalogo.API.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSE.Core.Data;
using FluentValidation.Results;
using NSE.Core.Messages;

namespace NSE.Catalogo.API.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext( DbContextOptions<CatalogoContext> options ) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();


            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
