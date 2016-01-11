
namespace Prodesp.Log.Common
{
    public interface ILogFactory
    {
        void Initialize();
        ICustomLog Create(string name);
    }
}
