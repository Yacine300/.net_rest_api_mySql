namespace firstApi.CommenUtility
{
    public class SqlQeuries
    {
        public static IConfiguration _configuration = new ConfigurationBuilder().AddXmlFile("sqlQeuries.xml", true, true).Build();
        public static string AddInformation {
            get{ return _configuration["AddInformation"];
            } }
        public static string Login
        {
            get
            {
                return _configuration["Login"];
            }
        }
    }
}
