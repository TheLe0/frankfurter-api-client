using Frankfurter.API.Client.Domain;
using Frankfurter.API.Client.Resources;

namespace Frankfurter.API.Client.Extensions
{
    internal static class CurrencyCodeParser
    {
        internal static CurrencyCode ToCurrencyCode(this string currencyCodeStr)
        {
            if (currencyCodeStr == Currencies.AustralianDollar) return CurrencyCode.AUD;
            if (currencyCodeStr == Currencies.BrazilianReal) return CurrencyCode.BRL;
            if (currencyCodeStr == Currencies.BritishPound) return CurrencyCode.GBP;
            if (currencyCodeStr == Currencies.BulgarianLev) return CurrencyCode.BGN;
            if (currencyCodeStr == Currencies.CanadianDollar) return CurrencyCode.CAD;
            if (currencyCodeStr == Currencies.ChineseRenminbiYuan) return CurrencyCode.CNY;
            if (currencyCodeStr == Currencies.CzechKoruna) return CurrencyCode.CZK;
            if (currencyCodeStr == Currencies.DanishKrone) return CurrencyCode.DKK;
            if (currencyCodeStr == Currencies.Euro) return CurrencyCode.EUR;
            if (currencyCodeStr == Currencies.HongKongDollar) return CurrencyCode.HKD;
            if (currencyCodeStr == Currencies.HungarianForint) return CurrencyCode.HUF;
            if (currencyCodeStr == Currencies.IcelandicKrona) return CurrencyCode.ISK;
            if (currencyCodeStr == Currencies.IndianRupee) return CurrencyCode.INR;
            if (currencyCodeStr == Currencies.IndonesianRupiah) return CurrencyCode.IDR;
            if (currencyCodeStr == Currencies.IsraeliNewSheqel) return CurrencyCode.ILS;
            if (currencyCodeStr == Currencies.JapaneseYen) return CurrencyCode.JPY;
            if (currencyCodeStr == Currencies.MalaysianRinggit) return CurrencyCode.MYR;
            if (currencyCodeStr == Currencies.MexicanPeso) return CurrencyCode.MXN;
            if (currencyCodeStr == Currencies.NewZealandDollar) return CurrencyCode.NZD;
            if (currencyCodeStr == Currencies.NorwegianKrone) return CurrencyCode.NOK;
            if (currencyCodeStr == Currencies.PhilippinePeso) return CurrencyCode.PHP;
            if (currencyCodeStr == Currencies.PolishZloty) return CurrencyCode.PLN;
            if (currencyCodeStr == Currencies.RomanianLeu) return CurrencyCode.RON;
            if (currencyCodeStr == Currencies.SingaporeDollar) return CurrencyCode.SGD;
            if (currencyCodeStr == Currencies.SouthAfricanRand) return CurrencyCode.ZAR;
            if (currencyCodeStr == Currencies.SouthKoreanWon) return CurrencyCode.KRW;
            if (currencyCodeStr == Currencies.SwedishKrona) return CurrencyCode.SEK;
            if (currencyCodeStr == Currencies.SwissFranc) return CurrencyCode.CHF;
            if (currencyCodeStr == Currencies.ThaiBaht) return CurrencyCode.THB;
            if (currencyCodeStr == Currencies.TurkishLira) return CurrencyCode.TRY;
            if (currencyCodeStr == Currencies.UnitedStatesDollar) return CurrencyCode.USD;

            return CurrencyCode.NONE;
        }

        internal static string ToString(this CurrencyCode currencyCode)
        {
            return currencyCode switch
            {
                CurrencyCode.AUD => Currencies.AustralianDollar,
                CurrencyCode.BRL => Currencies.BrazilianReal,
                CurrencyCode.GBP => Currencies.BritishPound,
                CurrencyCode.CAD => Currencies.CanadianDollar,
                CurrencyCode.CNY => Currencies.ChineseRenminbiYuan,
                CurrencyCode.CZK => Currencies.CzechKoruna,
                CurrencyCode.DKK => Currencies.DanishKrone,
                CurrencyCode.EUR => Currencies.Euro,
                CurrencyCode.HKD => Currencies.HongKongDollar,
                CurrencyCode.HUF => Currencies.HungarianForint,
                CurrencyCode.ISK => Currencies.IcelandicKrona,
                CurrencyCode.INR => Currencies.IndianRupee,
                CurrencyCode.IDR => Currencies.IndonesianRupiah,
                CurrencyCode.ILS => Currencies.IsraeliNewSheqel,
                CurrencyCode.JPY => Currencies.JapaneseYen,
                CurrencyCode.MYR => Currencies.MalaysianRinggit,
                CurrencyCode.MXN => Currencies.MexicanPeso,
                CurrencyCode.NZD => Currencies.NewZealandDollar,
                CurrencyCode.NOK => Currencies.NorwegianKrone,
                CurrencyCode.PHP => Currencies.PhilippinePeso,
                CurrencyCode.PLN => Currencies.PolishZloty,
                CurrencyCode.RON => Currencies.RomanianLeu,
                CurrencyCode.SGD => Currencies.SingaporeDollar,
                CurrencyCode.ZAR => Currencies.SouthAfricanRand,
                CurrencyCode.SEK => Currencies.SwedishKrona,
                CurrencyCode.CHF => Currencies.SwissFranc,
                CurrencyCode.THB => Currencies.ThaiBaht,
                CurrencyCode.TRY => Currencies.TurkishLira,
                CurrencyCode.USD => Currencies.UnitedStatesDollar,
                _ => string.Empty
            }; 
        }
    }
}
