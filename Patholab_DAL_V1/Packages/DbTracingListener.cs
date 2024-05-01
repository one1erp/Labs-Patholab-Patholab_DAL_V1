

//using Clutch.Diagnostics.EntityFramework;
//using System;
//using System.Data.Common;
//using System.Diagnostics;

//namespace Patholab_DAL_V1.Packages
//{

//    public class DbTracingListener : IDbTracingListener
//    {


//        public void CommandExecuting(DbTracingContext context)
//        {
//            //    throw new NotImplementedException();
//        }

//        public void CommandFinished(DbTracingContext context)
//        {
//            //     throw new NotImplementedException();
//        }

//        public void ReaderFinished(DbTracingContext context)
//        {
//            //    throw new NotImplementedException();
//        }

//        public void CommandFailed(DbTracingContext context)
//        {
//            Patholab_Common.Logger.WriteQueries("Command Failed " + context.Command.CommandText + " result - " + context.Result);
//        }

//        public void CommandExecuted(DbTracingContext context)
//        {
//            Patholab_Common.Logger.WriteQueries(context.Command.CommandText + "Executed in: " + context.Duration + "\n" + " Finish time - " + (context.FinishTime.HasValue ? "" : context.FinishTime.Value.ToString("yyyy/MM/dd/HH:mm:ss.FFF")));

//        }
//    }
//}
