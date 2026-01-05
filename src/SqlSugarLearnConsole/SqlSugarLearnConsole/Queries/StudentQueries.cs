using Newtonsoft.Json;
using SqlSugar;
using SqlSugarLearnConsole.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugarLearnConsole.Queries
{
    public class StudentQueries
    {
        private readonly SqlSugarClient _db;

        public StudentQueries(SqlSugarClient db)
        {
            _db = db;
        }

        public void ShowAllStudents()
        {
            Console.WriteLine("===所有学生列表===");
            var stulist = _db.Queryable<Student>().ToList();
            foreach (var stu in stulist)
            {
                Console.WriteLine($"姓名：{stu.Name}, 年龄：{stu.Age}, 分数：{stu.Score}");
            }
            Console.WriteLine();
        }

        public void ShowStudentsWithSchool()
        {
            Console.WriteLine("===学生及所在学校（Left Join）===");
            var resultList = _db.Queryable<Student, School>((st, sc) => new JoinQueryInfos(JoinType.Left, st.SchoolId == sc.Id))
                .Select((st,sc)=> new {st.Name, st.Score, SchoolName = sc.SchoolName})
                .ToList();
            Console.WriteLine(JsonConvert.SerializeObject(resultList, Formatting.Indented));  // 格式化输出
            foreach (var result in resultList)
            {
                //Console.WriteLine(result);
                Console.WriteLine($"{result.Name} ({result.Score}分) → {result.SchoolName}");
            }
            Console.WriteLine();
        }

        public void ShowSchoolStatistics()
        {
            Console.WriteLine("===各学校学生人数与平均分===");
            var stats = _db.Queryable<Student>()
                .GroupBy(st => st.SchoolId)
                .Select(st => new
                { 
                    SchoolId = st.SchoolId,
                    Count = SqlFunc.AggregateCount(st.Id),
                    AvgScore = SqlFunc.AggregateAvg(st.Score)
                })
                .ToList();
            
            foreach (var stat in stats)
            {
                var schoolName = _db.Queryable<School>()
                    .Where(sc => sc.Id == stat.SchoolId)
                    .Select(sc => sc.SchoolName)
                    .First();

                Console.WriteLine($"学校：{schoolName}，人数：{stat.Count}，平均分：{stat.AvgScore:F2}");
            }
            Console.WriteLine();
        }

        public void ShowHighScoreStudents()
        {
            Console.WriteLine("===== 高于平均分的学生 =====");
            var avg = _db.Queryable<Student>().Select(st => SqlFunc.AggregateAvg(st.Score)).First();
            var high = _db.Queryable<Student>().Where(st => st.Score > avg).ToList();

            Console.WriteLine($"全校平均分：{avg:F2}");
            foreach (var s in high)
            {
                Console.WriteLine($"优秀生：{s.Name} ({s.Score}分)");
            }
        }
    }
}
