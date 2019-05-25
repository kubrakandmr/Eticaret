using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.MvcWEBUI.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        //Extensions method olabilmesi için hem sınıfımın hem de methodumuzun static olması gerekir.

        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            //Extens ederken this kullanmak zorundayız.
            //Iapp.builder ı extens ediyoruz.Root u parametre olarak gönderiyoruz.
            //root içindeki UseNodeMo.klasörünü arıyacak.

            var path = Path.Combine(root, "node_modules"); //rootla node_modules i birleştir.
            var provider = new PhysicalFileProvider(path);//static dosyaları taşımak için kullanılan ara servis provider.

            var options = new StaticFileOptions(); //static dosya sunumu için.
            options.RequestPath = "/node_modules"; //şu adrese bir istek gelirse.
            options.FileProvider = provider; //sunumu provider tarafından yapılıcak.

            app.UseStaticFiles(options);

            return app;
        }
    }
}
