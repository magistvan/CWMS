using System.Collections.Generic;

namespace Project.Domain
{
    class Reader : User
    {
        private User boss;
        private static int ACCESS_LEVEL = 0;

        internal User Boss
        {
            get
            {
                return boss;
            }

            set
            {
                boss = value;
            }
        }

        public Reader(int id, string username, string password, string email, int unitid, List<int> flows, User boss) : base(id, username, password, email, unitid, flows)
        {
            this.boss = boss;
        }

        public override int AccessLevel()
        {
            return ACCESS_LEVEL;
        }
    }
}
