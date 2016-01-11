using System;
using System.Text;
using System.Diagnostics;
using Prodesp.Log.Common;
using NLog.Common;
using NLog;


namespace Prodesp.Log.CustomNLog
{
    /// <summary>
    /// Classe implementa o Log baseado no artigo de praticas de monitoramento e Encapsula o Processo do NLOG
    /// http://www.asp.net/aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/monitoring-and-telemetry
    /// </summary>
    public class NLogWrapper : Prodesp.Log.Common.ICustomLog
    {

        private Logger _logger;

       
     
        public NLogWrapper()
        {
            
        }

        public NLogWrapper(Logger logger)
        {
            _logger = logger;
        }

        #region "Implementacao Interface ILogger"
        public void Information(object message)
        {
            _logger.Info(message);
        }

        public void Information(string fmt, params object[] vars)
        {
            _logger.Info(fmt, vars);
        }

        public void Information(Exception exception,  string fmt, params object[] vars)
        {
            _logger.Info(exception, fmt, vars);
        }

        public void Warning(object message)
        {
            _logger.Warn(message);
        }

        public void Warning(string fmt, params object[] vars)
        {
            _logger.Warn(fmt, vars);
        }

        public void Warning(Exception exception, string fmt, params object[] vars)
        {
            _logger.Warn(exception, fmt, vars);
        }

        public void Error(object message)
        {
            _logger.Error(message);
        }

        public void Error(string fmt, params object[] vars)
        {
            _logger.Error(fmt, vars);
        }

        public void Error(Exception exception)
        {
            _logger.Error(exception);
        }

        public void Error(Exception exception, string fmt, params object[] vars)
        {
            _logger.Error(exception, fmt, vars);  
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
            string msg = String.Concat("Component:", componentName, ";Method:", method, ";Timespan:", timespan.ToString(), ";Properties:", properties);
            _logger.Info(msg);
        }
        #endregion

       
    }
}
