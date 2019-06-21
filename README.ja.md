Visual Inspection Api for C#
===
*[English](README.md) | [日本語](README.ja.md)*

ハカルスはメーカーとメディカル事業に向けて軽量と解釈できるAIソリューションズを提供しています。

私たちの技術はスパースモデリングに基づいて、人間のようにデータを理解でき、独特な特徴である機械学習手法である。スパースモデリングの軽量のデザインのおかげで、コンピューティングパワー、クラウド接続、および可用性のある学習データの資源制限環境に特に有用である。 

私たちのソリューションズは組み込みシステムでオフラインの環境かクラウドモジュールとして実行できます。伝統的なDLベースの侵入よりも、私たちははるかに多くリソース効率的で、よりよく結果を確保できます。

ハカルスの外観検査ソリューションの詳細を参照するには、こちらのリンク、https://hacarus.com/visual-inspection/ をご覧になってください。または、APIのアクセスリクエストはinquiry@hacarus.comまで連絡してください。

この外観検査 Api wrapper for C#はapi通して外観検査モジュールを統合したいソフトウエアエンジニアに向けて、wrapperはC#ベースのアプリケーションSupports .Net Framework 4.6.1 and .Net Core 2.0.メソッドコールの簡単な統合を提供しています。


- [インストール](#インストール)
- [条項](#条項)
- [使用法](#使用法)
  * [1. 初期化](#1-初期化)
  * [2. 承認する](#2-承認する)
  * [3. ライセンスをアクティベート](#3-ライセンスをアクティベート)
  * [4. データを入手する](#4-データを入手する)
  * [5. アルゴリズムを入手する](#5-アルゴリズムを入手する)
  * [6. モデルを入手する](#6-モデルを入手する)
  * [7. 学習](#7-学習)
  * [8. データを追加する](#8-データを追加する)
  * [9. 特定のデータを入手](#9-特定のデータを入手)
  * [10. 予測](#10-予測)
- [一般的なエラー](#一般的なエラー)

## インストール
このパッケージをプロジェクトにインストールするため、こちらのコマンドをPackage Manager Consoleに使用してください。


```
PM> Install-Package HacarusVisualInspectionApi -Version 1.0.0-beta
```

これを「Add packages」を使用してプロジェクトに追加し、Show prerelease packagesを確認して、 HacarusVisualInspectionApi を [nuget.org](nuget.org)のリポジトリで検索してください。


他のインストール選択は[Nuget Package Site](https://www.nuget.org/packages/HacarusVisualInspectionApi/1.0.0-beta)にあります。

## 用語
このドキュメントの全体で使用されている用語の簡単な説明：

**モデル**
モデルは一連のパラメータの設定とともに、データセットの学習データ（トレーニングデータとも呼ばれる）をアルゴリズムに適用して、作成できます（または、学習できます）。


**アルゴリズム**
アルゴリズムはモデルを構成するため使われている機械学習コード　－　外観検査作業の性質と予想される精度および性能によって選択されます。


**学習**
新しいモデルを制作することのプロセスである。

**パラメータ**
パラメータは、学習中にアルゴリズムを適用する方法を構成するために使用されます。 例えば、最小または最大受けられる画像解像度などに適用できます。


**データ**
データ（アイテムとも呼ばれる)は検査の対象となる単一のプロダクトのデータを表します。 1つのデータに1つまたは複数の画像を関連付けることができます。
例：倉庫内の梱包箱。6つの箱の各側面に6つの画像があります。

## 使用方法

#### 1. 初期設定

```csharp
using HacarusVisualInspectionApi;
HacarusVisualInspection visualInspection = new HacarusVisualInspection("https://yourserverurl.com/api");
```

- ライブラリを初期化します
- エンドポイントURLをパラメータとして使用
- エンドポイントが使用されていない場合、ライブラリはデフォルトのエンドポイントhttps://sdd.hacarus.com/apiを使用します。
- 個別のエンドポイントURLは、リクエストに応じてHacarusから提供されます。


#### 2. 認証

```csharp
using HacarusVisualInspectionApi.Models;
AccessTokenResponse response = visualInspection.Authorize(YourClientId, YourClientSecret);
```

- アクセストークンを生成します
- クライアントIDとクライアントシークレットをパラメータとして使用する
- クライアントIDとクライアントシークレットは、リクエストに応じてHacarusから提供されます。


##### リスポンスの一例

```json
{
    "data": {
        "access_token": "GeneratedAccessToken",
        "expires": 2592000
    }
}
```

##### 起こり得るエラー

- `401 Unauthorized`: クライエントIDは無効

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

- `401 Unauthorized`: クライアントシークレットが無効です

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

#### 3. ライセンスをアクティベートする

```csharp
using HacarusVisualInspectionApi.Models;
UploadResponse response = hacarusVisualInspection.ActivateLicense(customerId, licenseFile);
```

- ライセンスをアクティベート
- カスタマーIDとライセンスファイル両方ともパラメータとして追加してください。
- ライセンスはユーザーが`Train` または `Predict`というファンクションを使用できる前にアクティベートしてください。
- ライセンスファイルを得るため、ハカルスを連絡してください。



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

- `403 Forbidden`: Customer ID or license file is invalid  
```json
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "http://yourserverurl.com/api/auth/license"
        },
        "status": 403,
        "title": "Invalid license!"
    }
}
```

#### 4. データを取得する

```csharp
using HacarusVisualInspectionApi.Models;
ItemsResponse response = visualInspection.GetItems();
```

- 学習、推論、およびアーカイブ別に分類したアップロード済みアイテムのリストを取得します。
    - `training`: 学習に使用するデータ
        - データが`true`（good）、`false`（defect）、または`null`（ラベルなし）のいずれかにラベル付けされているかをgoodというキーで知ることができます。
    - `predict`: アップロード済みのデータのうち、推論用のもの
        - 推論結果を確認するには、`good`と`status`のキーを確認してください
    - `archived`: アーカイブ済みデータ（将来実装予定の機能、現在使用されていません）
- `override_assessment`および`confirm_assessment`はウエブサイト（UI）固有のものであり、SDKを使用している場合は無視できます。


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
    
#### 5. アルゴリズムの一覧を取得

```csharp
using HacarusVisualInspectionApi.Models;
AlgorithmResponse response = visualInspection.GetAlgorithms();
```

- 学習に使用できるアルゴリズムと使用できるパラメータをリストで返します

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

- `404 NotFound`: 利用可能なアルゴリズムがありません。 この問題が発生した場合はHacarusに連絡してください

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
    
#### 6. モデルの一覧を取得

```csharp
using HacarusVisualInspectionApi.Models;
ModelsResponse response = visualInspection.GetModels();
```

- データを予測するのに使用できる作成済みモデルのリストを取得します
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
using HacarusVisualInspectionApi.Models;
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

ModelRootObject reponse = visualInspection.Train(algorithmId, modelName, itemIds, new AlgorithmParameter[] { algorithmParameter });
```

- 予測に使用するモデルを作成します
- モデルの学習に使用するデータIDの配列を含むオプションのパラメータを入力します
- アルゴリズムの設定を調整するためAlgorithmParameterの配列を入力します
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
using HacarusVisualInspectionApi.Models;
UploadResponse response = visualInspection.Upload(filenames, isGood, isTraining);
```

- このメソッドを使用して、学習または予測のためのデータをアップロードしてラベルを付けます
- データに良品または不良品としてラベルを付ける場合は、`isGood`パラメータをブール値で`true`（良品）または`false`（不良品）に設定します。それ以外の場合は、`null`（ラベルなし）を使用します。
- データをアップロードする場合、データを予測に使用するか学習に使用するかを設定するには、`isTraining`パラメーターを使用します。 `isTraining`パラメータは必要です。
- `filenames`パラメータを使用して`ImageModel`の配列を渡します。 `ImageModel`は`filename`と`contentType`のプロパティを持ちます。
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

- `400 BadRequest`: ファイル名かファイル形の無効

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

- `400 BadRequest`: アップロード用の画像が送信されていません

```json
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/v1/upload"
        },
        "status": "No images to upload",
        "title": 400
    }
}
```
        
#### 9. 特定のデータを取得する

```csharp
using HacarusVisualInspectionApi.Models;
//Set a specific itemId to get detailed information about the item
ItemResponse response = visualInspection.GetItem(itemId);
```

- データIDで特定のデータを取得する
- データIDは、アップロード時に画像ファイル名に基づいて割り当てられます。
- 重要なキー:
    - `computed_assessment`: 予測の結果
    - `annotations`: `Serve`メソッドが呼び出されたときに生成されるアノテーションのリストを含みます
    - `raw_url`: アップロードされたファイルのURL
    - `url`: 欠陥箇所表示ファイル（緑色のボックス）
    - `status`: データのステータス。`pending`（未予測または予測中）または完了（predicted）のいずれか。

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
        "status": 404,
        "title": "No permission to view item!"
    }
}
```

#### 10. 予測

```csharp
using HacarusVisualInspectionApi.Models;
//Use itemIds to pass an array of item ids you want to set for prediction
//You may use a specific model for prediction by setting a modelId value. This is optional. IF not set, the active/default model will be used.
PredictResponse response = visualInspection.Serve(itemIds, modelId);
```

- データは良品か不良品があるか予測します
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

- `400 BadRequest`: 予測に使用できるモデルがないか、使用可能なモデルのステータスがの`failed`です。 `Train`メソッドを使用し、新しいモデルを作成してください。


```json
{
    "errors": {
        "detail": null,
        "source": {
            "pointer": "/api/v1/serve"
        },
        "status": 404,
        "title": "There is no available model"
    }
}
```

##  一般的なエラー
- メソッドを呼び出すときにまだ承認されていないエラーが出ました。エラーを遭遇する場合、最初に`Authorize`メソッドを呼び出してください。

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

- メソッドを呼び出すが、ライセンスがまだアクティベートされていないか期限切れになっているときのエラー。 遭遇したら、最初に`ActivateLicense`メソッドを呼び出してください。

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
