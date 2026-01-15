using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugarLearnConsole
{
    public class Dbconfig
    {
        // SqlServer 配置
        public static string SqlServerConn = "Server=.;Database = SqlSugarDemo; uid = sa; pwd = 123456; Encrypt=True;TrustServerCertificate=True";

        // DM8 配置（DM 默认端口 5236）
        public static string DmConn = "Server = localhost;User Id=SQLSUGARDEMO; PWD=Sqlsugardemo123";
    }
}
