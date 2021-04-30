using DriveTestFinderRepository.Entities;

namespace DriveTestFinderRepository.Repositories
{
    public class LanguageRepository : DataRepositoryBase<Language>
    {
        public LanguageRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
