//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cs_demand
    {
        public int demand_id { get; set; }
        public string seq { get; set; }
        public string q_code { get; set; }
        public string demand_content { get; set; }
        public string demand_type { get; set; }
        public string demand_status { get; set; }
        public string dispatch_description { get; set; }
        public string processing_description { get; set; }
        public string program_description { get; set; }
        public string apply_department { get; set; }
        public string apply_user { get; set; }
        public System.DateTime apply_date { get; set; }
        public string feasibility { get; set; }
        public short estimate_time { get; set; }
        public Nullable<System.DateTime> schedule_date { get; set; }
        public Nullable<System.DateTime> demand_confirm_date { get; set; }
        public Nullable<System.DateTime> demand_evaluation_date { get; set; }
        public decimal workhours { get; set; }
        public Nullable<System.DateTime> finish_date { get; set; }
        public string version_no { get; set; }
        public string merge_to_seq { get; set; }
        public string workhours_statisticsYerMonDay { get; set; }
        public int update_user_id { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public Nullable<System.DateTime> backtrack_date { get; set; }
        public string report_title { get; set; }
    }
}
