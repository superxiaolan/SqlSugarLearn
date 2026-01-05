using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace SqlSugarLearnConsole.Models
{
    [SugarTable("School")]
    public class School
    {
        [SugarColumn(IsPrimaryKey =  true, ColumnDescription = "主键")]
        public Guid Id { get; set; } = Guid.NewGuid(); //自动生成新Guid
        //[SugarColumn(ColumnLength = 100)]
        [SugarColumn(ColumnDataType = "NVARCHAR(100)")]
        public string SchoolName { get; set; }
        [SugarColumn(ColumnDataType = "NVARCHAR(200)")]
        public string Address{  get; set; }
    }
}
