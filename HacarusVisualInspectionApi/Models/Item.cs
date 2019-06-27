using System;
using System.Collections.Generic;

namespace HacarusVisualInspectionApi.Models
{

    public class Item
    {
        public object assessment { get; set; }
        public bool confirmed_assessment { get; set; }
        public DateTime date { get; set; }
        public string default_image { get; set; }
        public string description { get; set; }
        public int detected_objects { get; set; }
        public double detection_accuracy { get; set; }
        public DateTime? finished_date { get; set; }
        public bool? good { get; set; }
        public bool is_training_data { get; set; }
        public string item_id { get; set; }
        public string label { get; set; }
        public bool override_assessment { get; set; }
        public string status { get; set; }
        public string thumbnail_image { get; set; }
    }

    public class TrainingCount
    {
        public int defect { get; set; }
        public int good { get; set; }
    }

    public class Summary
    {
        public int adjusted { get; set; }
        public int analysed { get; set; }
        public int archived_defects { get; set; }
        public string assessment { get; set; }
        public int confirmed { get; set; }
        public int defects_detected { get; set; }
        public double detection_accuracy { get; set; }
        public int items_archived { get; set; }
        public int items_for_review { get; set; }
        public string title { get; set; }
        public TrainingCount training { get; set; }
    }

    public class ItemsData
    {
        public List<Item> archived { get; set; }
        public List<Item> predict { get; set; }
        public Summary summary { get; set; }
        public List<Item> training { get; set; }
    }

    public class ItemsResponse: Response
    {
        public ItemsData data { get; set; }
    }

    public class ComputedAssessment
    {
        public string assessment_result { get; set; }
        public int? detected_objects { get; set; }
        public double? detection_accuracy { get; set; }
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
        public int annotation_id { get; set; }
        public DateTime created_at { get; set; }
        public int image_id { get; set; }
        public object notes { get; set; }
        public double x_max { get; set; }
        public double x_min { get; set; }
        public double y_max { get; set; }
        public double y_min { get; set; }
    }

        public class Image
    {
        public List<Annotation> annotations { get; set; }
        public string content_type { get; set; }
        public int defect_counted { get; set; }
        public ExifMetadata exif_metadata { get; set; }
        public int file_size { get; set; }
        public int height { get; set; }
        public int image_id { get; set; }
        public bool is_raw_uploaded { get; set; }
        public object position { get; set; }
        public bool processed { get; set; }
        public string raw_url { get; set; }
        public object url { get; set; }
        public int width { get; set; }
    }

    public class ManualAssessment
    {
        public string assessment_result { get; set; }
        public int? detected_objects { get; set; }
        public double? detection_accuracy { get; set; }
        public bool? good { get; set; }
        public bool override_assessment { get; set; }
    }

    public class ItemData
    {
        public ComputedAssessment computed_assessment { get; set; }
        public bool confirmed_assessment { get; set; }
        public List<Image> images { get; set; }
        public bool is_training_data { get; set; }
        public string item_id { get; set; }
        public string label { get; set; }
        public ManualAssessment manual_assessment { get; set; }
        public string status { get; set; }
    }

    public class ItemResponse: Response
    {
        public ItemData data { get; set; }
    }
}
