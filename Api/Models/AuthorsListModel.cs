using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class AuthorsListModel
    {
        [Required]
        public string FilterBy { get; set; }

        [Required]
        public string FilterComparisonOperator { get; set; }

        [Required]
        public string FilterValue { get; set; }

        [Required]
        public string OrderBy { get; set; }

        public bool Desc { get;  set; }

        public int Paging { get; set; }
    }
}
