﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HacarusVisualInspectionApi.Models
{

    public class Item
    {
        [JsonProperty("assessment")]
        public string Assessment { get; set; }

        [JsonProperty("confirmed_assessment")]
        public bool ConfirmedAssessment { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("default_image")]
        public string DefaultImage { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("detected_objects")]
        public int DetectedObjects { get; set; }

        [JsonProperty("detection_accuracy")]
        public double DetectionAccuracy { get; set; }

        [JsonProperty("finished_date")]
        public DateTime? FinishedDate { get; set; }

        [JsonProperty("good")]
        public bool? Good { get; set; }

        [JsonProperty("is_training_data")]
        public bool IsTrainingData { get; set; }

        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("override_assessment")]
        public bool OverrideAssessment { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("thumbnail_image")]
        public string ThumbnailImage { get; set; }
    }

    public class TrainingCount
    {
        [JsonProperty("defect")]
        public int Defect { get; set; }

        [JsonProperty("good")]
        public int Good { get; set; }
    }

    public class Summary
    {
        [JsonProperty("adjusted")]
        public int Adjusted { get; set; }

        [JsonProperty("analysed")]
        public int Analysed { get; set; }

        [JsonProperty("archived_defects")]
        public int ArchivedDefects { get; set; }

        [JsonProperty("assessment")]
        public string Assessment { get; set; }

        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }

        [JsonProperty("defects_detected")]
        public int DefectsDetected { get; set; }

        [JsonProperty("detection_accuracy")]
        public double DetectionAccuracy { get; set; }

        [JsonProperty("items_archived")]
        public int ItemsArchived { get; set; }

        [JsonProperty("items_for_review")]
        public int ItemsForReview { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("training")]
        public TrainingCount Training { get; set; }
    }

    public class ItemsData
    {
        [JsonProperty("archived")]
        public List<Item> Archived { get; set; }

        [JsonProperty("predict")]
        public List<Item> Predict { get; set; }

        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("training")]
        public List<Item> Training { get; set; }
    }

    public class ItemsResponse: Response
    {
        [JsonProperty("data")]
        public ItemsData Data { get; set; }
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

    public class Annotation
    {
        [JsonProperty("annotation_id")]
        public int AnnotationId { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("image_id")]
        public int ImageId { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("x_max")]
        public double XMax { get; set; }

        [JsonProperty("x_min")]
        public double XMin { get; set; }

        [JsonProperty("y_max")]
        public double YMax { get; set; }

        [JsonProperty("y_min")]
        public double YMin { get; set; }
    }

        public class Image
    {
        [JsonProperty("annotations")]
        public List<Annotation> Annotations { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("defect_counted")]
        public int DefectCounted { get; set; }

        [JsonProperty("exif_metadata")]
        public ExifMetadata ExifMetadata { get; set; }

        [JsonProperty("file_size")]
        public int FileSize { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("image_id")]
        public int ImageId { get; set; }

        [JsonProperty("is_raw_uploaded")]
        public bool IsRawUploaded { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("processed")]
        public bool Processed { get; set; }

        [JsonProperty("raw_url")]
        public string RawUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class Assessment
    {
        [JsonProperty("assessment_result")]
        public string AssessmentResult { get; set; }

        [JsonProperty("detected_objects")]
        public int? DetectedObjects { get; set; }

        [JsonProperty("detection_accuracy")]
        public double? DetectionAccuracy { get; set; }

        [JsonProperty("good")]
        public bool? Good { get; set; }

        [JsonProperty("override_assessment")]
        public bool? OverrideAssessment { get; set; }
    }


    public class ItemData
    {
        [JsonProperty("computed_assessment")]
        public Assessment ComputedAssessment { get; set; }

        [JsonProperty("confirmed_assessment")]
        public bool ConfirmedAssessment { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("is_training_data")]
        public bool IsTrainingData { get; set; }

        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("manual_assessment")]
        public Assessment ManualAssessment { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class ItemResponse: Response
    {
        [JsonProperty("data")]
        public ItemData Data { get; set; }
    }
}
