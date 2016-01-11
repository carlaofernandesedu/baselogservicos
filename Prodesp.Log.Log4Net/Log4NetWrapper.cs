using System;
using System.Text;
using System.Diagnostics;
using Prodesp.Log.Common;
using log4net;


namespace Prodesp.Log.CustomLog4Net
{
    /// <summary>
    /// Classe implementa o Log baseado no artigo de praticas de monitoramento
    /// http://www.asp.net/aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/monitoring-and-telemetry
    /// </summary>
    public class Log4NetWrapper : ICustomLog
    {

        private ILog _logger;

     
        public Log4NetWrapper()
        {
            
        }

        public Log4NetWrapper(ILog logger)
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
            _logger.InfoFormat(fmt, vars);
        }

        public void Information(Exception exception,  string fmt, params object[] vars)
        {
            _logger.Info(String.Format(fmt,vars),exception);
        }

        public void Warning(object message)
        {
            _logger.Warn(message);
        }

        public void Warning(string fmt, params object[] vars)
        {
            _logger.WarnFormat(fmt, vars);
        }

        public void Warning(Exception exception, string fmt, params object[] vars)
        {
            _logger.Warn(String.Format(fmt, vars), exception);
        }

        public void Error(object message)
        {
            _logger.Error(message);
        }

        public void Error(string fmt, params object[] vars)
        {
            _logger.ErrorFormat(fmt, vars);
        }

        public void Error(Exception exception)
        {
            _logger.Error(exception);
        }

        public void Error(Exception exception, string fmt, params object[] vars)
        {
            _logger.Error(string.Format(fmt,vars),exception);  
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
            _logger.Info(msg);
        }
        #endregion
       
    }
}
