using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class Context : Methodic.Data.Contexts.Entities.Context
{
	protected override bool IsDataEnabled => true;

	protected override bool UseVersioning => false;

	protected override string UserName => null;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("/todo", opts =>
		{
			opts.CommandTimeout(3600);//todo - add in DataConfig
		});
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		OnSettingStaticData(modelBuilder);
	}

	private void OnSettingStaticData(ModelBuilder modelBuilder)
	{
		//var countryEntity = modelBuilder.MapEntity<Country, int>(tableName: $"{_tablePrefix}{nameof(Country)}");
		//countryEntity
		//	.Property(x => x.Name)
		//	.IsRequired()
		//	.HasMaxLength(250);
		//countryEntity
		//	.Property(x => x.Iso2)
		//	.IsRequired()
		//	.HasMaxLength(10);
		//countryEntity
		//	.Property(x => x.Iso3)
		//	.IsRequired()
		//	.HasMaxLength(10);

		//var speciesEntity = modelBuilder.MapEntity<Species, long>(tableName: $"{_tablePrefix}{nameof(Species)}");
		//speciesEntity.Ignore(x => x.Name);

		//var collectionEntity = modelBuilder.MapEntity<Collection, int>(tableName: $"{_tablePrefix}{nameof(Collection)}");
		//collectionEntity.Property(x => x.Name)
		//	.IsRequired()
		//	.HasMaxLength(500);
		//collectionEntity.Property(x => x.Owner)
		//	.HasMaxLength(300);
		//collectionEntity.Property(x => x.City)
		//	.HasMaxLength(300);
		//collectionEntity.Property(x => x.Address)
		//	.HasMaxLength(300);
		//collectionEntity.Property(x => x.WebAddress)
		//	.HasMaxLength(500);
		//collectionEntity.Property(x => x.InternationalCode)
		//	.HasMaxLength(50);
		//collectionEntity.Property(x => x.InventoryIdentifier)
		//	.HasMaxLength(50);

		//var collectionTypeEntity = modelBuilder.MapEntity<CollectionType, int>(tableName: $"{_tablePrefix}{nameof(CollectionType)}");
		//collectionTypeEntity.Property(x => x.Name)
		//	.IsRequired()
		//	.HasMaxLength(500);

		//var measureUnitTypeEntity = modelBuilder.MapEntity<MeasureUnit, int>(tableName: $"{_tablePrefix}{nameof(MeasureUnit)}");
		//measureUnitTypeEntity.Property(x => x.Name)
		//	.IsRequired()
		//	.HasMaxLength(500);

		//var countyEntity = modelBuilder.MapEntity<County, int>(tableName: $"{_tablePrefix}{nameof(County)}");
		//countyEntity.Property(x => x.Name)
		//	.IsRequired()
		//	.HasMaxLength(50);

		//var personTypeEntity = modelBuilder.MapEntity<PersonType, EnumPersonType>(tableName: $"{_tablePrefix}{nameof(PersonType)}");
		//personTypeEntity.Property(x => x.Name)
		//	.IsRequired()
		//	.HasMaxLength(50);

		//var organizationTypeEntity = modelBuilder.MapEntity<OrganizationType, EnumOrganizationType>(tableName: $"{_tablePrefix}{nameof(OrganizationType)}");
		//organizationTypeEntity.Property(x => x.Name)
		//.IsRequired()
		//.HasMaxLength(50);

		//var resourceUsageEntity = modelBuilder.MapEntity<ResourceUsage, EnumResourceUsage>(tableName: $"{_tablePrefix}{nameof(ResourceUsage)}");
		//organizationTypeEntity.Property(x => x.Name)
		//	.IsRequired()
		//	.HasMaxLength(50);

		//var usageTypeEntity = modelBuilder.MapEntity<UsageType, EnumUsageType>(tableName: $"{_tablePrefix}{nameof(UsageType)}");
		//usageTypeEntity.Property(x => x.Name)
		//	.IsRequired()
		//	.HasMaxLength(50);

	}
}
