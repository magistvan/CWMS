using System;
using System.Collections.Generic;
using System.Linq;
using Project.Domain;
using Project.Repository;
using Project.Exceptions;

namespace Project.Controllers
{
    class UserController
    {
        private UserRepository repository;

        public UserController()
        {
            repository = new UserRepository();
        }

        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="type"> 0 - Admin, 1 - Manager, 2 - Contributor, 3 - Reader</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="unit_id"></param>
        /// <param name="boss_id"></param>
        public void registation(int type, string username, string password, string email, int unit_id, int boss_id)
        {
            List<User> users = null;
            try
            {
                users = repository.getAll();
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
            try
            {
                users.Where(user => user.Username == username).First();
                throw new ControllerException("There is already a user with this username!!");
            }
            catch (Exception)
            {
            }
            User boss = null;
            if (type != 0)
            {
                try
                {
                    boss = repository.getById(boss_id);
                }
                catch (RepositoryException)
                {
                    throw new ControllerException("Invalid boss id");
                }
            }
            try
            {
                if (type == 0)
                {
                    repository.add(new Admin(0, username, password, email, unit_id, null));
                }
                else if (type == 1)
                {
                    repository.add(new Manager(0, username, password, email, unit_id, null, boss));
                }
                else if (type == 2)
                {
                    repository.add(new Contributor(0, username, password, email, unit_id, null, boss));
                }
                else if (type == 3)
                {
                    repository.add(new Reader(0, username, password, email, unit_id, null, boss));
                }
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
        }

        public void changePassword(int id, string password)
        {
            User user = null;
            try
            {
                user = repository.getById(id);
            }
            catch (RepositoryException)
            {
                throw new ControllerException("Invalid user id");
            }
            user.Password = password;
            try
            {
                repository.update(user);
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
        }

        public User getUserByUsername(string username)
        {
            List<User> users = null;
            try
            {
                users = repository.getAll();
            }
            catch (RepositoryException ex)
            {
                throw new ControllerException(ex.Message);
            }
            try
            {
                return users.Where(user => user.Username == username).First();
            }
            catch (Exception)
            {
                throw new ControllerException("There is no user with this username!!");
            }
        }
    }
}
