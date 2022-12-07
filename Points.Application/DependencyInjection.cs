using Microsoft.Extensions.DependencyInjection;
using Points.Application.Common.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DotProfile),typeof(CommentProfile));
            return services;
        }
    }
}
