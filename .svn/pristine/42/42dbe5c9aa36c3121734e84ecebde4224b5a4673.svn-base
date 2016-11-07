using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NasSeminarski
{
    public static class EkstendedFunkcije
    {
        public static string ToMyStrDMYYYY(this DateTime source)
        {
            return source.ToString("dd'.'MM'.'yyyy'.'");
        }

        public static string ToMyStrDMYYYY(this DateTime? source, string valueForNull)
        {
            return source.HasValue ? source.Value.ToString("dd'.'MM'.'yyyy'.'") : valueForNull;
        }
    }
}