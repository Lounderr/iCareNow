﻿namespace iCareNow.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly INormalizer keyNormalizer;

        public UsersService(INormalizer keyNormalizer)
        {
            this.keyNormalizer = keyNormalizer;
        }

        public string NormalizeFirstName(string firstName)
            => (this.keyNormalizer == null) ? firstName : this.keyNormalizer.NormalizeFirstName(firstName);

        public string NormalizeLastName(string lastName)
            => (this.keyNormalizer == null) ? lastName : this.keyNormalizer.NormalizeLastName(lastName);
    }
}
