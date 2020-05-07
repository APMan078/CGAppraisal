using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApp.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int UserAccessId { get; set; }
        


        public List<UserModel> userModelList { get; set; }
    }
}