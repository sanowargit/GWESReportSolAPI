
using Microsoft.Extensions.Configuration;

namespace GwesReportApi.Inventory
{
    public class Settings
    {
        private static IConfiguration Configuration { get; }

        public static string GwesConnectionString 
        {
           get { return Configuration.GetConnectionString("DefaultConnection"); } 
        }
        
        public static string Secret
        {
            get { return Configuration.GetValue<string>("AppSettings:Secret"); }
        }

        public static string AesKey
        {
            get { return Configuration.GetValue<string>("AppSettings:AesKey"); }
        }
        public static bool ValidateLifetime
        {
           
           get { if (Configuration.GetValue<string>("AppSettings:ValidateLifetime") == "true") { return true; } else { return false; } }
        }
        public static bool ValidateIssuerSigningKey
        {
            
            get { if (Configuration.GetValue<string>("AppSettings:ValidateIssuerSigningKey") == "true") { return true; } else { return false; } }
        }
        public static bool ValidateAudience
        {
            get { if (Configuration.GetValue<string>("AppSettings:ValidateAudience") == "true") { return true; } else { return false; } }
        }
        public static bool ValidateIssuer
        {
            
            get { if (Configuration.GetValue<string>("AppSettings:ValidateIssuer") == "true") { return true; } else { return false; }}
        }

        public static string ValidAudience
        {
            get { return Configuration.GetValue<string>("AppSettings:ValidAudience"); }
        }
        public static string ValidIssuer
        {
            get { return Configuration.GetValue<string>("AppSettings:ValidIssuer"); }
        }
        public static string ValidIPAddress
        {
            get { return Configuration.GetValue<string>("AppSettings:ValidIPAddress"); }
        }
    }
}
