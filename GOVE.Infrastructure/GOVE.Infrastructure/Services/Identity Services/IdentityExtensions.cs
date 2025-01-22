using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOVE.Repository.Implementors;
using GOVE.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomIdentityServerBuilderExtensions
    {
        //public static IIdentityServerBuilder AddUserStore(this IIdentityServerBuilder builder, IConfiguration configuration)
        //{
        //    builder.Services.AddSingleton<IUserRepository, UserRepository>(s => new UserRepository(configuration.GetConnectionString("ConnectionString")!));
        //    //builder.AddProfileService<UserProfileService>();
        //    //builder.AddResourceOwnerValidator<UserResouceOwnerPasswordValidator>();

        //    return builder;
        //}
    }
}
