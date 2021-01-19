using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameStoreApp.Data
{
    public static class SeedData
    {
        
        public static async Task CreateRoles(IServiceProvider serviceProvider,
                                            IConfiguration Configuration)
        {
            //incluir perfis customizados
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //define os perfis em um array de strings
            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;

            //percorre o array de strings
            //verifica se o perfil ja existe
            foreach (var roleName in roleNames)
            {
                //cria perfis e os inclui no banco de dados
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //cria um super usuario que pode manter a aplicacao web
            var poweruser = new IdentityUser
            {
                //obtem o nome e o email do arquivo de configuração
                UserName = Configuration.GetSection("UserSettings")["UserName"],
                Email = Configuration.GetSection("UserSettings")["UserEmail"]
            };

            //obtem a senha do arquivo de configuracao
            string userPassword = Configuration.GetSection("UserSettings")["UserPassword"];

            //verifica se existe um usuario com email informado
            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["UserEmail"]);

            if (user == null)
            {
                //cria o super usuario com os dados informados
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    //atribui o usuario ao perfil admin
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }
    }
}