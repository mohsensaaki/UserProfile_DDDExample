using Microsoft.Extensions.DependencyInjection;
using RuntimeApps.Common.Impl.Serialization.JsonNet;
using RuntimeApps.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Setting {
    public class Settings: IWith {

        private Settings() { }
        private static Settings _instace=new Settings();
        public static Settings Instance { get => _instace; }


        private static ISerializer _serializer=new JsonNetSerializer();
        private static IServiceCollection _serviceCollection=new ServiceCollection();
        private static IServiceProvider _serviceProvider=new DefaultServiceProviderFactory().CreateServiceProvider(_serviceCollection);

        public static ISerializer TheSerializer { get => _serializer; }
        public static IServiceCollection TheServiceCollection { get => _serviceCollection; }
        public static IServiceProvider TheServiceProvider { get => _serviceProvider; }
        
        public IWith ServiceCollection(IServiceCollection serviceCollection) {
            _serviceCollection = serviceCollection;
            return this;
        }

        public IWith Serializer(ISerializer serializer) {
           _serializer = serializer;
            return this;
        }

        public IWith ServiceProvider(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
            return this;
        }
    }
}
