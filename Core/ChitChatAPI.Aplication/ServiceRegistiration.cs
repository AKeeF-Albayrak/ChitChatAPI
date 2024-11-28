using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChatAPI.Aplication
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
        }
    }
}
