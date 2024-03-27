using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WomenORG.Data;
using WomenORG.Helper;
using WomenORG.Interfaces;
using WomenORG.Models;
using WomenORG.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDBContext>(options =>
   options.UseSqlServer(connectionString));
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ILearningProgramService, LearningProgramService>();
builder.Services.AddScoped<ReusableFunctions, ReusableFunctions>();
builder.Services.AddScoped<IParticipantService, ParticipantService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<ISponsorService, SponsorService>();
builder.Services.AddScoped<IPartnershipService, PartnershipService>();
builder.Services.AddScoped<IVolunteerService, VolunteerService>();

builder.Services.AddIdentity<UserModel, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 1;
}).AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {

        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,

    };
});
builder.Services.AddAuthorization(options =>
{
       options.AddPolicy("ViewGetAllRoles",
        policy => policy.RequireClaim("GetRoles"));
});
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();


app.Run();
