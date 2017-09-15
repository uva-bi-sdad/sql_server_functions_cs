using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Globalization;

namespace CS_SHAKER
{
    public partial class UserDefinedFunctions
    {
        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString PersonNameNormalize(string s)
        {
            string normalized = s.Normalize(NormalizationForm.FormD);

            StringBuilder resultBuilder = new StringBuilder();
            foreach (var character in normalized)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(character);
                if (category == UnicodeCategory.LowercaseLetter
                    || category == UnicodeCategory.UppercaseLetter
                    || category == UnicodeCategory.SpaceSeparator)
                    resultBuilder.Append(character);
            }
            string retString = resultBuilder.ToString().Trim().ToUpper();
            retString = Regex.Replace(retString.ToUpper(), "^MRS ", "");
            retString = Regex.Replace(retString.ToUpper(), "^MS ", "");
            retString = Regex.Replace(retString.ToUpper(), "^MR ", "");
            retString = Regex.Replace(retString.ToUpper(), "^DR ", "");
            retString = Regex.Replace(retString.ToUpper(), " II$", "");
            retString = Regex.Replace(retString.ToUpper(), " III$", "");
            retString = Regex.Replace(retString.ToUpper(), " IV$", "");
            retString = Regex.Replace(retString.ToUpper(), " V$", "");
            retString = Regex.Replace(retString.ToUpper(), " JR$", "");
            retString = Regex.Replace(retString.ToUpper(), " SR$", "");
            retString = Regex.Replace(retString, @"\s", "");
            return retString;
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString PlaceNameNormalize(string s)
        {
            string normalized = s.Normalize(NormalizationForm.FormD);

            StringBuilder resultBuilder = new StringBuilder();
            foreach (var character in normalized)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(character);
                if (category == UnicodeCategory.LowercaseLetter
                    || category == UnicodeCategory.UppercaseLetter
                    || category == UnicodeCategory.SpaceSeparator)
                    resultBuilder.Append(character);
            }
            string retString = resultBuilder.ToString().TrimStart();
            retString = Regex.Replace(retString.ToUpper(), "^THE ", "");
            retString = Regex.Replace(retString.ToUpper(), "^A ", "");
            retString = Regex.Replace(retString, @"\s", "");
            return retString;
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString PlaceStreetNameNormalize(string s)
        {
            string normalized = s.Normalize(NormalizationForm.FormD);

            StringBuilder resultBuilder = new StringBuilder();
            foreach (var character in normalized)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(character);
                if (category == UnicodeCategory.LowercaseLetter
                    || category == UnicodeCategory.UppercaseLetter
                    || category == UnicodeCategory.DecimalDigitNumber
                    || category == UnicodeCategory.SpaceSeparator)
                    resultBuilder.Append(character);
            }
            string retString = resultBuilder.ToString().Trim();
            retString = Regex.Replace(retString.ToUpper(), "^EAST ", "E");
            retString = Regex.Replace(retString.ToUpper(), "^WEST ", "W");
            retString = Regex.Replace(retString.ToUpper(), "^NORTH ", "N");
            retString = Regex.Replace(retString.ToUpper(), "^SOUTH ", "S");
            retString = Regex.Replace(retString.ToUpper(), " CIRCLE$", "");
            retString = Regex.Replace(retString.ToUpper(), " PLACE$", "");
            retString = Regex.Replace(retString.ToUpper(), " BLVD$", "");
            retString = Regex.Replace(retString.ToUpper(), " HIGHWAY$", "");
            retString = Regex.Replace(retString.ToUpper(), " HWY$", "");
            retString = Regex.Replace(retString.ToUpper(), " AVE$", "");
            retString = Regex.Replace(retString.ToUpper(), " AVE ", "");
            retString = Regex.Replace(retString.ToUpper(), " AVENUE$", "");
            retString = Regex.Replace(retString.ToUpper(), " ROAD$", "");
            retString = Regex.Replace(retString.ToUpper(), " RAOD$", "");
            retString = Regex.Replace(retString.ToUpper(), " RD$", "");
            retString = Regex.Replace(retString.ToUpper(), " LANE$", "");
            retString = Regex.Replace(retString.ToUpper(), " LN$", "");
            retString = Regex.Replace(retString.ToUpper(), " SQUARE$", "");
            retString = Regex.Replace(retString.ToUpper(), " SQR$", "");
            retString = Regex.Replace(retString.ToUpper(), " COURT$", "");
            retString = Regex.Replace(retString.ToUpper(), " CRT$", "");
            retString = Regex.Replace(retString.ToUpper(), " STREET$", "");
            retString = Regex.Replace(retString.ToUpper(), " STREET ", "");
            retString = Regex.Replace(retString.ToUpper(), " STR$", "");
            retString = Regex.Replace(retString.ToUpper(), " STR ", "");
            retString = Regex.Replace(retString, @"\s", "");
            return retString;
        }
    }
}

