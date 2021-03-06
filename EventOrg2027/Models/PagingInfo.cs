﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models 
{
    public class PagingInfo
    {
        public const int DEFAULT_PAGE_SIZE = 3;
        public const int NUMBER_PAGES_SHOW_BEFORE_AFTER = 5;
        public const int PAGE_SIZE_TABLE = 8;

        public int TotalItems { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    }
}
