using Microsoft.EntityFrameworkCore;

namespace Axxes.ToyCollector.DataAccess.Contracts.EF
{
    public interface IExtendToyContext
    {
        void LoadToyContextExtensions(ModelBuilder builder);
    }
}