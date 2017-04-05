using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace SistemaTroco.Classe
{
    public sealed class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISession GetSession()
        {
            if (_sessionFactory == null)
            {
                lock (typeof(NHibernateHelper))
                {
                    if (_sessionFactory == null)
                    {
                        Configuration cfg = new Configuration();
                        cfg.AddAssembly("MapeamentoOR");
                        _sessionFactory = cfg.BuildSessionFactory();
                    }
                }
            }
            return _sessionFactory.OpenSession();
        }
        private NHibernateHelper()
        {
        }

    }
}
