using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public class Return
    {
        private int id;
        private string reason;
        private string comment;
        private int bikeid;
        private int orderid;
        private DateTime returnTime;

        public Return(int id, string reason, string comment, int bikeid, int orderid, DateTime time)
        {
            this.id = id;
            this.reason = reason;
            this.comment = comment;
            this.bikeid = bikeid;
            this.orderid = orderid;
            this.returnTime = time;
        }

        public int GetId() { return id; }
        public string GetReason() { return reason; }
        public string GetComment() { return comment; }
        public int GetBikeId() { return bikeid; }
        public int GetOrderId() { return orderid; }
        public DateTime GetReturnTime() { return returnTime; }

    }
}
