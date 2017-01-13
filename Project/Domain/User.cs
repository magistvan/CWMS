using System;
using System.Collections.Generic;

namespace Project.Domain
{
    abstract class User
    {
        private int id;
        private String username;
        private String password;
        private String email;
        private int unitid;
        private List<int> flows;

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

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        internal int Unitid
        {
            get
            {
                return unitid;
            }

            set
            {
                unitid = value;
            }
        }

        internal List<int> Flows
        {
            get
            {
                return flows;
            }

            set
            {
                flows = value;
            }
        }

        public User(int id, string username, string password, string email, int unitid, List<int> flows)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
            this.unitid = unitid;
            this.flows = flows;
        }

        public override bool Equals(object obj)
        {
            if (obj is User)
            {
                User other = (User)obj;
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

        public virtual int AccessLevel()
        {
            return -1;
        }
    }
}
