---
title: API Reference

language_tabs: # must be one of https://git.io/vQNgJ
  - csharp
  - python

toc_footers:
  - <a href='https://github.com/lord/slate'>Documentation Powered by Slate</a>

includes:
  - errors

search: true
---

# t(:introduction)

- **C#** [![Build Status](https://travis-ci.org/hacarus/HacarusVisualInspectionApi.svg?branch=master)](https://travis-ci.org/hacarus/HacarusVisualInspectionApi)
- **Python**

[English](t(:enLink)) | [日本語](t(:jaLink))
<br/>
<br/>
t(:introductionMessage)

<div class="hacarus-content lang-specific csharp">
t(:introductionMessageMoreCSharp)
</div>

<div class="hacarus-content lang-specific python">
t(:introductionMessageMorePython)
</div>
<br/>
<br/>

## t(:installation)

```csharp
PM> Install-Package HacarusVisualInspectionApi -Version 1.1.2-beta
```

```python
> pip install hacarus_visual_inspection
```


<div class="hacarus-content lang-specific csharp">
t(:installationMessageCSharp)
</div>

<div class="hacarus-content lang-specific python">
t(:installationMessagePython)
</div>

<div class="hacarus-content lang-specific csharp">
t(:installationMessageMoreCSharp)
</div>

## t(:terms)
t(:termsMessage)

## t(:usage)
t(:usageMessage)
# t(:initialization)

```csharp
using HacarusVisualInspectionApi;
using HacarusVisualInspectionApi.Models;
HacarusVisualInspection VisualInspection = new HacarusVisualInspection("https://yourserverurl.com/api");

//Language support
HacarusVisualInspection VisualInspection = new HacarusVisualInspection("https://yourserverurl.com/api", "ja");
//HacarusVisualInspection VisualInspection = new HacarusVisualInspection(language: "ja");
//VisualInspection.SetLanguage("ja");
```

```python
from hacarus_visual_inspection import VisualInspectionSDK
sdk = VisualInspectionSDK(
    "<your_client_id>",
    "<your_client_secret>",
    "<your_api_url>"
)
```
t(:initializationMessage)

# t(:authorization)

```csharp
AccessTokenResponse Response = VisualInspection.Authorize("YourClientId", "YourClientSecret");
```

```python
# already part of the initialization
sdk = VisualInspectionSDK(
    "<your_client_id>",
    "<your_client_secret>",
    "<your_api_url>"
)
```
t(:authorizationMessage)


<!-- <div class="hacarus-content lang-specific csharp"> -->
> **t(:sampleResponse)**

```csharp
{
    "data": {
        "access_token": "GeneratedAccessToken",
        "expires": 2592000
    }
}
```

> **t(:possibleErrors)**
<br/>
> *t(:error401)* t(:invalidClientId)

```csharp
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/auth/token"
        },
        "status": 401,
        "title": "Cannot find client information"
    }
}
```

```python
    hacarus_visual_inspection.errors.APIError: Cannot find client information (401)
```
> *t(:error401)* t(:invalidClientSecret)

```csharp
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/auth/token"
        },
        "status": 401,
        "title": "Client id and secret mismatch"
    }
}
```

```python
    hacarus_visual_inspection.errors.APIError: Client id and secret mismatch (400)
```
<!-- </div>  -->

# t(:methods)

## t(:activateLicense)

```csharp
var LicenseFile = new FileModel("PathToFile", "ContentType");
UploadResponse Response = VisualInspection.ActivateLicense(LicenseFile);
```

```python
sdk.activate_license("test_client", "tests/data/license.key")
```
t(:activateLicenseMessage)

> **t(:sampleResponse)**

```json
{
    "status": "ok"
}
```

> **t(:possibleErrors)**
<br/>
> *t(:error403)* t(:invalidLicense)

```csharp
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/auth/license"
        },
        "status": 403,
        "title": "Invalid license!"
    }
}
```

```python
    python hacarus_visual_inspection.errors.APIError: Invalid license! (403)
```

> *t(:error403)* t(:licenseExists)

```csharp
{
    "errors": {
        "detail": "License already exists",
        "source": {
            "pointer": "/api/auth/license"
        },
        "status": 403,
        "title": "Invalid license!"
    }
}
```

```python
    python hacarus_visual_inspection.errors.APIError: License already exists! (403)
```

## t(:getVersionNumber)

```csharp
VersionResponse Response = VisualInspection.GetVersionNumber();
```

```python
sdk.get_version_number()
```
t(:getVersionNumberMessage)

> **t(:sampleResponse)**

```json
{
    "data": "1.0.0.0"
}
```

## t(:getItems)

```csharp
ItemsResponse Response = VisualInspection.GetItems();
```

```python
sdk.get_items()
```

<div class="hacarus-content-list lang-specific csharp">
t(:getItemsMessage, true: 'true', false: 'false', null: 'null')
</div>
<div class="hacarus-content-list lang-specific python">
t(:getItemsMessage, true: 'True', false: 'False', null: 'None')
</div>

> **t(:sampleResponse)**

```json
{
    "archived": [],
    "predict": [],
    "summary": {
        "adjusted": 0,
        "analysed": 0,
        "archived_defects": 0,
        "assessment": "Bad Product",
        "confirmed": 0,
        "defects_detected": 0,
        "detection_accuracy": 0,
        "items_archived": 0,
        "items_for_review": 0,
        "title": "Context #1",
        "training": {
            "defect": 0,
            "good": 1
        }
    },
    "training": [
        {
        "assessment": null,
        "confirmed_assessment": true,
        "date": "Mon, 10 Jun 2019 08:22:02 GMT",
        "default_image": "https://hacarus-saas-data.s3.amazonaws.com/raw/b21d2...",
        "description": null,
        "detected_objects": 0,
        "finished_date": null,
        "good": true,
        "is_training_data": true,
        "item_id": "T1-22-01",
        "label": "Job id is T1-22-01",
        "override_assessment": true,
        "status": "pending",
        "thumbnail_image": "https://hacarus-saas-data.s3.amazonaws.com/thumbnail/b21d2..."
        }
    ]
}
```

## t(:getAlgorithms)

```csharp
AlgorithmResponse Response = VisualInspection.GetAlgorithms();
```

```python
sdk.get_algorithms()
```

t(:getAlgorithmsMessage)

> **t(:sampleResponse)**

```json
[
    {
        "algorithm_id": "OC",
        "name": "OC",
        "parameters": [
            {
                "algorithm_parameter_id": 252,
                "created_at": "2019-06-06T23:29:17Z",
                "data_type": "float",
                "model_parameter": true,
                "name": "nu_max",
                "updated_at": "2019-06-07T00:10:09Z",
                "value": "0.1"
            },
            {
                "algorithm_parameter_id": 249,
                "created_at": "2019-06-06T23:29:17Z",
                "data_type": "tuple",
                "model_parameter": true,
                "name": "patch_size",
                "updated_at": "2019-06-06T23:30:20Z",
                "value": "[4, 4]"
            }
        ]
    }
]
```

> **t(:possibleError)**
  <br/>
> *t(:error404)* t(:noAlgorithm)

```csharp
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/v1/algorithms"
        },
        "status": 404,
        "title": "No algorithms found"
    }
}
```

## t(:getModels)

```csharp
ModelsResponse Response = VisualInspection.GetModels();
```

```python
sdk.get_models()
```

<div class="hacarus-content-list lang-specific csharp">
t(:getModelsMessage, serve: 'Serve', true: 'true')
</div>

<div class="hacarus-content-list lang-specific python">
t(:getModelsMessage, serve: 'serve', true: 'True')
</div>

 > **t(:sampleResponse)**

 ```json
 [
    {
        "active": true,
        "algorithm_id": "OC",
        "context_default": false,
        "created_at": "2019-06-10T08:28:16Z",
        "model_id": 269,
        "name": "Test-20190610-01",
        "status": "active",
        "version": "model-2019061008:28:16"
    }
]
```

## t(:deleteModels)

```csharp
//Use ModelIds to pass an array of model ids you want to delete
PredictResponse Response = VisualInspection.DeleteModels(ModelIds);
```

```python
# Use model_ids to pass an array of model ids you want to delete
response = sdk.delete_models(model_ids)
```

<div class="hacarus-content-list lang-specific csharp">
t(:deleteModelsMessage, getModels: 'GetModels')
</div>

<div class="hacarus-content-list lang-specific python">
t(:deleteModelsMessage, getModels: 'get_models')
</div>

> **t(:sampleResponse)**

```json
{
    "status": "ok"
}
```

> **t(:possibleErrors)**
<br/>
> *t(:error404)* t(:modelDoesNotExist)

```csharp
{
    "errors": {
        "detail": "No model found",
        "source": {
            "pointer": "/api/v1/model?"
        },
        "status": 404,
        "title": ""
    }
}
```

```python
hacarus_visual_inspection.errors.APIError: Cannot find models (404)
```

## t(:train)

```csharp
//ID of the algorithm you want to use
var AlgorithmId = "OC";
//Name of your model
var ModelName = "ModelName";
//Array of of item ids to use for training the model
var ItemIds = new string[] { "ItemId" };
//Algorithm parameter you want to adjust and use for training the model
AlgorithmParameter AlgorithmParameter = new AlgorithmParameter();
algorithmParameter.AlgorithmParameterId = 221;
algorithmParameter.Value = "50";

ModelResponse Reponse = VisualInspection.Train(AlgorithmId, ModelName, ItemIds, new AlgorithmParameter[] { AlgorithmParameter });
```

```python
#ID of the algorithm you want to use
algorithm_id = "hacarus-dictionary-learning";
#N ame of your model
model_name = "ModelName";
# List of of item ids to use for training the model
item_ids = ["ItemId"]
#Algorithm parameter you want to adjust and use for training the model
algo_param = [{
    "algorithm_parameter_id": 221,
    "value": "50"
}]

model = sdk.train(algorithm_id, model_name, algo_param, item_ids)
```

<div class="hacarus-content-list lang-specific csharp">
t(:trainMessage, algorithmParameter: 'AlgorithmParameter', getModels: "GetModels")
</div>

<div class="hacarus-content-list lang-specific python">
t(:trainMessage, algorithmParameter: 'algo_param', getModels: "get_models")
</div>

> **t(:sampleResponse)**

```json
{
    "active": false,
    "algorithm_id": "OC",
    "context_default": false,
    "context_id": 1000,
    "created_at": "2019-06-11T01:26:08Z",
    "model_id": 270,
    "name": "6/11/19 10:26:07 AM",
    "status": "creating",
    "updated_at": "2019-06-11T10:26:07Z",
    "version": "model-2019061101:26:07"
}
  ```

> **t(:possibleError)** <br/>
> *t(:error403)*</b> t(:invalidId)

```csharp
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/v1/train"
        },
        "status": 403,
        "title": "You do not have access to one or more item ids provided"
    }
}
```

```python
hacarus_visual_inspection.errors.APIError: You do not have access to one or more item ids provided (403)
```

## t(:addItem)

```csharp
//For training
UploadResponse Response = VisualInspection.Upload(Files, IsGood);
```

```python
# For training
filenames = ['images1.tif', 'tests/images2.tif']
is_good = True
sdk.upload(filenames, is_good)
```

<div class="hacarus-content-list lang-specific csharp">
t(:addItemMessage, isGood: 'IsGood', true: 'true', false: 'false')
</div>

<div class="hacarus-content-list lang-specific python">
t(:addItemMessage, isGood: 'is_good', true: 'True', false: 'False')
</div>

```csharp
//For prediction
UploadResponse Response = VisualInspection.Upload(Files);
```

```python
# For prediction
sdk.upload(filenames)
```

<div class="hacarus-content-list lang-specific csharp">
t(:addItemMessageMoreCSharp)
</div>
<div class="hacarus-content-list lang-specific python">
t(:addItemMessageMorePython)
</div>

> **t(:sampleResponse)**

```json
{
    "item_ids": [
        "IMG6760_U"
    ]
}
```

> **t(:possibleErrors)**
<br/>
> *t(:error400)* t(:invalidFile)

```csharp
{
    "errors": {
        "detail": [
            "Invalid filename 2019-05-24 at 3.27.11 PM.png"
        ],
        "source": {
            "pointer": "/api/v1/upload"
        },
        "status": 400,
        "title": "Invalid Request"
    }
}
```

```python
hacarus_visual_inspection.errors.APIError: Invalid filename 2019-05-24 at 3.27.11 PM.png (400)
```

> *t(:error400)*</b> t(:noImage)

```csharp
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/v1/upload"
        },
        "status": 400,
        "title":  "No images to upload"
    }
}
```

```python
hacarus_visual_inspection.errors.APIError: No images to upload (400)
```

## t(:setAnnotations)

```csharp
//Set integer values for YMin, XMax, YMin, YMax
Annotation NewAnnotation = new Annotation(YMin, XMax, YMin, YMax, Notes);
UploadResponse Response = VisualInspection.SetAnnotations(new Annotation[] { NewAnnotation }, ImageId);
```

```python
filenames = ['images1.tif', 'tests/images2.tif']
is_good = True
sdk.set_annotations(annotations, image_id)
```

<div class="hacarus-content-list lang-specific csharp">
t(:setAnnotationsMessage)
</div>

<div class="hacarus-content-list lang-specific python">
t(:setAnnotationsMessage)
</div>

> **t(:sampleResponse)**

```json
{
    "item_ids": [
        "IMG6760_U"
    ]
}
```

> **t(:possibleErrors)**
> *t(:error400)*</b> t(:imageIdDoesNotExist)

```csharp
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/v1/image/10/annotation?"
        },
        "status": 404,
        "title": "Cannot find image"
    }
}
```

```python
hacarus_visual_inspection.errors.APIError: Cannot find image (404)
```

## t(:getItem)

```csharp
//Set a specific ItemId to get detailed information about the item
ItemResponse Response = VisualInspection.GetItem("ItemId");
```

```python
#Set a specific ItemId to get detailed information about the item
item = sdk.get_item("ItemId");
```

<div class="hacarus-content-list lang-specific csharp">
t(:getItemMessage, serve: 'Serve')
</div>

<div class="hacarus-content-list lang-specific python">
t(:getItemMessage, serve: 'serve')
</div>

> **t(:sampleResponse)**

```json
{
    "computed_assessment": {
        "assessment_result": "[OC] Defected product",
        "detected_objects": 2,
        "detection_accuracy": 100,
        "good": false
    },
    "confirmed_assessment": true,
    "images": [
        {
            "annotations": [
                {
                    "annotation_id": 8269,
                    "created_at": "2019-06-11T05:47:00Z",
                    "image_id": 1805,
                    "notes": null,
                    "x_max": 620,
                    "x_min": 606,
                    "y_max": 2322,
                    "y_min": 2284
                },
                {
                    "annotation_id": 8270,
                    "created_at": "2019-06-11T05:47:00Z",
                    "image_id": 1805,
                    "notes": null,
                    "x_max": 2082,
                    "x_min": 2064,
                    "y_max": 1722,
                    "y_min": 1702
                }
            ],
            "content_type": "image/jpeg",
            "defect_counted": 70,
            "exif_metadata": {},
            "file_size": 1524794,
            "height": 3024,
            "image_id": 1805,
            "is_raw_uploaded": true,
            "position": null,
            "processed": true,
            "raw_url": "https://hacarus-saas-data.s3.amazonaws.com/raw/d9b6b9709b29d4deb30be4e981031f09823120c7",
            "url": "https://hacarus-saas-data.s3.amazonaws.com/processed/d9b6b9709b29d4deb30be4e981031f09823120c7",
            "width": 4032
        }
    ],
    "is_training_data": false,
    "item_id": "IMG6760_U",
    "label": "Job id is IMG6760_U",
    "manual_assessment": {
        "assessment_result": null,
        "detected_objects": null,
        "detection_accuracy": null,
        "good": null,
        "override_assessment": false
    },
    "status": "done"
}
```

> **t(:possibleErrors)**
  <br/>
> *t(:error404)* t(:itemIdDoesNotExists)

```csharp
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/v1/item/invaliditemidexample"
        },
        "status": 404,
        "title": "No match for item_id!"
    }
}
```

```python
hacarus_visual_inspection.errors.APIError: No match for item_id! (404)
```

> *t(:error401)* t(:doesNotBelongToClient)

```csharp
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/v1/item/sdsd"
        },
        "status": 401,
        "title": "No permission to view item!"
    }
}
```

```python
hacarus_visual_inspection.errors.APIError: No permission to view item! (401)
```

## t(:predict)

```csharp
//Use ItemIds to pass an array of item ids you want to set for prediction
//You may use a specific model for prediction by setting a ModelId value. This is optional. If not set, the active/default model will be used.
PredictResponse Response = VisualInspection.Serve(ItemIds, "ModelId");
```

```python
# Use item_ids to pass a list of item ids you want to set for prediction
# You may use a specific model for prediction by setting a model_id value. This is optional. If not set, the active/default model will be used.
response = sdk.serve(item_ids, "model_id")
```

<div class="hacarus-content-list lang-specific csharp">
t(:predictMessage, getItems: 'GetItems')
</div>

<div class="hacarus-content-list lang-specific python">
t(:predictMessage, getItems: 'get_items')
</div>

> **t(:sampleResponse)**

```json
{
    "item_ids": [
        "IMG6760_U"
    ],
    "model_version": "model-2019061101:26:07"
}
```

> **t(:possibleErrors)**
<br/>
> *t(:error404)* t(:itemDoesNotExists)

```csharp
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/v1/serve"
        },
        "status": 404,
        "title": "Cannot find items"
    }
}
```

```python
hacarus_visual_inspection.errors.APIError: Cannot find items (404)
```

> *t(:error400)* t(:noModel)

```csharp
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/v1/serve"
        },
        "status": 400,
        "title": "There is no available model"
    }
}
```
```python
hacarus_visual_inspection.errors.APIError: There is no available model (400)
```

## t(:getProcesses)

```csharp
PredictResponse Response = VisualInspection.GetProcesses();
```

```python
response = sdk.get_processes(item_ids, "model_id")
```

<div class="hacarus-content-list lang-specific csharp">
t(:getProcessesMessage)
</div>

<div class="hacarus-content-list lang-specific python">
t(:getProcessesMessage)
</div>

> **t(:sampleResponse)**

```json
{
    "predicting": ["predicting_model"],
    "training": ["training_algorithm"]
}
```


#t(:algorithmsWithVersion)

##t(:algorithmOverview)
  - t(:algorithmOverview1)
    - t(:algorithmOverview1a)
      - t(:algorithmOverview1ai)
      - t(:algorithmOverview1aii)
    - t(:algorithmOverview1b)
      - t(:algorithmOverview1bi)
      - t(:algorithmOverview1bii)
    - t(:algorithmOverview2)
      - t(:algorithmOverview2i)

##t(:algorithmDetails)

###t(:descriptionOfParameters)
  - t(:descriptionOfParametersText1)
  - t(:descriptionOfParametersText2)
  - t(:descriptionOfParametersText3)
  - t(:descriptionOfParametersText4)

###t(:algo1ai)
t(:algo1aiText)
t(:algo1aiTable)

###t(:algo1aii)
t(:algo1aiiText)
t(:algo1aiiTable)

###t(:algo1bi)
t(:algo1biText)
t(:algo1biTable)


###t(:algo1bii)
t(:algo1biiText)
t(:algo1biiTable)

###t(:algo2i)
t(:algo2iText)
t(:algo2iTable)
