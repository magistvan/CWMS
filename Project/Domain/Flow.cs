using System;
using System.Collections.Generic;

namespace Project.Domain
{
    class Flow
    {
        private int id;
        private List<int> documents;
        private User creator;
        private List<List<int>> revisors;
        private int step;
        private FLOW_STATUS status;
        private DateTime creationDate;
        private DateTime endDate;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        internal List<int> Documents
        {
            get
            {
                return documents;
            }

            set
            {
                documents = value;
            }
        }

        internal User Creator
        {
            get
            {
                return creator;
            }

            set
            {
                creator = value;
            }
        }

        internal List<List<int>> Revisors
        {
            get
            {
                return revisors;
            }

            set
            {
                revisors = value;
            }
        }

        public int Step
        {
            get
            {
                return step;
            }

            set
            {
                step = value;
            }
        }

        internal FLOW_STATUS Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
            set
            {
                creationDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }
        
        public Flow(int id, List<int> documents, User creator, List<List<int>> revisors, int step, FLOW_STATUS status, DateTime creationDate, DateTime endDate)
        {
            this.id = id;
            this.documents = documents;
            this.creator = creator;
            this.revisors = revisors;
            this.step = step;
            this.status = status;
            this.creationDate = creationDate;
            this.endDate = endDate;
        }

        public override bool Equals(object obj)
        {
            if (obj is Flow)
            {
                Flow other = (Flow)obj;
                if (other.id == id)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id;
        }
    }
}
