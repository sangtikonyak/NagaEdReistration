using System.Security.Cryptography;
using System.Text;
using UserRegistration.CustomExceptions;
using UserRegistration.Model;

namespace UserRegistration.Repository
{
    public class IUserServiceImpl : IUserService
    {
        private readonly UserDbContext _context;

        public IUserServiceImpl(UserDbContext context)
        {
            this._context = context;
        }

        public async Task<string> Register(User user)
        {
            try
            {
                User userFromDb = await _context.Users.FindAsync(user.Username);
                if (userFromDb != null)
                {
                    throw new UserAlreadyExistException("User Already Exist");
                }
                string hashedPassword = HashPassword(user.Password);

                user.Password = hashedPassword;

                await _context.AddAsync(user);
                int rowAffected = await _context.SaveChangesAsync();
                if (rowAffected < 1)
                {
                    throw new Exception("Data Not Saved To Database");
                }
                return "Data Saved Successfully";
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
