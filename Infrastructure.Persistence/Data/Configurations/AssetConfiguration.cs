using Core.Domain.Entity;
using Core.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Data.Configurations;
public class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Ticker)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.AssetClass)
        .HasConversion<string>()
        .HasMaxLength(50);

        // Индекс для быстрого поиска кастомных ассетов пользователя
        builder.HasIndex(a => a.UserId);

        // Индекс для быстрого поиска по тикеру (важно для глобальных ассетов)
        builder.HasIndex(a => a.Ticker).IsUnique();

        // Начальные данные (seed) (Добавить акции и криптовалюты?)
        builder.HasData(
            // Основные мировые валюты
            new Asset("USD", "US Dollar", AssetClass.Cash),
            new Asset("EUR", "Euro", AssetClass.Cash),
            new Asset("JPY", "Japanese Yen", AssetClass.Cash),
            new Asset("GBP", "British Pound Sterling", AssetClass.Cash),
            new Asset("CHF", "Swiss Franc", AssetClass.Cash),
            new Asset("CAD", "Canadian Dollar", AssetClass.Cash),
            new Asset("AUD", "Australian Dollar", AssetClass.Cash),
            new Asset("CNY", "Chinese Yuan", AssetClass.Cash),
            new Asset("HKD", "Hong Kong Dollar", AssetClass.Cash),
            new Asset("SGD", "Singapore Dollar", AssetClass.Cash),

            // Европейские валюты (не-евро)
            new Asset("NOK", "Norwegian Krone", AssetClass.Cash),
            new Asset("SEK", "Swedish Krona", AssetClass.Cash),
            new Asset("DKK", "Danish Krone", AssetClass.Cash),
            new Asset("ISK", "Icelandic Krona", AssetClass.Cash),
            new Asset("CZK", "Czech Koruna", AssetClass.Cash),
            new Asset("HUF", "Hungarian Forint", AssetClass.Cash),
            new Asset("PLN", "Polish Zloty", AssetClass.Cash),
            new Asset("RON", "Romanian Leu", AssetClass.Cash),
            new Asset("BGN", "Bulgarian Lev", AssetClass.Cash),
            new Asset("HRK", "Croatian Kuna", AssetClass.Cash),
            new Asset("RSD", "Serbian Dinar", AssetClass.Cash),
            new Asset("MKD", "Macedonian Denar", AssetClass.Cash),
            new Asset("ALL", "Albanian Lek", AssetClass.Cash),
            new Asset("BAM", "Bosnia and Herzegovina Convertible Mark", AssetClass.Cash),
            new Asset("MDL", "Moldovan Leu", AssetClass.Cash),
            new Asset("UAH", "Ukrainian Hryvnia", AssetClass.Cash),
            new Asset("BYN", "Belarusian Ruble", AssetClass.Cash),
            new Asset("RUB", "Russian Ruble", AssetClass.Cash),
            new Asset("TRY", "Turkish Lira", AssetClass.Cash),
            new Asset("GEL", "Georgian Lari", AssetClass.Cash),
            new Asset("AMD", "Armenian Dram", AssetClass.Cash),
            new Asset("AZN", "Azerbaijani Manat", AssetClass.Cash),

            // Азиатские валюты
            new Asset("INR", "Indian Rupee", AssetClass.Cash),
            new Asset("KRW", "South Korean Won", AssetClass.Cash),
            new Asset("IDR", "Indonesian Rupiah", AssetClass.Cash),
            new Asset("MYR", "Malaysian Ringgit", AssetClass.Cash),
            new Asset("THB", "Thai Baht", AssetClass.Cash),
            new Asset("PHP", "Philippine Peso", AssetClass.Cash),
            new Asset("VND", "Vietnamese Dong", AssetClass.Cash),
            new Asset("TWD", "Taiwan Dollar", AssetClass.Cash),
            new Asset("KHR", "Cambodian Riel", AssetClass.Cash),
            new Asset("LAK", "Lao Kip", AssetClass.Cash),
            new Asset("MMK", "Myanmar Kyat", AssetClass.Cash),
            new Asset("BDT", "Bangladeshi Taka", AssetClass.Cash),
            new Asset("PKR", "Pakistani Rupee", AssetClass.Cash),
            new Asset("LKR", "Sri Lankan Rupee", AssetClass.Cash),
            new Asset("NPR", "Nepalese Rupee", AssetClass.Cash),
            new Asset("BTN", "Bhutanese Ngultrum", AssetClass.Cash),
            new Asset("MVR", "Maldivian Rufiyaa", AssetClass.Cash),
            new Asset("AFN", "Afghan Afghani", AssetClass.Cash),
            new Asset("KZT", "Kazakhstani Tenge", AssetClass.Cash),
            new Asset("KGS", "Kyrgyzstani Som", AssetClass.Cash),
            new Asset("TJS", "Tajikistani Somoni", AssetClass.Cash),
            new Asset("TMT", "Turkmenistani Manat", AssetClass.Cash),
            new Asset("UZS", "Uzbekistani Som", AssetClass.Cash),
            new Asset("MNT", "Mongolian Tugrik", AssetClass.Cash),
            new Asset("KPW", "North Korean Won", AssetClass.Cash),
            new Asset("BND", "Brunei Dollar", AssetClass.Cash),
            new Asset("MOP", "Macanese Pataca", AssetClass.Cash),

            // Ближневосточные валюты
            new Asset("SAR", "Saudi Riyal", AssetClass.Cash),
            new Asset("AED", "UAE Dirham", AssetClass.Cash),
            new Asset("QAR", "Qatari Riyal", AssetClass.Cash),
            new Asset("KWD", "Kuwaiti Dinar", AssetClass.Cash),
            new Asset("BHD", "Bahraini Dinar", AssetClass.Cash),
            new Asset("OMR", "Omani Rial", AssetClass.Cash),
            new Asset("ILS", "Israeli New Shekel", AssetClass.Cash),
            new Asset("JOD", "Jordanian Dinar", AssetClass.Cash),
            new Asset("LBP", "Lebanese Pound", AssetClass.Cash),
            new Asset("SYP", "Syrian Pound", AssetClass.Cash),
            new Asset("IQD", "Iraqi Dinar", AssetClass.Cash),
            new Asset("IRR", "Iranian Rial", AssetClass.Cash),
            new Asset("YER", "Yemeni Rial", AssetClass.Cash),

            // Африканские валюты
            new Asset("ZAR", "South African Rand", AssetClass.Cash),
            new Asset("EGP", "Egyptian Pound", AssetClass.Cash),
            new Asset("MAD", "Moroccan Dirham", AssetClass.Cash),
            new Asset("TND", "Tunisian Dinar", AssetClass.Cash),
            new Asset("DZD", "Algerian Dinar", AssetClass.Cash),
            new Asset("LYD", "Libyan Dinar", AssetClass.Cash),
            new Asset("SDG", "Sudanese Pound", AssetClass.Cash),
            new Asset("SSP", "South Sudanese Pound", AssetClass.Cash),
            new Asset("ETB", "Ethiopian Birr", AssetClass.Cash),
            new Asset("ERN", "Eritrean Nakfa", AssetClass.Cash),
            new Asset("DJF", "Djiboutian Franc", AssetClass.Cash),
            new Asset("SOS", "Somali Shilling", AssetClass.Cash),
            new Asset("KES", "Kenyan Shilling", AssetClass.Cash),
            new Asset("UGX", "Ugandan Shilling", AssetClass.Cash),
            new Asset("TZS", "Tanzanian Shilling", AssetClass.Cash),
            new Asset("RWF", "Rwandan Franc", AssetClass.Cash),
            new Asset("BIF", "Burundian Franc", AssetClass.Cash),
            new Asset("MGA", "Malagasy Ariary", AssetClass.Cash),
            new Asset("MUR", "Mauritian Rupee", AssetClass.Cash),
            new Asset("SCR", "Seychellois Rupee", AssetClass.Cash),
            new Asset("KMF", "Comorian Franc", AssetClass.Cash),
            new Asset("AOA", "Angolan Kwanza", AssetClass.Cash),
            new Asset("MZN", "Mozambican Metical", AssetClass.Cash),
            new Asset("ZMW", "Zambian Kwacha", AssetClass.Cash),
            new Asset("ZWL", "Zimbabwean Dollar", AssetClass.Cash),
            new Asset("BWP", "Botswana Pula", AssetClass.Cash),
            new Asset("SZL", "Swazi Lilangeni", AssetClass.Cash),
            new Asset("LSL", "Lesotho Loti", AssetClass.Cash),
            new Asset("NAD", "Namibian Dollar", AssetClass.Cash),
            new Asset("GMD", "Gambian Dalasi", AssetClass.Cash),
            new Asset("GNF", "Guinean Franc", AssetClass.Cash),
            new Asset("SLE", "Sierra Leonean Leone", AssetClass.Cash),
            new Asset("LRD", "Liberian Dollar", AssetClass.Cash),
            new Asset("GHS", "Ghanaian Cedi", AssetClass.Cash),
            new Asset("NGN", "Nigerian Naira", AssetClass.Cash),
            new Asset("XOF", "West African CFA Franc", AssetClass.Cash), // Используется в 8 странах
            new Asset("XAF", "Central African CFA Franc", AssetClass.Cash), // Используется в 6 странах
            new Asset("CVE", "Cape Verdean Escudo", AssetClass.Cash),
            new Asset("STN", "São Tomé and Príncipe Dobra", AssetClass.Cash),
            new Asset("CDF", "Congolese Franc", AssetClass.Cash),
            new Asset("CAF", "Central African Republic Franc", AssetClass.Cash),
            new Asset("XPF", "CFP Franc", AssetClass.Cash), // Французские территории в Тихом океане
            new Asset("MWK", "Malawian Kwacha", AssetClass.Cash),

            // Американские валюты
            new Asset("BRL", "Brazilian Real", AssetClass.Cash),
            new Asset("ARS", "Argentine Peso", AssetClass.Cash),
            new Asset("CLP", "Chilean Peso", AssetClass.Cash),
            new Asset("COP", "Colombian Peso", AssetClass.Cash),
            new Asset("PEN", "Peruvian Sol", AssetClass.Cash),
            new Asset("UYU", "Uruguayan Peso", AssetClass.Cash),
            new Asset("PYG", "Paraguayan Guarani", AssetClass.Cash),
            new Asset("BOB", "Bolivian Boliviano", AssetClass.Cash),
            new Asset("VES", "Venezuelan Bolívar Soberano", AssetClass.Cash),
            new Asset("GYD", "Guyanese Dollar", AssetClass.Cash),
            new Asset("SRD", "Surinamese Dollar", AssetClass.Cash),
            new Asset("MXN", "Mexican Peso", AssetClass.Cash),
            new Asset("GTQ", "Guatemalan Quetzal", AssetClass.Cash),
            new Asset("BZD", "Belize Dollar", AssetClass.Cash),
            new Asset("HNL", "Honduran Lempira", AssetClass.Cash),
            new Asset("NIO", "Nicaraguan Córdoba", AssetClass.Cash),
            new Asset("CRC", "Costa Rican Colón", AssetClass.Cash),
            new Asset("PAB", "Panamanian Balboa", AssetClass.Cash),
            new Asset("CUP", "Cuban Peso", AssetClass.Cash),
            new Asset("JMD", "Jamaican Dollar", AssetClass.Cash),
            new Asset("HTG", "Haitian Gourde", AssetClass.Cash),
            new Asset("DOP", "Dominican Peso", AssetClass.Cash),
            new Asset("TTD", "Trinidad and Tobago Dollar", AssetClass.Cash),
            new Asset("BBD", "Barbadian Dollar", AssetClass.Cash),
            new Asset("XCD", "East Caribbean Dollar", AssetClass.Cash), // Используется в 8 странах
            new Asset("AWG", "Aruban Florin", AssetClass.Cash),
            new Asset("ANG", "Netherlands Antillean Guilder", AssetClass.Cash),
            new Asset("KYD", "Cayman Islands Dollar", AssetClass.Cash),
            new Asset("BMD", "Bermudian Dollar", AssetClass.Cash),
            new Asset("BSD", "Bahamian Dollar", AssetClass.Cash),
            new Asset("FKP", "Falkland Islands Pound", AssetClass.Cash)
        );
    }
}