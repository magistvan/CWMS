using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain
{
    class Log
    {
        private int id;
        private User user;
        private Unit unit;
        private DateTime date;
        private ACTION_TYPE actionType;

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

        internal User User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        internal Unit Unit
        {
            get
            {
                return unit;
            }

            set
            {
                unit = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        internal ACTION_TYPE ActionType
        {
            get
            {
                return actionType;
            }

            set
            {
                actionType = value;
            }
        }

        public Log(int id, User user, Unit unit, DateTime date, ACTION_TYPE actionType)
        {
            this.id = id;
            this.user = user;
            this.unit = unit;
            this.date = date;
            this.actionType = actionType;
        }

        public override bool Equals(object obj)
        {
            if (obj is Log)
            {
                Log other = (Log)obj;
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
