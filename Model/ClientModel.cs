using LG_Desktop.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG_Desktop.Model
{
    public class ClientModel
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public byte Age { get; set; }
        public string FullAddress { get; set; }
        public DateTime DOJ { get; set; }
        public string DOJString { get { return LgCommon.DateString(this.DOJ); } }
        public string PlanType { get; set; }
        public string ContactNo { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string PlanExtendedType { get; set; }
        public DateTime PlanExpired{ get; set; }
        public string PlanExpiredString { get { return LgCommon.DateString(this.DOJ); } }
        //public  Image Photo
        //{
        //    get
        //    {
        //        if (File.Exists(StaticFields.GET_SET_IMAGE(this.ID.ToString())))
        //            return Image.FromFile(StaticFields.GET_SET_IMAGE(this.ID.ToString()));
        //        else
        //            return null;
        //    }
        //}
    }
}
