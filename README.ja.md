Visual Inspection Api for C#
===
*[English](README.md) | [日本語](README.ja.md)*

ハカルスはメーカーとメディカル事業に向け、軽量で説明可能なAIソリューションズを提供しています。

弊社のスパースモデリングに基づいた技術は、人間のようにデータを理解できる独自の機械学習手法です。スパースモデリングは軽量に設計されているため、コンピューティングパワー、クラウド環境、および少量の学習データなどの資源の制限された環境下で特に有用です。

弊社のソリューションは組み込みシステムでオフライン環境かクラウドで実行できます。伝統的なディープラーニングベースの手法に比べ、資源を効率的に使用し、よりよい結果を提供します。

ハカルスの外観検査ソリューションの詳細を参照するには、こちらのリンク、https://hacarus.com/ja/visual-inspection/ をご覧ください。また、APIへのアクセスのリクエストはhttps://hacarus.com/ja/contact/ までご連絡ください。

この外観検査用 API wrapper for C#は、あなたのC#のプロジェクトに、APIを通じて外観検査モジュールを組み込むことができます。このライブラリはC# .Net Framework 4.6.1 と.Net Core 2.0.をサポートしています。


- [インストール](#インストール)
- [用語説明](#用語説明)
- [使用方法](#使用方法)
  * [1. 初期化](#1-初期化)
  * [2. 認証](#2-認証)
  * [3. ライセンスのアクティベート](#3-ライセンスのアクティベート)
  * [4. データを取得する](#4-データを取得する)
  * [5. アルゴリズムを取得する](#5-アルゴリズムを取得する)
  * [6. モデルを取得する](#6-モデルを取得する)
  * [7. 学習](#7-学習)
  * [8. データを追加する](#8-データを追加する)
  * [9. 特定のデータを取得する](#9-特定のデータを取得する)
  * [10. 予測](#10-予測)
- [一般的なエラー](#一般的なエラー)

## インストール
このパッケージをプロジェクトにインストールするため、こちらのコマンドをPackage Manager Consoleに入力してください。


```
PM> Install-Package HacarusVisualInspectionApi -Version 1.0.0-beta
```

NuGetパッケージマネージャを使用してプロジェクトに追加することもできます。Show prerelease packagesにチェックを入れ、 HacarusVisualInspectionApi を [nuget.org](nuget.org)のリポジトリで検索してください。


他のインストール方法は[Nuget Package Site](https://www.nuget.org/packages/HacarusVisualInspectionApi/1.0.0-beta)を参照ください。

## 用語説明
このドキュメントの全体で使用されている用語の簡単な説明：

**モデル**
モデルは一連のパラメータの設定とともに、データセットの学習データ（トレーニングデータ）をアルゴリズムに適用して、作成・学習できます。


**アルゴリズム**
アルゴリズムはモデルを構成するため使用する機械学習アルゴリズムのことです。外観検査の性質と予想される精度および性能によって選択します。


**学習**
新しいモデルを作成する操作です。

**パラメータ**
パラメータは、学習中にアルゴリズムを適用する方法を構成するために使用されます。 例えば、最小または最大の画像解像度などがあります。

**データ**
データ（アイテムとも呼ばれる)は検査の対象となる単一の製品のデータを表します。 1つのデータに1つまたは複数の画像を関連付けることができます。
例：倉庫内の梱包箱の場合、一つの箱に6つの面の画像があります。

## 使用方法

#### 1. 初期化

```csharp
using HacarusVisualInspectionApi;
using HacarusVisualInspectionApi.Models;
HacarusVisualInspection visualInspection = new HacarusVisualInspection("https://yourserverurl.com/api");
```

- ライブラリを初期化します。
- エンドポイントURLを引数として入力。
- エンドポイントが入力されていない場合、ライブラリはデフォルトのエンドポイント https://sdd.hacarus.com/api を使用します。
- 個別のエンドポイントURLは、リクエストに応じてHacarusから提供されます。

#### 2. 認証

```csharp
AccessTokenResponse response = visualInspection.Authorize(YourClientId, YourClientSecret);
```

- アクセストークンを生成します。
- クライアントIDとクライアントシークレットを引数として入力する。
- クライアントIDとクライアントシークレットは、リクエストに応じてHacarusから提供されます。


##### レスポンスの一例

```json
{
    "data": {
        "access_token": "GeneratedAccessToken",
        "expires": 2592000
    }
}
```

##### 起こり得るエラー

- `401 Unauthorized`: クライアントIDが無効です。

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

- `401 Unauthorized`: クライアントシークレットが無効です。

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

#### 3. ライセンスのアクティベート

```csharp
UploadResponse response = visualInspection.ActivateLicense(licenseFile, customerId);
```

- ライセンスをアクティベートします。
- ライセンスファイルとカスタマーIDを引数として入力してください。
- ライセンスはユーザーが`Train` または `Predict`というファンクションを使用する前にアクティベートしてください。
- ライセンスファイルを取得するには、ハカルスにご連絡ください。



##### レスポンスの一例
```json
{
    "data": {
        "customer_id": "test_client",
        "status": "ok"
    }
}
```

#### 起こり得るエラー

- `403 Forbidden`: 得意先コードまたはライセンスファイルが無効。  
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


- `403 Forbidden`: ライセンスはアクティベート済み。
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

#### 4. データを取得する

```csharp
ItemsResponse response = visualInspection.GetItems();
```

- 学習、推論、およびアーカイブ別に分類したアップロード済みアイテムのリストを取得します。
    - `training`: 学習に使用するデータ
        - データが`true`（good）、`false`（defect）、または`null`（ラベルなし）のいずれかにラベル付けされているかをgoodというキーで知ることができます。
    - `predict`: アップロード済みのデータのうち、推論用のもの
        - 推論結果を確認するには、`good`と`status`のキーを確認してください。
    - `archived`: アーカイブ済みデータ（将来実装予定の機能、現在使用されていません）
- `override_assessment`および`confirm_assessment`はUI（ユーザインタフェース）固有のものであり、SDKを使用している場合は無視できます。


##### レスポンスの一例

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
            "default_image": "https://hacarus-saas-data.s3.amazonaws.com/raw/b21d29f794e781e12f466a1fcc1bf1a1596e5320",
            "description": null,
            "detected_objects": 0,
            "finished_date": null,
            "good": true,
            "is_training_data": true,
            "item_id": "T1-22-01",
            "label": "Job id is T1-22-01",
            "override_assessment": true,
            "status": "pending",
            "thumbnail_image": "https://hacarus-saas-data.s3.amazonaws.com/thumbnail/b21d29f794e781e12f466a1fcc1bf1a1596e5320"
            }
        ]
    }
}
```
    
#### 5. アルゴリズムを取得する

```csharp
AlgorithmResponse response = visualInspection.GetAlgorithms();
```

- 学習に使用できるアルゴリズムと使用できるパラメータの一覧をリストで返します。

##### レスポンスの一例

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


##### 起こり得るエラー

- `404 NotFound`: 利用可能なアルゴリズムがありません。 この問題が発生した場合はHacarusに連絡してください。

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
    
#### 6. モデルを取得する

```csharp
ModelsResponse response = visualInspection.GetModels();
```

- データを推論するのに使用できる作成済みモデルのリストを取得します。
- モデルIDが渡されなかった場合（`Serve`メソッドを使用して）、`active`が`true`のモデルをデフォルトとして使用します。
- `status`キーは、モデルが`active`か`failed`かを示します。 
    - `status`が `active`のモデルは正常に作成され、予測に使用できます
    - `status`が `failed`のモデルは作成に失敗し、予測には使用できません

##### レスポンスの一例

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
    
#### 7. 学習

```csharp
//ID of the algorithm you want to use
var algorithmId = "hacarus-dictionary-learning";
//Name of your model
var modelName = "ModelName";
//Array of of item ids to use for training the model
var itemIds = new string[] { "item_id" };
//Algorithm parameter you want to adjust and use for training the model
AlgorithmParameter algorithmParameter = new AlgorithmParameter();
algorithmParameter.algorithm_parameter_id = 221;
algorithmParameter.value = "50";

ModelResponse reponse = visualInspection.Train(algorithmId, modelName, itemIds, new AlgorithmParameter[] { algorithmParameter });
```

- 推論に使用するモデルを作成します。
- モデルの学習に使用するデータIDの配列を含むオプションのパラメータを入力します。
- アルゴリズムの設定を調整するためAlgorithmParameterの配列を入力します。
- 新しく作成したモデルを確認するには、GetModels（）メソッドを使用します。
    

##### レスポンスの一例

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

##### 起こり得るエラー

- `403 Forbidden`: 少なくとも1つのデータIDがクライアントに属していないか、無効か、または存在しません。

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

#### 8. データを追加する

```csharp
UploadResponse response = visualInspection.Upload(filenames, isGood, isTraining);
```

- このメソッドを使用して、学習または推論のためのデータをアップロードしてラベルを付けます。
- データに良品または不良品としてラベルを付ける場合は、`isGood`パラメータをブール値で`true`（良品）または`false`（不良品）に設定します。それ以外の場合は、`null`（ラベルなし）を使用します。
- データをアップロードする場合、データを推論に使用するか学習に使用するかを設定するには、`isTraining`パラメーターを使用します。 isTrainingパラメータは必要です。

- `filenames`パラメータを使用して`FileModel`の配列を渡します。 `FileModel`は`filename`と`contentType`のプロパティを持ちます。
- アップロードしたデータを確認するには、`GetItems（）`メソッドを使用します。
- 画像のファイル名はデータID(`item_id`)として使用します。
- サポートされているファイル形式：`png`、`jpeg`、`tiff`

##### レスポンスの一例

```json
{
    "data": {
        "item_ids": [
            "IMG6760_U"
        ]
    }
}
```

##### 起こり得るエラー

- `400 BadRequest`: ファイル名かファイル形の無効。

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

- `400 BadRequest`: アップロード用の画像が送信されていません。

```json
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/v1/upload"
        },
        "status": 400,
        "title": "No images to upload"
    }
}
```
        
#### 9. 特定のデータを取得する

```csharp
//Set a specific itemId to get detailed information about the item
ItemResponse response = visualInspection.GetItem(itemId);
```

- データIDで特定のデータを取得します。
- データIDは、アップロード時に画像ファイル名に基づいて割り当てられます。
- 重要なキー:
    - `computed_assessment`: 予測の結果
    - `annotations`: `Serve`メソッドが呼び出されたときに生成されるアノテーションのリストを含みます
    - `raw_url`: アップロードされたファイルのURL
    - `url`: 欠陥箇所表示ファイル（緑色のボックス）
    - `status`: データのステータス。`pending`（推論前または予測中）または`done`（予測済み）のいずれか

##### レスポンスの一例

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

##### 起こり得るエラー

- `404 NotFound`: データIDが存在していません。

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

- `401 Unauthorized`: 指定されたデータIDのあるデータがクライアントに属していません。

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

#### 10. 予測

```csharp
//Use itemIds to pass an array of item ids you want to set for prediction
//You may use a specific model for prediction by setting a modelId value. This is optional. IF not set, the active/default model will be used.
PredictResponse response = visualInspection.Serve(itemIds, modelId);
```

- データは良品か不良品があるか推論します。
- 結果を確認するには、`GetItems()`メソッドを使用して、各データの`good`キーを確認します。

##### レスポンスの一例
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

##### 起こり得るエラー

- `404 NotFound`: 送信されたデータとデータIDは存在していません。

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

- `400 BadRequest`: 推論に使用できるモデルがないか、使用可能なモデルのステータスがの`failed`です。 `Train`メソッドを使用し、新しいモデルを作成してください。


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

##  一般的なエラー
- メソッドを呼び出すときにまだ承認されていないエラーです。エラーを遭遇する場合、最初に`Authorize`メソッドを呼び出してください。

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

- メソッドを呼び出すが、ライセンスがまだアクティベートされていないか期限切れになっているときのエラーです。 遭遇したら、最初に`ActivateLicense`メソッドを呼び出してください。

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
