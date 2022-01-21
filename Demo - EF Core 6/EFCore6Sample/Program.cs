using EFCore6Sample.CompiledModels;

using var context = new PeopleContext();

var timestamps = await new Seeder(context).SimulateBankAccountTransactions("Doe");

var lastBalance = await context.BankAccounts
                               .Where(b => b.Owner.LastName == "Doe")
                               .Select(b => b.Balance)
                               .SingleAsync();

WriteLine($"Current balance is {lastBalance}");

var bankAccountHistory = await context.BankAccounts
                                      .TemporalAll()
                                      .OrderBy(b => EF.Property<DateTime>(b, "PeriodStart"))
                                      .Select(b => new
                                      {
                                          Balance = b.Balance,
                                          From = EF.Property<DateTime>(b, "PeriodStart"),
                                          To = EF.Property<DateTime>(b, "PeriodEnd")
                                      })
                                      .ToListAsync();

bankAccountHistory.ForEach(record => WriteLine($"The balance was {record.Balance} from {record.From} to {record.To}"));

public class Seeder
{
    private readonly PeopleContext peopleContext;

    public Seeder(PeopleContext peopleContext)
    {
        this.peopleContext = peopleContext;
    }

    public async Task<IEnumerable<DateTime>> SimulateBankAccountTransactions(string owner)
    {
        var timestamps = new List<DateTime>();

        foreach(var _ in Enumerable.Range(0, 5))
        {
            var bankAccount = await peopleContext.BankAccounts
                                                 .FirstAsync(b => b.Owner.LastName == owner);

            bankAccount.Balance += new Random().Next(-50, 50);
            await peopleContext.SaveChangesAsync();

            Thread.Sleep(1000);

            timestamps.Add(DateTime.UtcNow);
        }

        return timestamps;
    }
}

public class PeopleContext : DbContext
{
    public DbSet<Person> People => Set<Person>();   
    public DbSet<BankAccount> BankAccounts => Set<BankAccount>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BankAccounts")
                         .UseModel(PeopleContextModel.Instance);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankAccount>()
                    .HasData(new BankAccount 
                    { 
                        Id = 1 
                    });

        modelBuilder.Entity<Person>()
                    .HasData(new Person
                    {
                        Id = 1,
                        FirstName = "John",
                        LastName = "Doe",
                        AccountId = 1
                    });

        modelBuilder.Entity<BankAccount>()
                    .ToTable(tableBuilder => tableBuilder.IsTemporal());
    }
}

public class Person
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int AccountId { get; set; }

    public BankAccount Account { get; set; } = null!;
}

public class BankAccount
{
    public int Id { get; set; }

    [Precision(10, 1)]
    public decimal Balance { get; set; }

    public Person Owner { get; set; } = null!;
}