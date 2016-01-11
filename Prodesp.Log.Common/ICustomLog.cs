using System;
using System.Runtime.CompilerServices;

namespace Prodesp.Log.Common
{
    /// <summary>
    /// Classe que implementa boas praticas Monitoring e Telemetry de acordo com as artigos das URLS
    ///http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/connection-resiliency-and-command-interception-with-the-entity-framework-in-an-asp-net-mvc-application
    ///https://code.msdn.microsoft.com/Cloud-Service-Fundamentals-4ca72649
    ///Indica niveis de log info, warning, error ,traceapi (servicos externos)
    /// </summary>
    public interface ICustomLog
    {
        void Information(object message);
        void Information(string fmt, params object[] vars);
        void Information(Exception exception, string fmt, params object[] vars);
        void Warning(object message);
        void Warning(string fmt, params object[] vars);
        void Warning(Exception exception, string fmt, params object[] vars);
        void Error(object message);
        void Error(string fmt, params object[] vars);
        void Error(Exception exception);
        void Error(Exception exception, string fmt, params object[] vars);
        void TraceApi(string componentName, string method, TimeSpan timespan);
        void TraceApi(string componentName, string method, TimeSpan timespan, string properties);
        void TraceApi(string componentName, string method, TimeSpan timespan, string fmt, params object[] vars);
        /*
        ///Metodos que estão no pattern da Microsoft mas não no livro
        void Debug(object message);
        void Debug(string fmt, params object[] vars);
        void Debug(Exception exception, string fmt, params object[] vars);
        void Fatal(object message);
        void Fatal(Exception exception, object message);
        void Fatal(string fmt, params object[] vars);
        void Fatal(Exception exception, string fmt, params object[] vars);  
        Guid TraceIn(string method);
        void TraceOut(Guid eventId, string method);
        Guid TraceIn(string method, string properties);
        void TraceOut(Guid eventId, string method, string properties);
        Guid TraceIn(string method, string fmt, params object[] vars);
        void TraceOut(Guid eventId, string method, string fmt, params object[] vars);
         */
    }
}
