using Newtonsoft.Json;
using ClassLocalization = ArcQms.Localization.Model.QmsServiceInfo;
using System.ComponentModel.DataAnnotations;

namespace ArcQms.Model
{
    public class QmsServiceInfo
    {
        [JsonProperty("id")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "Id")]
        public int Id { get; set; }

        [JsonProperty("guid")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "Guid")]
        public string Guid { get; set; }

        [JsonProperty("name")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "Name")]
        public string Name { get; set; }

        [JsonProperty("desc")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "Description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "Type")]
        public string Type { get; set; }

        [JsonProperty("epsg")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "Epsg")]
        public string Epsg { get; set; }
    }
}
