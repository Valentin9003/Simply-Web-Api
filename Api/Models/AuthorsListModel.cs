using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class AuthorsListModel
    {
        public string FilterBy { get; set; }

        public string FilterComparisonOperator { get; set; }

        public string FilterValue { get; set; }

        public string OrderBy { get; set; }

        public bool Desc { get;  set; }

        public int Paging { get; set; }
    }
}
