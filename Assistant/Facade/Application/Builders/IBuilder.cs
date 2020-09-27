
using System.Threading.Tasks;

namespace Rovecode.Assistant.Facade.Application.Builders
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
