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
    
    public partial class cs_authority
    {
        public int auth_id { get; set; }
        public string auth_code { get; set; }
        public string auth_name { get; set; }
        public string enabled { get; set; }
        public string memo { get; set; }
        public int update_user_id { get; set; }
        public System.DateTime update_date { get; set; }
    }
}
