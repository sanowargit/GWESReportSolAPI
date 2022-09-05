using System.Data;
using System;

namespace GwesReportApi.Models
{
    public class DataFormat
    {
        public int GetIntValue(DataRow DR, String key)
        {
            if (DR[key] != null && DR[key] != DBNull.Value && !DR[key].Equals(""))
                return int.Parse(DR[key].ToString());
            else
                return 0;
        }

        public String GetStringValue(DataRow DR, String key)
        {
            if (DR[key] != null && DR[key] != DBNull.Value)
                return DR[key].ToString();
            else
                return "";
        }

        public decimal GetDecimalValue(DataRow DR, String key)
        {
            if (DR[key] != null && DR[key] != DBNull.Value && !DR[key].Equals(""))
                return decimal.Parse(DR[key].ToString());
            else
                return decimal.Parse("0.00");
        }
        public decimal GetDecimalValue(DataRow DR, String key, int decimalPlace)
        {
            string decimalPlaceString = "N" + decimalPlace.ToString();

            if (DR[key] != null && DR[key] != DBNull.Value && !DR[key].Equals(""))
                return decimal.Parse((decimal.Parse(DR[key].ToString())).ToString(decimalPlaceString));
            else
                return decimal.Parse("0.00");
        }

        public double GetDoubleValue(DataRow DR, String key)
        {
            if (DR[key] != null && DR[key] != DBNull.Value && !DR[key].Equals(""))
                return double.Parse(DR[key].ToString());
            else
                return double.Parse("0.00");
        }

        public double GetDoubleValue(DataRow DR, String key, int decimalPlace)
        {
            string decimalPlaceString = "N" + decimalPlace.ToString();

            if (DR[key] != null && DR[key] != DBNull.Value && !DR[key].Equals(""))
                return double.Parse((double.Parse(DR[key].ToString())).ToString(decimalPlaceString));
            else
                return double.Parse("0.00");
        }

        public DateTime GetDateTime(DataRow DR, String key)
        {
            if (DR[key] != null && DR[key] != DBNull.Value && !DR[key].Equals(""))
                return DateTime.Parse(DR[key].ToString());
            else
                return DateTime.Parse("");
        }
        public bool GetBoolValue(DataRow DR, String key)
        {
            if (DR[key] != null && DR[key] != DBNull.Value && !DR[key].Equals(""))
                return bool.Parse(DR[key].ToString());
            else
                return bool.Parse("0");
        }

    }
}
