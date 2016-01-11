using System;
using System.Text;
using System.Diagnostics;



namespace Prodesp.Log.Common
{
    /// <summary>
    /// Classe implementa o Log baseado no artigo de praticas de monitoramento
    /// http://www.asp.net/aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/monitoring-and-telemetry
    /// </summary>
    public class TraceLogWrapper : ICustomLog
    {
        #region "Implementacao Interface ILogger"
        public void Information(object message)
        {
            Trace.TraceInformation(Convert.ToString(message));
        }

        public void Information(string fmt, params object[] vars)
        {
            Trace.TraceInformation(fmt, vars);
        }

        public void Information(Exception exception,  string fmt, params object[] vars)
        {
            Trace.TraceInformation(FormatUtils.FormatExceptionStackTrace(exception), fmt, vars);
        }

        public void Warning(object message)
        {
            Trace.TraceWarning(Convert.ToString(message));
        }

        public void Warning(string fmt, params object[] vars)
        {
            Trace.TraceWarning(fmt, vars);
        }

        public void Warning(Exception exception, string fmt, params object[] vars)
        {
            Trace.TraceWarning(FormatUtils.FormatExceptionStackTrace(exception), fmt, vars);   
        }

        public void Error(object message)
        {
            Trace.TraceError(message.ToString());
        }

        public void Error(string fmt, params object[] vars)
        {
            Trace.TraceError(fmt, vars);
        }

        public void Error(Exception exception)
        {
            Trace.TraceError(FormatUtils.FormatExceptionStackTrace(exception));
        }

        public void Error(Exception exception, string fmt, params object[] vars)
        {
            Trace.TraceError(FormatUtils.FormatExceptionStackTrace(exception), fmt, vars);   
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan)
        {
            TraceApi(componentName,method,timespan,"");
        }
        public void TraceApi(string componentName, string method, TimeSpan timespan, string fmt, params object[] vars)
        {
            TraceApi(componentName, method, timespan, string.Format(fmt, vars));
        }
       
        public void TraceApi(string componentName, string method, TimeSpan timespan, string properties)
        {
            var msg = FormatUtils.FormatTraceApi(componentName, method, timespan, properties);
            Trace.TraceInformation(msg);
        }
        #endregion

        #region "Suporte tratamento mensagens"
        private static string TratarMensagem(string message, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            var retorno = message;
            if (!String.IsNullOrWhiteSpace(memberName))
                retorno = retorno + ";Member:" + memberName;
            if (!String.IsNullOrWhiteSpace(sourceFilePath))
                retorno = retorno + ";SourceFile:" + sourceFilePath;
            if (sourceLineNumber > 0)
                retorno = retorno + ";SourceLine:" + sourceLineNumber.ToString();

            return retorno;
        }

        private static string FormatExceptionMessage(Exception exception, string fmt, object[] vars)
        {
            // Simple exception formatting: for a more comprehensive version see 
            // http://code.msdn.microsoft.com/windowsazure/Fix-It-app-for-Building-cdd80df4
            var msg = string.Format(fmt, vars);
            var msgfinal = string.Format(";Exception Details={0}",FormatUtils.FormatException(exception, includeContext:true));
            return (msg + msgfinal);
        }

       
        #endregion


        
    }
}
