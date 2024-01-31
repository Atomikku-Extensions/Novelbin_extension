using System.Text;

namespace Novelbin.Core.Extensions
{
    /// <summary>
    /// Represents a class that contains extension methods for the <see cref="string"/> class.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Represents a method that formats a string with the given arguments.
        /// </summary>
        /// <param name="text">Used to concatenate with <paramref name="arguments"/>.</param>
        /// <param name="arguments">Used to concatenate with <paramref name="text"/>.</param>
        /// <returns>The string value.</returns>
        public static string FormatingString(this string text, params string[] arguments)
        {
            StringBuilder stringBuilder = new(text);
            foreach (var argument in arguments)
            {
                if (string.IsNullOrEmpty(argument)) continue;
                stringBuilder.Append(argument);
            }

            return stringBuilder.ToString();
        }
    }
}