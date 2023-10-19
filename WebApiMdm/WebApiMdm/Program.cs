using Microsoft.Extensions.DependencyInjection;
using WebApiMdm.DataAccess.Connection;
using WebApiMdm.DataAccess.Connection.AdventureWorks2019;
using WebApiMdm.DataAccess.Repositories.AdventureWorks2019;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.DataAccess.Services;
using WebApiMdm.DataAccess.UnitOfWork;
using WebApiMdm.Services.AdventureWorks2019.Production;
using WebApiMdm.Services.AdventureWorks2019.Production.Interfaces;
using WebApiMdm.DataAccess.Connection.AssetsManagement;
using WebApiMdm.DataAccess.Connection.CommercialBanking;
using WebApiMdm.DataAccess.Connection.InsuranceServices;
using WebApiMdm.DataAccess.Connection.MdmMaster;
using WebApiMdm.DataAccess.Connection.RetailBanking;
using WebApiMdm.Services;
using WebApiMdm.Services.MdmMaster;

var builder = WebApplication.CreateBuilder(args);

// Build configuration as usual
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

ConnectionHelper.configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IAdventureWorks2019SqlQueryService, AdventureWorks2019SqlQueryService>();

// Configure Connection string for AdventureWorks2019UnitOfWork
string adventureWorks2019ConnectionString = ConnectionHelper.GetConnectionString("AdventureWorks2019");

builder.Services.AddTransient<AdventureWorks2019UnitOfWork>(sp =>
    new AdventureWorks2019UnitOfWork(new AdventureWorks2019DbConfig
    {
        ConnectionString = adventureWorks2019ConnectionString
    }, new AdventureWorks2019SqlQueryService()
    ));



// Configure Connection string for AssetsManagement
string assetsManagementConnectionString = ConnectionHelper.GetConnectionString("AssetsManagement");
builder.Services.AddTransient<IAssetsManagementSqlQueryService, AssetsManagementSqlQueryService>();
builder.Services.AddTransient<AssetsManagementUnitOfWork>(sp =>
    new AssetsManagementUnitOfWork(new AssetsManagementDbConfig
    {
        ConnectionString = assetsManagementConnectionString
    }, new AssetsManagementSqlQueryService()
    ));

// Configure Connection string for CommercialBanking
string commercialBankingConnectionString = ConnectionHelper.GetConnectionString("CommercialBanking");
builder.Services.AddTransient<ICommercialBankingSqlQueryService, CommercialBankingSqlQueryService>();
builder.Services.AddTransient<CommercialBankingUnitOfWork>(sp =>
    new CommercialBankingUnitOfWork(new CommercialBankingDbConfig
    {
        ConnectionString = commercialBankingConnectionString
    }, new CommercialBankingSqlQueryService()
    ));

// Configure Connection string for InsuranceServices
string InsuranceServicesConnectionString = ConnectionHelper.GetConnectionString("InsuranceServices");
builder.Services.AddTransient<IInsuranceServicesSqlQueryService, InsuranceServicesSqlQueryService>();
builder.Services.AddTransient<InsuranceServicesUnitOfWork>(sp =>
    new InsuranceServicesUnitOfWork(new InsuranceServicesDbConfig
    {
        ConnectionString = InsuranceServicesConnectionString
    }, new InsuranceServicesSqlQueryService()
    ));

// Configure Connection string for MdmMaster
string mdmMasterConnectionString = ConnectionHelper.GetConnectionString("MdmMaster");
builder.Services.AddTransient<IMdmMasterSqlQueryService, MdmMasterSqlQueryService>();
builder.Services.AddTransient<MdmMasterUnitOfWork>(sp =>
    new MdmMasterUnitOfWork(new MdmMasterDbConfig
    {
        ConnectionString = mdmMasterConnectionString
    }, new MdmMasterSqlQueryService()
    ));

// Configure Connection string for RetailBanking
string retailBankingConnectionString = ConnectionHelper.GetConnectionString("RetailBanking");
builder.Services.AddTransient<IRetailBankingSqlQueryService, RetailBankingSqlQueryService>();
builder.Services.AddTransient<RetailBankingUnitOfWork>(sp =>
    new RetailBankingUnitOfWork(new RetailBankingDbConfig
    {
        ConnectionString = retailBankingConnectionString
    }, new RetailBankingSqlQueryService()
    ));

builder.Services.AddTransient<ICustomerDataOrchestrationService, CustomerDataOrchestrationService>();
builder.Services.AddTransient<ITestDbConnectionService, TestDbConnectionService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductModelService, ProductModelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Redirect root to Swagger UI
    app.Use(async (context, next) =>
    {
        if (context.Request.Path.Value == "/")
        {
            context.Response.Redirect("/swagger");
            return;
        }
        await next.Invoke();
    });
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
