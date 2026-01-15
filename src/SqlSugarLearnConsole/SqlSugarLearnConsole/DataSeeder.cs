using SqlSugar;
using SqlSugarLearnConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugarLearnConsole
{
    public class DataSeeder
    {
        private readonly SqlSugarClient _db;

        public DataSeeder(SqlSugarClient db)
        {
            _db = db;
        }

        public void Seed()
        {
            Console.WriteLine("开始插入测试数据...\n");

            //插入学校
            var zju = new School { SchoolName = "浙江大学", Address = "杭州市拱墅区" };
            var shjtu = new School { SchoolName = "上海交通大学", Address = "上海市闵行区" };

            _db.Insertable(zju).ExecuteCommand();
            _db.Insertable(shjtu).ExecuteCommand();

            Console.WriteLine($"插入学校：{zju.SchoolName} (Id:{zju.Id})");
            Console.WriteLine($"插入学校：{shjtu.SchoolName} (Id:{shjtu.Id})");

            var students = new List<Student>();
            students.Add(new Student() { Name = "张三", Age = 20, SchoolId = zju.Id, Score = 99.9m });
            students.Add(new Student() { Name = "李四", Age = 21, SchoolId = zju.Id, Score = 88.0m });
            students.Add(new Student() { Name = "王五", Age = 19, SchoolId = shjtu.Id, Score = 92.3m });
            students.Add(new Student() { Name = "赵六", Age = 22, SchoolId = shjtu.Id, Score = 76.5m });

            _db.Insertable(students).ExecuteCommand();
            Console.WriteLine($"插入 {students.Count} 名学生");

            // 插入订单和订单项
            var order = new Orders { CustomerId = 1001, TotalPrice = 74751m };
            _db.Insertable(order).ExecuteCommand();

            var items = new[]
            {
                new OrderItem { OrderId = order.Id, ProductName = "机械键盘", Quantity = 1, Price = 799m },
                new OrderItem { OrderId = order.Id, ProductName = "无线鼠标", Quantity = 1, Price = 199m },
                new OrderItem { OrderId = order.Id, ProductName = "显示器支架", Quantity = 1, Price = 599m }
            };
            _db.Insertable(items).ExecuteCommand();

            Console.WriteLine($"插入订单 {order.Id} 及其 {items.Length} 条明细");
            Console.WriteLine("测试数据插入完成！\n");
        }
    }
}
