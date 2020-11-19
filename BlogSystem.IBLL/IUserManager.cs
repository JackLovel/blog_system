using BlogSystem.Dto;
using System;
using System.Threading.Tasks;

namespace BlogSystem.IBLL
{
    public interface IUserManager
    {
        Task Register(string email, string password);
        //Task<bool> Login(string email, string password);
        bool Login(string email, string password, out Guid userid);
        Task ChangePassword(string email, string oldPwd, string newPwd);
        Task ChangeUserInformation(string email, string siteName, string imagePath);
        Task<UserInformationDto> GetUserByEmail(string email);
    }
}
