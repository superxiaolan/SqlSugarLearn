using SqlSugar;
using SqlSugarLearnConsole.Models;
using SqlSugarLearnConsole.Queries;

namespace SqlSugarLearnConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 选择数据库，true = SqlServer， false = DM 
            var context = new DbContext(useSqlServer: true);
            var db = context.Db;

            // 建表（只需运行一次，之后可注释）
            // db.CodeFirst.InitTables(typeof(School), typeof(Student), typeof(Order), typeof(OrderItem));

            // 插入测试数据（第一次运行打开，之后可注释或加判断）
            //new DataSeeder(db).Seed();

            //执行各种查询示例
            var studentQueries = new StudentQueries(db);
            studentQueries.ShowAllStudents();
            studentQueries.ShowStudentsWithSchool();
            studentQueries.ShowSchoolStatistics();
            studentQueries.ShowHighScoreStudents();

            Console.WriteLine("程序结束，按任意键退出...");
            Console.ReadKey();

        }

    }
}
