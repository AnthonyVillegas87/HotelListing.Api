using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Api.Data.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasData(
            new Hotel
            {
                Id = 1,
                Name = "Marriott Times Square",
                Address = "1535 Broadway, New York",
                Rating = 4.5,
                CountryId = 1 // USA
            },
            new Hotel
            {
                Id = 2,
                Name = "The Savoy",
                Address = "Strand, London WC2R 0EU",
                Rating = 4.8,
                CountryId = 2 // UK
            },
            new Hotel
            {
                Id = 3,
                Name = "Ritz Paris",
                Address = "15 Place Vendôme, 75001 Paris",
                Rating = 4.9,
                CountryId = 3 // France
            },
            new Hotel
            {
                Id = 4,
                Name = "Hotel Adlon Kempinski",
                Address = "Unter den Linden 77, 10117 Berlin",
                Rating = 4.7,
                CountryId = 4 // Germany
            },
            new Hotel
            {
                Id = 5,
                Name = "Hotel de Russie",
                Address = "Via del Babuino 9, Rome",
                Rating = 4.6,
                CountryId = 5 // Italy
            },
            new Hotel
            {
                Id = 6,
                Name = "Mandarin Oriental Barcelona",
                Address = "Passeig de Gràcia 38-40, Barcelona",
                Rating = 4.8,
                CountryId = 6 // Spain
            },
            new Hotel
            {
                Id = 7,
                Name = "Four Seasons Sydney",
                Address = "199 George St, Sydney NSW 2000",
                Rating = 4.7,
                CountryId = 10 // Australia
            },
            new Hotel
            {
                Id = 8,
                Name = "Fairmont Banff Springs",
                Address = "405 Spray Ave, Banff, AB",
                Rating = 4.8,
                CountryId = 11 // Canada
            }
            );
    }
}