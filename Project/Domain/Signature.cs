using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain
{
    class Signature
    {
        private int userid;
        private int documentid;

        public int Userid
        {
            get
            {
                return userid;
            }

            set
            {
                userid = value;
            }
        }

        public int Documentid
        {
            get
            {
                return documentid;
            }

            set
            {
                documentid = value;
            }
        }

        public Signature(int userid, int documentid)
        {
            this.userid = userid;
            this.documentid = documentid;
        }
    }
}
