using System;
using System.Collections.Generic;
using System.Text;

namespace Model.General
{
    public class BasePagination
    {
        public int TotalPage { get; set; } = 1;
        public int PageSkip { get; set; } = 0;
        public int PageTake { get; set; } = 10;
        public string DefaultFilter { get; set; } = "";
        public int Count { get; set; }

        public static BasePagination pagination(BasePagination pagination, int count)
        {
            pagination.PageTake = (count - (pagination.TotalPage * 10) == 0) ? 10 : count - (pagination.TotalPage * 10);
            if ((pagination.TotalPage * 10) < count)
                pagination.TotalPage += 1;

            if (pagination.PageSkip != pagination.TotalPage)
                pagination.PageTake = 10;

            pagination.PageSkip = ((pagination.PageSkip == 0 ? 1 : pagination.PageSkip) - 1) * 10;

            return pagination;
        }
    }
}
