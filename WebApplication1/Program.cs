
using AppApi.Data;
using MaxWebApi.Repositorios;
using MaxWebApi.Repositorios.Cidade;
using MaxWebApi.Repositorios.Empresa;
using MaxWebApi.Repositorios.Interfaces;
using MaxWebApi.Repositorios.Interfaces.Empresa;
using MaxWebApi.Repositorios.Interfaces.Generico;
using MaxWebApi.Repositorios.Interfaces.Pedido;
using Microsoft.EntityFrameworkCore;
using MaxWebApi.Repositorios.Interfaces.Pessoa;
using MaxWebApi.Repositorios.Interfaces.Produto;
using MaxWebApi.Repositorios.Interfaces.PedidoItem;
using MaxWebApi.Repositorios.Ncm;
using MaxWebApi.Repositorios.Pessoa;
using MaxWebApi.Repositorios.Produto;
using MaxWebApi.Repositorios.Situacao;
using MaxWebApi.Repositorios.Pedido;
using MaxWebApi.Repositorios.PedidoItem;

namespace MaxWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionStringMySql = builder.Configuration.GetConnectionString("ConnectionMySql");
            builder.Services.AddDbContext<MaxWebApiDBContext>(option => option.UseMySql(
                    connectionStringMySql,
                    ServerVersion.Parse("10.3")
                ));

            builder.Services.AddScoped<INcmRepositorio, NcmRepositorio>();
            builder.Services.AddScoped<ICidadeRepositorio, CidadeRepositorio>();
            builder.Services.AddScoped<ISituacaoRepositorio, SituacaoRepositorio>();

            builder.Services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();
            builder.Services.AddScoped<IEmpresaUnidadeRepositorio, EmpresaUnidadeRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();


            builder.Services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
            builder.Services.AddScoped<IPessoaContribuinteRepositorio, PessoaContriubinteRepositorio>();
            builder.Services.AddScoped<IPessoaTipoRepositorio, PessoaTipoRepositorio>();

            builder.Services.AddScoped<IProdutoGrupoRepositorio, ProdutoGrupoRepositorio>();
            builder.Services.AddScoped<IProdutoDepartamentoRepositorio, ProdutoDepartamentoRepositorio>();
            builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            builder.Services.AddScoped<IPedidoItemRepositorio, PedidoItemRepositorio>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "MyPolicy",
                    policy =>
                    {
                        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                        policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                        policy.WithOrigins("http://localhost:7080").AllowAnyHeader().AllowAnyMethod();
                        policy.WithOrigins("http://192.168.100.3:8080").AllowAnyHeader().AllowAnyMethod();                    
                        policy.WithOrigins("http://localhost:7080/api/Pessoa").AllowAnyHeader().AllowAnyMethod();
                        policy.WithOrigins("http://localhost:7080/api/Pedido").AllowAnyHeader().AllowAnyMethod();
                    });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                //var url = "https://localhost:4200/";
                //var urlPessoa1 = "https://localhost:4200/Pessoa";
                //var urlPessoa2 = "https://localhost:7080/Pessoa";
                //url = "*";
                //app.UseCors(b => b.WithOrigins(url));
                //app.UseCors(c => c.WithOrigins(urlPessoa1));
                //app.UseCors(d => d.WithOrigins(urlPessoa2));
            }

            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}