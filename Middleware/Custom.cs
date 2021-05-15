using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.AspNetCore.Builder
{
    public static class Custom
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, 
            string rootPath)
        {
            var path = Path.Combine(rootPath, "node_modules");
            //combines 2 paths into a string
            var fileProvider = new PhysicalFileProvider(path);
            var options = new StaticFileOptions();
            //options for serving static files
            options.RequestPath = "/node_modules";
            options.FileProvider = fileProvider;
            app.UseStaticFiles(options);
            return app;
        }
    }
}
