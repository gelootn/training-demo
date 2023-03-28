using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Demo.Dal.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class TableAttribute : Attribute
    {
        public string TableName { get; }

        public TableAttribute(string tableName)
        {
            TableName = tableName;
        }
    }
}
