using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an_3.Paging
{
    public class Paging
    {
        private int _totalPages;
        public int CurrentPage { get; set; }
        public int RowsPerPage { get; set; } = 10;
        public int TotalPages
        {
            get => _totalPages; set
            {
                _totalPages = value;
                Pages = new List<PageInfo>();
                for (int i = 1; i <= _totalPages; i++)
                {
                    Pages.Add(new PageInfo()
                    {
                        Page = i,
                        TotalPages = _totalPages
                    });
                }
            }
        }
        public List<PageInfo> Pages { get; set; }
    }
}
