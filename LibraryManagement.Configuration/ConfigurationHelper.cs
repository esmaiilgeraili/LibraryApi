using LibraryManagement.Shared.Contracts.ConfigurationDTO;

namespace LibraryManagement.Configuration
{
    public class ConfigurationHelper
    {
        public static ConfigurationModel GetConfiguration()
        {
            try
            {
                DotNetEnv.Env.TraversePath().Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Private Config File Not Found");
            }

            var ConnectionStringModel = new ConnectionStringModel()
            {
                LibraryContextDB = Environment.GetEnvironmentVariable("LM_CONNECTIONSTRINGMODEL_LibraryContextDB"),
            };

            //************************************Result*******************************************
            try
            {
                var res = new ConfigurationModel()
                {
                    ConnectionString = ConnectionStringModel,
                };

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
