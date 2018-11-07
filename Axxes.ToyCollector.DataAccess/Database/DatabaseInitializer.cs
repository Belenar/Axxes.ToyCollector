using Axxes.ToyCollector.Core.Contracts.Database;
using Axxes.ToyCollector.DataAccess.EF;

namespace Axxes.ToyCollector.DataAccess.Database
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private bool _isInitialized;

        private readonly ToyContext _context;

        public DatabaseInitializer(ToyContext context)
        {
            _context = context;
        }

        public void Initialize()
        {

            if (!_isInitialized)
            { 
                _isInitialized = true;
            }
        }
    }
}
