using Blog.Interface;
using Blog.Repository;
using Blog.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.DependencyInjection
{
    public class DependencyInjectionConfig
    {
        public static void Register(IServiceCollection service)
        {

            service.AddTransient<IBlogService, BlogService>();
            service.AddTransient<IBlogRepositorio, BlogRepository>();
        }
    }
}
