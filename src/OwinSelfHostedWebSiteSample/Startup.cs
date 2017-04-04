using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using OwinSelfHostedWebSiteSample;

[assembly: OwinStartup(typeof(Startup))]
namespace OwinSelfHostedWebSiteSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            var physicalFileSystem = new PhysicalFileSystem(@".\www"); //. = root, Web = your physical directory that contains all other static content, see prev step
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem
            };
            options.StaticFileOptions.FileSystem = physicalFileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = true;
            options.DefaultFilesOptions.DefaultFileNames = new[] { "index.html" }; //put whatever default pages you like here
            app.UseFileServer(options);
        }


    }
}
