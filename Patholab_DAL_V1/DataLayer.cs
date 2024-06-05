using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using LSSERVICEPROVIDERLib;
using Patholab_Common;
using Patholab_DAL_V1.Logic;
using Patholab_DAL_V1.Packages;
using System.Reflection.Emit;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;

namespace Patholab_DAL_V1
{
    public class DataLayer
    {

        internal Entities context;
        internal OracleConnection OraCon;
        public static string ConnectionString { get; set; }
        private EntityConnection entityConnection;
        private INautilusDBConnection _ntlsCon;
        private ConnectionsGenerator generator;
#pragma warning disable CS0169 // The field 'DataLayer._session_id' is never used
        double _session_id;
#pragma warning restore CS0169 // The field 'DataLayer._session_id' is never used

        public DataLayer(bool debug = false)
        {

        }

        public DataLayer(int x)
        {

        }
        public void OpenListener()
        {
#pragma warning disable CS0168 // Variable is declared but never used
            try
            {


                // Enable Tracing queries
                //     Clutch.Diagnostics.EntityFramework.DbTracing.Enable ( );
                // Adding the listener (implementation of IDbTracingListener)
                //    Clutch.Diagnostics.EntityFramework.DbTracing.AddListener (
                //    new Packages.DbTracingListener ( ) );// IDbTracingListener()); 
            }
            catch (Exception xx)
            {


            }
#pragma warning restore CS0168 // Variable is declared but never used
        }

        public List<T> FetchDataFromDB<T>(string query, Func<OracleDataReader, T> mapFunc)
        {
            List<T> results = new List<T>();

            #region  Sample calling format

            //    List<SpecificSdgLogRow> rowsFromDB = _dal.FetchDataFromDB(query, reader =>
            //    {
            //        return new SpecificSdgLogRow
            //        {
            //            SdgId = Convert.ToInt32(reader[0]),
            //            Time = Convert.ToDateTime(reader[1]),
            //            Description = reader[2].ToString(),
            //            Info = reader[3].ToString()
            //        };
            //    });

            #endregion

            try
            {
                var oraCon = GetOracleConnection(_ntlsCon);

                using (OracleCommand command = oraCon.CreateCommand())
                {
                    command.CommandText = query;

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T item = mapFunc(reader);
                            results.Add(item);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("DB ERROR " + ex.Message);
            }
            return results;

        }

        public OracleConnection GetOracleConnection(INautilusDBConnection ntlsCon)
        {
            OracleConnection connection = null;

            if (ntlsCon != null)
            {
                try
                {
                    // Get the ADO.NET connection string from the provided interface
                    string _connectionString = ntlsCon.GetADOConnectionString();

                    // Split the connection string by ';' to extract relevant information
                    var splitted = _connectionString.Split(';');

                    // Initialize a new connection string
                    var cs = "";

                    // Build the connection string excluding the first element (assumed to be the provider)
                    for (int i = 1; i < splitted.Length; i++)
                    {
                        cs += splitted[i] + ';';
                    }

                    
                    // Get the username from the provided interface
                    var username = ntlsCon.GetUsername();

   

                    // If username is empty, construct a new connection string with default user
                    if (string.IsNullOrEmpty(username))
                    {
                        var serverDetails = ntlsCon.GetServerDetails();
                        cs = "User Id=/;Data Source=" + serverDetails + ";";
                    }

                    // Create a new Oracle connection using the prepared connection string
                    connection = new OracleConnection(cs);


                    // Open the connection to the Oracle database
                    connection.Open();



                    // Get the LIMS user password from the provided interface
                    string limsUserPassword = ntlsCon.GetLimsUserPwd();


                    // Determine the SQL command to set the role based on the presence of LIMS user password
                    string roleCommand = string.IsNullOrEmpty(limsUserPassword) ? "set role lims_user" : "set role lims_user identified by " + limsUserPassword;


                    // Execute the role-setting command on the Oracle connection
                    OracleCommand command = new OracleCommand(roleCommand, connection);

                    command.ExecuteNonQuery();

                    // Get the session ID from the provided interface
                    double _session_id = ntlsCon.GetSessionId();

                    // Prepare and execute the SQL command to connect to the specified session
                    string sSql = string.Format("call lims.lims_env.connect_same_session({0})", _session_id);
                    command = new OracleCommand(sSql, connection);
                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    // Catch and rethrow any exceptions that occur during the Oracle connection establishment
                    throw new Exception("An error occurred while establishing Oracle connection: " + e.Message);
                }

            }

            return connection;
        }



        public OracleConnection GetOracleConnection()
        {

            return generator.GetAdoConnection();

        }

        public void Connect(INautilusDBConnection nautilusDbConnection)
        {


            this._ntlsCon = nautilusDbConnection;
            if (_ntlsCon.GetUsername() == "ashi")
            {

                //HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
                OpenListener();
            }
            Utils.CreateConstring(_ntlsCon);

            generator = new ConnectionsGenerator(nautilusDbConnection);

            var cs = generator.BuildEfConString();

            EntityConnection ec = ConnectionsGenerator.Create("LIMS_SYS", cs, "Model1");

            context = new Entities(ec);

            generator.InitNautilusConnection(context);


        }

        #region Oracle connection not in use

        public OracleConnection OpenSqlOraCon()
        {

            OraCon = new OracleConnection();
            OracleConnectionStringBuilder oraBuilder =
                new OracleConnectionStringBuilder();

            var username = _ntlsCon.GetUsername();
            if (string.IsNullOrEmpty(username))
            {
                username = "/";
            }

            oraBuilder.UserID = username;
            oraBuilder.Password = _ntlsCon.GetPassword();
            oraBuilder.DataSource = _ntlsCon.GetServerName();
            OraCon.ConnectionString = oraBuilder.ToString();
            OraCon.Open();

            String roleCommand = "set role lims_user";
            // set the Oracle user for this connecition
            OracleCommand command = new OracleCommand(roleCommand, OraCon);

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
            var sessionId = _ntlsCon.GetSessionId();

            // Connect to the same session
            string sSql = string.Format("call lims.lims_env.connect_same_session({0})", sessionId);
            command = new OracleCommand(sSql, OraCon);

            // Execute the command
            command.ExecuteNonQuery();

            return OraCon;
        }



        #endregion


        public void MockConnect()
        {
            //   OpenListener();
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            string csONE1 = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=\" Oracle.DataAccess.Client\";provider connection string=\"Data Source=PATHOLAB;User ID=Ashi;Password=aa\"";
#pragma warning restore CS0219 // Variable is assigned but its value is never used
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            string csPATHO = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=\" Oracle.DataAccess.Client\";provider connection string=\"Data Source=LIMSPROD;User ID=lims_sys;Password=lims_sys\"";
#pragma warning restore CS0219 // Variable is assigned but its value is never used

            string csnaut94 = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=\" Oracle.DataAccess.Client\";provider connection string=\"Data Source=naut;User ID=lims_sys;Password=lims_sys\"";
            //csPATHO

            //     if (1==1)
            //    HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

            //       OpenListener();
            entityConnection = ConnectionsGenerator.Create("LIMS_SYS", csnaut94, "Model1");

            context = new Entities(entityConnection);

            //  context=new Entities(csONE1);

        }


        public void MockConnect(string connectionString)
        {
            entityConnection = ConnectionsGenerator.Create("LIMS_SYS", connectionString, "Model1");

            context = new Entities(entityConnection);

            return;

        }
        public DbSet<TEntity> GetAll<TEntity>() where TEntity : class
        {
            var qq = Repository.GetAll<TEntity>(context);
            return qq;
        }

        public string GetSession_role()
        {
            var aa = context.Database.SqlQuery<string>("select * from session_roles").ToList();
            return aa[0];
        }
        public System.Linq.IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            var q = Repository.FindBy<TEntity>(context, predicate);
            return q;
        }
        public decimal GetSdgByContainer(string containerId)
        {
            return RunFunction.GetSdgByContainer(context, containerId);
        }
        public decimal GetSamplesByContainer(string containerId)
        {
            return RunFunction.GetSamplesByContainer(context, containerId);
        }

        public decimal GetSamplesByContainerAndStatus(string containerId)
        {
            return RunFunction.GetSamplesByContainerAndStatus(context, containerId);
        }
        public decimal IfExitEXTRA_SLIDES_STATUS_P(string BlockNumber, string ExRequestCreatedOn)
        {
            return RunFunction.IfExitEXTRA_SLIDES_STATUS_P(context, BlockNumber, ExRequestCreatedOn);
        }

        public SDG GetSdgTree(long sdgId)
        {

            var sdg = (from item in context.SDGs.Include("SAMPLEs")
                       .Include("SAMPLEs.ALIQUOTs")
                       .Include("SAMPLEs.ALIQUOTs.TESTs")
                       .Include("SAMPLEs.ALIQUOTs.TESTs.RESULTs")
                       where item.SDG_ID == sdgId
                       select item).FirstOrDefault();

            return sdg;
        }
        public IQueryable<RESULT> GetSdgResultsxxxxxxx(long sdgId)//Ashi cancel 26/05/22
        {

            var tree = (from sdg in context.SDGs
                        from sample in context.SAMPLEs
                        from aliq in context.ALIQUOT
                        from tst in context.TESTs
                        from res in context.RESULTs
                        where sdg.SDG_ID == sdgId
                        && sample.SDG_ID.Value == sdg.SDG_ID
                        && aliq.SAMPLE_ID.Value == sample.SAMPLE_ID
                        && tst.ALIQUOT_ID.Value == aliq.ALIQUOT_ID
                        && res.TEST_ID.Value == tst.TEST_ID
                        select res);

            return tree;
        }


        public IQueryable<SDG> GetSdgRevisions()
        {
            var revisionNames = from c in context.SDGs
                                group c by c.NAME.Substring(0, 10) into grp
                                where grp.Count() > 1
                                select grp.Key;


            var sdgRev = from sdg in context.SDGs
                         from rn in revisionNames
                         where sdg.NAME == rn
                         select sdg;


            return sdgRev;
        }

        public void Close()
        {
            try
            {
                context.Database.Connection.Close();

                //ashi 15.8.18
                //      ????Check it again if helps for leaking memory
                //context.Dispose();
                //  context = null;
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
            }
        }

        public SDG_DETAILS Get_SDG_DETAILS(long sdgId)
        {

            return SdgLogic.Get_SDG_DETAILS(context, sdgId);
        }
        public SDG_DETAILS Get_SDG_DETAILS(string name)
        {

            return SdgLogic.Get_SDG_DETAILS(context, name);
        }

        public List<SDG_RESULTS> Get_SDG_RESULTS(long sdgId)
        {
            return SdgLogic.Get_SDG_RESULTS(context, sdgId);


        }

        public List<SDG_RESULTS> Get_SDG_RESULTS(string name)
        {
            return SdgLogic.Get_SDG_RESULTS(context, name);
        }




        /// <summary>
        /// Add Extra req to DB
        /// </summary>
        /// <param name="sdgId">Add the request to this Sdg Id</param>
        /// <param name="entityName">The EntityName, for example: B000001/22</param>
        /// <param name="exRequestType"> Request Type: T for consult, I for Immono.....</param>
        /// <param name="createdByOperator"></param>
        /// <param name="reqDet">Request Details</param>
        /// <param name="remarks">Request remarks</param>
        /// <returns></returns>
        public U_EXTRA_REQUEST_DATA Ex_Req_Logic(long sdgId, string entityName,
            Enums.ExtraRequestType exRequestType, long createdByOperator, string reqDet, string remarks)
        {

            #region כרגע לא מממשים רשומה אחת לכל דרישה

            //   var sdgHasRequests = FindBy<U_EXTRA_REQUEST_USER>(x => x.U_SDG_ID == sdgId).FirstOrDefault();
            //   if (sdgHasRequests == null)
            //   {
            // the current sdg with sdgId has no Extra Request, hence we need to add U_EXTRA_REQUEST in addition to U_EXTRA_REQUEST_DATA
            //     }
            //     else
            //     {
            // the current sdg with sdgId has Extra Request already, hence we need to add only U_EXTRA_REQUEST_DATA with the same U_EXTRA_REQUEST_ID of the parent U_EXTRA_REQUEST

            //    parentId = sdgHasRequests.U_EXTRA_REQUEST_ID;
            //     }
            #endregion

            string requestReason = ExtraRequestLogic.GetReason(exRequestType);

            var date = DateTime.Now;

            long? parentId;

            //Add new U_EXTRA_REQUEST
            var ExReqId = GetNewId("SQ_U_EXTRA_REQUEST");
            long convertedExReqId = Convert.ToInt64(ExReqId);
            U_EXTRA_REQUEST req = new U_EXTRA_REQUEST()
            {
                NAME = requestReason + ";" + ExReqId,
                U_EXTRA_REQUEST_ID = convertedExReqId,
                VERSION = "1",
                VERSION_STATUS = "A",
            };
            //Add new U_EXTRA_REQUEST_USER
            U_EXTRA_REQUEST_USER reqUser = new U_EXTRA_REQUEST_USER()
            {
                U_EXTRA_REQUEST_ID = convertedExReqId,
                U_SDG_ID = sdgId,
                U_CREATED_ON = date,
                U_CREATED_BY = createdByOperator,
                U_STATUS = "V"
            };

            Add(req);
            Add(reqUser);

            parentId = convertedExReqId;



            //Get Entity Type  Sample\Block\Slide";
            string entType = ExtraRequestLogic.GetEntityType(entityName);

            //Get Request Type New Color
            string reqType = Enum.GetName(typeof(Enums.ExtraRequestType), exRequestType);


            string eqdName = entityName;
            if (requestReason == "Add Slide")
            {
                eqdName = entityName.Substring(0, 14);
                reqType = GetPartType(reqDet);
                entType = "Block";
            }

            //ADD NEW U_EXTRA_REQUEST_DATA
            var ExReqUserId = GetNewId("SQ_U_EXTRA_REQUEST_DATA");
            var ConvertedExReqUserId = Convert.ToInt64(ExReqUserId);
            U_EXTRA_REQUEST_DATA rd = new U_EXTRA_REQUEST_DATA()
            {
                U_EXTRA_REQUEST_DATA_ID = ConvertedExReqUserId,
                NAME = eqdName + ";" + ExReqUserId,
                DESCRIPTION = "F",
                VERSION = "1",
                VERSION_STATUS = "A"
            };
            U_EXTRA_REQUEST_DATA_USER rdu = new U_EXTRA_REQUEST_DATA_USER()
            {
                U_EXTRA_REQUEST_DATA_ID = ConvertedExReqUserId,
                U_EXTRA_REQUEST_ID = parentId,
                U_ENTITY_TYPE = entType,
                U_REQUEST_DETAILS = reqDet,
                U_STATUS = "V",
                U_SLIDE_NAME = entityName,
                U_REQ_TYPE = reqType,
                U_REMARKS = remarks,
            };

            Add(rd);
            Add(rdu);
            SaveChanges();

            return rd;
        }


        /// <summary>
        /// Get Part type by color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public string GetPartType(string color)
        {
            var q = from item in context.U_PARTS_USER
                    where item.U_STAIN == color
                    select item.U_PART_TYPE;

            return q.FirstOrDefault();

        }

        #region Refresh data
        //The best way to refresh entities in your context is to dispose your context and create a new one.
        //If you really need to refresh some entity and you are using Code First approach with DbContext class, you can use
        public void ReloadEntity<TEntity>(
            TEntity entity)
            where TEntity : class
        {
            context.Entry(entity).Reload();
        }

        public void newMethod<TEntity>(TEntity entity, string NavigationProperty) where TEntity : class
        {
            context.Entry(entity).Reference(NavigationProperty).Load();

        }


        //To reload collection navigation properties, you can use
        public void ReloadNavigationProperty<TEntity, TElement>(
            TEntity entity,
            Expression<Func<TEntity, ICollection<TElement>>> navigationProperty)
            where TEntity : class
            where TElement : class
        {
            context.Entry(entity).Collection<TElement>(navigationProperty).Load();
        }
        public void RefreshAll()
        {
            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }
        #endregion

        public PHRASE_HEADER GetPhraseByName(string phraseName)
        {
            return PhraseLogic.GetPhraseByName(context, phraseName);
        }

        public PHRASE_HEADER GetPhraseByID(long PHRASE_ID)
        {
            return PhraseLogic.GetPhraseByID(context, PHRASE_ID);

        }
        public IQueryable<PHRASE_ENTRY> GetPhraseEntries(string phraseName)
        {
            return PhraseLogic.GetPhraseEntries(context, phraseName);
        }

        public IQueryable<PHRASE_ENTRY> GetPhraseEntriesNew(string phraseName)
        {
            return PhraseLogic.GetPhraseEntriesNew(context, phraseName);

        }

        public OPERATOR GetOperatorByIdIncludeRole(double operatorId)
        {
            return OperatorLogic.GetOperatorByIdIncludeRole(context, operatorId);
        }

        public decimal GetNewId(string sequenceName)
        {
            SetRoleAndConnect();
            return RunFunction.GetNewId(context, sequenceName);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            Repository.Add(context, entity);
        }
        public void Edit<TEntity>(TEntity entity) where TEntity : class
        {
            Repository.Edit(context, entity);
        }
        public DateTime GetSysdate()
        {
            return RunFunction.RunGetSysdate(context);
        }

        public long Run_Authorization_signed_by(long sdgId, long index)
        {
            return RunFunction.Run_Authorization_signed_by(context, sdgId, index);
        }
        public decimal Run_PATHOLAB_SYNTAX(long customerId, string dpt)
        {
            //return RunFunction.Run_PATHOLAB_SYNTAX(OraCon, customerId, dpt);
            return RunFunction.Run_PATHOLAB_SYNTAX(context, customerId, dpt);
        }

        public decimal? Run_GET_PRICE(long customerId, long partId)
        {
            return RunFunction.Run_Get_Price(context, customerId, partId);
        }
        public decimal? Run_GET_PRICE_URGENT(long customerId, long partId)
        {
            return RunFunction.Run_Get_Price_Urgent(context, customerId, partId);
        }
        public bool InsertToSdgLog(long SdgId, string applicationCode, long sessionId, string Description)
        {
            return RunFunction.Run_Insert_To_Sdg_Log(context, SdgId, applicationCode, sessionId, Description);
        }
        public bool OK_PAP_RESULT(long sdgId)
        {
            return RunFunction.OK_PAP_RESULT(context, sdgId);
        }

        public bool Run_CheckId(string id)
        {
            return RunFunction.Run_CheckId(context, id);
            // return RunFunction.Run_CheckId(OraCon, id);
        }
        public string OTHER_SDG_FOR_PATIENT(string id)
        {
            return RunFunction.OTHER_SDG_FOR_PATIENT(context, id);
            // return RunFunction.Run_CheckId(OraCon, id);
        }
        public dynamic RunQuery(string sql)
        {
            return RunFunction.RunQuery(context, sql);
        }
        public string GetDynamicStr(string sql)
        {
            return RunFunction.GetDynamicStr(context, sql);
        }
        public IEnumerable<string> GetDynamicList(string sql)
        {
            return RunFunction.GetDynamicList(context, sql);
        }
        public decimal? GetDynamicDecimal(string sql)
        {
            return RunFunction.GetDynamicDecimal(context, sql);
        }
        public string ExecuteScalar(string sql)
        {
            return RunFunction.ExecuteScalar(context, sql);
        }
        public List<ObjDetails> GetObjDetailses(string sql, string condition)
        {
            return RunFunction.GetObjDetailses(context, sql, condition);
        }
        public string GeneratePatholabNumber(SDG_USER newSDg)
        {
            return SdgLogic.GeneratePatholabNumber(context, newSDg);
        }
        public string ValidateSampleMsg(U_SAMPLE_MSG_USER item)
        {
            return SampleMsgLogic.ValidateSampleMsg(item);
        }
        public CLIENT AddClient(string _identity, DateTime? _birthDate,
            string ispassport, string FirstName, string lastName, string gender)
        {
            return ClientLogic.AddClient(context, _identity, _birthDate,
              ispassport, FirstName, lastName, gender);
        }
        public void SetRoleAndConnect()
        {

            string limsUserPassword = "";
            if (_ntlsCon != null) limsUserPassword = _ntlsCon.GetLimsUserPwd();

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
            context.Database.ExecuteSqlCommand(roleCommand);
            if (_ntlsCon != null)
            {
                double sessionId = _ntlsCon.GetSessionId();
                context.Database.ExecuteSqlCommand(string.Format("call lims.lims_env.connect_same_session({0})",
                                                                 sessionId));
            }
        }

        public void SaveChanges()
        {
            try
            {
                SetRoleAndConnect();
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //If problem it's priviliges run set role again
                if (ex.InnerException != null && ex.InnerException.ToString().ToUpper().Contains("ORA-01031"))
                {
                    Logger.WriteLogFile("InnerException contains ORA-01031 error , so run SetRoleAndConnect");
                    SetRoleAndConnect();
                    context.SaveChanges();
                    return;
                }

                throw ex;
            }


        }



        public void UpdateResult(string val, long resultId)
        {
            context.Database.ExecuteSqlCommand(
                string.Format("UPDATE LIMS_SYS.RESULT SET FORMATTED_RESULT='{0}' WHERE RESULT_ID='{1}'", val, resultId));
        }
        public void UpdateRtfResult()
        {

        }

        public void AddRtfResult()
        {

        }


        public void AddCytoPrintControl(string sample)
        {
            var date = DateTime.Now;
            var ExReqId = GetNewId("SQ_U_CYTO_PRINT_CONTROL");
            long convertedExReqId = Convert.ToInt64(ExReqId);
            U_CYTO_PRINT_CONTROL req = new U_CYTO_PRINT_CONTROL()
            {
                NAME = sample,// + ";" + ExReqId,
                U_CYTO_PRINT_CONTROL_ID = convertedExReqId,
                VERSION = "1",
                VERSION_STATUS = "A",
            };
            //Add new U_CYTO_PRINT_CONTROL_USER
            U_CYTO_PRINT_CONTROL_USER reqUser = new U_CYTO_PRINT_CONTROL_USER()
            {
                U_CYTO_PRINT_CONTROL_ID = convertedExReqId,
                U_DATE_PRINT = date
            };

            Add(req);
            Add(reqUser);
        }
        public void UpdateCytoPrintControl(string sample)
        {
            context.Database.ExecuteSqlCommand(
     string.Format("update U_CYTO_PRINT_CONTROL_USER set U_DATE_PRINT = systimestamp where U_CYTO_PRINT_CONTROL_ID = {0}", sample));


        }

        internal static List<ObjDetails> GetObjDetailses(Entities context, string tableName, string condition)
        {
            try
            {

                if (!string.IsNullOrEmpty(condition))
                {
                    condition = "where " + condition;
                }
                var q = context.Database.SqlQuery<ObjDetails>("Select " + tableName + "_Id as Id,name from lims_sys." + tableName + "  " + condition, null).ToList();
                return q;

            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
                return null;
            }

        }

        public void InsertToSdgLog(long sdgId, string v1, double v2, string v3)
        {
            throw new NotImplementedException();
        }
    }
}