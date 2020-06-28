using System;

namespace WasmApp
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    sealed class BuildConfigurationAttribute : Attribute
    {
        public string? BaseUrl { get; }
        public string BuildDate { get; }

        public BuildConfigurationAttribute(string? baseUrl, string? buildDate)
        {
            BaseUrl = string.IsNullOrWhiteSpace(baseUrl) ? null : baseUrl;
            BuildDate = buildDate ?? "n/a";
        }
    }
}
