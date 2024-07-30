using nopCommerceApi.Exceptions;
using nopCommerceApi.Models.Product;

namespace nopCommerceApi.Helpers
{
    public static class DtoHelper
    {

        /// <summary>
        /// Check if properly format of ids for dto property. 
        /// </summary>
        /// <remarks>
        /// Some of fields in DTO has to be string comma seperate 
        /// ids of related entities. This method checks if the string
        /// is in the proper format.
        /// </remarks>
        /// <param name="stringSpecyficFormat">proper string format - 10,20,30</param>
        /// <returns>List<int>, if string is empty return empty List with int</returns>
        /// <exception cref="BadRequestException"></exception>
        public static IEnumerable<int> BeAListFromCommaSeparatedString(string stringSpecyficFormat)
        {
            if (string.IsNullOrEmpty(stringSpecyficFormat))
                return new List<int>();

            var ids = stringSpecyficFormat.Split(',');
            if (ids.All(id => int.TryParse(id, out _)))
            {
                return ids.Select(id => int.Parse(id)).ToList();
            }
            else
            {
                throw new BadRequestException($"Invalid comma separated list: {stringSpecyficFormat}");
            }
        }
    }
}
