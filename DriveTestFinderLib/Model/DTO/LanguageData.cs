using DriveTestFinderRepository.Entities;

namespace DriveTestFinderLib.Model.DTO
{
    public class LanguageData
    {
        public int LanguageId { get; set; }
        public string Description { get; set; }

        public static LanguageData FromLanguge(Language language)
        {
            return new LanguageData { LanguageId = language.LanguageId, Description = language.Description };
        }
    }
}
