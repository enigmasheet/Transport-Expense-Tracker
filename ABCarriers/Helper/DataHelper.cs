using NepaliDateConverter;
using System;

namespace ABCarriers.Helper
{
	
    public class DateHelper
    {
        // Convert English (AD) to Nepali (BS)
        public static string ConvertToNepaliDate(DateTime englishDate)
        {
            var nepaliDate = NepaliDateConverter.EnglishToNepali(englishDate);
            return $"{nepaliDate.Year}/{nepaliDate.Month}/{nepaliDate.Day}";
        }

        // Convert Nepali (BS) to English (AD)
        public static DateTime ConvertToEnglishDate(int year, int month, int day)
        {
            var englishDate = NepaliDateConverter.NepaliToEnglish(year, month, day);
            return new DateTime(englishDate.Year, englishDate.Month, englishDate.Day);
        }
    }

}
