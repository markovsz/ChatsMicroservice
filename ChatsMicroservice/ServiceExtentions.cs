using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatsMicroservice.Filters;
using Messager.Chats.Application.Services.Services;
using Messager.Chats.Domain.Interfaces.Repositories;
using Messager.Chats.Domain.Interfaces.Repositories.Repository;
using Messager.Chats.Infrastructure.Data;
using Messager.Chats.Infrastructure.Data.Repository;
using Messager.Chats.Infrastructure.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatsMicroservice
{
    public static class ServiceExtentions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), 
                b => b.MigrationsAssembly("TelephoneNetworkProvider")));
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IChatsRepository, ChatsRepository>();
            services.AddScoped<IChatMembersRepository, ChatMembersRepository>();
            services.AddScoped<IMessagesRepository, MessagesRepository>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureService(this IServiceCollection services)
        {
            services.AddScoped<IChatsService, ChatsService>();
            services.AddScoped<IChatMembersService, ChatMembersService>();
            services.AddScoped<IMessagesService, MessagesService>();
        }

        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ExtractUserIdFilter>(); //transient
        }
    }
}
