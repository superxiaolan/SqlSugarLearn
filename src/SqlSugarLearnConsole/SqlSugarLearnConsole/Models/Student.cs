using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace SqlSugarLearnConsole.Models
{
    [SugarTable("Student")]
    public class Student
    {
        [SugarColumn(IsPrimaryKey = true)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [SugarColumn(ColumnDataType = "NVARCHAR(50)")]
        public string Name { get; set; }

        public int Age { get; set; }

        public Guid SchoolId { get; set; } // 学校的主键id 使用 Guid

        public decimal Score { get; set; }
    }
}
