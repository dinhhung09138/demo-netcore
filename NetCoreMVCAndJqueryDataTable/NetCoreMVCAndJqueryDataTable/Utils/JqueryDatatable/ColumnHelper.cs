using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVCAndJqueryDataTable.Utils.JqueryDatatable
{
    /// <summary>
    /// List of column of datatable
    /// </summary>
    public class ColumnHelper
    {
        /// <summary>
        /// Name of column map with column's name in data object
        /// IF not, that is the order of the column in table on design
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Allow for Search
        /// </summary>
        public bool Searchable { get; set; }
        /// <summary>
        /// Allow for order
        /// </summary>
        public bool Orderable { get; set; }

        /// <summary>
        /// Column data in jquery datatable
        /// </summary>
        public ColumnHelper()
        {
            this.Data = string.Empty;
            this.Name = string.Empty;
            this.Searchable = false;
            this.Orderable = false;
        }
    }
}
