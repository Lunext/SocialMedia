
using System.Reflection;
using Application.Activities;
using Application.Core;
using Application.Interfaces;
using Infrastructure.Photos;
using Infrastructure.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions;

    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config){
                    services.AddEndpointsApiExplorer();
                    services.AddSwaggerGen();

                    services.AddCors(opt=>{
                    opt.AddPolicy("CorsPolicy",policy=>{
                        policy.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:3000");
                    });
                    });

                    services.AddDbContext<DataContext>(opt=>{

                        opt.UseSqlite(config.GetConnectionString("DefaultConnection"));  
                    });

        
                    // services.AddMediatR(Assembly.GetExecutingAssembly());
                    // services.AddMediatR(typeof(Program).Assembly);
                    //  services.AddMediatR(typeof(List.Handler).Assembly);
                    services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

                    services.AddAutoMapper(typeof(MappingProfiles));

                    services.AddScoped<IUserAccessor,UserAccessor>();

                    services.AddScoped<IPhotoAccessor, PhotoAccessor>();
                    services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));

                    services.AddSignalR(); 

                    return services;


        }
        
    }
