using Microsoft.EntityFrameworkCore;
using PRN231_Trial_PE_1.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PE_PRN_Fall22B1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<PE_PRN_Fall22B1Context>();
builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy", builder => builder.AllowCredentials().SetIsOriginAllowed((hosts) => true).AllowAnyHeader().AllowAnyMethod());
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CORSPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();
