using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EfToolLibrary
{
    public static class EFMiscExtension
    {
        public static void LtcCascadeDeleteOff(this ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
