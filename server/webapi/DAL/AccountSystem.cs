using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class AccountSystem: DbContext
    {
        public AccountSystem(DbContextOptions<AccountSystem> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<PersonalTypes> PersonalTypes { get; set; }
        public DbSet<InvestmentPolicyTypes> InvestmentPolicyTypes { get; set; }
        public DbSet<PersonalInAccount> PersonalInAccounts { get; set; }

    }
}
