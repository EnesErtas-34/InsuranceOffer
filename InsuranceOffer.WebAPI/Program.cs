//using InsuranceOffer.BusinessLayer.Abstract;
//using InsuranceOffer.BusinessLayer.Concrete;
//using InsuranceOffer.DataAccessLayer.Abstract;
//using InsuranceOffer.DataAccessLayer.Concrete.EntityFramework;
//using InsuranceOffer.DataAccessLayer.Concrete.EntityFramework.Contexts;
//var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDbContext<EurekoInsuranceContext>();
//builder.Services.AddScoped<IInsuredDal, EfInsuredDal>();
//builder.Services.AddScoped<IInsuredService, InsuredManager>();
//builder.Services.AddScoped<IPolicyDal, EfPolicyDal>();
//builder.Services.AddScoped<IPolicyService, PolicyManager>();
//builder.Services.AddScoped<IAssuranceDal, EfAssuranceDal>();
//builder.Services.AddScoped<IAssuranceService, AssuranceManager>();
//builder.Services.AddScoped<IPoliceAssuranceDal, EfPoliceAssuranceDal>();
//builder.Services.AddScoped<IPoliceAssuranceService, PoliceAssuranceManager>(); 
//builder.Services.AddScoped<IPayDal,EfPayDal>();
//builder.Services.AddScoped<IPayService,PayManager>();

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using InsuranceOffer.BusinessLayer.Abstract;
using InsuranceOffer.BusinessLayer.Concrete;
using InsuranceOffer.DataAccessLayer.Abstract;
using InsuranceOffer.DataAccessLayer.Concrete.EntityFramework;
using InsuranceOffer.DataAccessLayer.Concrete.EntityFramework.Contexts;
using InsuranceOffer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EurekoInsuranceContext>();
builder.Services.AddScoped<IInsuredDal, EfInsuredDal>();
builder.Services.AddScoped<IInsuredService, InsuredManager>();
builder.Services.AddScoped<IPolicyDal, EfPolicyDal>();
builder.Services.AddScoped<IPolicyService, PolicyManager>();
builder.Services.AddScoped<IAssuranceDal, EfAssuranceDal>();
builder.Services.AddScoped<IAssuranceService, AssuranceManager>();
builder.Services.AddScoped<IPoliceAssuranceDal, EfPoliceAssuranceDal>();
builder.Services.AddScoped<IPoliceAssuranceService, PoliceAssuranceManager>();
builder.Services.AddScoped<IPayDal, EfPayDal>();
builder.Services.AddScoped<IPayService, PayManager>();
builder.Services.AddScoped<IVerificationCodesDal, EfVerificationCodesDal>();
builder.Services.AddScoped<IVerificationCodesService, VerificationManager>();
builder.Services.AddScoped<ISmsService, SmsService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS policy
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
