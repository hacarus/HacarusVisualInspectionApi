using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{

    public partial class ItemResponse : Response
    {
        [JsonProperty("data")]
        public Item Data { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("default_image")]
        public string DefaultImage { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("finished_date")]
        public DateTime? FinishedDate { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("is_training_data")]
        public bool? IsTrainingData { get; set; }

        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        [JsonProperty("override")]
        public Override Override { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("thumbnail_image")]
        public string ThumbnailImage { get; set; }
    
        [JsonProperty("models")]
        public Model[] Models { get; set; }

    }

    public partial class Image
    {
        [JsonProperty("annotations")]
        public Annotation[] Annotations { get; set; }

        [JsonProperty("batch_id")]
        public string BatchId { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("defects")]
        public long Defects { get; set; }

        [JsonProperty("exif_metadata")]
        public ExifMetadata ExifMetadata { get; set; }

        [JsonProperty("file_name")]
        public string FileName { get; set; }

        [JsonProperty("file_size")]
        public int? FileSize { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("image_id")]
        public long ImageId { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("processed")]
        public bool Processed { get; set; }

        [JsonProperty("uploaded")]
        public bool Uploaded { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("is_raw_uploaded")]
        public bool? IsRawUploaded { get; set; }

        [JsonProperty("raw_url")]
        public string RawUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Annotation
    {
        [JsonProperty("annotation_id")]
        public int AnnotationId { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("for_training")]
        public bool ForTraining { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("x_max")]
        public int XMax { get; set; }

        [JsonProperty("x_min")]
        public int XMin { get; set; }

        [JsonProperty("y_max")]
        public int YMax { get; set; }

        [JsonProperty("y_min")]
        public int YMin { get; set; }


        public Annotation() { }
        public Annotation(
            int xMin,
            int xMax,
            int yMin,
            int yMax,
            string notes)
        {
            XMin = xMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
            Notes = notes;
        }

        public bool ShouldSerializeAnnotationId()
        {
            return false;
        }

        public bool ShouldSerializeCreatedAt()
        {
            return false;
        }

        public bool ShouldSerializeForTraining()
        {
            return false;
        }
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
        [JsonProperty("GPSInfo")]
        public Dictionary<string, object> GpsInfo { get; set; }
        [JsonProperty("ISOSpeedRatings")]
        public int IsoSpeedRatings { get; set; }
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


    public class Override
    {
        [JsonProperty("detected_objects")]
        public int? DetectedObjects { get; set; }

        [JsonProperty("detection_accuracy")]
        public int? DetectionAccuracy { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }
    }


    public class Model
    {
        [JsonProperty("aggregate")]
        public Aggregate Aggregate { get; set; }

        [JsonProperty("assessments")]
        public Assessment[] Assessments { get; set; }

        [JsonProperty("model_id")]
        public long ModelId { get; set; }
    }

    public class Aggregate
    {
        [JsonProperty("detected_objects")]
        public long DetectedObjects { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class Assessment
    {
        [JsonProperty("annotations")]
        public Annotation[] Annotations { get; set; }

        [JsonProperty("computed")]
        public Override Computed { get; set; }

        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("final")]
        public Override Final { get; set; }

        [JsonProperty("finished_date")]
        public DateTime? FinishedDate { get; set; }

        [JsonProperty("image_id")]
        public long ImageId { get; set; }

        [JsonProperty("model_id")]
        public long ModelId { get; set; }
    }
}
