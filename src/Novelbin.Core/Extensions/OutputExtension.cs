using Atomikku.Models.Extension;

namespace Novelbin.Core.Extensions
{
    public static class OutputExtension
    {
        public static Output CreateOutput(this Output output) => new Output
        {
            Tittle = output.Tittle,
            SecondTittle = output.SecondTittle,
            Description = output.Description,
            Author = output.Author,
            ReleaseDate = output.ReleaseDate,
            ImageUrl = output.ImageUrl,
            Chapters = output.Chapters
        };
    }
}