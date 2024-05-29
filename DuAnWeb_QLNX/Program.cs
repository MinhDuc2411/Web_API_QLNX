using DATA_DuAn.Data;
using DuAnWeb_QLNX.Repository;
using DuAnWeb_QLNX.Repository.DanhMucXe;
using DuAnWeb_QLNX.Repository.DanhMucXeRepository;
using DuAnWeb_QLNX.Repository.HopDongThueRepository;
using DuAnWeb_QLNX.Repository.KhachHangRepository;
using DuAnWeb_QLNX.Repository.NhanVienRepository;
using DuAnWeb_QLNX.Repository.ThanhToanRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddHttpClient();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarRentalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.AddDbContext<CarRentalAuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarRentalAuthDbConnection")));
builder.Services.AddScoped<IDanhMucXeRepository, DanhMucXeRepository>();
builder.Services.AddScoped<IHopDongThueRepository, HopDongThueRepository>();
builder.Services.AddScoped<IKhachHangRepository, KhachHangRepository>();
builder.Services.AddScoped<INhanVienRepository, NhanVienRepository>();
builder.Services.AddScoped<IThanhToanRepository, ThanhToanRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
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

app.Run();
