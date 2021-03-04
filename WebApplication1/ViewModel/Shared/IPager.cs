using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.ViewModel.Shared
{
    public abstract class Pager
    {
        int page_index { get; set; }
        int page_count { get; set; }
    }
}
