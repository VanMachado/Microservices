﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.IdentityServer.Infra.Context
{
    public class SqlContext : IdentityDbContext<ApplicationUser>
    {
        public SqlContext(DbContextOptions<SqlContext> options) 
            : base(options)
        {
        }
    }
}
