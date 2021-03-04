using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using WebApplication1.ViewModel.Shared;

namespace WebApplication1.ViewModel.News
{
    public class NewsListViewModel : Pager
    {
        internal string kind_name { get; set; }
        public IEnumerable<SelectListItem> kind_list { get; set; }
        public List<News> news_list { get; set; }
        public int Page_index { get ; set ; }
        public int Page_count { get; set; }
        //internal List<Breadcrumbs> breadcrumbs_list { get; set; }

        public class News {
            public int news_id { get; set; }
            [Display(Name = "標題")]
            public string title { get; set; }
            [Display(Name = "內容")]
            public string content { get; set; }
            [Display(Name = "公布起始日期")]
            public DateTime begin_date { get; set; }
            [Display(Name = "公布截止日期")]
            public Nullable<DateTime> end_date { get; set; }
            [Display(Name = "公布日期")]
            public string begin_end_date { get; set; }
            [Display(Name = "新聞置頂")]
            public string top_news { get; set; }
            [Display(Name = "新聞類別")]
            public string kind { get; set; }
        }
    }


}