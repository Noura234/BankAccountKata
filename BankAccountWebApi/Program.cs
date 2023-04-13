using BankAccountKata.Application;
using BankAccountKata.Interfaces;

namespace BankAccountWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IBankAccount, BankAccount>();
            builder.Services.AddSingleton<IClock, Clock>();
            builder.Services.AddSingleton<IStatementPrinter, StatementPrinter>();
            builder.Services.AddSingleton<ITestableConsole, TestableConsole>();
            builder.Services.AddSingleton<ITransactionRepository, TransactionRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}