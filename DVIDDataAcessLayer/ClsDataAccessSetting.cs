using System;

namespace DVIDDataAcessLayer
{
    internal static class ClsDataAccessSetting
    {
        public static string ConnectionString = Environment.GetEnvironmentVariable("DVLD_CONNECTION_STRING");
    }
}
