using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace EMS_DataAccses_Layer
{
    public class clsSettingConnection
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["EMS"].ConnectionString;
        // "Server=.;Database=EMS;User Id=sa;Password=sa123456;";

        public static void LogError(string Message)
        {
            string sourceName = "EMS";

            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            EventLog.WriteEntry(sourceName, Message, EventLogEntryType.Information);
        }
    }
}
