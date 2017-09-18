using Academy.Framework.Core.Contracts;

namespace Academy.Core.Contracts
{
    public interface IEngine
    {
        void Start();

        IDatabase Database { get; }
    }
}
