using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{

    public class Item
    {
        [JsonProperty("assessment")]
        public object assessment { get; set; }

        [JsonProperty("confirmed_assessment")]
        public bool confirmed_assessment { get; set; }

        [JsonProperty("date")]
        public DateTime date { get; set; }

        [JsonProperty("default_image")]
        public string default_image { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("detected_objects")]
        public int detected_objects { get; set; }

        [JsonProperty("detection_accuracy")]
        public double detection_accuracy { get; set; }

        [JsonProperty("finished_date")]
        public DateTime? finished_date { get; set; }

        [JsonProperty("good")]
        public bool? good { get; set; }

        [JsonProperty("is_training_data")]
        public bool is_training_data { get; set; }

        [JsonProperty("item_id")]
        public string item_id { get; set; }

        [JsonProperty("label")]
        public string label { get; set; }

        [JsonProperty("override_assessment")]
        public bool override_assessment { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("thumbnail_image")]
        public string thumbnail_image { get; set; }
    }

    public class TrainingCount
    {
        [JsonProperty("defect")]
        public int defect { get; set; }

        [JsonProperty("good")]
        public int good { get; set; }
    }

    public class Summary
    {
        [JsonProperty("adjusted")]
        public int adjusted { get; set; }

        [JsonProperty("analysed")]
        public int analysed { get; set; }

        [JsonProperty("archived_defects")]
        public int archived_defects { get; set; }

        [JsonProperty("assessment")]
        public string assessment { get; set; }

        [JsonProperty("confirmed")]
        public int confirmed { get; set; }

        [JsonProperty("defects_detected")]
        public int defects_detected { get; set; }

        [JsonProperty("detection_accuracy")]
        public double detection_accuracy { get; set; }

        [JsonProperty("items_archived")]
        public int items_archived { get; set; }

        [JsonProperty("items_for_review")]
        public int items_for_review { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("training")]
        public TrainingCount training { get; set; }
    }

    public class ItemsData
    {
        [JsonProperty("archived")]
        public List<Item> archived { get; set; }

        [JsonProperty("predict")]
        public List<Item> predict { get; set; }

        [JsonProperty("summary")]
        public Summary summary { get; set; }

        [JsonProperty("training")]
        public List<Item> training { get; set; }
    }

    public class ItemsResponse: Response
    {
        [JsonProperty("data")]
        public ItemsData data { get; set; }
    }

    public class ComputedAssessment
    {
        [JsonProperty("assessment_result")]
        public string assessment_result { get; set; }

        [JsonProperty("detected_objects")]
        public int? detected_objects { get; set; }

        [JsonProperty("detection_accuracy")]
        public double? detection_accuracy { get; set; }

        [JsonProperty("good")]
        public bool? good { get; set; }
    }

    public class ExifMetadata
    {
        public List<int> ApertureValue { get; set; }
        public List<int> BrightnessValue { get; set; }
        public int ColorSpace { get; set; }
        public string ComponentsConfiguration { get; set; }
        public string DateTime { get; set; }
        public string DateTimeDigitized { get; set; }
        public string DateTimeOriginal { get; set; }
        public int ExifImageHeight { get; set; }
        public int ExifImageWidth { get; set; }
        public int ExifOffset { get; set; }
        public string ExifVersion { get; set; }
        public List<int> ExposureBiasValue { get; set; }
        public int ExposureMode { get; set; }
        public int ExposureProgram { get; set; }
        public List<int> ExposureTime { get; set; }
        public List<int> FNumber { get; set; }
        public int Flash { get; set; }
        public string FlashPixVersion { get; set; }
        public List<int> FocalLength { get; set; }
        public int FocalLengthIn35mmFilm { get; set; }
        public Dictionary<string, object> GPSInfo { get; set; }
        public int ISOSpeedRatings { get; set; }
        public string LensMake { get; set; }
        public string LensModel { get; set; }
        public List<List<int>> LensSpecification { get; set; }
        public string Make { get; set; }
        public int MeteringMode { get; set; }
        public string Model { get; set; }
        public int Orientation { get; set; }
        public int ResolutionUnit { get; set; }
        public int SceneCaptureType { get; set; }
        public string SceneType { get; set; }
        public int SensingMethod { get; set; }
        public List<int> ShutterSpeedValue { get; set; }
        public string Software { get; set; }
        public List<int> SubjectLocation { get; set; }
        public string SubsecTimeDigitized { get; set; }
        public string SubsecTimeOriginal { get; set; }
        public int WhiteBalance { get; set; }
        public List<int> XResolution { get; set; }
        public int YCbCrPositioning { get; set; }
        public List<int> YResolution { get; set; }
    }

    public class Annotation
    {
        [JsonProperty("annotation_id")]
        public int annotation_id { get; set; }

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("image_id")]
        public int image_id { get; set; }

        [JsonProperty("notes")]
        public object notes { get; set; }

        [JsonProperty("x_max")]
        public double x_max { get; set; }

        [JsonProperty("x_min")]
        public double x_min { get; set; }

        [JsonProperty("y_max")]
        public double y_max { get; set; }

        [JsonProperty("y_min")]
        public double y_min { get; set; }
    }

        public class Image
    {
        [JsonProperty("annotations")]
        public List<Annotation> annotations { get; set; }

        [JsonProperty("content_type")]
        public string content_type { get; set; }

        [JsonProperty("defect_counted")]
        public int defect_counted { get; set; }

        [JsonProperty("exif_metadata")]
        public ExifMetadata exif_metadata { get; set; }

        [JsonProperty("file_size")]
        public int file_size { get; set; }

        [JsonProperty("height")]
        public int height { get; set; }

        [JsonProperty("image_id")]
        public int image_id { get; set; }

        [JsonProperty("is_raw_uploaded")]
        public bool is_raw_uploaded { get; set; }

        [JsonProperty("position")]
        public object position { get; set; }

        [JsonProperty("processed")]
        public bool processed { get; set; }

        [JsonProperty("raw_url")]
        public string raw_url { get; set; }

        [JsonProperty("url")]
        public object url { get; set; }

        [JsonProperty("width")]
        public int width { get; set; }
    }

    public class ManualAssessment
    {
        [JsonProperty("assessment_result")]
        public string assessment_result { get; set; }

        [JsonProperty("detected_objects")]
        public int? detected_objects { get; set; }

        [JsonProperty("detection_accuracy")]
        public double? detection_accuracy { get; set; }

        [JsonProperty("good")]
        public bool? good { get; set; }

        [JsonProperty("override_assessment")]
        public bool override_assessment { get; set; }
    }

    public class ItemData
    {
        [JsonProperty("computed_assessment")]
        public ComputedAssessment computed_assessment { get; set; }

        [JsonProperty("confirmed_assessment")]
        public bool confirmed_assessment { get; set; }

        [JsonProperty("images")]
        public List<Image> images { get; set; }

        [JsonProperty("is_training_data")]
        public bool is_training_data { get; set; }

        [JsonProperty("item_id")]
        public string item_id { get; set; }

        [JsonProperty("label")]
        public string label { get; set; }

        [JsonProperty("manual_assessment")]
        public ManualAssessment manual_assessment { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
    }

    public class ItemResponse: Response
    {
        [JsonProperty("data")]
        public ItemData data { get; set; }
    }
}
