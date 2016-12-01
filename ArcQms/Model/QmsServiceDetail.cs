using Newtonsoft.Json;
using System;
using ClassLocalization = ArcQms.Localization.Model.QmsServiceDetail;
using System.ComponentModel.DataAnnotations;

namespace ArcQms.Model
{
    public class QmsServiceDetail : QmsServiceInfo
    {
        [JsonProperty("license_name")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "LicenseName")]
        public string LicenseName { get; set; }

        [JsonProperty("license_url")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "LicenseUrl")]
        public string LicenseUrl { get; set; }

        [JsonProperty("copyright_text")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "CopyrightText")]
        public string CopyrightText { get; set; }

        [JsonProperty("copyright_url")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "CopyrightUrl")]
        public string CopyrightUrl { get; set; }

        [JsonProperty("terms_of_use_url")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "TermsOfUseUrl")]
        public string TermsOfUseUrl { get; set; }

        [JsonProperty("created_at")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "Created")]
        public DateTime Created { get; set; }

        [JsonProperty("updated_at")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "Updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("source")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "Source")]
        public string Source { get; set; }

        [JsonProperty("source_url")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "SourceUrl")]
        public string SourceUrl { get; set; }

        [JsonProperty("url")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "Url")]
        public string Url { get; set; }

        [JsonProperty("z_min")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "ZMin")]
        public string ZMin { get; set; }

        [JsonProperty("z_max")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "ZMax")]
        public string ZMax { get; set; }

        [JsonProperty("y_origin_top")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "YOriginTop")]
        public bool YOriginTop { get; set; }

        [JsonProperty("icon")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "IconId")]
        public string IconId { get; set; }

        [JsonProperty("submitter")]
        [Display(ResourceType = typeof(ClassLocalization.Resource), Name = "Submitter")]
        public string Submitter { get; set; }
    }
}