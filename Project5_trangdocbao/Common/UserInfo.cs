using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project5_trangdocbao
{
    [Serializable]
    public class UserInfo
    {
        public long UserID { set; get; }
        public string Username { set; get; }
    }
}