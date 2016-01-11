using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Prodesp.Log.Common;
using NLog;


namespace Prodesp.Log.CustomNLog
{
    public class NLogFactory : ILogFactory
    {

        public NLogFactory() 
       {
           Initialize();
       }
       public void Initialize()
        {
            try
            {
                var config = new object();
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
                Trace.WriteLine("Erro ao inicializar Factory Nlog:" + ex.ToString());
            }
        }

        public ICustomLog Create(string name) 
        {
            try
            { 
                return new NLogWrapper(LogManager.GetLogger(name));
            }
            catch(Exception ex)
            {
                Trace.WriteLine("Erro ao criar NLog object: " + ex.ToString());
                return new TraceLogWrapper();
            }
        }
    }
}
