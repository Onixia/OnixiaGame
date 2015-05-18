namespace Onixia.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class OnixiaDbContext : IdentityDbContext<User>
    {
        public OnixiaDbContext()
            : base("DefaultConnection", false)
        {
        }

        public static OnixiaDbContext Create()
        {
            return new OnixiaDbContext();
        }
    }
}