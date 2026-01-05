using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugarLearnConsole
{
    public class DbContext
    {
        private readonly SqlSugarClient _db;

        // 选择数据库，true = SqlServer， false = DM 
        public DbContext(bool useSqlServer = true)
        {
            _db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = useSqlServer ? Dbconfig.SqlServerConn : Dbconfig.DmConn,
                DbType = useSqlServer ? DbType.SqlServer : DbType.Dm,
                IsAutoCloseConnection = true
            });

            //_db.Aop.OnLogExecuting = (sql, pars) =>
            //{
            //    Console.WriteLine("=== SQL 执行 ===");
            //    Console.WriteLine(sql);
            //    if (pars.Length > 0)
            //        Console.WriteLine(string.Join(",", pars.Select(p => $"{p.ParameterName}={p.Value}")));
            //    Console.WriteLine();
            //};
        }

        public SqlSugarClient Db => _db;
    }
}
