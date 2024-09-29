using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using minimal_api.Domain.Entidades;
using minimal_api.Infraestrutura.Db;
using minimal_api.Domain.Servicos;
using System.Reflection;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class AdministradorServicoTeste
    {
        private DbContexto CriarContextoDeTeste(){
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
        }

        [TestMethod]
        public void TestandoSalvarAdministrado(){
            //arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador();
            adm.Email = "teste@teste.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";
            
            var administradorServico = new AdministradorServico(context);

            //act 
            administradorServico.Incluir(adm);
            

            //assert
            Assert.AreEqual(1, administradorServico.Todos(1).Count());
            Assert.AreEqual("teste@teste.com", adm.Email);
            Assert.AreEqual("teste", adm.Senha);
            Assert.AreEqual("Adm", adm.Perfil);
        }

        [TestMethod]
        public void TestandoBuscaPorId(){
            //arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador();
            adm.Email = "teste@teste.com";
            adm.Senha = "teste";
            adm.Perfil = "Adm";
            
            var administradorServico = new AdministradorServico(context);

            //act 
            administradorServico.Incluir(adm);
            var admDoBanco = administradorServico.BuscaPorId(adm.Id);
            

            //assert
            Assert.AreEqual(1, admDoBanco.Id);
        }
    }
}