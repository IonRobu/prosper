﻿using Data.Domain.Business;
using Data.Domain.Static;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class Context : Methodic.Data.Contexts.Entities.Context
{
	protected override bool IsDataEnabled => true;

	protected override bool UseVersioning => false;

	protected override string UserName => null;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite(string.Format(
			@"Data Source={0}\Configuration\Data\store.db",
			Directory.GetCurrentDirectory()
		), opts =>
		{
			opts.CommandTimeout(3600);//todo - add in DataConfig
		});
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		OnSettingStaticData(modelBuilder);
		OnSettingTransaction(modelBuilder);
		//modelBuilder.UseCollation("NOCASE");

		//foreach (var property in modelBuilder.Model.GetEntityTypes()
		//										.SelectMany(t => t.GetProperties())
		//										.Where(p => p.ClrType == typeof(string)))
		//{
		//	property.SetCollation("NOCASE");
		//	property.SetColumnType("TEXT COLLATE NOCASE");
		//}
	}

	private void OnSettingStaticData(ModelBuilder modelBuilder)
	{
		var categoryEntity = modelBuilder.MapEntity<Category, int>(tableName: nameof(Category));

		categoryEntity
			.Property(x => x.Name)
			//.UseCollation("NOCASE")
			.IsRequired()
			.HasMaxLength(250);

		var cardEntity = modelBuilder.MapEntity<Card, int>(tableName: nameof(Card));
		cardEntity
			.Property(x => x.Name)
			.IsRequired()
			.HasMaxLength(250); 
		
		cardEntity
			.Property(x => x.Number)
			.IsRequired()
			.HasMaxLength(250);

		var accountEntity = modelBuilder.MapEntity<Account, int>(tableName: nameof(Account));
		accountEntity
			.Property(x => x.Name)
			.IsRequired()
			.HasMaxLength(250);

	}

	private void OnSettingTransaction(ModelBuilder modelBuilder)
	{
		var transactionEntity = modelBuilder.MapEntity<Transaction, int>(tableName: nameof(Transaction));
		transactionEntity
			.Property(x => x.Name)
			.IsRequired()
			.HasMaxLength(250);

		modelBuilder.Entity<Transaction>()
			.Property(e => e.Amount)
			.HasConversion<double>();
	}
}
