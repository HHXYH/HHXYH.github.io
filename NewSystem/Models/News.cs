//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class News
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public System.DateTime Createtime { get; set; }
    }
}
