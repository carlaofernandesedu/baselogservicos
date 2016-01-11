using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Prodesp.Log.Common;
using log4net;

namespace Prodesp.Log.CustomLog4Net
{
    public class Log4NetFactory : ILogFactory
    {

       public Log4NetFactory() 
       {
           Initialize();
       }
       public void Initialize()
        {
            try
            {
                var config = log4net.Config.BasicConfigurator.Configure();
                if (config!=null)
                {
                    Trace.WriteLine("Configuracao padrao inicializada");
                }
                else
                {
                    Trace.WriteLine("Problemas ao carregar configuracao basica");
                }
            }
            catch(Exception ex)
            {
                Trace.WriteLine("Erro ao inicializar Factory:" + ex.ToString());
            }
        }

        public ICustomLog Create(string name)
        {
            try
            { 
                return new Log4NetWrapper(log4net.LogManager.GetLogger(name));
            }
            catch(Exception ex)
            {
                Trace.WriteLine("Erro ao criar Log4NET object: " + ex.ToString());
                return new TraceLogWrapper();
            }
        }
    }
}
