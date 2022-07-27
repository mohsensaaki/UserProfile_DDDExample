using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Setting {
    public interface IWith {
        IWith Serializer(RuntimeApps.Common.Utils.ISerializer serializer);
        IWith ServiceCollection(IServiceCollection serviceCollection);
        IWith ServiceProvider(IServiceProvider serviceProvider);

    }
}
