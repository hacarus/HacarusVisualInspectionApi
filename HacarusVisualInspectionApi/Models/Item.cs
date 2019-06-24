using System;
using System.Collections.Generic;

namespace HacarusVisualInspectionApi.Models
{

    public class Item
    {
        public object assessment { get; set; }
        public bool confirmed_assessment { get; set; }
        public string date { get; set; }
        public string default_image { get; set; }
        public object description { get; set; }
        public int detected_objects { get; set; }
        public int detection_accuracy { get; set; }
        public string finished_date { get; set; }
        public object good { get; set; }
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
        public object assessment_result { get; set; }
        public object detected_objects { get; set; }
        public object detection_accuracy { get; set; }
        public object good { get; set; }
    }

    public class ExifMetadata
    {
    }

    public class Image
    {
        public List<object> annotations { get; set; }
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
        public object assessment_result { get; set; }
        public object detected_objects { get; set; }
        public object detection_accuracy { get; set; }
        public object good { get; set; }
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
