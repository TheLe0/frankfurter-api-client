using Frankfurter.API.Client.Domain;
using Frankfurter.API.Client.Resources;

namespace Frankfurter.API.Client.Extensions
{
    internal static class CurrencyCodeParser
    {
        internal static CurrencyCode ToCurrencyCode(this string currencyCodeStr)
        {
            if (currencyCodeStr == Currencies.AustralianDollar)
                return CurrencyCode.AUD;
            else if (currencyCodeStr == Currencies.BrazilianReal)
                return CurrencyCode.BRL;
            else if (currencyCodeStr == Currencies.BritishPound)
                return CurrencyCode.GBP;
            else if (currencyCodeStr == Currencies.BulgarianLev)
                return CurrencyCode.BGN;
            else if (currencyCodeStr == Currencies.CanadianDollar)
                return CurrencyCode.CAD;
            else if (currencyCodeStr == Currencies.ChineseRenminbiYuan)
                return CurrencyCode.CNY;
            else if (currencyCodeStr == Currencies.CzechKoruna)
                return CurrencyCode.CZK;
            else if (currencyCodeStr == Currencies.DanishKrone)
                return CurrencyCode.DKK;
            else if (currencyCodeStr == Currencies.Euro)
                return CurrencyCode.EUR;
            else if (currencyCodeStr == Currencies.HongKongDollar)
                return CurrencyCode.HKD;
            else if (currencyCodeStr == Currencies.HungarianForint)
                return CurrencyCode.HUF;
            else if (currencyCodeStr == Currencies.IcelandicKrona)
                return CurrencyCode.ISK;
            else if (currencyCodeStr == Currencies.IndianRupee)
                return CurrencyCode.INR;
            else if (currencyCodeStr == Currencies.IndonesianRupiah)
                return CurrencyCode.IDR;
            else if (currencyCodeStr == Currencies.IsraeliNewSheqel)
                return CurrencyCode.ILS;
            else if (currencyCodeStr == Currencies.JapaneseYen)
                return CurrencyCode.JPY;
            else if (currencyCodeStr == Currencies.MalaysianRinggit)
                return CurrencyCode.MYR;
            else if (currencyCodeStr == Currencies.MexicanPeso)
                return CurrencyCode.MXN;
            else if (currencyCodeStr == Currencies.NewZealandDollar)
                return CurrencyCode.NZD;
            else if (currencyCodeStr == Currencies.NorwegianKrone)
                return CurrencyCode.NOK;
            else if (currencyCodeStr == Currencies.PhilippinePeso)
                return CurrencyCode.PHP;
            else if (currencyCodeStr == Currencies.PolishZloty)
                return CurrencyCode.PLN;
            else if (currencyCodeStr == Currencies.RomanianLeu)
                return CurrencyCode.RON;
            else if (currencyCodeStr == Currencies.SingaporeDollar)
                return CurrencyCode.SGD;
            else if (currencyCodeStr == Currencies.SouthAfricanRand)
                return CurrencyCode.ZAR;
            else if (currencyCodeStr == Currencies.SouthKoreanWon)
                return CurrencyCode.KRW;
            else if (currencyCodeStr == Currencies.SwedishKrona)
                return CurrencyCode.SEK;
            else if (currencyCodeStr == Currencies.SwissFranc)
                return CurrencyCode.CHF;
            else if (currencyCodeStr == Currencies.ThaiBaht)
                return CurrencyCode.THB;
            else if (currencyCodeStr == Currencies.TurkishLira)
                return CurrencyCode.TRY;
            else if (currencyCodeStr == Currencies.UnitedStatesDollar)
                return CurrencyCode.USD;
            else
                return CurrencyCode.None;
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
