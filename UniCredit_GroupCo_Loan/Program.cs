using Microsoft.EntityFrameworkCore;
using UniCredit_GroupCo_Loan.BusinessEntities;
using UniCredit_GroupCo_Loan.BusinessEntities.Intefrace;
using UniCredit_GroupCo_Loan.DataBaselogic.HotelManagementDBModel;
using UniCredit_GroupCo_Loan.RepositoryLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRegistrationRepository, UserRegistrationRepository>();
builder.Services.AddScoped<IuserRegistrationService, UserRegistrationService>();
builder.Services.AddDbContext<HotelManagementContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CFAConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
