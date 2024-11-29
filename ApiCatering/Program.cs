using Catering.Data.Repository.RBebida_Reserva;
using Catering.Data.Repository.RBebidas;
using Catering.Data.Repository.RCalificacion;
using Catering.Data.Repository.RCliente;
using Catering.Data.Repository.RCuenta_Cliente;
using Catering.Data.Repository.RCuenta_Propietario;
using Catering.Data.Repository.RDescuentos;
using Catering.Data.Repository.REmpresa;
using Catering.Data.Repository.Reserva_Dirreccion;
using Catering.Data.Repository.RImagenes_Empresa;
using Catering.Data.Repository.RMenu_Bebida_Reserva;
using Catering.Data.Repository.RMenu_Platillo_Reserva;
using Catering.Data.Repository.RMenu_Reserva;
using Catering.Data.Repository.RPlatillo;
using Catering.Data.Repository.RPlatillo_Reserva;
using Catering.Data.Repository.RPropietario_Empresa;
using Catering.Data.Repository.RReserva;
using Catering.Data.Repository.RReserva_Dirreccion;
using Catering.Data.Repository.RReserva_Info_Cliente;
using Catering.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Catering.Data.Migrations.ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});
//
builder.Services.AddScoped<IBebida_ReservaRepository, Bebida_ReservaRepository>();
builder.Services.AddScoped<Bebida_ReservaServices>();
//
builder.Services.AddScoped<IBebidaRepository, BebidaRepository>();
builder.Services.AddScoped<BebidaServices>();
//
builder.Services.AddScoped<ICalificacionRepository, CalificacionRepository>();
builder.Services.AddScoped<CalificacionServices>();
//
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ClienteServices>();
//
builder.Services.AddScoped<ICuenta_ClienteRepository, Cuenta_ClienteRepository>();
builder.Services.AddScoped<Cuenta_ClienteServices>();
//
builder.Services.AddScoped<ICuenta_PropietarioRepository, Cuenta_PropietarioRepository>();
builder.Services.AddScoped<Cuenta_PropietarioServices>();
//
builder.Services.AddScoped<IDescuentosRepository, DescuentosRepository>();
builder.Services.AddScoped<DescuentosService>();
//
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<EmpresaServices>();
//
builder.Services.AddScoped<IImagenes_EmpresaRepository, Imagenes_EmpresaRepository>();
builder.Services.AddScoped<Imagenes_EmpresaServices>();
//
builder.Services.AddScoped<IMenu_Bebida_ReservaRepository, Menu_Bebida_ReservaRepository>();
builder.Services.AddScoped<Menu_Bebida_ReservaService>();
//
builder.Services.AddScoped<IMenu_Platillo_ReservaRepository, Menu_Platillo_ReservaRepository>();
builder.Services.AddScoped<Menu_Platillo_ReservaService>();
//
builder.Services.AddScoped<IMenu_ReservaRepository, Menu_ReservaRepository>();
builder.Services.AddScoped<Menu_ReservaService>();
//
builder.Services.AddScoped<IPlatilloRepository, PlatilloRepository>();
builder.Services.AddScoped<PlatilloService>();
//
builder.Services.AddScoped<IPlatillo_ReservaRepository, Platillo_ReservaRepository>();
builder.Services.AddScoped<Platillo_ReservaServices>();
//
builder.Services.AddScoped<IPropietario_EmpresaRepository, Propietario_EmpresaRepository>();
builder.Services.AddScoped<Propietario_EmpresaService>();
//
builder.Services.AddScoped<IReserva_Repository, ReservaRepository>();
builder.Services.AddScoped<ReservasService>();
//
builder.Services.AddScoped<IReserva_DirreccionRepository, Reserva_DirreccionRepository>();
builder.Services.AddScoped<Reserva_DirreccionServices>();
//
builder.Services.AddScoped<IReserva_Info_ClienteRepository, Reserva_Info_ClienteRepository>();
builder.Services.AddScoped<Reserva_Info_ClienteServices>();

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
