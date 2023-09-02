using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Tests.Dummies
{
    internal class UserRepoDummy : IUserRepository
    {
        void IUserRepository.DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        User IUserRepository.GetUser(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUserRepository.GetUsers()
        {
            throw new NotImplementedException();
        }

        void IUserRepository.InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        void IUserRepository.Save()
        {
            throw new NotImplementedException();
        }

        void IUserRepository.UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
