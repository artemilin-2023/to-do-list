using AutoMapper;
using TaskManager.Domain;
using TaskManager.Infrastructure.Data;
using TaskManager.Infrastructure.Data.Entities;

namespace TaskManager.Infrastructure.Tests.DataTests
{
    internal class UserRepositoryTests
    {

        [Test]
        public void MaperTest()
        {
            var mapper = new MapperConfiguration(config => { config.AddProfile(new MapperProfile()); }).CreateMapper();

            var userEntity = new UserEntity()
            {
                Username = "name",
                Email = "mail",
                Id = Guid.NewGuid(),
                PasswordHash = "asdfg"
            };

            var user = mapper.Map<User>(userEntity);

            Assert.That(user, Is.Not.Null);
            Assert.That(AreEqual(userEntity, user), Is.True);
        }

        private static bool AreEqual(UserEntity a, User b)
        {
            return a.Username == b.Username
                && a.Email == b.Email
                && a.Id == b.Id
                && a.PasswordHash == b.PasswordHash;
        }
    }
}
