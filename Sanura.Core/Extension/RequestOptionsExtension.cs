using System.Dynamic;
using Sanura.Core.Model;

namespace Sanura.Core.Extension
{
    public static class RequestOptionsExtension
    {
        public static dynamic GetProperties(this RequestOptions options)
        {
            var parameters = new ExpandoObject() as IDictionary<String, object>;

            if (options.Filters != null)
            {
                foreach (var keyValue in options.Filters)
                {
                    if (!string.IsNullOrEmpty(keyValue.Value))
                        parameters.Add(keyValue.Key, keyValue.Value);
                }
            }

            if (options.OrderBy != null && !string.IsNullOrEmpty(options.OrderBy.Column))
            {
                parameters["orderByColumn"] = options.OrderBy.Column;
                parameters["@sortType"] = options.OrderBy.IsDesc;
            }
            return parameters;
        }
    }
}