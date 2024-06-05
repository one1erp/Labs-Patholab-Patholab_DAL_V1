using LSSERVICEPROVIDERLib;
using Oracle.ManagedDataAccess.Client;
using Patholab_Common;
//using Oracle.ManagedDataAccess.Client;

using System;
using System.Configuration;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Mapping;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;


namespace Patholab_DAL_V1
{
    public class ConnectionsGenerator
    {

        private readonly INautilusDBConnection _ntlsCon;

        static bool ManagedProvider = true;
        static string providerS;
        string provider;
        public string _adoConString;
#pragma warning disable CS0649 // Field 'ConnectionsGenerator._nautilusDbConnection' is never assigned to, and will always have its default value null
        private readonly INautilusDBConnection _nautilusDbConnection;
#pragma warning restore CS0649 // Field 'ConnectionsGenerator._nautilusDbConnection' is never assigned to, and will always have its default value null
        public ConnectionsGenerator(INautilusDBConnection ntlsCon)
        {


            _ntlsCon = ntlsCon;
            SetProvider();
     

            if (ManagedProvider)
                provider = "Oracle.ManagedDataAccess.Client";//one1pc1092  
            else
                provider = "Oracle.DataAccess.Client";//one1pc2123


        }

        private static void SetProvider()
        {

            //Ashi:add it because instalaiton problems 13/09/20
            var providerKey = ConfigurationManager.AppSettings["ManagedProvider"];
            if ((providerKey != null && providerKey.ToString().ToUpper() == "FALSE")
                || Environment.MachineName == "ONE1PC2123" || Environment.MachineName == "ONE1PC2211"
                || Environment.MachineName == "ONE1PC2269" || Environment.MachineName == "ONE1PC2643" || Environment.MachineName == "ONE1PC2619")
            {
                ManagedProvider = false;
                Logger.WriteLogFile("MangedProvider is false");
            }


            if (ManagedProvider)
                providerS = "Oracle.ManagedDataAccess.Client";//one1pc1092  
            else
                providerS = "Oracle.DataAccess.Client";//one1pc2123

        }

        public void InitNautilusConnection(Entities context)
        {
            try
            {

                // Get lims user password
                string limsUserPassword = _ntlsCon.GetLimsUserPwd();

                // Set role lims user
                string roleCommand;
                if (limsUserPassword == "")
                {
                    // LIMS_USER is not password protected
                    roleCommand = "set role lims_user";
                }
                else
                {
                    // LIMS_USER is password protected.
                    roleCommand = "set role lims_user identified by " + limsUserPassword;
                }

                // Try/Catch block
                try
                {
                    // Execute the command
                    var roleCommand_status = context.Database.ExecuteSqlCommand(roleCommand);
                }
                catch (Exception f)
                {
                    // Throw the exception
                    throw new Exception("Inconsistent role Security : " + f.Message);
                }

                // Get the session id
                double sessionId = _ntlsCon.GetSessionId();

                // Connect to the same session
                string sSql = string.Format("call lims.lims_env.connect_same_session({0})", sessionId);


                // Execute the command
                var connect_same_session_status = context.Database.ExecuteSqlCommand(sSql);

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public string BuildEfConString()
        {


            OracleConnectionStringBuilder oraBuilder =
            new OracleConnectionStringBuilder();



            var username = _ntlsCon.GetUsername();
            if (string.IsNullOrEmpty(username))
            {
                username = "/";

            }
            //Ashi check check
            oraBuilder.UserID = username;
            oraBuilder.Password = _ntlsCon.GetPassword();
            oraBuilder.DataSource = _ntlsCon.GetServerDetails();


            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
            new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = provider;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = oraBuilder.ToString(); ;

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/Model1.csdl|" +
                        "res://*/Model1.ssdl|" +
                        "res://*/Model1.msl";

            return entityBuilder.ToString();
        }

        public static EntityConnection Create(string schema, string connString, string model)
        {

            SetProvider();
            XmlReader[] conceptualReader = new XmlReader[]
    {
        XmlReader.Create(
            Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream(model + ".csdl")
        )
    };

            XmlReader[] mappingReader = new XmlReader[]
    {
        XmlReader.Create(
            Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream(model + ".msl")
        )
    };

            var storageReader = XmlReader.Create(
                Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream(model + ".ssdl")
            );
            XNamespace storageNS = "http://schemas.microsoft.com/ado/2009/11/edm/ssdl";

            var storageXml = XElement.Load(storageReader);

            storageXml.Attribute("Provider").SetValue(providerS);//"Oracle.ManagedDataAccess.Client");

            var est = storageXml.Descendants(storageNS + "EntitySet");

            foreach (var entitySet in est)  
            {
                var schemaAttribute = entitySet.Attributes("Schema").FirstOrDefault();
                if (schemaAttribute != null)
                {
                    schemaAttribute.SetValue(schema);
                }
            }

            storageXml.CreateReader();

            StoreItemCollection storageCollection =
                new StoreItemCollection(
                    new XmlReader[] { storageXml.CreateReader() }
                );

            EdmItemCollection conceptualCollection = new EdmItemCollection(conceptualReader);

            StorageMappingItemCollection mappingCollection =
                new StorageMappingItemCollection(
                    conceptualCollection, storageCollection, mappingReader
                );

            var workspace = new MetadataWorkspace();
            workspace.RegisterItemCollection(conceptualCollection);
            workspace.RegisterItemCollection(storageCollection);
            workspace.RegisterItemCollection(mappingCollection);

            var connectionData = new EntityConnectionStringBuilder(connString);

            var connection = DbProviderFactories

                        .GetFactory(providerS)

                        .CreateConnection();

            connection.ConnectionString = connectionData.ProviderConnectionString;

            return new EntityConnection(workspace, connection);
        }
        public ConnectionsGenerator(string adoConString, INautilusDBConnection nautilusDbConnection)
        {

            _ntlsCon = nautilusDbConnection;
            SetProvider();


            if (ManagedProvider)
                provider = "Oracle.ManagedDataAccess.Client";//one1pc1092  
            else
                provider = "Oracle.DataAccess.Client";//one1pc2123

            _adoConString = adoConString;

        }
        public OracleConnection GetAdoConnection()
        {
            //Create the connection
            OracleConnection connection = new OracleConnection(_adoConString);

            // Open the connection
            connection.Open();

            // Get lims user password
            string limsUserPassword = _nautilusDbConnection.GetLimsUserPwd();

            // Set role lims user
            string roleCommand;
            if (limsUserPassword == "")
            {
                // LIMS_USER is not password protected
                roleCommand = "set role lims_user";
            }
            else
            {
                // LIMS_USER is password protected.
                roleCommand = "set role lims_user identified by " + limsUserPassword;
            }

            // set the Oracle user for this connecition
            OracleCommand command = new OracleCommand(roleCommand, connection);

            // Try/Catch block
            try
            {
                // Execute the command
                command.ExecuteNonQuery();
            }
            catch (Exception f)
            {
                // Throw the exception
                throw new Exception("Inconsistent role Security : " + f.Message);
            }

            // Get the session id
            double sessionId = _nautilusDbConnection.GetSessionId();

            // Connect to the same session
            string sSql = string.Format("call lims.lims_env.connect_same_session({0})", sessionId);

            // Build the command
            command = new OracleCommand(sSql, connection);

            // Execute the command
            command.ExecuteNonQuery();

            return connection;
        }

      
    }
}
