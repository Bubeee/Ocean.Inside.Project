using System;
using Microsoft.AspNet.Identity;

namespace Ocean.Inside.Domain.Auth
{
    public class ApplicationUser : IUser
    {
        public ApplicationUser(string name)
        {
            Id = Guid.NewGuid().ToString();
            UserName = name;
        }

        public string Id { get; private set; }
        public string UserName { get; set; }
    }
}
