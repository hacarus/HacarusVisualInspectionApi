Visual Inspection Api for C#
===
*[English](README.md) | [日本語](README.ja.md)*

Hacarus is a provider of lightweight and explainable AI solutions for manufacturing and medical industries. 

Our technology is based on Sparse Modeling, a Machine Learning technique that understands data like a human would - by its unique key features. Sparse Modeling is especially useful in resource constraint environments where computing power, cloud connection and availability of training data are limited – thanks to its lightweight design. 

Our solutions can run in an offline environment on embedded systems or as a cloud module. Compared with conventional DL based approaches we are far more resource efficient and produce better results. 

Visit https://hacarus.com/visual-inspection/ to learn more about Hacarus’ Visual Inspection solution or [contact us](https://hacarus.com/contact/) to request access to our API.

This Visual Inspection Api wrapper for C#  is made for software engineers who want to integrate with the Hacarus Visual Inspection module through its API. The wrapper provides simple to use method calls for easy integration to your C# based applications. Supports .Net Framework 4.6.1 and .Net Core 2.0.

- [Installation](#Installation)
- [Terms](#Terms)
- [Usage](#Usage)
  * [1. Initialization](#1-Initialization)
  * [2. Authorize](#2-Authorize)
  * [3. Activate License](#3-Activate-License)
  * [4. Get Items](#4-Get-Items)
  * [5. Get Algorithms](#5-Get-Algorithms)
  * [6. Get Models](#6-Get-Models)
  * [7. Train](#7-Train)
  * [8. Add Item](#8-Add-Item)
  * [9. Get Specific Item](#9-Get-Specific-Item)
  * [10. Predict](#10-Predict)
- [Generic Error](#Generic-Error)

## Installation
To install this package on your project, use this command in Package Manager Console.

```
PM> Install-Package HacarusVisualInspectionApi -Version 1.0.0-beta
```

You can also add it on your project by using "Add packages", check on the `Show prerelease packages`, and search for `HacarusVisualInspectionApi` on the nuget.org repository.

Other installation options can be found on [Nuget Package Site](https://www.nuget.org/packages/HacarusVisualInspectionApi/1.0.0-beta).

## Terms
A brief explanation of the terms used throughout this documentation:

**Model**
A model is created (or trained) by applying an algorithm to a data-set of items (also called training-data), along with the configuration of a set of parameters.
After creation, the model can be used to analyze new data.

**Algorithm**
The machine learning code that is used to build a model – selected depending on the nature of the visual inspection task and the expected precision and performance.

**Training**
The process of creating a new model.

**Parameter**
Parameters are used to configure how an algorithm should be applied during the training. For example the minimal or maximum accepted image resolution, etc.

**Item**
An item represents the data of a single product that is the subject of the inspection. One item can have one or several images associated.
For example: A packaging box in a storage warehouse, with 6 images for each of the 6 box sides.


## Usage

To get started, you need the following:
- Client ID and Client Secret
    - These will be used to authorize the SDK.
    - An authorized user will be able to access the system's functions, such as adding items, getting list of items, algorithms, and models.
    - To be able to train models and to use the predict function, you also need an active license.
- License File and Customer ID
    - These will be used to activate your license.
- Training Images
    - A prerequisite to creating a new model, is to provide training items by uploading images.
    - Use training items to create a model.
    - Add items for prediction by uploading images.
    - Use the created model to predict the items for prediction.
    - Sample images for evaluation are available for download here: [Metal Plates](https://drive.google.com/file/d/1Zg-gCX9gxxYjEau9j29oe0hDBuppDosh/view) and [Wood Blocks](https://drive.google.com/file/d/1oRvEfeDfa3seEn0rFXRa1IgTUyzg0hxv/view)
        - Contains good and defect images and a list of parameters you may use to create a model. 
        - Images for training are located in a folder `train`, images for prediction are in `predict`
        - NG means defect image, OK means good images



#### 1. Initialization

```csharp
using HacarusVisualInspectionApi;
using HacarusVisualInspectionApi.Models;
HacarusVisualInspection VisualInspection = new HacarusVisualInspection("https://yourserverurl.com/api");
```

- Initializes the library
- Use your endpoint URL as parameter
- If no endpoint is used, the library will use the default endpoint https://sdd.hacarus.com/api
- INDIVIDUAL endpoint URL will be provided by Hacarus on request

#### 2. Authorize

```csharp
AccessTokenResponse Response = VisualInspection.Authorize("YourClientId", "YourClientSecret");
```

 - Generates access token
 - Use your Client ID and Client Secret as parameters
 - Client ID and Client Secret will be provided by Hacarus on request

##### Sample Response

```json
{
    "data": {
        "access_token": "GeneratedAccessToken",
        "expires": 2592000
    }
}
```

##### Possible errors

- `401 Unauthorized`: Client ID is invalid

```json
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

- `401 Unauthorized`: Client secret is invalid

```json
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

#### 3. Activate License

```csharp
var LicenseFile = new FileModel("PathToFile", "ContentType");
UploadResponse Response = VisualInspection.ActivateLicense(LicenseFile, "CustomerId");
```

- Activates the license
- Customer ID and license file must be added as parameters
- License must be activated first before the user can use the  `Train` or `Predict` functions
- To have a license file, please contact Hacarus


##### Sample Response
```json
{
    "data": {
        "customer_id": "CustomerId",
        "status": "ok"
    }
}
```

#### Possible errors
- `403 Forbidden`: Customer ID or license file is invalid  
```json
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

- `403 Forbidden`: License is already active
```json
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

#### 4. Get Items

```csharp
ItemsResponse Response = VisualInspection.GetItems();
```

- Retrieves list of uploaded items grouped by training, predict, and archived
    - `training`: Items to be used for training
        - Check for key `good` to know if item is labeled as `true`(good), `false`(defect) or `null` (unlabeled)
    - `predict`: Uploaded items that can be predicted
        - To check for labels and results, check for the keys `good` and `status`
    - `archived`: Achived items (Future feature, currently not in use)
- `override_assessment` and `confirmed_assessment` are specific to UI and can be ignored when working with the SDK


##### Sample Response

```json
{
    "data": {
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
            "default_image": "https://hacarus-saas-data.s3.amazonaws.com/raw/b21d29f794e781e12f466a1fcc1bf1a1596e5320a",
            "description": null,
            "detected_objects": 0,
            "finished_date": null,
            "good": true,
            "is_training_data": true,
            "item_id": "T1-22-01",
            "label": "Job id is T1-22-01",
            "override_assessment": true,
            "status": "pending",
            "thumbnail_image": "https://hacarus-saas-data.s3.amazonaws.com/thumbnail/b21d29f794e781e12f466a1fcc1bf1a1596e5320a"
            }
        ]
    }
}
```
    
#### 5. Get Algorithms

```csharp
AlgorithmResponse Response = VisualInspection.GetAlgorithms();
```

- Returns list of available algorithms including parameters that can be used to create a model

##### Sample Response

```json
{
    "data": [
        {
            "algorithm_id": "one-class-svm",
            "name": "Patch One Class SVM",
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
}
```


##### Possible error

- `404 NotFound`: No available algorithm. Please contact Hacarus if this problem occurs

```json
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
    
#### 6. Get Models

```csharp
ModelsResponse Response = VisualInspection.GetModels();
```

- Gets list of created models that can be used to predict items
- The key `active` means that if an item is predicted (using `Serve` method) without passing a model id, the model with `active` valued `true` will be used as default
- The key `status` shows if a model is `active` or `failed.` 
    - Models with `status: "active"` are successfully created and can be used for prediction
    - Models with `status: "failed"` are not successfully created and cannot be used for prediction

##### Sample Response

```json
{
    "data": [
        {
            "active": true,
            "algorithm_id": "one-class-svm",
            "context_default": false,
            "created_at": "2019-06-10T08:28:16Z",
            "model_id": 269,
            "name": "Test-20190610-01",
            "status": "active",
            "version": "model-2019061008:28:16"
        }
    ]
}
```
    
#### 7. Train

```csharp
//ID of the algorithm you want to use
var AlgorithmId = "hacarus-dictionary-learning";
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

- Creates model to use for prediction
- Accepts an optional parameter that contains array of item ids that will be used for training the model
- Accepts an optional parameter that contains array of AlgorithmParameter for adjusting the algorithm settings
- To check the newly created model, use `GetModels()` method
    

##### Sample Response

```json
{
    "data": {
        "active": false,
        "algorithm_id": "one-class-svm",
        "context_default": false,
        "context_id": 1000,
        "created_at": "2019-06-11T01:26:08Z",
        "model_id": 270,
        "name": "6/11/19 10:26:07 AM",
        "status": "creating",
        "updated_at": "2019-06-11T10:26:07Z",
        "version": "model-2019061101:26:07"
    }
}
```

##### Possible error

- `403 Forbidden`: Atleast one item id does not belong to the client, is invalid or does not exist.

```json
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

#### 8. Add Item

```csharp
UploadResponse Response = VisualInspection.Upload(Files, IsGood);
```
- Use this method to upload and label items for training
- To label items as good or defect, set `IsGood` parameter to a boolean value `true`(good) or `false`(defect)

```csharp
UploadResponse Response = VisualInspection.Upload(Files);
```
- Use this method to upload items for prediction
- Use `Files` parameter to pass an array of `FileModel`. `FileModel` have properties `FileName` and `ContentType`.
- To create a FileModel, use `FileModel File = new FileModel()` or `FileModel File = new FileModel("FileName", "ContentType")`
- To check the uploaded item, use the `GetItems()` method
- The filename of the image will be used as the `item_id` of the item
- Supported file types: `png`, `jpeg`, `tiff`


##### Sample Response

```json
{
    "data": {
        "item_ids": [
            "IMG6760_U"
        ]
    }
}
```

##### Possible errors

- `400 BadRequest`: Invalid file name or file type

```json
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

- `400 BadRequest`: No image sent for upload

```json
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
        
#### 9. Get Specific Item

```csharp
//Set a specific ItemId to get detailed information about the item
ItemResponse Response = VisualInspection.GetItem("ItemId");
```

- Get details of a specific item identified by its item ID 
- The item ID is assigned during upload and based on the image file name
- Important keys:
    - `computed_assessment`: result of the prediction
    - `annotations`: contains list of annotations generated when `Serve` method is called
    - `raw_url`: url of your uploaded file
    - `url`: processed file with defect annotations (green boxes)
    - `status`: status of the item. It can be `pending`(not yet predicted or being predicted) or `done`(predicted)

##### Sample Response

```json
{
    "data": {
        "computed_assessment": {
            "assessment_result": "[PatchOneClassSVMDetector] Defected product",
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
}
```

##### Possible errors

- `404 NotFound`: Item id does not exist

```json
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

- `401 Unauthorized`: Item with the given item id does not belong to the client

```json
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

#### 10. Predict

```csharp
//Use ItemIds to pass an array of item ids you want to set for prediction
//You may use a specific model for prediction by setting a ModelId value. This is optional. If not set, the active/default model will be used.
PredictResponse Response = VisualInspection.Serve(ItemIds, "ModelId");
```

- Predicts if items are good or defect
- To check the result, use the `GetItems()` method and check for key `good` of each item

##### Sample Response
```json
{
    "data": {
        "item_ids": [
            "IMG6760_U"
        ],
        "model_version": "model-2019061101:26:07"
    }    
}
```

##### Possible errors

- `404 NotFound`: Item with item id sent does not exist

```json
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

- `400 BadRequest`: No model available to use for prediction or available models have `failed` status. Create a new model by using `Train` method.

```json
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

## Generic Error
- Error when calling a method but not yet authorized. When encounted, please call `Authorize` method first.

```json
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/v1/algorithms"
        },
        "status": 401,
        "title": "No permission to access this resource"
    }
}
```

- Error when calling a method but license is not yet activated or expired. When encounted, please call `ActivateLicense` method first.

    ```json
    {
        "errors": {
            "detail": null,
            "source": {
                "pointer": "/api/v1/upload"
            },
            "status": 403,
            "title": "Invalid license!"
        }
    }
    ```
