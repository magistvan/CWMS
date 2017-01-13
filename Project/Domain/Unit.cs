using System;
using System.Collections.Generic;

namespace Project.Domain
{
    class Unit
    {
        private int id;
        private String name;
        private List<User> users;

        public Unit(int id, string name, List<User> users)
        {
            this.id = id;
            this.name = name;
            this.users = users;
        }

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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        internal List<User> Users
        {
            get
            {
                return users;
            }

            set
            {
                users = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Unit)
            {
                Unit other = (Unit)obj;
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
