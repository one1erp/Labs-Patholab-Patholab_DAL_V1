using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using OracleCommand = Oracle.DataAccess.Client.OracleCommand;
//using OracleConnection = Oracle.DataAccess.Client.OracleConnection;
using OracleCommand = Oracle.DataAccess.Client.OracleCommand;
using OracleConnection = Oracle.DataAccess.Client.OracleConnection;
using Patholab_Common;

namespace Patholab_DAL_V1.Packages
{
    public class RunFunction
    {
        internal static DateTime RunGetSysdate(Entities context)
        {
            var res = context.Database.SqlQuery<DateTime>(" select  sysdate from dual ");
            return res.SingleOrDefault();
        }

        internal static long Run_Authorization_signed_by(Entities context, long sdgId, long index)
        {
            var res = context.Database.SqlQuery<long>(" select  LIMS.Authorization.signed_by(" + sdgId + "," + index + ") from dual ");
            return res.SingleOrDefault();
        }

        internal static decimal? Run_Get_Price(Entities context, long p_customer_id, long p_parts_id)
        {
#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                var res = context.Database.SqlQuery<decimal?>(" select  LIMS.Get_Price(" + p_customer_id + "," + p_parts_id + ") from dual ");
                if (res.SingleOrDefault() == null)
                    return null;
                else
                    return res.SingleOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
#pragma warning restore CS0168 // Variable is declared but never used
        }
        internal static decimal? Run_Get_Price_Urgent(Entities context, long p_customer_id, long p_parts_id)
        {
#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                var res = context.Database.SqlQuery<decimal?>(" select  LIMS.Get_Price_Urgent(" + p_customer_id + "," + p_parts_id + ") from dual ");
                if (res.SingleOrDefault() == null)
                    return null;
                else
                    return res.SingleOrDefault();
            }
            catch (Exception e)
            {
                return null;
            }
#pragma warning restore CS0168 // Variable is declared but never used
        }
        internal static bool Run_CheckId(Entities context, string id)
        {
            //Debugger.Launch();
            if (id == null)
            {
                return false;
            }

            string sql = "select LIMS.check_id_Test ('" + id + "') from dual";
            var res =
                context.Database.SqlQuery<string>(sql);
            //return res.SingleOrDefault() != null && res.Single() != null;
            return res.SingleOrDefault() != null && res.Single() == "TRUE";


#pragma warning disable CS0162 // Unreachable code detected
            return false;
#pragma warning restore CS0162 // Unreachable code detected
        }
        internal static string OTHER_SDG_FOR_PATIENT(Entities context, string id)
        {
            if (id == null)
            {
                return null;
            }

            string sql = "select LIMS.OTHER_SDG_FOR_PATIENT ('" + id + "') from dual";
            var res =
                context.Database.SqlQuery<string>(sql);
            return res.SingleOrDefault();


#pragma warning disable CS0162 // Unreachable code detected
            return null;
#pragma warning restore CS0162 // Unreachable code detected
        }

        internal static decimal Run_PATHOLAB_SYNTAX(Entities context, long customerId, string dpt)
        {

            if (dpt.Length > 1)
            {
                return 0;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            try
            {
                string sql = "select LIMS.PATHOLAB_SYNTAX (" + customerId + ",'" + dpt + "') from dual ";
                var res =
                    context.Database.SqlQuery<decimal>(sql);
                return res.SingleOrDefault();
            }
            catch (Exception e)
            {

                return 0;

            }
#pragma warning restore CS0168 // Variable is declared but never used
        }

        internal static decimal GetNewId(Entities context, string sequenceName)
        {
            try
            {

                string sql = "select lims." + sequenceName + ".nextval from dual";
                var res =
              context.Database.SqlQuery<decimal>(sql);
                return res.SingleOrDefault();

            }
            catch (Exception ex)
            {
                Logger.WriteLogFile(ex);
                throw ex;

            }
        }
        internal static bool OK_PAP_RESULT(Entities context, long sdgId)
        {
            string sql = "";
            try
            {
                 sql = "begin lims.OK_PAP_RESULT  (" + sdgId.ToString() + " ); end;";
                 var res =
                     context.Database.ExecuteSqlCommand(sql);
                return true;
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
                Logger.WriteQueries(sql);
                return false;
            }
        }
        internal static bool Run_Insert_To_Sdg_Log(Entities context, long SdgId, string applicationCode, long sessionId, string Description)
        {
            // return false; //Works only for lims_sys
            string sql = "";
            // Debugger.Launch();
            try
            {
                sql = "begin lims.Insert_To_Sdg_Log  (" + SdgId.ToString() + ", '" + applicationCode + "'," + sessionId.ToString() + ", '" + Description + "' ); end;";
                var res =
                    context.Database.ExecuteSqlCommand(sql);
                return true;
            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
                Logger.WriteQueries(sql);
                return false;
            }
        }

        internal static dynamic RunQuery(Entities context, string query)
        {
#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                return context.Database.SqlQuery<dynamic>(query);
            }
            catch (Exception ex)
            {
                return false;
            }
#pragma warning restore CS0168 // Variable is declared but never used
        }
        internal static IEnumerable<string> GetDynamicList(Entities context, string query)
        {
#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                var q = context.Database.SqlQuery<string>(query);
                return q;
            }
            catch (Exception ex)
            {
                return null;

            }
#pragma warning restore CS0168 // Variable is declared but never used
        }
        internal static string GetDynamicStr(Entities context, string sql)
        {
            try
            {

                var q = context.Database.SqlQuery<string>(sql);
                return q.First();
            }
            catch (Exception ex)
            {
                Logger.WriteLogFile(ex.Message);
                return null;

            }
        }
        internal static decimal? GetDynamicDecimal(Entities context, string sql)
        {
#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                var q = context.Database.SqlQuery<decimal>(sql);
                return q.First();
            }
            catch (Exception ex)
            {
                return null;

            }
#pragma warning restore CS0168 // Variable is declared but never used
        }
        internal static string ExecuteScalar(Entities context, string query)
        {
#pragma warning disable CS0168 // Variable is declared but never used
            try
            {

                string res = context.Database.SqlQuery<string>(query).FirstOrDefault();
                return res;

            }
            catch (Exception ex)
            {
                return "";
            }
#pragma warning restore CS0168 // Variable is declared but never used
        }

        internal static List<ObjDetails> GetObjDetailses(Entities context, string tableName, string condition)
        {
            try
            {


                if (!string.IsNullOrEmpty(condition))
                {
                    condition = "where " + condition;
                }
                var q = context.Database.SqlQuery<ObjDetails>("Select " + tableName + "_Id as ID,NAME from lims_sys." + tableName + "  " + condition).ToList();
                return q;

            }
            catch (Exception e)
            {
                Logger.WriteLogFile(e);
                return null;
            }

        }

        internal static decimal GetSamplesByContainer(Entities context, decimal containerId)
        {
            return GetSamplesByContainer(context, containerId.ToString());
        }


        internal static decimal GetSdgByContainer(Entities context, string containerId)
        {
            try
            {



                string sql = "select count(1) from lims_sys.sdg_user where u_container_id='" + containerId + "'";
                var res =
              context.Database.SqlQuery<decimal>(sql);
                return res.SingleOrDefault();

            }
            catch (Exception ex)
            {
                Logger.WriteLogFile(ex);
                throw ex;

            }
        }
        internal static decimal GetSamplesByContainer(Entities context, string containerId)
        {
            try
            {

                string sql = "select count(1) from lims_sys.sample where sdg_id in" +
                    " (select sdg_id   from lims_sys.sdg_user where u_container_id='" + containerId + "')";
                var res =
              context.Database.SqlQuery<decimal>(sql);
                return res.SingleOrDefault();

            }
            catch (Exception ex)
            {
                Logger.WriteLogFile(ex);
                throw ex;

            }
        }

        internal static decimal GetSamplesByContainerAndStatus(Entities context, string containerId)
        {
            try
            {

                string sql = "select count(1) from lims_sys.sample where sdg_id in" +
                    " (select sdg_id   from lims_sys.sdg_user where u_container_id='" + containerId + "') and status <> 'U'";
                var res =
              context.Database.SqlQuery<decimal>(sql);
                return res.SingleOrDefault();

            }
            catch (Exception ex)
            {
                Logger.WriteLogFile(ex);
                throw ex;

            }
        }

        private static dynamic GetDataRow(DbDataReader dataReader)
        {
            var dataRow = new ExpandoObject() as IDictionary<string, object>;
            for (var fieldCount = 0; fieldCount < dataReader.FieldCount; fieldCount++)
                dataRow.Add(dataReader.GetName(fieldCount), dataReader[fieldCount]);
            return dataRow;
        }

        internal static decimal IfExitEXTRA_SLIDES_STATUS_P(Entities context, string BlockNumber, string ExRequestCreatedOn)
        {
            try
            {

                string sql = "select count(1) from lims.EXTRA_SLIDES_STATUS_P where BlockNumber ='" + BlockNumber + "' and ExRequestCreatedOn = '" + ExRequestCreatedOn + "'";
                var res =
              context.Database.SqlQuery<decimal>(sql);
                return res.SingleOrDefault();

            }
            catch (Exception ex)
            {
                Logger.WriteLogFile(ex);
                throw ex;

            }
        }
    }
}
