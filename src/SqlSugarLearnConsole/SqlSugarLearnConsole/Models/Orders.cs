using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace SqlSugarLearnConsole.Models
{
    [SugarTable("Orders")]
    public class Orders
    {
        [SugarColumn(IsPrimaryKey = true)]
        public Guid Id { get; set; } = Guid.NewGuid();

        public int CustomerId { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public decimal TotalPrice { get; set; }
    }
}
