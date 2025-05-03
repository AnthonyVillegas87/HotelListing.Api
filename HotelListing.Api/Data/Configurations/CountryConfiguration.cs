using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Api.Data.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasData(
            new Country { CountryId = 1, Name = "United States", ShortName = "USA" },
            new Country { CountryId = 2, Name = "United Kingdom", ShortName = "UK" },
            new Country { CountryId = 3, Name = "France", ShortName = "FR" },
            new Country { CountryId = 4, Name = "Germany", ShortName = "DE" },
            new Country { CountryId = 5, Name = "Italy", ShortName = "IT" },
            new Country { CountryId = 6, Name = "Spain", ShortName = "ES" },
            new Country { CountryId = 7, Name = "Portugal", ShortName = "PT" },
            new Country { CountryId = 8, Name = "Netherlands", ShortName = "NL" },
            new Country { CountryId = 9, Name = "Sweden", ShortName = "SE" },
            new Country { CountryId = 10, Name = "Australia", ShortName = "AU" },
            new Country { CountryId = 11, Name = "Canada", ShortName = "CA" },
            new Country { CountryId = 12, Name = "New Zealand", ShortName = "NZ" }
        );
    }
}