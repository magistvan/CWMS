using System.Collections.Generic;

namespace Project.Domain
{
    class Admin : User
    {
        private static int ACCESS_LEVEL = 3;

        public Admin(int id, string username, string password, string email, int unitid, List<int> flows) : base(id, username, password, email, unitid, flows) { }

        public override int AccessLevel()
        {
            return ACCESS_LEVEL;
        }
    }
}
