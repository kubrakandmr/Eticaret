using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.MvcWEBUI.Entities
{
    public class CustomIdentityDbContext :IdentityDbContext <CustomIdentityUser,CustomIdentityRole,string>
    {
        //öncelikle user class sonra role class ı ve veritabanında hangi veri türünde primarykey tutuyorsak o veri türü
        //string olmasının sebebi unique identifier tutuyor onun karşılığı string.
        public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext>options):base(options)
        {

        }
    }
}
