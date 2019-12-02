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
LoginParams loginParams = new LoginParams(
  clientId: "client id",
  clientSecret: "client secret",
  grantType: "client_credentials"
);
var resp = instance.Login(loginParams);

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

## t(:getVersionNumber)

<a id="opIdget_version"></a>

> Code samples

```csharp
var Version = instance.GetVersion();

```

`GET /auth/app_version`

<div class='hacarus-content-list'>t(:getVersionNumberMessage)</div>

> Example responses

> 200 Response

```json
{
  "data": "data"
}
```

<h3 id="t-getVersionNumber-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|The app version|[GetVersionResponse](#schemagetversionresponse)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

## t(:getAlgorithms)

<a id="opIdget_algorithms"></a>

> Code samples

```csharp
var Algorithms = instance.GetAlgorithms();

```

`GET /v1/algorithms`

<div class='hacarus-content-list'>t(:getAlgorithmsMessage)</div>

> Example responses

> 200 Response

```json
{
  "data": [
    {
      "name": "name",
      "algorithm_id": "algorithm_id",
      "parameters": [
        null,
        null
      ]
    },
    {
      "name": "name",
      "algorithm_id": "algorithm_id",
      "parameters": [
        null,
        null
      ]
    }
  ]
}
```

<h3 id="t-getAlgorithms-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successful get of algorithms|[GetAlgorithmResponse](#schemagetalgorithmresponse)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

## t(:getItems)

<a id="opIdget_items"></a>

> Code samples

```csharp
var Items = instance.GetItems();

```

`GET /v1/items`

<div class='hacarus-content-list'>t(:getItemsMessage, true: 'true', false: 'false', null: 'null')</div>

> Example responses

> 200 Response

```json
{
  "data": {
    "summary": {
      "predict_stats": [
        {
          "NG_count": 1,
          "done_count": 6,
          "confirmed_count": 9,
          "accuracy": 5.025004791520295,
          "adjusted_count": 9,
          "model_id": "model_id",
          "OK_count": 4
        },
        {
          "NG_count": 1,
          "done_count": 6,
          "confirmed_count": 9,
          "accuracy": 5.025004791520295,
          "adjusted_count": 9,
          "model_id": "model_id",
          "OK_count": 4
        }
      ],
      "training_stats": {
        "NG_count": 6,
        "OK_count": 7
      },
      "title": "title"
    },
    "predict": [
      {
        "models": [
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          },
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          }
        ],
        "images": [
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          },
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          }
        ],
        "item_id": "item_id",
        "name": "name",
        "active": true,
        "description": "description",
        "default_image": "default_image",
        "is_training_data": true,
        "override": {
          "result": "result",
          "detection_accuracy": 6,
          "label": "label",
          "detected_objects": 0
        },
        "thumbnail_image": "thumbnail_image",
        "status": "done"
      },
      {
        "models": [
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          },
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          }
        ],
        "images": [
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          },
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          }
        ],
        "item_id": "item_id",
        "name": "name",
        "active": true,
        "description": "description",
        "default_image": "default_image",
        "is_training_data": true,
        "override": {
          "result": "result",
          "detection_accuracy": 6,
          "label": "label",
          "detected_objects": 0
        },
        "thumbnail_image": "thumbnail_image",
        "status": "done"
      }
    ],
    "training": [
      {
        "models": [
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          },
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          }
        ],
        "images": [
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          },
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          }
        ],
        "item_id": "item_id",
        "name": "name",
        "active": true,
        "description": "description",
        "default_image": "default_image",
        "is_training_data": true,
        "override": {
          "result": "result",
          "detection_accuracy": 6,
          "label": "label",
          "detected_objects": 0
        },
        "thumbnail_image": "thumbnail_image",
        "status": "done"
      },
      {
        "models": [
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          },
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          }
        ],
        "images": [
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          },
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          }
        ],
        "item_id": "item_id",
        "name": "name",
        "active": true,
        "description": "description",
        "default_image": "default_image",
        "is_training_data": true,
        "override": {
          "result": "result",
          "detection_accuracy": 6,
          "label": "label",
          "detected_objects": 0
        },
        "thumbnail_image": "thumbnail_image",
        "status": "done"
      }
    ]
  }
}
```

<h3 id="t-getItems-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|A list of items|[GetItemsResponse](#schemagetitemsresponse)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

## t(:getItem)

<a id="opIdget_item"></a>

> Code samples

```csharp
var Item = instance.GetItem("Some Item Id");

```

`GET /v1/item/{item_id}`

<div class='hacarus-content-list'>t(:getItemMessage, serve: 'Serve')</div>

<h3 id="t-getitem-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|item_id|path|string|true|none|
|show_annotations|query|boolean|false|Return annotations|
|show_assessments|query|boolean|false|Return annotations|

> Example responses

> 200 Response

```json
{
  "data": {
    "models": [
      {
        "assessments": [
          {
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 4,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "confirmed": true,
            "file_size": 1,
            "content_type": "content_type",
            "width": 1,
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_id": 7,
            "height": 1
          },
          {
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 4,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "confirmed": true,
            "file_size": 1,
            "content_type": "content_type",
            "width": 1,
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_id": 7,
            "height": 1
          }
        ],
        "model_id": "model_id",
        "aggregate": {
          "label": "label",
          "detected_objects": 2.027123023002322
        }
      },
      {
        "assessments": [
          {
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 4,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "confirmed": true,
            "file_size": 1,
            "content_type": "content_type",
            "width": 1,
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_id": 7,
            "height": 1
          },
          {
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 4,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "confirmed": true,
            "file_size": 1,
            "content_type": "content_type",
            "width": 1,
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_id": 7,
            "height": 1
          }
        ],
        "model_id": "model_id",
        "aggregate": {
          "label": "label",
          "detected_objects": 2.027123023002322
        }
      }
    ],
    "images": [
      {
        "exif_metadata": {
          "key": "{}"
        },
        "defect_counted": 1,
        "processed_url": "processed_url",
        "is_raw_uploaded": true,
        "annotations": [
          null,
          null
        ],
        "file_size": 5,
        "processed": true,
        "content_type": "content_type",
        "width": 7,
        "model_results": [
          {
            "result": "result",
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_key": "image_key",
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "detection_accuracy": 3,
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "label": "OK",
            "model_id": "model_id",
            "confirmed": true,
            "detected_objects": 9
          },
          {
            "result": "result",
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_key": "image_key",
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "detection_accuracy": 3,
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "label": "OK",
            "model_id": "model_id",
            "confirmed": true,
            "detected_objects": 9
          }
        ],
        "position": "position",
        "image_id": 2,
        "raw_url": "raw_url",
        "height": 5
      },
      {
        "exif_metadata": {
          "key": "{}"
        },
        "defect_counted": 1,
        "processed_url": "processed_url",
        "is_raw_uploaded": true,
        "annotations": [
          null,
          null
        ],
        "file_size": 5,
        "processed": true,
        "content_type": "content_type",
        "width": 7,
        "model_results": [
          {
            "result": "result",
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_key": "image_key",
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "detection_accuracy": 3,
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "label": "OK",
            "model_id": "model_id",
            "confirmed": true,
            "detected_objects": 9
          },
          {
            "result": "result",
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_key": "image_key",
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "detection_accuracy": 3,
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "label": "OK",
            "model_id": "model_id",
            "confirmed": true,
            "detected_objects": 9
          }
        ],
        "position": "position",
        "image_id": 2,
        "raw_url": "raw_url",
        "height": 5
      }
    ],
    "item_id": "item_id",
    "name": "name",
    "active": true,
    "description": "description",
    "default_image": "default_image",
    "is_training_data": true,
    "override": {
      "result": "result",
      "detection_accuracy": 6,
      "label": "label",
      "detected_objects": 0
    },
    "thumbnail_image": "thumbnail_image",
    "status": "done"
  }
}
```

<h3 id="t-getItem-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|An item|[GetItemResponse](#schemagetitemresponse)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

## t(:addItem)

<a id="opIdupload_item"></a>

> Code samples

```python
import requests
headers = {
  'Content-Type': 'multipart/form-data',
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('https://spectro-deom.hacarus.com/api/v1/upload', headers = headers)

print r.json()

```

`POST /v1/upload`

<div class='hacarus-content-list'>t(:addItemMessage, isGood: 'IsGood', true: 'true', false: 'false')</div> <div class='hacarus-content-list lang-specific csharp'>
t(:addItemMessageMoreCSharp)
</div>
<div class='hacarus-content-list lang-specific python'>
t(:addItemMessageMorePython)
</div>

> Body parameter

```yaml
training: true
good: true
model_id: string
files:
  - string

```

<h3 id="t-additem-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[UploadRequest](#schemauploadrequest)|false|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "item_ids": [
      "item_ids",
      "item_ids"
    ]
  }
}
```

<h3 id="t-addItem-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successful upload|[UploadResponse](#schemauploadresponse)|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|default error handler|[BaseError](#schemabaseerror)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

## t(:train)

<a id="opIdtrain"></a>

> Code samples

```csharp
var TrainIds = new List<String> { "<some item id>" };
TrainParams prms = new TrainParams(
  algorithmId: "some algorithm id",
  itemIds: TrainIds,
  name: "name of model"
);

var resp = instance.Train(prms);

```

`POST /v1/train`

<div class='hacarus-content-list'>t(:trainMessage, algorithmParameter: 'AlgorithmParameter', getModels: 'GetModels')</div>

> Body parameter

```json
{
  "override_params": [
    {
      "algorithm_parameter_id": 0,
      "value": "value"
    },
    {
      "algorithm_parameter_id": 0,
      "value": "value"
    }
  ],
  "name": "name",
  "item_ids": [
    "item_ids",
    "item_ids"
  ],
  "algorithm_id": "algorithm_id"
}
```

<h3 id="t-train-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[TrainParams](#schematrainparams)|true|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "ok_img_count": 1,
    "image_url": "image_url",
    "precision": 5.962133916683182,
    "active": true,
    "model_id": "model_id",
    "context_default": true,
    "version": "version",
    "algorithm_type": "algorithm_type",
    "stats": {
      "precision": {
        "projected": 7.061401241503109,
        "computed": 2.3021358869347655
      },
      "recall": {
        "projected": 7.061401241503109,
        "computed": 2.3021358869347655
      }
    },
    "recall": 5.637376656633329,
    "name": "name",
    "context_id": 0,
    "status_text": "status_text",
    "ng_img_count": 6,
    "algorithm_id": "algorithm_id",
    "status": "creating"
  }
}
```

<h3 id="t-train-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successful login|[TrainResponse](#schematrainresponse)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

## t(:getModels)

<a id="opIdget_models"></a>

> Code samples

```csharp
var Models = instance.GetModels();
//or
var Models = instance.GetModels("<some algorithm id>");

```

`GET /v1/models`

<div class='hacarus-content-list'>t(:getModelsMessage, serve: 'Serve', true: 'true')</div>

<h3 id="t-getmodels-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|algorithm_id|query|string|false|Filter by algorithm id|

> Example responses

> 200 Response

```json
{
  "data": [
    {
      "ok_img_count": 1,
      "image_url": "image_url",
      "precision": 5.962133916683182,
      "active": true,
      "model_id": "model_id",
      "context_default": true,
      "version": "version",
      "algorithm_type": "algorithm_type",
      "stats": {
        "precision": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        },
        "recall": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        }
      },
      "recall": 5.637376656633329,
      "name": "name",
      "context_id": 0,
      "status_text": "status_text",
      "ng_img_count": 6,
      "algorithm_id": "algorithm_id",
      "status": "creating"
    },
    {
      "ok_img_count": 1,
      "image_url": "image_url",
      "precision": 5.962133916683182,
      "active": true,
      "model_id": "model_id",
      "context_default": true,
      "version": "version",
      "algorithm_type": "algorithm_type",
      "stats": {
        "precision": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        },
        "recall": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        }
      },
      "recall": 5.637376656633329,
      "name": "name",
      "context_id": 0,
      "status_text": "status_text",
      "ng_img_count": 6,
      "algorithm_id": "algorithm_id",
      "status": "creating"
    }
  ]
}
```

<h3 id="t-getModels-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successful get of models|[GetModelsResponse](#schemagetmodelsresponse)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

## Delete Models

<a id="opIddelete_models"></a>

> Code samples

```csharp
var ModelIds = new List<String> { "some model id" };
var DeleteParams = new DeleteModelRequest(Annotations);
var resp = instance.DeleteModels(DeleteParams);

```

`DELETE /v1/model`

Deletes models by id sent by user

> Body parameter

```json
{
  "model_ids": [
    "model_ids",
    "model_ids"
  ]
}
```

<h3 id="d-ete-model-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[DeleteModelRequest](#schemadeletemodelrequest)|true|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "status": "status"
  }
}
```

<h3 id="t-ete-model-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successful Model Delete|[StatusOk](#schemastatusok)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

## t(:predict)

<a id="opIdpredict"></a>

> Code samples

```csharp
var PredictIds = new List<String> { "<some item id>" };
PredictParams prms = new PredictParams(
  modelId: "<some model id>",
  itemIds: PredictIds
);

var resp = instance.Predict(prms);

```

`POST /v1/serve`

<div class='hacarus-content-list'>t(:predictMessage, getItems: 'GetItems')</div>

> Body parameter

```json
{
  "item_ids": [
    "item_ids",
    "item_ids"
  ],
  "model_id": "model_id"
}
```

<h3 id="t-predict-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[PredictParams](#schemapredictparams)|true|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "model_version": "model_version",
    "item_ids": [
      "item_ids",
      "item_ids"
    ]
  }
}
```

<h3 id="t-predict-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successful Prediction|[PredictResponse](#schemapredictresponse)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

## Upload License

<a id="opIdupload_license"></a>

> Code samples

```csharp
using (FileStream fs = File.Open("/some/path/to/license.key", FileMode.Open))
{
  var resp = instance.UploadLicense(fs);
}

```

`POST /v1/license`

Uploads License File

> Body parameter

```yaml
license: string

```

<h3 id="u-oad-licens-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[LicenseRequest](#schemalicenserequest)|true|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "customer_id": "customer_id",
    "status": "status"
  }
}
```

<h3 id="t-oad-licens-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successful upload of license|[LicenseResponse](#schemalicenseresponse)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

## annotate

<a id="opIdannotate"></a>

> Code samples

```csharp
var Annotations = new List<BaseAnnotation> { new BaseAnnotation(
    xMin: 0, xMax: 10, yMin: 0, yMax: 10, notes: "adrian" ) };
var AnnotateParams = new AnnotateParams(Annotations);
var resp = instance.Annotate("1027", AnnotateParams);

```

`POST /v1/image/{image_id}/annotation`

Add annotations to image

> Body parameter

```json
{
  "annotations": [
    {
      "notes": "notes",
      "y_min": 0,
      "x_max": 1,
      "y_max": 1,
      "x_min": 0
    },
    {
      "notes": "notes",
      "y_min": 0,
      "x_max": 1,
      "y_max": 1,
      "x_min": 0
    }
  ]
}
```

<h3 id="a-otat-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|image_id|path|string|true|none|
|body|body|[AnnotateParams](#schemaannotateparams)|true|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "status": "status"
  }
}
```

<h3 id="t-otat-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successful annotation|[StatusOk](#schemastatusok)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

## Export Models

<a id="opIdexport_models"></a>

> Code samples

```csharp
var ModelIds = new List<String> { "some model id" };
var ExportedModels = instance.ExportModels(ModelIds);

using (var fileStream = File.Create("/some/path/to/some.zip"))
{
    ExportedModels.Seek(0, SeekOrigin.Begin);
    ExportedModels.CopyTo(fileStream);
    fileStream.Close();
}

```

`POST /v1/export_models`

Exports models by id sent by user

> Body parameter

```json
{
  "model_ids": [
    "model_ids",
    "model_ids"
  ]
}
```

<h3 id="e-ort-model-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[ExportModelRequest](#schemaexportmodelrequest)|true|none|

> Example responses

> 200 Response

> default Response

```json
{
  "errors": {
    "detail": "string",
    "source": {
      "pointer": "string"
    },
    "status": 0,
    "title": "string"
  }
}
```

<h3 id="t-ort-model-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successful Model Export|string|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

## Import Models

<a id="opIdimport_models"></a>

> Code samples

```csharp
using (FileStream fs = File.Open("/some/path/to/some/models.zip", FileMode.Open))
{
  var resp = instance.ImportModels(fs);
}

```

`POST /v1/import_models`

Import model from zip file

> Body parameter

```yaml
models: string

```

<h3 id="i-ort-model-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[ImportModelRequest](#schemaimportmodelrequest)|true|none|

> Example responses

> 200 Response

```json
{
  "data": [
    {
      "ok_img_count": 1,
      "image_url": "image_url",
      "precision": 5.962133916683182,
      "active": true,
      "model_id": "model_id",
      "context_default": true,
      "version": "version",
      "algorithm_type": "algorithm_type",
      "stats": {
        "precision": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        },
        "recall": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        }
      },
      "recall": 5.637376656633329,
      "name": "name",
      "context_id": 0,
      "status_text": "status_text",
      "ng_img_count": 6,
      "algorithm_id": "algorithm_id",
      "status": "creating"
    },
    {
      "ok_img_count": 1,
      "image_url": "image_url",
      "precision": 5.962133916683182,
      "active": true,
      "model_id": "model_id",
      "context_default": true,
      "version": "version",
      "algorithm_type": "algorithm_type",
      "stats": {
        "precision": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        },
        "recall": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        }
      },
      "recall": 5.637376656633329,
      "name": "name",
      "context_id": 0,
      "status_text": "status_text",
      "ng_img_count": 6,
      "algorithm_id": "algorithm_id",
      "status": "creating"
    }
  ]
}
```

<h3 id="t-ort-model-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successful upload of license|[ImportModelResponse](#schemaimportmodelresponse)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

## Get Workers

<a id="opIdget_workers"></a>

> Code samples

```csharp
var Workers = instance.GetWorkers();

```

`GET /v1/workers`

Returns Pending, Done, and In Progress

> Example responses

> 200 Response

```json
{
  "data": {
    "active_worker_count": 0,
    "in_progress": [
      {
        "queue_time": 1.4658129805029452,
        "result": "result",
        "start_time": 5.962133916683182,
        "end_time": 6.027456183070403,
        "type": "type"
      },
      {
        "queue_time": 1.4658129805029452,
        "result": "result",
        "start_time": 5.962133916683182,
        "end_time": 6.027456183070403,
        "type": "type"
      }
    ],
    "pending": [
      {
        "queue_time": 1.4658129805029452,
        "result": "result",
        "start_time": 5.962133916683182,
        "end_time": 6.027456183070403,
        "type": "type"
      },
      {
        "queue_time": 1.4658129805029452,
        "result": "result",
        "start_time": 5.962133916683182,
        "end_time": 6.027456183070403,
        "type": "type"
      }
    ],
    "done": [
      {
        "queue_time": 1.4658129805029452,
        "result": "result",
        "start_time": 5.962133916683182,
        "end_time": 6.027456183070403,
        "type": "type"
      },
      {
        "queue_time": 1.4658129805029452,
        "result": "result",
        "start_time": 5.962133916683182,
        "end_time": 6.027456183070403,
        "type": "type"
      }
    ]
  }
}
```

<h3 id="t--worker-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|A list of items|[GetWorkersResponse](#schemagetworkersresponse)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
bearerAuth
</aside>

# Schemas

<h2 id="tocS_LoginParams">LoginParams</h2>
<!-- backwards compatibility -->
<a id="schemaloginparams"></a>
<a id="schema_LoginParams"></a>
<a id="tocSloginparams"></a>
<a id="tocsloginparams"></a>

```json
{
  "grant_type": "grant_type",
  "client_secret": "client_secret",
  "client_id": "client_id"
}

```

login parameters

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|client_id|string|true|none|none|
|client_secret|string|true|none|none|
|grant_type|string|true|none|none|

<h2 id="tocS_LoginResponse">LoginResponse</h2>
<!-- backwards compatibility -->
<a id="schemaloginresponse"></a>
<a id="schema_LoginResponse"></a>
<a id="tocSloginresponse"></a>
<a id="tocsloginresponse"></a>

```json
{
  "data": {
    "access_token": "access_token"
  }
}

```

response object of login

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[LoginResponseData](#schemaloginresponsedata)|true|none|access_token data|

<h2 id="tocS_BaseError">BaseError</h2>
<!-- backwards compatibility -->
<a id="schemabaseerror"></a>
<a id="schema_BaseError"></a>
<a id="tocSbaseerror"></a>
<a id="tocsbaseerror"></a>

```json
{
  "errors": {
    "detail": "string",
    "source": {
      "pointer": "string"
    },
    "status": 0,
    "title": "string"
  }
}

```

Error Object

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|errors|[BaseError_errors](#schemabaseerror_errors)|false|none|none|

<h2 id="tocS_GetVersionResponse">GetVersionResponse</h2>
<!-- backwards compatibility -->
<a id="schemagetversionresponse"></a>
<a id="schema_GetVersionResponse"></a>
<a id="tocSgetversionresponse"></a>
<a id="tocsgetversionresponse"></a>

```json
{
  "data": "data"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|string|false|none|none|

<h2 id="tocS_GetAlgorithmResponse">GetAlgorithmResponse</h2>
<!-- backwards compatibility -->
<a id="schemagetalgorithmresponse"></a>
<a id="schema_GetAlgorithmResponse"></a>
<a id="tocSgetalgorithmresponse"></a>
<a id="tocsgetalgorithmresponse"></a>

```json
{
  "data": [
    {
      "name": "name",
      "algorithm_id": "algorithm_id",
      "parameters": [
        null,
        null
      ]
    },
    {
      "name": "name",
      "algorithm_id": "algorithm_id",
      "parameters": [
        null,
        null
      ]
    }
  ]
}

```

response object of login

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[[Algorithm](#schemaalgorithm)]|true|none|AlgorithmResponseData|

<h2 id="tocS_GetItemsResponse">GetItemsResponse</h2>
<!-- backwards compatibility -->
<a id="schemagetitemsresponse"></a>
<a id="schema_GetItemsResponse"></a>
<a id="tocSgetitemsresponse"></a>
<a id="tocsgetitemsresponse"></a>

```json
{
  "data": {
    "summary": {
      "predict_stats": [
        {
          "NG_count": 1,
          "done_count": 6,
          "confirmed_count": 9,
          "accuracy": 5.025004791520295,
          "adjusted_count": 9,
          "model_id": "model_id",
          "OK_count": 4
        },
        {
          "NG_count": 1,
          "done_count": 6,
          "confirmed_count": 9,
          "accuracy": 5.025004791520295,
          "adjusted_count": 9,
          "model_id": "model_id",
          "OK_count": 4
        }
      ],
      "training_stats": {
        "NG_count": 6,
        "OK_count": 7
      },
      "title": "title"
    },
    "predict": [
      {
        "models": [
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          },
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          }
        ],
        "images": [
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          },
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          }
        ],
        "item_id": "item_id",
        "name": "name",
        "active": true,
        "description": "description",
        "default_image": "default_image",
        "is_training_data": true,
        "override": {
          "result": "result",
          "detection_accuracy": 6,
          "label": "label",
          "detected_objects": 0
        },
        "thumbnail_image": "thumbnail_image",
        "status": "done"
      },
      {
        "models": [
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          },
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          }
        ],
        "images": [
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          },
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          }
        ],
        "item_id": "item_id",
        "name": "name",
        "active": true,
        "description": "description",
        "default_image": "default_image",
        "is_training_data": true,
        "override": {
          "result": "result",
          "detection_accuracy": 6,
          "label": "label",
          "detected_objects": 0
        },
        "thumbnail_image": "thumbnail_image",
        "status": "done"
      }
    ],
    "training": [
      {
        "models": [
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          },
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          }
        ],
        "images": [
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          },
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          }
        ],
        "item_id": "item_id",
        "name": "name",
        "active": true,
        "description": "description",
        "default_image": "default_image",
        "is_training_data": true,
        "override": {
          "result": "result",
          "detection_accuracy": 6,
          "label": "label",
          "detected_objects": 0
        },
        "thumbnail_image": "thumbnail_image",
        "status": "done"
      },
      {
        "models": [
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          },
          {
            "assessments": [
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              },
              {
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "exif_metadata": {
                  "key": "{}"
                },
                "defect_counted": 4,
                "processed_url": "processed_url",
                "is_raw_uploaded": true,
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "confirmed": true,
                "file_size": 1,
                "content_type": "content_type",
                "width": 1,
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_id": 7,
                "height": 1
              }
            ],
            "model_id": "model_id",
            "aggregate": {
              "label": "label",
              "detected_objects": 2.027123023002322
            }
          }
        ],
        "images": [
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          },
          {
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 1,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "file_size": 5,
            "processed": true,
            "content_type": "content_type",
            "width": 7,
            "model_results": [
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              },
              {
                "result": "result",
                "computed": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "image_key": "image_key",
                "final": {
                  "result": "result",
                  "detection_accuracy": 6,
                  "label": "label",
                  "detected_objects": 0
                },
                "annotations": [
                  null,
                  null
                ],
                "created_at": "2000-01-23T04:56:07.000+00:00",
                "detection_accuracy": 3,
                "finished_date": "2000-01-23T04:56:07.000+00:00",
                "label": "OK",
                "model_id": "model_id",
                "confirmed": true,
                "detected_objects": 9
              }
            ],
            "position": "position",
            "image_id": 2,
            "raw_url": "raw_url",
            "height": 5
          }
        ],
        "item_id": "item_id",
        "name": "name",
        "active": true,
        "description": "description",
        "default_image": "default_image",
        "is_training_data": true,
        "override": {
          "result": "result",
          "detection_accuracy": 6,
          "label": "label",
          "detected_objects": 0
        },
        "thumbnail_image": "thumbnail_image",
        "status": "done"
      }
    ]
  }
}

```

Get Items Response

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[GetItemsResponse_data](#schemagetitemsresponse_data)|false|none|none|

<h2 id="tocS_GetItemResponse">GetItemResponse</h2>
<!-- backwards compatibility -->
<a id="schemagetitemresponse"></a>
<a id="schema_GetItemResponse"></a>
<a id="tocSgetitemresponse"></a>
<a id="tocsgetitemresponse"></a>

```json
{
  "data": {
    "models": [
      {
        "assessments": [
          {
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 4,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "confirmed": true,
            "file_size": 1,
            "content_type": "content_type",
            "width": 1,
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_id": 7,
            "height": 1
          },
          {
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 4,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "confirmed": true,
            "file_size": 1,
            "content_type": "content_type",
            "width": 1,
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_id": 7,
            "height": 1
          }
        ],
        "model_id": "model_id",
        "aggregate": {
          "label": "label",
          "detected_objects": 2.027123023002322
        }
      },
      {
        "assessments": [
          {
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 4,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "confirmed": true,
            "file_size": 1,
            "content_type": "content_type",
            "width": 1,
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_id": 7,
            "height": 1
          },
          {
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "exif_metadata": {
              "key": "{}"
            },
            "defect_counted": 4,
            "processed_url": "processed_url",
            "is_raw_uploaded": true,
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "confirmed": true,
            "file_size": 1,
            "content_type": "content_type",
            "width": 1,
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_id": 7,
            "height": 1
          }
        ],
        "model_id": "model_id",
        "aggregate": {
          "label": "label",
          "detected_objects": 2.027123023002322
        }
      }
    ],
    "images": [
      {
        "exif_metadata": {
          "key": "{}"
        },
        "defect_counted": 1,
        "processed_url": "processed_url",
        "is_raw_uploaded": true,
        "annotations": [
          null,
          null
        ],
        "file_size": 5,
        "processed": true,
        "content_type": "content_type",
        "width": 7,
        "model_results": [
          {
            "result": "result",
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_key": "image_key",
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "detection_accuracy": 3,
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "label": "OK",
            "model_id": "model_id",
            "confirmed": true,
            "detected_objects": 9
          },
          {
            "result": "result",
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_key": "image_key",
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "detection_accuracy": 3,
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "label": "OK",
            "model_id": "model_id",
            "confirmed": true,
            "detected_objects": 9
          }
        ],
        "position": "position",
        "image_id": 2,
        "raw_url": "raw_url",
        "height": 5
      },
      {
        "exif_metadata": {
          "key": "{}"
        },
        "defect_counted": 1,
        "processed_url": "processed_url",
        "is_raw_uploaded": true,
        "annotations": [
          null,
          null
        ],
        "file_size": 5,
        "processed": true,
        "content_type": "content_type",
        "width": 7,
        "model_results": [
          {
            "result": "result",
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_key": "image_key",
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "detection_accuracy": 3,
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "label": "OK",
            "model_id": "model_id",
            "confirmed": true,
            "detected_objects": 9
          },
          {
            "result": "result",
            "computed": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "image_key": "image_key",
            "final": {
              "result": "result",
              "detection_accuracy": 6,
              "label": "label",
              "detected_objects": 0
            },
            "annotations": [
              null,
              null
            ],
            "created_at": "2000-01-23T04:56:07.000+00:00",
            "detection_accuracy": 3,
            "finished_date": "2000-01-23T04:56:07.000+00:00",
            "label": "OK",
            "model_id": "model_id",
            "confirmed": true,
            "detected_objects": 9
          }
        ],
        "position": "position",
        "image_id": 2,
        "raw_url": "raw_url",
        "height": 5
      }
    ],
    "item_id": "item_id",
    "name": "name",
    "active": true,
    "description": "description",
    "default_image": "default_image",
    "is_training_data": true,
    "override": {
      "result": "result",
      "detection_accuracy": 6,
      "label": "label",
      "detected_objects": 0
    },
    "thumbnail_image": "thumbnail_image",
    "status": "done"
  }
}

```

response object of get specific item

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[Item](#schemaitem)|true|none|Item Model|

<h2 id="tocS_UploadRequest">UploadRequest</h2>
<!-- backwards compatibility -->
<a id="schemauploadrequest"></a>
<a id="schema_UploadRequest"></a>
<a id="tocSuploadrequest"></a>
<a id="tocsuploadrequest"></a>

```json
{
  "training": true,
  "good": true,
  "model_id": "string",
  "files": [
    "string"
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|training|boolean|true|none|none|
|good|boolean|false|none|none|
|model_id|string|false|none|none|
|files|[string]|true|none|none|

<h2 id="tocS_UploadResponse">UploadResponse</h2>
<!-- backwards compatibility -->
<a id="schemauploadresponse"></a>
<a id="schema_UploadResponse"></a>
<a id="tocSuploadresponse"></a>
<a id="tocsuploadresponse"></a>

```json
{
  "data": {
    "item_ids": [
      "item_ids",
      "item_ids"
    ]
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[UploadResponseData](#schemauploadresponsedata)|false|none|none|

<h2 id="tocS_UploadResponseData">UploadResponseData</h2>
<!-- backwards compatibility -->
<a id="schemauploadresponsedata"></a>
<a id="schema_UploadResponseData"></a>
<a id="tocSuploadresponsedata"></a>
<a id="tocsuploadresponsedata"></a>

```json
{
  "item_ids": [
    "item_ids",
    "item_ids"
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|item_ids|[string]|false|none|none|

<h2 id="tocS_TrainParams">TrainParams</h2>
<!-- backwards compatibility -->
<a id="schematrainparams"></a>
<a id="schema_TrainParams"></a>
<a id="tocStrainparams"></a>
<a id="tocstrainparams"></a>

```json
{
  "override_params": [
    {
      "algorithm_parameter_id": 0,
      "value": "value"
    },
    {
      "algorithm_parameter_id": 0,
      "value": "value"
    }
  ],
  "name": "name",
  "item_ids": [
    "item_ids",
    "item_ids"
  ],
  "algorithm_id": "algorithm_id"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|algorithm_id|string|true|none|none|
|name|string¦null|true|none|none|
|item_ids|[string]¦null|false|none|none|
|override_params|[[BaseAlgorithmParameter](#schemabasealgorithmparameter)]|false|none|[Base Algorithm Parameter Model]|

<h2 id="tocS_TrainResponse">TrainResponse</h2>
<!-- backwards compatibility -->
<a id="schematrainresponse"></a>
<a id="schema_TrainResponse"></a>
<a id="tocStrainresponse"></a>
<a id="tocstrainresponse"></a>

```json
{
  "data": {
    "ok_img_count": 1,
    "image_url": "image_url",
    "precision": 5.962133916683182,
    "active": true,
    "model_id": "model_id",
    "context_default": true,
    "version": "version",
    "algorithm_type": "algorithm_type",
    "stats": {
      "precision": {
        "projected": 7.061401241503109,
        "computed": 2.3021358869347655
      },
      "recall": {
        "projected": 7.061401241503109,
        "computed": 2.3021358869347655
      }
    },
    "recall": 5.637376656633329,
    "name": "name",
    "context_id": 0,
    "status_text": "status_text",
    "ng_img_count": 6,
    "algorithm_id": "algorithm_id",
    "status": "creating"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[Model](#schemamodel)|false|none|Model Model|

<h2 id="tocS_GetModelsResponse">GetModelsResponse</h2>
<!-- backwards compatibility -->
<a id="schemagetmodelsresponse"></a>
<a id="schema_GetModelsResponse"></a>
<a id="tocSgetmodelsresponse"></a>
<a id="tocsgetmodelsresponse"></a>

```json
{
  "data": [
    {
      "ok_img_count": 1,
      "image_url": "image_url",
      "precision": 5.962133916683182,
      "active": true,
      "model_id": "model_id",
      "context_default": true,
      "version": "version",
      "algorithm_type": "algorithm_type",
      "stats": {
        "precision": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        },
        "recall": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        }
      },
      "recall": 5.637376656633329,
      "name": "name",
      "context_id": 0,
      "status_text": "status_text",
      "ng_img_count": 6,
      "algorithm_id": "algorithm_id",
      "status": "creating"
    },
    {
      "ok_img_count": 1,
      "image_url": "image_url",
      "precision": 5.962133916683182,
      "active": true,
      "model_id": "model_id",
      "context_default": true,
      "version": "version",
      "algorithm_type": "algorithm_type",
      "stats": {
        "precision": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        },
        "recall": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        }
      },
      "recall": 5.637376656633329,
      "name": "name",
      "context_id": 0,
      "status_text": "status_text",
      "ng_img_count": 6,
      "algorithm_id": "algorithm_id",
      "status": "creating"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[[Model](#schemamodel)]|false|none|[Model Model]|

<h2 id="tocS_DeleteModelRequest">DeleteModelRequest</h2>
<!-- backwards compatibility -->
<a id="schemadeletemodelrequest"></a>
<a id="schema_DeleteModelRequest"></a>
<a id="tocSdeletemodelrequest"></a>
<a id="tocsdeletemodelrequest"></a>

```json
{
  "model_ids": [
    "model_ids",
    "model_ids"
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|model_ids|[string]|true|none|none|

<h2 id="tocS_StatusOk">StatusOk</h2>
<!-- backwards compatibility -->
<a id="schemastatusok"></a>
<a id="schema_StatusOk"></a>
<a id="tocSstatusok"></a>
<a id="tocsstatusok"></a>

```json
{
  "data": {
    "status": "status"
  }
}

```

Generic Ok Handler

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[StatusOk_data](#schemastatusok_data)|false|none|none|

<h2 id="tocS_PredictParams">PredictParams</h2>
<!-- backwards compatibility -->
<a id="schemapredictparams"></a>
<a id="schema_PredictParams"></a>
<a id="tocSpredictparams"></a>
<a id="tocspredictparams"></a>

```json
{
  "item_ids": [
    "item_ids",
    "item_ids"
  ],
  "model_id": "model_id"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|model_id|string¦null|false|none|none|
|item_ids|[string]¦null|true|none|none|

<h2 id="tocS_PredictResponse">PredictResponse</h2>
<!-- backwards compatibility -->
<a id="schemapredictresponse"></a>
<a id="schema_PredictResponse"></a>
<a id="tocSpredictresponse"></a>
<a id="tocspredictresponse"></a>

```json
{
  "data": {
    "model_version": "model_version",
    "item_ids": [
      "item_ids",
      "item_ids"
    ]
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[PredictResponseData](#schemapredictresponsedata)|false|none|none|

<h2 id="tocS_PredictResponseData">PredictResponseData</h2>
<!-- backwards compatibility -->
<a id="schemapredictresponsedata"></a>
<a id="schema_PredictResponseData"></a>
<a id="tocSpredictresponsedata"></a>
<a id="tocspredictresponsedata"></a>

```json
{
  "model_version": "model_version",
  "item_ids": [
    "item_ids",
    "item_ids"
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|item_ids|[string]|false|none|none|
|model_version|string|false|none|none|

<h2 id="tocS_LicenseRequest">LicenseRequest</h2>
<!-- backwards compatibility -->
<a id="schemalicenserequest"></a>
<a id="schema_LicenseRequest"></a>
<a id="tocSlicenserequest"></a>
<a id="tocslicenserequest"></a>

```json
{
  "license": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|license|string(binary)|true|none|none|

<h2 id="tocS_LicenseResponse">LicenseResponse</h2>
<!-- backwards compatibility -->
<a id="schemalicenseresponse"></a>
<a id="schema_LicenseResponse"></a>
<a id="tocSlicenseresponse"></a>
<a id="tocslicenseresponse"></a>

```json
{
  "data": {
    "customer_id": "customer_id",
    "status": "status"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[LicenseResponseData](#schemalicenseresponsedata)|false|none|none|

<h2 id="tocS_LicenseResponseData">LicenseResponseData</h2>
<!-- backwards compatibility -->
<a id="schemalicenseresponsedata"></a>
<a id="schema_LicenseResponseData"></a>
<a id="tocSlicenseresponsedata"></a>
<a id="tocslicenseresponsedata"></a>

```json
{
  "customer_id": "customer_id",
  "status": "status"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|customer_id|string|false|none|none|
|status|string|false|none|none|

<h2 id="tocS_AnnotateParams">AnnotateParams</h2>
<!-- backwards compatibility -->
<a id="schemaannotateparams"></a>
<a id="schema_AnnotateParams"></a>
<a id="tocSannotateparams"></a>
<a id="tocsannotateparams"></a>

```json
{
  "annotations": [
    {
      "notes": "notes",
      "y_min": 0,
      "x_max": 1,
      "y_max": 1,
      "x_min": 0
    },
    {
      "notes": "notes",
      "y_min": 0,
      "x_max": 1,
      "y_max": 1,
      "x_min": 0
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|annotations|[[BaseAnnotation](#schemabaseannotation)]|true|none|[Base Annotation Model]|

<h2 id="tocS_ExportModelRequest">ExportModelRequest</h2>
<!-- backwards compatibility -->
<a id="schemaexportmodelrequest"></a>
<a id="schema_ExportModelRequest"></a>
<a id="tocSexportmodelrequest"></a>
<a id="tocsexportmodelrequest"></a>

```json
{
  "model_ids": [
    "model_ids",
    "model_ids"
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|model_ids|[string]|true|none|none|

<h2 id="tocS_ImportModelRequest">ImportModelRequest</h2>
<!-- backwards compatibility -->
<a id="schemaimportmodelrequest"></a>
<a id="schema_ImportModelRequest"></a>
<a id="tocSimportmodelrequest"></a>
<a id="tocsimportmodelrequest"></a>

```json
{
  "models": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|models|string(binary)|true|none|none|

<h2 id="tocS_ImportModelResponse">ImportModelResponse</h2>
<!-- backwards compatibility -->
<a id="schemaimportmodelresponse"></a>
<a id="schema_ImportModelResponse"></a>
<a id="tocSimportmodelresponse"></a>
<a id="tocsimportmodelresponse"></a>

```json
{
  "data": [
    {
      "ok_img_count": 1,
      "image_url": "image_url",
      "precision": 5.962133916683182,
      "active": true,
      "model_id": "model_id",
      "context_default": true,
      "version": "version",
      "algorithm_type": "algorithm_type",
      "stats": {
        "precision": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        },
        "recall": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        }
      },
      "recall": 5.637376656633329,
      "name": "name",
      "context_id": 0,
      "status_text": "status_text",
      "ng_img_count": 6,
      "algorithm_id": "algorithm_id",
      "status": "creating"
    },
    {
      "ok_img_count": 1,
      "image_url": "image_url",
      "precision": 5.962133916683182,
      "active": true,
      "model_id": "model_id",
      "context_default": true,
      "version": "version",
      "algorithm_type": "algorithm_type",
      "stats": {
        "precision": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        },
        "recall": {
          "projected": 7.061401241503109,
          "computed": 2.3021358869347655
        }
      },
      "recall": 5.637376656633329,
      "name": "name",
      "context_id": 0,
      "status_text": "status_text",
      "ng_img_count": 6,
      "algorithm_id": "algorithm_id",
      "status": "creating"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[[Model](#schemamodel)]|false|none|[Model Model]|

<h2 id="tocS_GetWorkersResponse">GetWorkersResponse</h2>
<!-- backwards compatibility -->
<a id="schemagetworkersresponse"></a>
<a id="schema_GetWorkersResponse"></a>
<a id="tocSgetworkersresponse"></a>
<a id="tocsgetworkersresponse"></a>

```json
{
  "data": {
    "active_worker_count": 0,
    "in_progress": [
      {
        "queue_time": 1.4658129805029452,
        "result": "result",
        "start_time": 5.962133916683182,
        "end_time": 6.027456183070403,
        "type": "type"
      },
      {
        "queue_time": 1.4658129805029452,
        "result": "result",
        "start_time": 5.962133916683182,
        "end_time": 6.027456183070403,
        "type": "type"
      }
    ],
    "pending": [
      {
        "queue_time": 1.4658129805029452,
        "result": "result",
        "start_time": 5.962133916683182,
        "end_time": 6.027456183070403,
        "type": "type"
      },
      {
        "queue_time": 1.4658129805029452,
        "result": "result",
        "start_time": 5.962133916683182,
        "end_time": 6.027456183070403,
        "type": "type"
      }
    ],
    "done": [
      {
        "queue_time": 1.4658129805029452,
        "result": "result",
        "start_time": 5.962133916683182,
        "end_time": 6.027456183070403,
        "type": "type"
      },
      {
        "queue_time": 1.4658129805029452,
        "result": "result",
        "start_time": 5.962133916683182,
        "end_time": 6.027456183070403,
        "type": "type"
      }
    ]
  }
}

```

response object of get specific item

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[GetWorkersResponse_data](#schemagetworkersresponse_data)|true|none|none|

<h2 id="tocS_LoginResponseData">LoginResponseData</h2>
<!-- backwards compatibility -->
<a id="schemaloginresponsedata"></a>
<a id="schema_LoginResponseData"></a>
<a id="tocSloginresponsedata"></a>
<a id="tocsloginresponsedata"></a>

```json
{
  "access_token": "access_token"
}

```

access_token data

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|access_token|string|true|none|none|

<h2 id="tocS_GetAlgorithmResponseData">GetAlgorithmResponseData</h2>
<!-- backwards compatibility -->
<a id="schemagetalgorithmresponsedata"></a>
<a id="schema_GetAlgorithmResponseData"></a>
<a id="tocSgetalgorithmresponsedata"></a>
<a id="tocsgetalgorithmresponsedata"></a>

```json
[
  {
    "name": "name",
    "algorithm_id": "algorithm_id",
    "parameters": [
      null,
      null
    ]
  }
]

```

AlgorithmResponseData

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[Algorithm](#schemaalgorithm)]|false|none|AlgorithmResponseData|

<h2 id="tocS_Item">Item</h2>
<!-- backwards compatibility -->
<a id="schemaitem"></a>
<a id="schema_Item"></a>
<a id="tocSitem"></a>
<a id="tocsitem"></a>

```json
{
  "models": [
    {
      "assessments": [
        {
          "computed": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "exif_metadata": {
            "key": "{}"
          },
          "defect_counted": 4,
          "processed_url": "processed_url",
          "is_raw_uploaded": true,
          "annotations": [
            null,
            null
          ],
          "created_at": "2000-01-23T04:56:07.000+00:00",
          "finished_date": "2000-01-23T04:56:07.000+00:00",
          "confirmed": true,
          "file_size": 1,
          "content_type": "content_type",
          "width": 1,
          "final": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "image_id": 7,
          "height": 1
        },
        {
          "computed": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "exif_metadata": {
            "key": "{}"
          },
          "defect_counted": 4,
          "processed_url": "processed_url",
          "is_raw_uploaded": true,
          "annotations": [
            null,
            null
          ],
          "created_at": "2000-01-23T04:56:07.000+00:00",
          "finished_date": "2000-01-23T04:56:07.000+00:00",
          "confirmed": true,
          "file_size": 1,
          "content_type": "content_type",
          "width": 1,
          "final": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "image_id": 7,
          "height": 1
        }
      ],
      "model_id": "model_id",
      "aggregate": {
        "label": "label",
        "detected_objects": 2.027123023002322
      }
    },
    {
      "assessments": [
        {
          "computed": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "exif_metadata": {
            "key": "{}"
          },
          "defect_counted": 4,
          "processed_url": "processed_url",
          "is_raw_uploaded": true,
          "annotations": [
            null,
            null
          ],
          "created_at": "2000-01-23T04:56:07.000+00:00",
          "finished_date": "2000-01-23T04:56:07.000+00:00",
          "confirmed": true,
          "file_size": 1,
          "content_type": "content_type",
          "width": 1,
          "final": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "image_id": 7,
          "height": 1
        },
        {
          "computed": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "exif_metadata": {
            "key": "{}"
          },
          "defect_counted": 4,
          "processed_url": "processed_url",
          "is_raw_uploaded": true,
          "annotations": [
            null,
            null
          ],
          "created_at": "2000-01-23T04:56:07.000+00:00",
          "finished_date": "2000-01-23T04:56:07.000+00:00",
          "confirmed": true,
          "file_size": 1,
          "content_type": "content_type",
          "width": 1,
          "final": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "image_id": 7,
          "height": 1
        }
      ],
      "model_id": "model_id",
      "aggregate": {
        "label": "label",
        "detected_objects": 2.027123023002322
      }
    }
  ],
  "images": [
    {
      "exif_metadata": {
        "key": "{}"
      },
      "defect_counted": 1,
      "processed_url": "processed_url",
      "is_raw_uploaded": true,
      "annotations": [
        null,
        null
      ],
      "file_size": 5,
      "processed": true,
      "content_type": "content_type",
      "width": 7,
      "model_results": [
        {
          "result": "result",
          "computed": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "image_key": "image_key",
          "final": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "annotations": [
            null,
            null
          ],
          "created_at": "2000-01-23T04:56:07.000+00:00",
          "detection_accuracy": 3,
          "finished_date": "2000-01-23T04:56:07.000+00:00",
          "label": "OK",
          "model_id": "model_id",
          "confirmed": true,
          "detected_objects": 9
        },
        {
          "result": "result",
          "computed": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "image_key": "image_key",
          "final": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "annotations": [
            null,
            null
          ],
          "created_at": "2000-01-23T04:56:07.000+00:00",
          "detection_accuracy": 3,
          "finished_date": "2000-01-23T04:56:07.000+00:00",
          "label": "OK",
          "model_id": "model_id",
          "confirmed": true,
          "detected_objects": 9
        }
      ],
      "position": "position",
      "image_id": 2,
      "raw_url": "raw_url",
      "height": 5
    },
    {
      "exif_metadata": {
        "key": "{}"
      },
      "defect_counted": 1,
      "processed_url": "processed_url",
      "is_raw_uploaded": true,
      "annotations": [
        null,
        null
      ],
      "file_size": 5,
      "processed": true,
      "content_type": "content_type",
      "width": 7,
      "model_results": [
        {
          "result": "result",
          "computed": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "image_key": "image_key",
          "final": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "annotations": [
            null,
            null
          ],
          "created_at": "2000-01-23T04:56:07.000+00:00",
          "detection_accuracy": 3,
          "finished_date": "2000-01-23T04:56:07.000+00:00",
          "label": "OK",
          "model_id": "model_id",
          "confirmed": true,
          "detected_objects": 9
        },
        {
          "result": "result",
          "computed": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "image_key": "image_key",
          "final": {
            "result": "result",
            "detection_accuracy": 6,
            "label": "label",
            "detected_objects": 0
          },
          "annotations": [
            null,
            null
          ],
          "created_at": "2000-01-23T04:56:07.000+00:00",
          "detection_accuracy": 3,
          "finished_date": "2000-01-23T04:56:07.000+00:00",
          "label": "OK",
          "model_id": "model_id",
          "confirmed": true,
          "detected_objects": 9
        }
      ],
      "position": "position",
      "image_id": 2,
      "raw_url": "raw_url",
      "height": 5
    }
  ],
  "item_id": "item_id",
  "name": "name",
  "active": true,
  "description": "description",
  "default_image": "default_image",
  "is_training_data": true,
  "override": {
    "result": "result",
    "detection_accuracy": 6,
    "label": "label",
    "detected_objects": 0
  },
  "thumbnail_image": "thumbnail_image",
  "status": "done"
}

```

Item Model

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|item_id|string|false|none|none|
|active|boolean|true|none|none|
|default_image|string|false|none|none|
|description|string|false|none|none|
|name|string|true|none|none|
|thumbnail_image|string|false|none|none|
|is_training_data|boolean|true|none|none|
|override|[Assessment](#schemaassessment)|false|none|Assessment Model|
|status|string|false|none|none|
|images|[[Image](#schemaimage)]|false|none|[Image Model]|
|models|[[ItemModels](#schemaitemmodels)]|false|none|[Item Models Model]|

#### Enumerated Values

|Property|Value|
|---|---|
|status|done|
|status|archived|
|status|pending|

<h2 id="tocS_BaseAlgorithmParameter">BaseAlgorithmParameter</h2>
<!-- backwards compatibility -->
<a id="schemabasealgorithmparameter"></a>
<a id="schema_BaseAlgorithmParameter"></a>
<a id="tocSbasealgorithmparameter"></a>
<a id="tocsbasealgorithmparameter"></a>

```json
{
  "algorithm_parameter_id": 0,
  "value": "value"
}

```

Base Algorithm Parameter Model

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|algorithm_parameter_id|integer|true|none|none|
|value|string|true|none|none|

<h2 id="tocS_Model">Model</h2>
<!-- backwards compatibility -->
<a id="schemamodel"></a>
<a id="schema_Model"></a>
<a id="tocSmodel"></a>
<a id="tocsmodel"></a>

```json
{
  "ok_img_count": 1,
  "image_url": "image_url",
  "precision": 5.962133916683182,
  "active": true,
  "model_id": "model_id",
  "context_default": true,
  "version": "version",
  "algorithm_type": "algorithm_type",
  "stats": {
    "precision": {
      "projected": 7.061401241503109,
      "computed": 2.3021358869347655
    },
    "recall": {
      "projected": 7.061401241503109,
      "computed": 2.3021358869347655
    }
  },
  "recall": 5.637376656633329,
  "name": "name",
  "context_id": 0,
  "status_text": "status_text",
  "ng_img_count": 6,
  "algorithm_id": "algorithm_id",
  "status": "creating"
}

```

Model Model

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|active|boolean|false|none|none|
|algorithm_id|string|false|none|none|
|algorithm_type|string|false|none|none|
|context_default|boolean|false|none|none|
|context_id|integer|false|none|none|
|image_url|string¦null|false|none|none|
|model_id|string|false|none|none|
|name|string|false|none|none|
|ng_img_count|integer|false|none|none|
|ok_img_count|integer|false|none|none|
|status|string|false|none|none|
|status_text|string¦null|false|none|none|
|version|string|false|none|none|
|precision|number¦null|false|none|none|
|recall|number¦null|false|none|none|
|stats|[Model_stats](#schemamodel_stats)|false|none|none|

#### Enumerated Values

|Property|Value|
|---|---|
|status|creating|
|status|active|
|status|failed|
|status|deleted|

<h2 id="tocS_BaseAnnotation">BaseAnnotation</h2>
<!-- backwards compatibility -->
<a id="schemabaseannotation"></a>
<a id="schema_BaseAnnotation"></a>
<a id="tocSbaseannotation"></a>
<a id="tocsbaseannotation"></a>

```json
{
  "notes": "notes",
  "y_min": 0,
  "x_max": 1,
  "y_max": 1,
  "x_min": 0
}

```

Base Annotation Model

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|notes|string¦null|false|none|none|
|x_min|integer¦null|true|none|none|
|x_max|integer|true|none|none|
|y_min|integer¦null|true|none|none|
|y_max|integer|true|none|none|

<h2 id="tocS_Worker">Worker</h2>
<!-- backwards compatibility -->
<a id="schemaworker"></a>
<a id="schema_Worker"></a>
<a id="tocSworker"></a>
<a id="tocsworker"></a>

```json
{
  "queue_time": 1.4658129805029452,
  "result": "result",
  "start_time": 5.962133916683182,
  "end_time": 6.027456183070403,
  "type": "type"
}

```

Worker Model

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|end_time|number¦null|false|none|none|
|queue_time|number¦null|false|none|none|
|start_time|number¦null|false|none|none|
|result|string¦null|false|none|none|
|type|string¦null|false|none|none|

<h2 id="tocS_Algorithm">Algorithm</h2>
<!-- backwards compatibility -->
<a id="schemaalgorithm"></a>
<a id="schema_Algorithm"></a>
<a id="tocSalgorithm"></a>
<a id="tocsalgorithm"></a>

```json
{
  "name": "name",
  "algorithm_id": "algorithm_id",
  "parameters": [
    null,
    null
  ]
}

```

Algorithm Model

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|algorithm_id|string|true|none|none|
|name|string|true|none|none|
|parameters|[[AlgorithmParameter](#schemaalgorithmparameter)]|false|none|[Algorithm Parameter Model]|

<h2 id="tocS_Assessment">Assessment</h2>
<!-- backwards compatibility -->
<a id="schemaassessment"></a>
<a id="schema_Assessment"></a>
<a id="tocSassessment"></a>
<a id="tocsassessment"></a>

```json
{
  "result": "result",
  "detection_accuracy": 6,
  "label": "label",
  "detected_objects": 0
}

```

Assessment Model

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|label|string|false|none|none|
|result|string|false|none|none|
|detected_objects|integer¦null|false|none|none|
|detection_accuracy|integer¦null|false|none|none|

<h2 id="tocS_Image">Image</h2>
<!-- backwards compatibility -->
<a id="schemaimage"></a>
<a id="schema_Image"></a>
<a id="tocSimage"></a>
<a id="tocsimage"></a>

```json
{
  "exif_metadata": {
    "key": "{}"
  },
  "defect_counted": 1,
  "processed_url": "processed_url",
  "is_raw_uploaded": true,
  "annotations": [
    null,
    null
  ],
  "file_size": 5,
  "processed": true,
  "content_type": "content_type",
  "width": 7,
  "model_results": [
    {
      "result": "result",
      "computed": {
        "result": "result",
        "detection_accuracy": 6,
        "label": "label",
        "detected_objects": 0
      },
      "image_key": "image_key",
      "final": {
        "result": "result",
        "detection_accuracy": 6,
        "label": "label",
        "detected_objects": 0
      },
      "annotations": [
        null,
        null
      ],
      "created_at": "2000-01-23T04:56:07.000+00:00",
      "detection_accuracy": 3,
      "finished_date": "2000-01-23T04:56:07.000+00:00",
      "label": "OK",
      "model_id": "model_id",
      "confirmed": true,
      "detected_objects": 9
    },
    {
      "result": "result",
      "computed": {
        "result": "result",
        "detection_accuracy": 6,
        "label": "label",
        "detected_objects": 0
      },
      "image_key": "image_key",
      "final": {
        "result": "result",
        "detection_accuracy": 6,
        "label": "label",
        "detected_objects": 0
      },
      "annotations": [
        null,
        null
      ],
      "created_at": "2000-01-23T04:56:07.000+00:00",
      "detection_accuracy": 3,
      "finished_date": "2000-01-23T04:56:07.000+00:00",
      "label": "OK",
      "model_id": "model_id",
      "confirmed": true,
      "detected_objects": 9
    }
  ],
  "position": "position",
  "image_id": 2,
  "raw_url": "raw_url",
  "height": 5
}

```

Image Model

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|content_type|string|false|none|none|
|defect_counted|integer¦null|false|none|none|
|exif_metadata|object|false|none|Exif Metadata Model|
|» **additionalProperties**|object|false|none|none|
|file_size|integer¦null|false|none|none|
|height|integer¦null|false|none|none|
|image_id|integer|true|none|none|
|is_raw_uploaded|boolean¦null|false|none|none|
|position|string¦null|false|none|none|
|processed|boolean¦null|false|none|none|
|processed_url|string¦null|false|none|none|
|raw_url|string|false|none|none|
|width|integer¦null|false|none|none|
|annotations|[[Annotation](#schemaannotation)]¦null|false|none|[Annotation Model]|
|model_results|[[ModelResult](#schemamodelresult)]¦null|false|none|[ModelResult Model]|

<h2 id="tocS_ItemModels">ItemModels</h2>
<!-- backwards compatibility -->
<a id="schemaitemmodels"></a>
<a id="schema_ItemModels"></a>
<a id="tocSitemmodels"></a>
<a id="tocsitemmodels"></a>

```json
{
  "assessments": [
    {
      "computed": {
        "result": "result",
        "detection_accuracy": 6,
        "label": "label",
        "detected_objects": 0
      },
      "exif_metadata": {
        "key": "{}"
      },
      "defect_counted": 4,
      "processed_url": "processed_url",
      "is_raw_uploaded": true,
      "annotations": [
        null,
        null
      ],
      "created_at": "2000-01-23T04:56:07.000+00:00",
      "finished_date": "2000-01-23T04:56:07.000+00:00",
      "confirmed": true,
      "file_size": 1,
      "content_type": "content_type",
      "width": 1,
      "final": {
        "result": "result",
        "detection_accuracy": 6,
        "label": "label",
        "detected_objects": 0
      },
      "image_id": 7,
      "height": 1
    },
    {
      "computed": {
        "result": "result",
        "detection_accuracy": 6,
        "label": "label",
        "detected_objects": 0
      },
      "exif_metadata": {
        "key": "{}"
      },
      "defect_counted": 4,
      "processed_url": "processed_url",
      "is_raw_uploaded": true,
      "annotations": [
        null,
        null
      ],
      "created_at": "2000-01-23T04:56:07.000+00:00",
      "finished_date": "2000-01-23T04:56:07.000+00:00",
      "confirmed": true,
      "file_size": 1,
      "content_type": "content_type",
      "width": 1,
      "final": {
        "result": "result",
        "detection_accuracy": 6,
        "label": "label",
        "detected_objects": 0
      },
      "image_id": 7,
      "height": 1
    }
  ],
  "model_id": "model_id",
  "aggregate": {
    "label": "label",
    "detected_objects": 2.027123023002322
  }
}

```

Item Models Model

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|model_id|string|false|none|none|
|aggregate|[ItemModels_aggregate](#schemaitemmodels_aggregate)|true|none|none|
|assessments|[[ItemModelAssessment](#schemaitemmodelassessment)]|true|none|[Item Model Assessment Model]|

<h2 id="tocS_Stat">Stat</h2>
<!-- backwards compatibility -->
<a id="schemastat"></a>
<a id="schema_Stat"></a>
<a id="tocSstat"></a>
<a id="tocsstat"></a>

```json
{
  "projected": 7.061401241503109,
  "computed": 2.3021358869347655
}

```

Precision and Recall Model

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|computed|number¦null|false|none|none|
|projected|number¦null|false|none|none|

<h2 id="tocS_AlgorithmParameter">AlgorithmParameter</h2>
<!-- backwards compatibility -->
<a id="schemaalgorithmparameter"></a>
<a id="schema_AlgorithmParameter"></a>
<a id="tocSalgorithmparameter"></a>
<a id="tocsalgorithmparameter"></a>

```json
{
  "algorithm_parameter_id": 0,
  "value": "value",
  "data_type": "string",
  "display_name": "string"
}

```

Algorithm Parameter Model

### Properties

allOf

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[BaseAlgorithmParameter](#schemabasealgorithmparameter)|false|none|Base Algorithm Parameter Model|

and

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[AlgorithmParameter_allOf](#schemaalgorithmparameter_allof)|false|none|none|

<h2 id="tocS_ExifMetadata">ExifMetadata</h2>
<!-- backwards compatibility -->
<a id="schemaexifmetadata"></a>
<a id="schema_ExifMetadata"></a>
<a id="tocSexifmetadata"></a>
<a id="tocsexifmetadata"></a>

```json
{
  "property1": {},
  "property2": {}
}

```

Exif Metadata Model

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|**additionalProperties**|object|false|none|none|

<h2 id="tocS_Annotation">Annotation</h2>
<!-- backwards compatibility -->
<a id="schemaannotation"></a>
<a id="schema_Annotation"></a>
<a id="tocSannotation"></a>
<a id="tocsannotation"></a>

```json
{
  "notes": "notes",
  "y_min": 0,
  "x_max": 1,
  "y_max": 1,
  "x_min": 0,
  "image_id": "string",
  "model_id": "string",
  "annotation_id": 0,
  "for_training": true
}

```

Annotation Model

### Properties

allOf

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[BaseAnnotation](#schemabaseannotation)|false|none|Base Annotation Model|

and

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[Annotation_allOf](#schemaannotation_allof)|false|none|none|

<h2 id="tocS_ModelResult">ModelResult</h2>
<!-- backwards compatibility -->
<a id="schemamodelresult"></a>
<a id="schema_ModelResult"></a>
<a id="tocSmodelresult"></a>
<a id="tocsmodelresult"></a>

```json
{
  "result": "result",
  "computed": {
    "result": "result",
    "detection_accuracy": 6,
    "label": "label",
    "detected_objects": 0
  },
  "image_key": "image_key",
  "final": {
    "result": "result",
    "detection_accuracy": 6,
    "label": "label",
    "detected_objects": 0
  },
  "annotations": [
    null,
    null
  ],
  "created_at": "2000-01-23T04:56:07.000+00:00",
  "detection_accuracy": 3,
  "finished_date": "2000-01-23T04:56:07.000+00:00",
  "label": "OK",
  "model_id": "model_id",
  "confirmed": true,
  "detected_objects": 9
}

```

ModelResult Model

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|label|string|true|none|none|
|detected_objects|integer|true|none|none|
|detection_accuracy|integer¦null|false|none|none|
|image_key|string|true|none|none|
|result|string|true|none|none|
|model_id|string|true|none|none|
|annotations|[[Annotation](#schemaannotation)]¦null|false|none|[Annotation Model]|
|confirmed|boolean¦null|false|none|none|
|finished_date|string(date-time)|false|none|none|
|created_at|string(date-time)|false|none|none|
|computed|[Assessment](#schemaassessment)|false|none|Assessment Model|
|final|[Assessment](#schemaassessment)|false|none|Assessment Model|

#### Enumerated Values

|Property|Value|
|---|---|
|label|OK|
|label|NG|

<h2 id="tocS_ItemModelAssessment">ItemModelAssessment</h2>
<!-- backwards compatibility -->
<a id="schemaitemmodelassessment"></a>
<a id="schema_ItemModelAssessment"></a>
<a id="tocSitemmodelassessment"></a>
<a id="tocsitemmodelassessment"></a>

```json
{
  "computed": {
    "result": "result",
    "detection_accuracy": 6,
    "label": "label",
    "detected_objects": 0
  },
  "exif_metadata": {
    "key": "{}"
  },
  "defect_counted": 4,
  "processed_url": "processed_url",
  "is_raw_uploaded": true,
  "annotations": [
    null,
    null
  ],
  "created_at": "2000-01-23T04:56:07.000+00:00",
  "finished_date": "2000-01-23T04:56:07.000+00:00",
  "confirmed": true,
  "file_size": 1,
  "content_type": "content_type",
  "width": 1,
  "final": {
    "result": "result",
    "detection_accuracy": 6,
    "label": "label",
    "detected_objects": 0
  },
  "image_id": 7,
  "height": 1
}

```

Item Model Assessment Model

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|annotations|[[Annotation](#schemaannotation)]¦null|false|none|[Annotation Model]|
|computed|[Assessment](#schemaassessment)|false|none|Assessment Model|
|confirmed|boolean¦null|false|none|none|
|content_type|string¦null|false|none|none|
|processed_url|string¦null|false|none|none|
|defect_counted|integer¦null|false|none|none|
|is_raw_uploaded|boolean¦null|false|none|none|
|image_id|integer¦null|false|none|none|
|height|integer¦null|false|none|none|
|width|integer¦null|false|none|none|
|file_size|integer¦null|false|none|none|
|created_at|string(date-time)|false|none|none|
|finished_date|string(date-time)|false|none|none|
|final|[Assessment](#schemaassessment)|false|none|Assessment Model|
|exif_metadata|object|false|none|Exif Metadata Model|
|» **additionalProperties**|object|false|none|none|

<h2 id="tocS_BaseError_errors_source">BaseError_errors_source</h2>
<!-- backwards compatibility -->
<a id="schemabaseerror_errors_source"></a>
<a id="schema_BaseError_errors_source"></a>
<a id="tocSbaseerror_errors_source"></a>
<a id="tocsbaseerror_errors_source"></a>

```json
{
  "pointer": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|pointer|string|false|none|none|

<h2 id="tocS_BaseError_errors">BaseError_errors</h2>
<!-- backwards compatibility -->
<a id="schemabaseerror_errors"></a>
<a id="schema_BaseError_errors"></a>
<a id="tocSbaseerror_errors"></a>
<a id="tocsbaseerror_errors"></a>

```json
{
  "detail": "string",
  "source": {
    "pointer": "string"
  },
  "status": 0,
  "title": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|detail|string|false|none|none|
|source|[BaseError_errors_source](#schemabaseerror_errors_source)|false|none|none|
|status|integer|false|none|none|
|title|string|false|none|none|

<h2 id="tocS_GetItemsResponse_data_summary_training_stats">GetItemsResponse_data_summary_training_stats</h2>
<!-- backwards compatibility -->
<a id="schemagetitemsresponse_data_summary_training_stats"></a>
<a id="schema_GetItemsResponse_data_summary_training_stats"></a>
<a id="tocSgetitemsresponse_data_summary_training_stats"></a>
<a id="tocsgetitemsresponse_data_summary_training_stats"></a>

```json
{
  "NG_count": 6,
  "OK_count": 7
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|NG_count|integer|false|none|none|
|OK_count|integer|false|none|none|

<h2 id="tocS_GetItemsResponse_data_summary_predict_stats">GetItemsResponse_data_summary_predict_stats</h2>
<!-- backwards compatibility -->
<a id="schemagetitemsresponse_data_summary_predict_stats"></a>
<a id="schema_GetItemsResponse_data_summary_predict_stats"></a>
<a id="tocSgetitemsresponse_data_summary_predict_stats"></a>
<a id="tocsgetitemsresponse_data_summary_predict_stats"></a>

```json
{
  "NG_count": 1,
  "done_count": 6,
  "confirmed_count": 9,
  "accuracy": 5.025004791520295,
  "adjusted_count": 9,
  "model_id": "model_id",
  "OK_count": 4
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|NG_count|integer|false|none|none|
|OK_count|integer|false|none|none|
|accuracy|number|false|none|none|
|adjusted_count|integer|false|none|none|
|confirmed_count|integer|false|none|none|
|done_count|integer|false|none|none|
|model_id|string|false|none|none|

<h2 id="tocS_GetItemsResponse_data_summary">GetItemsResponse_data_summary</h2>
<!-- backwards compatibility -->
<a id="schemagetitemsresponse_data_summary"></a>
<a id="schema_GetItemsResponse_data_summary"></a>
<a id="tocSgetitemsresponse_data_summary"></a>
<a id="tocsgetitemsresponse_data_summary"></a>

```json
{
  "predict_stats": [
    {
      "NG_count": 1,
      "done_count": 6,
      "confirmed_count": 9,
      "accuracy": 5.025004791520295,
      "adjusted_count": 9,
      "model_id": "model_id",
      "OK_count": 4
    },
    {
      "NG_count": 1,
      "done_count": 6,
      "confirmed_count": 9,
      "accuracy": 5.025004791520295,
      "adjusted_count": 9,
      "model_id": "model_id",
      "OK_count": 4
    }
  ],
  "training_stats": {
    "NG_count": 6,
    "OK_count": 7
  },
  "title": "title"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|title|string|false|none|none|
|training_stats|[GetItemsResponse_data_summary_training_stats](#schemagetitemsresponse_data_summary_training_stats)|false|none|none|
|predict_stats|[[GetItemsResponse_data_summary_predict_stats](#schemagetitemsresponse_data_summary_predict_stats)]|false|none|none|

<h2 id="tocS_GetItemsResponse_data">GetItemsResponse_data</h2>
<!-- backwards compatibility -->
<a id="schemagetitemsresponse_data"></a>
<a id="schema_GetItemsResponse_data"></a>
<a id="tocSgetitemsresponse_data"></a>
<a id="tocsgetitemsresponse_data"></a>

```json
{
  "summary": {
    "predict_stats": [
      {
        "NG_count": 1,
        "done_count": 6,
        "confirmed_count": 9,
        "accuracy": 5.025004791520295,
        "adjusted_count": 9,
        "model_id": "model_id",
        "OK_count": 4
      },
      {
        "NG_count": 1,
        "done_count": 6,
        "confirmed_count": 9,
        "accuracy": 5.025004791520295,
        "adjusted_count": 9,
        "model_id": "model_id",
        "OK_count": 4
      }
    ],
    "training_stats": {
      "NG_count": 6,
      "OK_count": 7
    },
    "title": "title"
  },
  "predict": [
    {
      "models": [
        {
          "assessments": [
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            },
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            }
          ],
          "model_id": "model_id",
          "aggregate": {
            "label": "label",
            "detected_objects": 2.027123023002322
          }
        },
        {
          "assessments": [
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            },
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            }
          ],
          "model_id": "model_id",
          "aggregate": {
            "label": "label",
            "detected_objects": 2.027123023002322
          }
        }
      ],
      "images": [
        {
          "exif_metadata": {
            "key": "{}"
          },
          "defect_counted": 1,
          "processed_url": "processed_url",
          "is_raw_uploaded": true,
          "annotations": [
            null,
            null
          ],
          "file_size": 5,
          "processed": true,
          "content_type": "content_type",
          "width": 7,
          "model_results": [
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            },
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            }
          ],
          "position": "position",
          "image_id": 2,
          "raw_url": "raw_url",
          "height": 5
        },
        {
          "exif_metadata": {
            "key": "{}"
          },
          "defect_counted": 1,
          "processed_url": "processed_url",
          "is_raw_uploaded": true,
          "annotations": [
            null,
            null
          ],
          "file_size": 5,
          "processed": true,
          "content_type": "content_type",
          "width": 7,
          "model_results": [
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            },
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            }
          ],
          "position": "position",
          "image_id": 2,
          "raw_url": "raw_url",
          "height": 5
        }
      ],
      "item_id": "item_id",
      "name": "name",
      "active": true,
      "description": "description",
      "default_image": "default_image",
      "is_training_data": true,
      "override": {
        "result": "result",
        "detection_accuracy": 6,
        "label": "label",
        "detected_objects": 0
      },
      "thumbnail_image": "thumbnail_image",
      "status": "done"
    },
    {
      "models": [
        {
          "assessments": [
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            },
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            }
          ],
          "model_id": "model_id",
          "aggregate": {
            "label": "label",
            "detected_objects": 2.027123023002322
          }
        },
        {
          "assessments": [
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            },
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            }
          ],
          "model_id": "model_id",
          "aggregate": {
            "label": "label",
            "detected_objects": 2.027123023002322
          }
        }
      ],
      "images": [
        {
          "exif_metadata": {
            "key": "{}"
          },
          "defect_counted": 1,
          "processed_url": "processed_url",
          "is_raw_uploaded": true,
          "annotations": [
            null,
            null
          ],
          "file_size": 5,
          "processed": true,
          "content_type": "content_type",
          "width": 7,
          "model_results": [
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            },
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            }
          ],
          "position": "position",
          "image_id": 2,
          "raw_url": "raw_url",
          "height": 5
        },
        {
          "exif_metadata": {
            "key": "{}"
          },
          "defect_counted": 1,
          "processed_url": "processed_url",
          "is_raw_uploaded": true,
          "annotations": [
            null,
            null
          ],
          "file_size": 5,
          "processed": true,
          "content_type": "content_type",
          "width": 7,
          "model_results": [
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            },
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            }
          ],
          "position": "position",
          "image_id": 2,
          "raw_url": "raw_url",
          "height": 5
        }
      ],
      "item_id": "item_id",
      "name": "name",
      "active": true,
      "description": "description",
      "default_image": "default_image",
      "is_training_data": true,
      "override": {
        "result": "result",
        "detection_accuracy": 6,
        "label": "label",
        "detected_objects": 0
      },
      "thumbnail_image": "thumbnail_image",
      "status": "done"
    }
  ],
  "training": [
    {
      "models": [
        {
          "assessments": [
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            },
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            }
          ],
          "model_id": "model_id",
          "aggregate": {
            "label": "label",
            "detected_objects": 2.027123023002322
          }
        },
        {
          "assessments": [
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            },
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            }
          ],
          "model_id": "model_id",
          "aggregate": {
            "label": "label",
            "detected_objects": 2.027123023002322
          }
        }
      ],
      "images": [
        {
          "exif_metadata": {
            "key": "{}"
          },
          "defect_counted": 1,
          "processed_url": "processed_url",
          "is_raw_uploaded": true,
          "annotations": [
            null,
            null
          ],
          "file_size": 5,
          "processed": true,
          "content_type": "content_type",
          "width": 7,
          "model_results": [
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            },
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            }
          ],
          "position": "position",
          "image_id": 2,
          "raw_url": "raw_url",
          "height": 5
        },
        {
          "exif_metadata": {
            "key": "{}"
          },
          "defect_counted": 1,
          "processed_url": "processed_url",
          "is_raw_uploaded": true,
          "annotations": [
            null,
            null
          ],
          "file_size": 5,
          "processed": true,
          "content_type": "content_type",
          "width": 7,
          "model_results": [
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            },
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            }
          ],
          "position": "position",
          "image_id": 2,
          "raw_url": "raw_url",
          "height": 5
        }
      ],
      "item_id": "item_id",
      "name": "name",
      "active": true,
      "description": "description",
      "default_image": "default_image",
      "is_training_data": true,
      "override": {
        "result": "result",
        "detection_accuracy": 6,
        "label": "label",
        "detected_objects": 0
      },
      "thumbnail_image": "thumbnail_image",
      "status": "done"
    },
    {
      "models": [
        {
          "assessments": [
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            },
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            }
          ],
          "model_id": "model_id",
          "aggregate": {
            "label": "label",
            "detected_objects": 2.027123023002322
          }
        },
        {
          "assessments": [
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            },
            {
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "exif_metadata": {
                "key": "{}"
              },
              "defect_counted": 4,
              "processed_url": "processed_url",
              "is_raw_uploaded": true,
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "confirmed": true,
              "file_size": 1,
              "content_type": "content_type",
              "width": 1,
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_id": 7,
              "height": 1
            }
          ],
          "model_id": "model_id",
          "aggregate": {
            "label": "label",
            "detected_objects": 2.027123023002322
          }
        }
      ],
      "images": [
        {
          "exif_metadata": {
            "key": "{}"
          },
          "defect_counted": 1,
          "processed_url": "processed_url",
          "is_raw_uploaded": true,
          "annotations": [
            null,
            null
          ],
          "file_size": 5,
          "processed": true,
          "content_type": "content_type",
          "width": 7,
          "model_results": [
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            },
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            }
          ],
          "position": "position",
          "image_id": 2,
          "raw_url": "raw_url",
          "height": 5
        },
        {
          "exif_metadata": {
            "key": "{}"
          },
          "defect_counted": 1,
          "processed_url": "processed_url",
          "is_raw_uploaded": true,
          "annotations": [
            null,
            null
          ],
          "file_size": 5,
          "processed": true,
          "content_type": "content_type",
          "width": 7,
          "model_results": [
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            },
            {
              "result": "result",
              "computed": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "image_key": "image_key",
              "final": {
                "result": "result",
                "detection_accuracy": 6,
                "label": "label",
                "detected_objects": 0
              },
              "annotations": [
                null,
                null
              ],
              "created_at": "2000-01-23T04:56:07.000+00:00",
              "detection_accuracy": 3,
              "finished_date": "2000-01-23T04:56:07.000+00:00",
              "label": "OK",
              "model_id": "model_id",
              "confirmed": true,
              "detected_objects": 9
            }
          ],
          "position": "position",
          "image_id": 2,
          "raw_url": "raw_url",
          "height": 5
        }
      ],
      "item_id": "item_id",
      "name": "name",
      "active": true,
      "description": "description",
      "default_image": "default_image",
      "is_training_data": true,
      "override": {
        "result": "result",
        "detection_accuracy": 6,
        "label": "label",
        "detected_objects": 0
      },
      "thumbnail_image": "thumbnail_image",
      "status": "done"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|predict|[[Item](#schemaitem)]|false|none|[Item Model]|
|summary|[GetItemsResponse_data_summary](#schemagetitemsresponse_data_summary)|false|none|none|
|training|[[Item](#schemaitem)]|false|none|[Item Model]|

<h2 id="tocS_StatusOk_data">StatusOk_data</h2>
<!-- backwards compatibility -->
<a id="schemastatusok_data"></a>
<a id="schema_StatusOk_data"></a>
<a id="tocSstatusok_data"></a>
<a id="tocsstatusok_data"></a>

```json
{
  "status": "status"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|status|string|false|none|none|

<h2 id="tocS_GetWorkersResponse_data">GetWorkersResponse_data</h2>
<!-- backwards compatibility -->
<a id="schemagetworkersresponse_data"></a>
<a id="schema_GetWorkersResponse_data"></a>
<a id="tocSgetworkersresponse_data"></a>
<a id="tocsgetworkersresponse_data"></a>

```json
{
  "active_worker_count": 0,
  "in_progress": [
    {
      "queue_time": 1.4658129805029452,
      "result": "result",
      "start_time": 5.962133916683182,
      "end_time": 6.027456183070403,
      "type": "type"
    },
    {
      "queue_time": 1.4658129805029452,
      "result": "result",
      "start_time": 5.962133916683182,
      "end_time": 6.027456183070403,
      "type": "type"
    }
  ],
  "pending": [
    {
      "queue_time": 1.4658129805029452,
      "result": "result",
      "start_time": 5.962133916683182,
      "end_time": 6.027456183070403,
      "type": "type"
    },
    {
      "queue_time": 1.4658129805029452,
      "result": "result",
      "start_time": 5.962133916683182,
      "end_time": 6.027456183070403,
      "type": "type"
    }
  ],
  "done": [
    {
      "queue_time": 1.4658129805029452,
      "result": "result",
      "start_time": 5.962133916683182,
      "end_time": 6.027456183070403,
      "type": "type"
    },
    {
      "queue_time": 1.4658129805029452,
      "result": "result",
      "start_time": 5.962133916683182,
      "end_time": 6.027456183070403,
      "type": "type"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|active_worker_count|integer|false|none|none|
|done|[[Worker](#schemaworker)]|false|none|[Worker Model]|
|in_progress|[[Worker](#schemaworker)]|false|none|[Worker Model]|
|pending|[[Worker](#schemaworker)]|false|none|[Worker Model]|

<h2 id="tocS_Model_stats">Model_stats</h2>
<!-- backwards compatibility -->
<a id="schemamodel_stats"></a>
<a id="schema_Model_stats"></a>
<a id="tocSmodel_stats"></a>
<a id="tocsmodel_stats"></a>

```json
{
  "precision": {
    "projected": 7.061401241503109,
    "computed": 2.3021358869347655
  },
  "recall": {
    "projected": 7.061401241503109,
    "computed": 2.3021358869347655
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|precision|[Stat](#schemastat)|false|none|Precision and Recall Model|
|recall|[Stat](#schemastat)|false|none|Precision and Recall Model|

<h2 id="tocS_ItemModels_aggregate">ItemModels_aggregate</h2>
<!-- backwards compatibility -->
<a id="schemaitemmodels_aggregate"></a>
<a id="schema_ItemModels_aggregate"></a>
<a id="tocSitemmodels_aggregate"></a>
<a id="tocsitemmodels_aggregate"></a>

```json
{
  "label": "label",
  "detected_objects": 2.027123023002322
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|detected_objects|number¦null|false|none|none|
|label|string¦null|false|none|none|

<h2 id="tocS_AlgorithmParameter_allOf">AlgorithmParameter_allOf</h2>
<!-- backwards compatibility -->
<a id="schemaalgorithmparameter_allof"></a>
<a id="schema_AlgorithmParameter_allOf"></a>
<a id="tocSalgorithmparameter_allof"></a>
<a id="tocsalgorithmparameter_allof"></a>

```json
{
  "data_type": "string",
  "display_name": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data_type|string|true|none|none|
|display_name|string|true|none|none|

<h2 id="tocS_Annotation_allOf">Annotation_allOf</h2>
<!-- backwards compatibility -->
<a id="schemaannotation_allof"></a>
<a id="schema_Annotation_allOf"></a>
<a id="tocSannotation_allof"></a>
<a id="tocsannotation_allof"></a>

```json
{
  "image_id": "string",
  "model_id": "string",
  "annotation_id": 0,
  "for_training": true
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|image_id|string¦null|false|none|none|
|model_id|string¦null|false|none|none|
|annotation_id|integer|true|none|none|
|for_training|boolean¦null|false|none|none|



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
