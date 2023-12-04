using Methodic.Common.Models.Admin.Enums;
using Methodic.Core.Components.Attributes;
using Methodic.Core.Configuration.Settings;
using System.ComponentModel.DataAnnotations;

namespace Core.Configuration.Settings;

public class DataSettings : SectionSettingsBase
{
	[ConfigurationStep(Order = 1)]
	public DatabaseSettings Database { get; set; } = new();

	[ConfigurationStep(Order = 2)]
	public PopulateDataSettings PopulateData { get; set; } = new();

	public class DatabaseSettings
	{
		[Required, DataEndpoint("data-providers")]
		public string DatabaseProvider { get; set; }

		[Required, MaxLength(200), ControlSize(EnumConfigurationPropertyControlSize.Large)]
		public string ConnectionString { get; set; }

		public bool UseVersioning { get; set; }

		public bool UseSchema { get; set; }

		[ControlSize(EnumConfigurationPropertyControlSize.Small)]
		public string DataSchema { get; set; }

		[ControlSize(EnumConfigurationPropertyControlSize.Small)]
		public string StaticSchema { get; set; }
	}

	public class PopulateDataSettings
	{

	}

}