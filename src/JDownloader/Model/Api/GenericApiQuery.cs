using System.Linq;
using System.Reflection;

namespace JDownloader.Model
{
    public abstract class GenericApiQuery
    {
        /// <summary>
        /// The number of results to return. Use -1 to return all results.
        /// </summary>
        public int MaxResults { get; set; } = 20;

        /// <summary>
        /// The starting index of the results
        /// </summary>
        public int StartAt { get; set; }

        public void IncludeDetails(bool includeDetails)
        {
            foreach (PropertyInfo prop in GetType().GetProperties().Where(x => x.PropertyType == typeof(bool)))
            {
                prop.SetValue(this, includeDetails);
            }
        }
    }
}