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
    
    public partial class cs_question
    {
        public string q_code { get; set; }
        public string q_priority { get; set; }
        public string q_kind { get; set; }
        public string q_title { get; set; }
        public string q_content { get; set; }
        public string q_status { get; set; }
        public string q_processing_description { get; set; }
        public string apply_department { get; set; }
        public int apply_user_id { get; set; }
        public System.DateTime apply_date { get; set; }
        public int record_user_id { get; set; }
        public Nullable<System.DateTime> restrict_finish_date { get; set; }
        public string demand { get; set; }
        public Nullable<System.DateTime> schedule_date { get; set; }
        public Nullable<short> estimate_time { get; set; }
        public Nullable<System.DateTime> finish_date { get; set; }
        public string memo { get; set; }
        public int update_user_id { get; set; }
        public System.DateTime update_date { get; set; }
        public string complexity { get; set; }
        public string temporarily { get; set; }
    }
}