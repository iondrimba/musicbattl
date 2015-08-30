using System;
using System.Configuration;

namespace MusicBattlWebAPI.Helpers
{
    public class WebConfigHelper
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            }
        }

        public static string drimbabattlkey
        {
            get
            {
                return ConfigurationManager.AppSettings["drimbabattlkey"].ToString();
            }
        }

        public static int PastBattlsDisplayCount
        {
            get
            {
                int retorno = Convert.ToInt32(ConfigurationManager.AppSettings["PastBattlsDisplayCount"].ToString());
                return retorno;
            }
        }

        public static int AllTimerWinnersDisplayCount
        {
            get
            {
                int retorno = Convert.ToInt32(ConfigurationManager.AppSettings["AllTimerWinnersDisplayCount"].ToString());
                return retorno;
            }
        }

        public static int TopMostVotedDisplayCount
        {
            get
            {
                int retorno = Convert.ToInt32(ConfigurationManager.AppSettings["TopMostVotedDisplayCount"].ToString());
                return retorno;
            }
        }

        public static int TopUserDisplayCount
        {
            get
            {
                int retorno = Convert.ToInt32(ConfigurationManager.AppSettings["TopUserDisplayCount"].ToString());
                return retorno;
            }
        }

        public static int BattlsResultsDisplayCount
        {
            get
            {
                int retorno = Convert.ToInt32(ConfigurationManager.AppSettings["BattlsResultsDisplayCount"].ToString());
                return retorno;
            }
        }

        public static int BattlInterval
        {
            get
            {
                int retorno = Convert.ToInt32(ConfigurationManager.AppSettings["BattlInterval"].ToString());
                return retorno;
            }
        }
    }
}