---
title: Saas web detection v1
language_tabs:
  - shell: Shell
  - http: HTTP
  - javascript: JavaScript
  - ruby: Ruby
  - python: Python
  - php: PHP
  - java: Java
  - go: Go
toc_footers: []
includes: []
search: true
highlight_theme: darkula
headingLevel: 2

---

<!-- Generator: Widdershins v3.6.6 -->

<h1 id="saas-web-detection">Saas web detection v1</h1>

> Scroll down for code samples, example requests and responses. Select a language for code samples from the tabs above or the mobile navigation menu.

Base URLs:

* <a href="https://spectro-demo.hacarus.com/">https://spectro-demo.hacarus.com/</a>

* <a href="https://sdd-api.hacarus.com/">https://sdd-api.hacarus.com/</a>

* <a href="https://spectro-local.hacarus.com/">https://spectro-local.hacarus.com/</a>

# Authentication

- HTTP Authentication, scheme: bearer

- oAuth2 authentication.

    - Flow: clientCredentials

    - Token URL = [http://localhost:3000/api/auth/token](http://localhost:3000/api/auth/token)

|Scope|Scope Description|
|---|---|
|all|all scopes|

<h1 id="saas-web-detection-targets">targets</h1>

Inspection Target related operations

## I18n.t(:getInspectionTargets, default: data.operationUniqueName)

<a id="opIdgetInspectionTargets"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://spectro-demo.hacarus.com/api/v1/targets/ \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
GET https://spectro-demo.hacarus.com/api/v1/targets/ HTTP/1.1
Host: spectro-demo.hacarus.com
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/targets/',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.get 'https://spectro-demo.hacarus.com/api/v1/targets/',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.get('https://spectro-demo.hacarus.com/api/v1/targets/', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('GET','https://spectro-demo.hacarus.com/api/v1/targets/', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/targets/");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("GET");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("GET", "https://spectro-demo.hacarus.com/api/v1/targets/", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`GET /api/v1/targets/`

*Get List of Inpection Targets*

Get all inspection targets created by user

> Example responses

> 200 Response

```json
{
  "data": [
    {
      "name": "string",
      "target_id": 0,
      "preprocessing": [
        {
          "name": "string",
          "active": true,
          "config": "string"
        }
      ]
    }
  ]
}
```

<h3 id="getinspectiontargets-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[InspectionTargetListWrapper](#schemainspectiontargetlistwrapper)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:getInspectionTargetById, default: data.operationUniqueName)

<a id="opIdgetInspectionTargetById"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://spectro-demo.hacarus.com/api/v1/targets/{target_id} \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
GET https://spectro-demo.hacarus.com/api/v1/targets/{target_id} HTTP/1.1
Host: spectro-demo.hacarus.com
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/targets/{target_id}',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.get 'https://spectro-demo.hacarus.com/api/v1/targets/{target_id}',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.get('https://spectro-demo.hacarus.com/api/v1/targets/{target_id}', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('GET','https://spectro-demo.hacarus.com/api/v1/targets/{target_id}', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/targets/{target_id}");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("GET");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("GET", "https://spectro-demo.hacarus.com/api/v1/targets/{target_id}", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`GET /api/v1/targets/{target_id}`

*Get Inspection Target by ID*

Get a single inspection target using the inspection target ID.

<h3 id="getinspectiontargetbyid-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|target_id|path|string|true|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "name": "string",
    "target_id": 0,
    "preprocessing": [
      {
        "name": "string",
        "active": true,
        "config": "string"
      }
    ]
  }
}
```

<h3 id="getinspectiontargetbyid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[InspectionTargetWrapper](#schemainspectiontargetwrapper)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:setInspectionTargetById, default: data.operationUniqueName)

<a id="opIdsetInspectionTargetById"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://spectro-demo.hacarus.com/api/v1/targets/{target_id} \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST https://spectro-demo.hacarus.com/api/v1/targets/{target_id} HTTP/1.1
Host: spectro-demo.hacarus.com
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/targets/{target_id}',
{
  method: 'POST',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post 'https://spectro-demo.hacarus.com/api/v1/targets/{target_id}',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('https://spectro-demo.hacarus.com/api/v1/targets/{target_id}', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','https://spectro-demo.hacarus.com/api/v1/targets/{target_id}', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/targets/{target_id}");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "https://spectro-demo.hacarus.com/api/v1/targets/{target_id}", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/v1/targets/{target_id}`

*Set Default Inspection Target by ID*

Set the default inspection target using the inspection target ID.

<h3 id="setinspectiontargetbyid-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|target_id|path|string|true|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "name": "string",
    "target_id": 0,
    "preprocessing": [
      {
        "name": "string",
        "active": true,
        "config": "string"
      }
    ]
  }
}
```

<h3 id="setinspectiontargetbyid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[InspectionTargetWrapper](#schemainspectiontargetwrapper)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:getModelResults, default: data.operationUniqueName)

<a id="opIdgetModelResults"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://spectro-demo.hacarus.com/api/v1/targets/model/results \
  -H 'Accept: application/octet-stream' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST https://spectro-demo.hacarus.com/api/v1/targets/model/results HTTP/1.1
Host: spectro-demo.hacarus.com
Accept: application/octet-stream

```

```javascript

const headers = {
  'Accept':'application/octet-stream',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/targets/model/results',
{
  method: 'POST',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'application/octet-stream',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post 'https://spectro-demo.hacarus.com/api/v1/targets/model/results',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'application/octet-stream',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('https://spectro-demo.hacarus.com/api/v1/targets/model/results', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'application/octet-stream',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','https://spectro-demo.hacarus.com/api/v1/targets/model/results', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/targets/model/results");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"application/octet-stream"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "https://spectro-demo.hacarus.com/api/v1/targets/model/results", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/v1/targets/model/results`

<h3 id="getmodelresults-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|model_ids|query|array[string]|false|none|

> Example responses

> 200 Response

> 422 Response

```json
{
  "errors": {
    "detail": "string",
    "message": [
      {
        "errors": [
          "string"
        ],
        "key": "string"
      }
    ],
    "source": {
      "pointer": "string"
    },
    "title": "string",
    "status": 0
  }
}
```

<h3 id="getmodelresults-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|CSV file containing the model/s results|string|
|422|[Unprocessable Entity](https://tools.ietf.org/html/rfc2518#section-10.3)|Unprocessable Entity|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

<h1 id="saas-web-detection-algorithms">algorithms</h1>

Algorithm related operations

## I18n.t(:getAlgorithms, default: data.operationUniqueName)

<a id="opIdgetAlgorithms"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://spectro-demo.hacarus.com/api/v1/algorithms/ \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
GET https://spectro-demo.hacarus.com/api/v1/algorithms/ HTTP/1.1
Host: spectro-demo.hacarus.com
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/algorithms/',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.get 'https://spectro-demo.hacarus.com/api/v1/algorithms/',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.get('https://spectro-demo.hacarus.com/api/v1/algorithms/', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('GET','https://spectro-demo.hacarus.com/api/v1/algorithms/', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/algorithms/");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("GET");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("GET", "https://spectro-demo.hacarus.com/api/v1/algorithms/", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`GET /api/v1/algorithms/`

*Get List of Algorithms*

<ul>
  <li>
    Returns list of available algorithms including parameters that can be used to create a model
  </li>
  <li>
    Algorithm documentation available <a href='https://hacarus.github.io/HacarusVisualInspectionApi/#t-algorithmswithversion'>here</a>
  </li>
</ul>

> Example responses

> 200 Response

```json
{
  "data": [
    {
      "created_at": "2020-10-19T10:35:37Z",
      "name": "string",
      "parameters": [
        {
          "created_at": "2020-10-19T10:35:37Z",
          "value": "string",
          "range_upper": "string",
          "display_name": "string",
          "name": "string",
          "data_type": "string",
          "updated_at": "2020-10-19T10:35:37Z",
          "range_lower": "string",
          "algorithm_id": "string",
          "model_parameter": true,
          "algorithm_parameter_id": 0
        }
      ],
      "version": "string",
      "attribute": "string",
      "algorithm_id": "string",
      "type": "string",
      "file_name": "string",
      "class_name": "string",
      "updated_at": "2020-10-19T10:35:37Z"
    }
  ]
}
```

<h3 id="getalgorithms-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[AlgorithmWithParameterListWrapper](#schemaalgorithmwithparameterlistwrapper)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:getAlgorithmById, default: data.operationUniqueName)

<a id="opIdgetAlgorithmById"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id} \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
GET https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id} HTTP/1.1
Host: spectro-demo.hacarus.com
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.get 'https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.get('https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('GET','https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("GET");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("GET", "https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`GET /api/v1/algorithms/{algorithm_id}`

*Get Algorithm by ID*

Get a single algorithm by ID

<h3 id="getalgorithmbyid-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|algorithm_id|path|string|true|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "created_at": "2020-10-19T10:35:37Z",
    "name": "string",
    "parameters": [
      {
        "created_at": "2020-10-19T10:35:37Z",
        "value": "string",
        "range_upper": "string",
        "display_name": "string",
        "name": "string",
        "data_type": "string",
        "updated_at": "2020-10-19T10:35:37Z",
        "range_lower": "string",
        "algorithm_id": "string",
        "model_parameter": true,
        "algorithm_parameter_id": 0
      }
    ],
    "version": "string",
    "attribute": "string",
    "algorithm_id": "string",
    "type": "string",
    "file_name": "string",
    "class_name": "string",
    "updated_at": "2020-10-19T10:35:37Z"
  }
}
```

<h3 id="getalgorithmbyid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[AlgorithmWithParameterWrapper](#schemaalgorithmwithparameterwrapper)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:train, default: data.operationUniqueName)

<a id="opIdtrain"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}/train \
  -H 'Content-Type: application/json' \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}/train HTTP/1.1
Host: spectro-demo.hacarus.com
Content-Type: application/json
Accept: application/json

```

```javascript
const inputBody = '{
  "name": "string",
  "item_ids": [
    "string"
  ],
  "override_params": [
    {
      "algorithm_parameter_id": 0,
      "value": "string"
    }
  ]
}';
const headers = {
  'Content-Type':'application/json',
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}/train',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Content-Type' => 'application/json',
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post 'https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}/train',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Content-Type': 'application/json',
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}/train', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Content-Type' => 'application/json',
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}/train', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}/train");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Content-Type": []string{"application/json"},
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "https://spectro-demo.hacarus.com/api/v1/algorithms/{algorithm_id}/train", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/v1/algorithms/{algorithm_id}/train`

*Train*

Train a model

> Body parameter

```json
{
  "name": "string",
  "item_ids": [
    "string"
  ],
  "override_params": [
    {
      "algorithm_parameter_id": 0,
      "value": "string"
    }
  ]
}
```

<h3 id="train-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[TrainRequest](#schematrainrequest)|true|none|
|algorithm_id|path|string|true|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "created_at": "2020-10-19T10:35:37Z",
    "stats": {
      "accuracy": 0,
      "precision": {
        "computed": 0,
        "projected": 0
      },
      "recall": {
        "computed": 0,
        "projected": 0
      }
    },
    "training_time": 0,
    "model_id": "string",
    "name": "string",
    "ok_img_count": 0,
    "ng_img_count": 0,
    "status_text": "string",
    "version": "string",
    "image_url": "string",
    "precision": 0,
    "active": true,
    "algorithm_id": "string",
    "algorithm_type": "string",
    "context_id": 0,
    "status": "string",
    "updated_at": "2020-10-19T10:35:37Z",
    "recall": 0
  }
}
```

<h3 id="train-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[HModelWrapper](#schemahmodelwrapper)|
|422|[Unprocessable Entity](https://tools.ietf.org/html/rfc2518#section-10.3)|Unprocessable Entity|[BaseError](#schemabaseerror)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

<h1 id="saas-web-detection-models">models</h1>

Model related operations

## I18n.t(:getModels, default: data.operationUniqueName)

<a id="opIdgetModels"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://spectro-demo.hacarus.com/api/v1/models/ \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
GET https://spectro-demo.hacarus.com/api/v1/models/ HTTP/1.1
Host: spectro-demo.hacarus.com
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/models/',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.get 'https://spectro-demo.hacarus.com/api/v1/models/',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.get('https://spectro-demo.hacarus.com/api/v1/models/', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('GET','https://spectro-demo.hacarus.com/api/v1/models/', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/models/");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("GET");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("GET", "https://spectro-demo.hacarus.com/api/v1/models/", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`GET /api/v1/models/`

*Get List of Models*

Get all models created by user

<h3 id="getmodels-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|algorithm_id|query|string|false|none|

> Example responses

> 200 Response

```json
{
  "data": [
    {
      "created_at": "2020-10-19T10:35:37Z",
      "stats": {
        "accuracy": 0,
        "precision": {
          "computed": 0,
          "projected": 0
        },
        "recall": {
          "computed": 0,
          "projected": 0
        }
      },
      "training_time": 0,
      "model_id": "string",
      "name": "string",
      "ok_img_count": 0,
      "ng_img_count": 0,
      "status_text": "string",
      "version": "string",
      "image_url": "string",
      "precision": 0,
      "active": true,
      "algorithm_id": "string",
      "algorithm_type": "string",
      "context_id": 0,
      "status": "string",
      "updated_at": "2020-10-19T10:35:37Z",
      "recall": 0
    }
  ]
}
```

<h3 id="getmodels-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[HModelListWrapper](#schemahmodellistwrapper)|
|422|[Unprocessable Entity](https://tools.ietf.org/html/rfc2518#section-10.3)|Unprocessable Entity|[BaseError](#schemabaseerror)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:deleteModels, default: data.operationUniqueName)

<a id="opIddeleteModels"></a>

> Code samples

```shell
# You can also use wget
curl -X DELETE https://spectro-demo.hacarus.com/api/v1/models/ \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
DELETE https://spectro-demo.hacarus.com/api/v1/models/ HTTP/1.1
Host: spectro-demo.hacarus.com
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/models/',
{
  method: 'DELETE',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.delete 'https://spectro-demo.hacarus.com/api/v1/models/',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.delete('https://spectro-demo.hacarus.com/api/v1/models/', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('DELETE','https://spectro-demo.hacarus.com/api/v1/models/', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/models/");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("DELETE");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("DELETE", "https://spectro-demo.hacarus.com/api/v1/models/", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`DELETE /api/v1/models/`

*Delete Models*

Delete models by id (list)

<h3 id="deletemodels-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|model_ids|query|array[string]|false|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "model_ids": [
      "string"
    ]
  }
}
```

<h3 id="deletemodels-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[ModelIdsQueryWrapper](#schemamodelidsquerywrapper)|
|422|[Unprocessable Entity](https://tools.ietf.org/html/rfc2518#section-10.3)|Unprocessable Entity|[BaseError](#schemabaseerror)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:getModelById, default: data.operationUniqueName)

<a id="opIdgetModelById"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://spectro-demo.hacarus.com/api/v1/models/{model_id} \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
GET https://spectro-demo.hacarus.com/api/v1/models/{model_id} HTTP/1.1
Host: spectro-demo.hacarus.com
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/models/{model_id}',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.get 'https://spectro-demo.hacarus.com/api/v1/models/{model_id}',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.get('https://spectro-demo.hacarus.com/api/v1/models/{model_id}', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('GET','https://spectro-demo.hacarus.com/api/v1/models/{model_id}', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/models/{model_id}");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("GET");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("GET", "https://spectro-demo.hacarus.com/api/v1/models/{model_id}", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`GET /api/v1/models/{model_id}`

*Get Model by ID*

Get a single model by ID

<h3 id="getmodelbyid-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|model_id|path|string|true|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "created_at": "2020-10-19T10:35:37Z",
    "stats": {
      "accuracy": 0,
      "precision": {
        "computed": 0,
        "projected": 0
      },
      "recall": {
        "computed": 0,
        "projected": 0
      }
    },
    "training_time": 0,
    "model_id": "string",
    "name": "string",
    "ok_img_count": 0,
    "ng_img_count": 0,
    "status_text": "string",
    "version": "string",
    "image_url": "string",
    "precision": 0,
    "active": true,
    "algorithm_id": "string",
    "algorithm_type": "string",
    "context_id": 0,
    "status": "string",
    "updated_at": "2020-10-19T10:35:37Z",
    "recall": 0
  }
}
```

<h3 id="getmodelbyid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[HModelWrapper](#schemahmodelwrapper)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:exportModelsWithId, default: data.operationUniqueName)

<a id="opIdexportModelsWithId"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://spectro-demo.hacarus.com/api/v1/models/export \
  -H 'Content-Type: application/json' \
  -H 'Accept: application/zip' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST https://spectro-demo.hacarus.com/api/v1/models/export HTTP/1.1
Host: spectro-demo.hacarus.com
Content-Type: application/json
Accept: application/zip

```

```javascript
const inputBody = '{
  "model_ids": [
    "string"
  ]
}';
const headers = {
  'Content-Type':'application/json',
  'Accept':'application/zip',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/models/export',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Content-Type' => 'application/json',
  'Accept' => 'application/zip',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post 'https://spectro-demo.hacarus.com/api/v1/models/export',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Content-Type': 'application/json',
  'Accept': 'application/zip',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('https://spectro-demo.hacarus.com/api/v1/models/export', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Content-Type' => 'application/json',
    'Accept' => 'application/zip',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','https://spectro-demo.hacarus.com/api/v1/models/export', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/models/export");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Content-Type": []string{"application/json"},
        "Accept": []string{"application/zip"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "https://spectro-demo.hacarus.com/api/v1/models/export", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/v1/models/export`

*Export models*

Export models given the Id

> Body parameter

```json
{
  "model_ids": [
    "string"
  ]
}
```

<h3 id="exportmodelswithid-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[ModelIdsQuery](#schemamodelidsquery)|true|none|

> Example responses

> 200 Response

> 422 Response

```json
{
  "errors": {
    "detail": "string",
    "message": [
      {
        "errors": [
          "string"
        ],
        "key": "string"
      }
    ],
    "source": {
      "pointer": "string"
    },
    "title": "string",
    "status": 0
  }
}
```

<h3 id="exportmodelswithid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Zip file containing the model/s|string|
|422|[Unprocessable Entity](https://tools.ietf.org/html/rfc2518#section-10.3)|Unprocessable Entity|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:importModels, default: data.operationUniqueName)

<a id="opIdimportModels"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://spectro-demo.hacarus.com/api/v1/models/import \
  -H 'Content-Type: multipart/form-data' \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST https://spectro-demo.hacarus.com/api/v1/models/import HTTP/1.1
Host: spectro-demo.hacarus.com
Content-Type: multipart/form-data
Accept: application/json

```

```javascript
const inputBody = '{
  "models": "string"
}';
const headers = {
  'Content-Type':'multipart/form-data',
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/models/import',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Content-Type' => 'multipart/form-data',
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post 'https://spectro-demo.hacarus.com/api/v1/models/import',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Content-Type': 'multipart/form-data',
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('https://spectro-demo.hacarus.com/api/v1/models/import', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Content-Type' => 'multipart/form-data',
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','https://spectro-demo.hacarus.com/api/v1/models/import', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/models/import");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Content-Type": []string{"multipart/form-data"},
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "https://spectro-demo.hacarus.com/api/v1/models/import", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/v1/models/import`

*Import models*

Import models from the zip file

> Body parameter

```yaml
models: string

```

<h3 id="importmodels-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[ImportModels](#schemaimportmodels)|true|none|

> Example responses

> 200 Response

```json
{
  "data": [
    {
      "created_at": "2020-10-19T10:35:37Z",
      "stats": {
        "accuracy": 0,
        "precision": {
          "computed": 0,
          "projected": 0
        },
        "recall": {
          "computed": 0,
          "projected": 0
        }
      },
      "training_time": 0,
      "model_id": "string",
      "name": "string",
      "ok_img_count": 0,
      "ng_img_count": 0,
      "status_text": "string",
      "version": "string",
      "image_url": "string",
      "precision": 0,
      "active": true,
      "algorithm_id": "string",
      "algorithm_type": "string",
      "context_id": 0,
      "status": "string",
      "updated_at": "2020-10-19T10:35:37Z",
      "recall": 0
    }
  ]
}
```

<h3 id="importmodels-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[HModelListWrapper](#schemahmodellistwrapper)|
|422|[Unprocessable Entity](https://tools.ietf.org/html/rfc2518#section-10.3)|Unprocessable Entity|[BaseError](#schemabaseerror)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:predictItems, default: data.operationUniqueName)

<a id="opIdpredictItems"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://spectro-demo.hacarus.com/api/v1/models/{model_id}/predict \
  -H 'Content-Type: application/json' \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST https://spectro-demo.hacarus.com/api/v1/models/{model_id}/predict HTTP/1.1
Host: spectro-demo.hacarus.com
Content-Type: application/json
Accept: application/json

```

```javascript
const inputBody = '{
  "item_ids": [
    "string"
  ]
}';
const headers = {
  'Content-Type':'application/json',
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/models/{model_id}/predict',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Content-Type' => 'application/json',
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post 'https://spectro-demo.hacarus.com/api/v1/models/{model_id}/predict',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Content-Type': 'application/json',
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('https://spectro-demo.hacarus.com/api/v1/models/{model_id}/predict', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Content-Type' => 'application/json',
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','https://spectro-demo.hacarus.com/api/v1/models/{model_id}/predict', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/models/{model_id}/predict");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Content-Type": []string{"application/json"},
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "https://spectro-demo.hacarus.com/api/v1/models/{model_id}/predict", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/v1/models/{model_id}/predict`

*Predict Items*

Predict items in the background

> Body parameter

```json
{
  "item_ids": [
    "string"
  ]
}
```

<h3 id="predictitems-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[Predict](#schemapredict)|true|none|
|model_id|path|string|true|The model id, set to "active" to use current active model|

> Example responses

> 200 Response

```json
{
  "data": {
    "item_ids": [
      "string"
    ],
    "model_version": "string"
  }
}
```

<h3 id="predictitems-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[PredictItemsResponseWrapper](#schemapredictitemsresponsewrapper)|
|422|[Unprocessable Entity](https://tools.ietf.org/html/rfc2518#section-10.3)|Unprocessable Entity|[BaseError](#schemabaseerror)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

<h1 id="saas-web-detection-items">items</h1>

Item related operations

## I18n.t(:getItemsByType, default: data.operationUniqueName)

<a id="opIdgetItemsByType"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://spectro-demo.hacarus.com/api/v1/items/?item_type=string \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
GET https://spectro-demo.hacarus.com/api/v1/items/?item_type=string HTTP/1.1
Host: spectro-demo.hacarus.com
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/items/?item_type=string',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.get 'https://spectro-demo.hacarus.com/api/v1/items/',
  params: {
  'item_type' => 'string'
}, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.get('https://spectro-demo.hacarus.com/api/v1/items/', params={
  'item_type': 'string'
}, headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('GET','https://spectro-demo.hacarus.com/api/v1/items/', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/items/?item_type=string");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("GET");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("GET", "https://spectro-demo.hacarus.com/api/v1/items/", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`GET /api/v1/items/`

*Get List of Items*

Returns items based on given `item_type` (prediction, training)

<h3 id="getitemsbytype-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|count|query|integer(int32)|false|none|
|page|query|integer(int32)|false|none|
|model_id|query|string|false|none|
|item_type|query|string|true|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "items": [
      {
        "item_id": "string",
        "assessments": [
          {
            "model_id": "string",
            "annotations": [
              {
                "created_at": "2020-10-19T10:35:37Z",
                "annotation_id": 0,
                "x_min": 0,
                "x_max": 0,
                "y_min": 0,
                "label": 0,
                "y_max": 0,
                "notes": "string"
              }
            ],
            "detection_accuracy": 0,
            "images": [
              {
                "height": 0,
                "name": "string",
                "file_size": 0,
                "width": 0,
                "url": "string"
              }
            ],
            "result": "string",
            "detected_objects": 0,
            "label": "string"
          }
        ],
        "name": "string",
        "user_assessment": {
          "label": "string",
          "images": [
            {
              "height": 0,
              "name": "string",
              "file_size": 0,
              "width": 0,
              "url": "string"
            }
          ],
          "result": "string",
          "annotations": [
            {
              "created_at": "2020-10-19T10:35:37Z",
              "annotation_id": 0,
              "x_min": 0,
              "x_max": 0,
              "y_min": 0,
              "label": 0,
              "y_max": 0,
              "notes": "string"
            }
          ]
        },
        "active": true,
        "is_training_data": true,
        "images": [
          {
            "height": 0,
            "name": "string",
            "file_size": 0,
            "width": 0,
            "url": "string"
          }
        ],
        "status": "string"
      }
    ],
    "current_page": 0,
    "end_page": 0,
    "count_per_page": 0
  }
}
```

<h3 id="getitemsbytype-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[GetItemsResponseWrapper](#schemagetitemsresponsewrapper)|
|422|[Unprocessable Entity](https://tools.ietf.org/html/rfc2518#section-10.3)|Unprocessable Entity|[BaseError](#schemabaseerror)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:addItem, default: data.operationUniqueName)

<a id="opIdaddItem"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://spectro-demo.hacarus.com/api/v1/items/ \
  -H 'Content-Type: multipart/form-data' \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST https://spectro-demo.hacarus.com/api/v1/items/ HTTP/1.1
Host: spectro-demo.hacarus.com
Content-Type: multipart/form-data
Accept: application/json

```

```javascript
const inputBody = '{
  "files": [
    "string"
  ],
  "training": true,
  "good": true,
  "model_id": "string"
}';
const headers = {
  'Content-Type':'multipart/form-data',
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/items/',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Content-Type' => 'multipart/form-data',
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post 'https://spectro-demo.hacarus.com/api/v1/items/',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Content-Type': 'multipart/form-data',
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('https://spectro-demo.hacarus.com/api/v1/items/', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Content-Type' => 'multipart/form-data',
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','https://spectro-demo.hacarus.com/api/v1/items/', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/items/");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Content-Type": []string{"multipart/form-data"},
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "https://spectro-demo.hacarus.com/api/v1/items/", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/v1/items/`

*Add Item*

Add prediction or training item/s. This endpoint also gives you an option to tag an item as Good or Bad

> Body parameter

```yaml
files:
  - string
training: true
good: true
model_id: string

```

<h3 id="additem-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[AddItemRequest](#schemaadditemrequest)|true|none|

> Example responses

> 201 Response

```json
{
  "data": {
    "item_ids": [
      "string"
    ]
  }
}
```

<h3 id="additem-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|201|[Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)|CREATED|[AddItemResponseWrapper](#schemaadditemresponsewrapper)|
|422|[Unprocessable Entity](https://tools.ietf.org/html/rfc2518#section-10.3)|Unprocessable Entity|[BaseError](#schemabaseerror)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:getItemById, default: data.operationUniqueName)

<a id="opIdgetItemById"></a>

> Code samples

```shell
# You can also use wget
curl -X GET https://spectro-demo.hacarus.com/api/v1/items/{item_id} \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
GET https://spectro-demo.hacarus.com/api/v1/items/{item_id} HTTP/1.1
Host: spectro-demo.hacarus.com
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/items/{item_id}',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.get 'https://spectro-demo.hacarus.com/api/v1/items/{item_id}',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.get('https://spectro-demo.hacarus.com/api/v1/items/{item_id}', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('GET','https://spectro-demo.hacarus.com/api/v1/items/{item_id}', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/items/{item_id}");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("GET");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("GET", "https://spectro-demo.hacarus.com/api/v1/items/{item_id}", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`GET /api/v1/items/{item_id}`

*Get Item by Id*

Get specific item and annotations

<h3 id="getitembyid-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|show_assessments|query|boolean|false|none|
|show_annotations|query|boolean|false|none|
|model_id|query|string|false|none|
|item_id|path|string|true|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "item_id": "string",
    "assessments": [
      {
        "model_id": "string",
        "annotations": [
          {
            "created_at": "2020-10-19T10:35:37Z",
            "annotation_id": 0,
            "x_min": 0,
            "x_max": 0,
            "y_min": 0,
            "label": 0,
            "y_max": 0,
            "notes": "string"
          }
        ],
        "detection_accuracy": 0,
        "images": [
          {
            "height": 0,
            "name": "string",
            "file_size": 0,
            "width": 0,
            "url": "string"
          }
        ],
        "result": "string",
        "detected_objects": 0,
        "label": "string"
      }
    ],
    "name": "string",
    "user_assessment": {
      "label": "string",
      "images": [
        {
          "height": 0,
          "name": "string",
          "file_size": 0,
          "width": 0,
          "url": "string"
        }
      ],
      "result": "string",
      "annotations": [
        {
          "created_at": "2020-10-19T10:35:37Z",
          "annotation_id": 0,
          "x_min": 0,
          "x_max": 0,
          "y_min": 0,
          "label": 0,
          "y_max": 0,
          "notes": "string"
        }
      ]
    },
    "active": true,
    "is_training_data": true,
    "images": [
      {
        "height": 0,
        "name": "string",
        "file_size": 0,
        "width": 0,
        "url": "string"
      }
    ],
    "status": "string"
  }
}
```

<h3 id="getitembyid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[ItemWrapper](#schemaitemwrapper)|
|422|[Unprocessable Entity](https://tools.ietf.org/html/rfc2518#section-10.3)|Unprocessable Entity|[BaseError](#schemabaseerror)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:annotate, default: data.operationUniqueName)

<a id="opIdannotate"></a>

> Code samples

```shell
# You can also use wget
curl -X PATCH https://spectro-demo.hacarus.com/api/v1/items/{item_id} \
  -H 'Content-Type: application/json' \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
PATCH https://spectro-demo.hacarus.com/api/v1/items/{item_id} HTTP/1.1
Host: spectro-demo.hacarus.com
Content-Type: application/json
Accept: application/json

```

```javascript
const inputBody = '{
  "annotations": [
    {
      "x_max": 0,
      "x_min": 0,
      "y_max": 0,
      "y_min": 0,
      "label": 0,
      "notes": "string"
    }
  ]
}';
const headers = {
  'Content-Type':'application/json',
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/items/{item_id}',
{
  method: 'PATCH',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Content-Type' => 'application/json',
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.patch 'https://spectro-demo.hacarus.com/api/v1/items/{item_id}',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Content-Type': 'application/json',
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.patch('https://spectro-demo.hacarus.com/api/v1/items/{item_id}', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Content-Type' => 'application/json',
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('PATCH','https://spectro-demo.hacarus.com/api/v1/items/{item_id}', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/items/{item_id}");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("PATCH");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Content-Type": []string{"application/json"},
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("PATCH", "https://spectro-demo.hacarus.com/api/v1/items/{item_id}", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`PATCH /api/v1/items/{item_id}`

> Body parameter

```json
{
  "annotations": [
    {
      "x_max": 0,
      "x_min": 0,
      "y_max": 0,
      "y_min": 0,
      "label": 0,
      "notes": "string"
    }
  ]
}
```

<h3 id="annotate-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[AnnotateItemRequest](#schemaannotateitemrequest)|true|none|
|item_id|path|string|true|none|

> Example responses

> 422 Response

```json
{
  "errors": {
    "detail": "string",
    "message": [
      {
        "errors": [
          "string"
        ],
        "key": "string"
      }
    ],
    "source": {
      "pointer": "string"
    },
    "title": "string",
    "status": 0
  }
}
```

<h3 id="annotate-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|202|[Accepted](https://tools.ietf.org/html/rfc7231#section-6.3.3)|ACCEPTED|None|
|422|[Unprocessable Entity](https://tools.ietf.org/html/rfc2518#section-10.3)|Unprocessable Entity|[BaseError](#schemabaseerror)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

<h1 id="saas-web-detection-utils">utils</h1>

Support and utility functions

## I18n.t(:setLicense, default: data.operationUniqueName)

<a id="opIdsetLicense"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://spectro-demo.hacarus.com/api/v1/utils/ \
  -H 'Content-Type: multipart/form-data' \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST https://spectro-demo.hacarus.com/api/v1/utils/ HTTP/1.1
Host: spectro-demo.hacarus.com
Content-Type: multipart/form-data
Accept: application/json

```

```javascript
const inputBody = '{
  "license_data": "string"
}';
const headers = {
  'Content-Type':'multipart/form-data',
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/utils/',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Content-Type' => 'multipart/form-data',
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post 'https://spectro-demo.hacarus.com/api/v1/utils/',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Content-Type': 'multipart/form-data',
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('https://spectro-demo.hacarus.com/api/v1/utils/', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Content-Type' => 'multipart/form-data',
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','https://spectro-demo.hacarus.com/api/v1/utils/', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/utils/");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Content-Type": []string{"multipart/form-data"},
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "https://spectro-demo.hacarus.com/api/v1/utils/", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/v1/utils/`

> Body parameter

```yaml
license_data: string

```

<h3 id="setlicense-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[License](#schemalicense)|true|none|

> Example responses

> 200 Response

```json
{
  "data": {
    "license_expiry": "string"
  }
}
```

<h3 id="setlicense-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[LicenseResponseWrapper](#schemalicenseresponsewrapper)|
|422|[Unprocessable Entity](https://tools.ietf.org/html/rfc2518#section-10.3)|Unprocessable Entity|[BaseError](#schemabaseerror)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:getLogs, default: data.operationUniqueName)

<a id="opIdgetLogs"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://spectro-demo.hacarus.com/api/v1/utils/debug \
  -H 'Accept: application/octet-stream' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST https://spectro-demo.hacarus.com/api/v1/utils/debug HTTP/1.1
Host: spectro-demo.hacarus.com
Accept: application/octet-stream

```

```javascript

const headers = {
  'Accept':'application/octet-stream',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/utils/debug',
{
  method: 'POST',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'application/octet-stream',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post 'https://spectro-demo.hacarus.com/api/v1/utils/debug',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'application/octet-stream',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('https://spectro-demo.hacarus.com/api/v1/utils/debug', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'application/octet-stream',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','https://spectro-demo.hacarus.com/api/v1/utils/debug', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/utils/debug");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"application/octet-stream"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "https://spectro-demo.hacarus.com/api/v1/utils/debug", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/v1/utils/debug`

> Example responses

> 200 Response

<h3 id="getlogs-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|ZIP file containing the debug logs|string|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

## I18n.t(:getHashId, default: data.operationUniqueName)

<a id="opIdgetHashId"></a>

> Code samples

```shell
# You can also use wget
curl -X POST https://spectro-demo.hacarus.com/api/v1/utils/node_hash \
  -H 'Accept: application/json' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST https://spectro-demo.hacarus.com/api/v1/utils/node_hash HTTP/1.1
Host: spectro-demo.hacarus.com
Accept: application/json

```

```javascript

const headers = {
  'Accept':'application/json',
  'Authorization':'Bearer {access-token}'

};

fetch('https://spectro-demo.hacarus.com/api/v1/utils/node_hash',
{
  method: 'POST',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'application/json',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post 'https://spectro-demo.hacarus.com/api/v1/utils/node_hash',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'application/json',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('https://spectro-demo.hacarus.com/api/v1/utils/node_hash', headers = headers)

print r.json()

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'application/json',
    'Authorization' => 'Bearer {access-token}',

    );

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','https://spectro-demo.hacarus.com/api/v1/utils/node_hash', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("https://spectro-demo.hacarus.com/api/v1/utils/node_hash");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"application/json"},
        "Authorization": []string{"Bearer {access-token}"},

    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "https://spectro-demo.hacarus.com/api/v1/utils/node_hash", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/v1/utils/node_hash`

> Example responses

> 200 Response

```json
{
  "data": {
    "hash_id": "string"
  }
}
```

<h3 id="gethashid-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|OK|[LicenseHashResponseWrapper](#schemalicensehashresponsewrapper)|
|default|Default|Default error response|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

<h1 id="saas-web-detection-spectro">Spectro</h1>

Generic operations

## I18n.t(:login, default: data.operationUniqueName)

<a id="opIdlogin"></a>

> Code samples

```csharp
LoginParams loginParams = new LoginParams(
  clientId: "client id",
  clientSecret: "client secret",
  grantType: "client_credentials"
);
var resp = instance.Login(loginParams);

```

`POST /api/auth/token`

*Authorization*

Returns the access token

> Body parameter

```json
{
  "grant_type": "client_credentials",
  "client_secret": "client_secret",
  "client_id": "client_id"
}
```

<h3 id="login-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[LoginParams](#schemaloginparams)|true|none|

> Example responses

> 200 Response

```json
{
  "access_token": "access_token"
}
```

<h3 id="login-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successful login|[LoginResponse](#schemaloginresponse)|
|default|Default|default error handler|[BaseError](#schemabaseerror)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
jwt, oauth2
</aside>

# Schemas

<h2 id="tocS_KeyValueError">KeyValueError</h2>
<!-- backwards compatibility -->
<a id="schemakeyvalueerror"></a>
<a id="schema_KeyValueError"></a>
<a id="tocSkeyvalueerror"></a>
<a id="tocskeyvalueerror"></a>

```json
{
  "errors": [
    "string"
  ],
  "key": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|errors|[string]|false|none|none|
|key|string|false|none|Error key|

<h2 id="tocS_ErrorSource">ErrorSource</h2>
<!-- backwards compatibility -->
<a id="schemaerrorsource"></a>
<a id="schema_ErrorSource"></a>
<a id="tocSerrorsource"></a>
<a id="tocserrorsource"></a>

```json
{
  "pointer": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|pointer|string|false|none|Endpoint errored|

<h2 id="tocS_Error">Error</h2>
<!-- backwards compatibility -->
<a id="schemaerror"></a>
<a id="schema_Error"></a>
<a id="tocSerror"></a>
<a id="tocserror"></a>

```json
{
  "detail": "string",
  "message": [
    {
      "errors": [
        "string"
      ],
      "key": "string"
    }
  ],
  "source": {
    "pointer": "string"
  },
  "title": "string",
  "status": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|detail|string|false|none|Error Details|
|message|[[KeyValueError](#schemakeyvalueerror)]|false|none|none|
|source|[ErrorSource](#schemaerrorsource)|false|none|Error Source|
|title|string|false|none|Error Title|
|status|integer(int32)|false|none|Error status code|

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
    "message": [
      {
        "errors": [
          "string"
        ],
        "key": "string"
      }
    ],
    "source": {
      "pointer": "string"
    },
    "title": "string",
    "status": 0
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|errors|[Error](#schemaerror)|false|none|none|

<h2 id="tocS_LoginResponse">LoginResponse</h2>
<!-- backwards compatibility -->
<a id="schemaloginresponse"></a>
<a id="schema_LoginResponse"></a>
<a id="tocSloginresponse"></a>
<a id="tocsloginresponse"></a>

```json
{
  "access_token": "access_token"
}

```

response object of login

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|access_token|string|true|none|none|

<h2 id="tocS_LoginParams">LoginParams</h2>
<!-- backwards compatibility -->
<a id="schemaloginparams"></a>
<a id="schema_LoginParams"></a>
<a id="tocSloginparams"></a>
<a id="tocsloginparams"></a>

```json
{
  "grant_type": "client_credentials",
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

<h2 id="tocS_Preprocessing">Preprocessing</h2>
<!-- backwards compatibility -->
<a id="schemapreprocessing"></a>
<a id="schema_Preprocessing"></a>
<a id="tocSpreprocessing"></a>
<a id="tocspreprocessing"></a>

```json
{
  "name": "string",
  "active": true,
  "config": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|name|string|true|none|none|
|active|boolean¦null|false|none|none|
|config|string¦null|false|none|none|

<h2 id="tocS_InspectionTarget">InspectionTarget</h2>
<!-- backwards compatibility -->
<a id="schemainspectiontarget"></a>
<a id="schema_InspectionTarget"></a>
<a id="tocSinspectiontarget"></a>
<a id="tocsinspectiontarget"></a>

```json
{
  "name": "string",
  "target_id": 0,
  "preprocessing": [
    {
      "name": "string",
      "active": true,
      "config": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|name|string|false|none|none|
|target_id|integer(int32)|false|none|none|
|preprocessing|[[Preprocessing](#schemapreprocessing)]|false|none|none|

<h2 id="tocS_InspectionTargetListWrapper">InspectionTargetListWrapper</h2>
<!-- backwards compatibility -->
<a id="schemainspectiontargetlistwrapper"></a>
<a id="schema_InspectionTargetListWrapper"></a>
<a id="tocSinspectiontargetlistwrapper"></a>
<a id="tocsinspectiontargetlistwrapper"></a>

```json
{
  "data": [
    {
      "name": "string",
      "target_id": 0,
      "preprocessing": [
        {
          "name": "string",
          "active": true,
          "config": "string"
        }
      ]
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[[InspectionTarget](#schemainspectiontarget)]|false|none|none|

<h2 id="tocS_InspectionTargetWrapper">InspectionTargetWrapper</h2>
<!-- backwards compatibility -->
<a id="schemainspectiontargetwrapper"></a>
<a id="schema_InspectionTargetWrapper"></a>
<a id="tocSinspectiontargetwrapper"></a>
<a id="tocsinspectiontargetwrapper"></a>

```json
{
  "data": {
    "name": "string",
    "target_id": 0,
    "preprocessing": [
      {
        "name": "string",
        "active": true,
        "config": "string"
      }
    ]
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[InspectionTarget](#schemainspectiontarget)|false|none|none|

<h2 id="tocS_AlgorithmParameter">AlgorithmParameter</h2>
<!-- backwards compatibility -->
<a id="schemaalgorithmparameter"></a>
<a id="schema_AlgorithmParameter"></a>
<a id="tocSalgorithmparameter"></a>
<a id="tocsalgorithmparameter"></a>

```json
{
  "created_at": "2020-10-19T10:35:37Z",
  "value": "string",
  "range_upper": "string",
  "display_name": "string",
  "name": "string",
  "data_type": "string",
  "updated_at": "2020-10-19T10:35:37Z",
  "range_lower": "string",
  "algorithm_id": "string",
  "model_parameter": true,
  "algorithm_parameter_id": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|created_at|string(date-time)|true|none|none|
|value|string¦null|false|none|none|
|range_upper|string¦null|false|none|none|
|display_name|string¦null|false|none|none|
|name|string|true|none|none|
|data_type|string|false|none|none|
|updated_at|string(date-time)|true|none|none|
|range_lower|string¦null|false|none|none|
|algorithm_id|string|true|none|none|
|model_parameter|boolean¦null|false|none|none|
|algorithm_parameter_id|integer(int32)|false|none|none|

<h2 id="tocS_AlgorithmWithParameter">AlgorithmWithParameter</h2>
<!-- backwards compatibility -->
<a id="schemaalgorithmwithparameter"></a>
<a id="schema_AlgorithmWithParameter"></a>
<a id="tocSalgorithmwithparameter"></a>
<a id="tocsalgorithmwithparameter"></a>

```json
{
  "created_at": "2020-10-19T10:35:37Z",
  "name": "string",
  "parameters": [
    {
      "created_at": "2020-10-19T10:35:37Z",
      "value": "string",
      "range_upper": "string",
      "display_name": "string",
      "name": "string",
      "data_type": "string",
      "updated_at": "2020-10-19T10:35:37Z",
      "range_lower": "string",
      "algorithm_id": "string",
      "model_parameter": true,
      "algorithm_parameter_id": 0
    }
  ],
  "version": "string",
  "attribute": "string",
  "algorithm_id": "string",
  "type": "string",
  "file_name": "string",
  "class_name": "string",
  "updated_at": "2020-10-19T10:35:37Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|created_at|string(date-time)|true|none|none|
|name|string|true|none|none|
|parameters|[[AlgorithmParameter](#schemaalgorithmparameter)]|false|none|none|
|version|string¦null|false|none|none|
|attribute|string|false|none|none|
|algorithm_id|string|true|none|none|
|type|string|false|none|none|
|file_name|string|true|none|none|
|class_name|string|true|none|none|
|updated_at|string(date-time)|true|none|none|

<h2 id="tocS_AlgorithmWithParameterListWrapper">AlgorithmWithParameterListWrapper</h2>
<!-- backwards compatibility -->
<a id="schemaalgorithmwithparameterlistwrapper"></a>
<a id="schema_AlgorithmWithParameterListWrapper"></a>
<a id="tocSalgorithmwithparameterlistwrapper"></a>
<a id="tocsalgorithmwithparameterlistwrapper"></a>

```json
{
  "data": [
    {
      "created_at": "2020-10-19T10:35:37Z",
      "name": "string",
      "parameters": [
        {
          "created_at": "2020-10-19T10:35:37Z",
          "value": "string",
          "range_upper": "string",
          "display_name": "string",
          "name": "string",
          "data_type": "string",
          "updated_at": "2020-10-19T10:35:37Z",
          "range_lower": "string",
          "algorithm_id": "string",
          "model_parameter": true,
          "algorithm_parameter_id": 0
        }
      ],
      "version": "string",
      "attribute": "string",
      "algorithm_id": "string",
      "type": "string",
      "file_name": "string",
      "class_name": "string",
      "updated_at": "2020-10-19T10:35:37Z"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[[AlgorithmWithParameter](#schemaalgorithmwithparameter)]|false|none|none|

<h2 id="tocS_AlgorithmWithParameterWrapper">AlgorithmWithParameterWrapper</h2>
<!-- backwards compatibility -->
<a id="schemaalgorithmwithparameterwrapper"></a>
<a id="schema_AlgorithmWithParameterWrapper"></a>
<a id="tocSalgorithmwithparameterwrapper"></a>
<a id="tocsalgorithmwithparameterwrapper"></a>

```json
{
  "data": {
    "created_at": "2020-10-19T10:35:37Z",
    "name": "string",
    "parameters": [
      {
        "created_at": "2020-10-19T10:35:37Z",
        "value": "string",
        "range_upper": "string",
        "display_name": "string",
        "name": "string",
        "data_type": "string",
        "updated_at": "2020-10-19T10:35:37Z",
        "range_lower": "string",
        "algorithm_id": "string",
        "model_parameter": true,
        "algorithm_parameter_id": 0
      }
    ],
    "version": "string",
    "attribute": "string",
    "algorithm_id": "string",
    "type": "string",
    "file_name": "string",
    "class_name": "string",
    "updated_at": "2020-10-19T10:35:37Z"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[AlgorithmWithParameter](#schemaalgorithmwithparameter)|false|none|none|

<h2 id="tocS_OverrideParam">OverrideParam</h2>
<!-- backwards compatibility -->
<a id="schemaoverrideparam"></a>
<a id="schema_OverrideParam"></a>
<a id="tocSoverrideparam"></a>
<a id="tocsoverrideparam"></a>

```json
{
  "algorithm_parameter_id": 0,
  "value": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|algorithm_parameter_id|integer(int32)|false|none|none|
|value|string|false|none|none|

<h2 id="tocS_TrainRequest">TrainRequest</h2>
<!-- backwards compatibility -->
<a id="schematrainrequest"></a>
<a id="schema_TrainRequest"></a>
<a id="tocStrainrequest"></a>
<a id="tocstrainrequest"></a>

```json
{
  "name": "string",
  "item_ids": [
    "string"
  ],
  "override_params": [
    {
      "algorithm_parameter_id": 0,
      "value": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|name|string|false|none|none|
|item_ids|[string]|false|none|none|
|override_params|[[OverrideParam](#schemaoverrideparam)]|false|none|none|

<h2 id="tocS_HModelPrecision">HModelPrecision</h2>
<!-- backwards compatibility -->
<a id="schemahmodelprecision"></a>
<a id="schema_HModelPrecision"></a>
<a id="tocShmodelprecision"></a>
<a id="tocshmodelprecision"></a>

```json
{
  "computed": 0,
  "projected": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|computed|number¦null|false|none|none|
|projected|number¦null|false|none|none|

<h2 id="tocS_HModelStats">HModelStats</h2>
<!-- backwards compatibility -->
<a id="schemahmodelstats"></a>
<a id="schema_HModelStats"></a>
<a id="tocShmodelstats"></a>
<a id="tocshmodelstats"></a>

```json
{
  "accuracy": 0,
  "precision": {
    "computed": 0,
    "projected": 0
  },
  "recall": {
    "computed": 0,
    "projected": 0
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|accuracy|number¦null|false|none|none|
|precision|[HModelPrecision](#schemahmodelprecision)|false|none|none|
|recall|[HModelPrecision](#schemahmodelprecision)|false|none|none|

<h2 id="tocS_HModel">HModel</h2>
<!-- backwards compatibility -->
<a id="schemahmodel"></a>
<a id="schema_HModel"></a>
<a id="tocShmodel"></a>
<a id="tocshmodel"></a>

```json
{
  "created_at": "2020-10-19T10:35:37Z",
  "stats": {
    "accuracy": 0,
    "precision": {
      "computed": 0,
      "projected": 0
    },
    "recall": {
      "computed": 0,
      "projected": 0
    }
  },
  "training_time": 0,
  "model_id": "string",
  "name": "string",
  "ok_img_count": 0,
  "ng_img_count": 0,
  "status_text": "string",
  "version": "string",
  "image_url": "string",
  "precision": 0,
  "active": true,
  "algorithm_id": "string",
  "algorithm_type": "string",
  "context_id": 0,
  "status": "string",
  "updated_at": "2020-10-19T10:35:37Z",
  "recall": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|created_at|string(date-time)|true|none|none|
|stats|[HModelStats](#schemahmodelstats)|false|none|none|
|training_time|integer(int32)¦null|false|none|none|
|model_id|string|true|none|none|
|name|string|true|none|none|
|ok_img_count|integer(int32)|false|none|none|
|ng_img_count|integer(int32)|false|none|none|
|status_text|string¦null|false|none|none|
|version|string|true|none|none|
|image_url|string¦null|false|none|none|
|precision|number¦null|false|none|none|
|active|boolean¦null|false|none|none|
|algorithm_id|string|true|none|none|
|algorithm_type|string|true|none|none|
|context_id|integer(int32)|true|none|none|
|status|string|false|none|none|
|updated_at|string(date-time)|true|none|none|
|recall|number¦null|false|none|none|

<h2 id="tocS_HModelWrapper">HModelWrapper</h2>
<!-- backwards compatibility -->
<a id="schemahmodelwrapper"></a>
<a id="schema_HModelWrapper"></a>
<a id="tocShmodelwrapper"></a>
<a id="tocshmodelwrapper"></a>

```json
{
  "data": {
    "created_at": "2020-10-19T10:35:37Z",
    "stats": {
      "accuracy": 0,
      "precision": {
        "computed": 0,
        "projected": 0
      },
      "recall": {
        "computed": 0,
        "projected": 0
      }
    },
    "training_time": 0,
    "model_id": "string",
    "name": "string",
    "ok_img_count": 0,
    "ng_img_count": 0,
    "status_text": "string",
    "version": "string",
    "image_url": "string",
    "precision": 0,
    "active": true,
    "algorithm_id": "string",
    "algorithm_type": "string",
    "context_id": 0,
    "status": "string",
    "updated_at": "2020-10-19T10:35:37Z",
    "recall": 0
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[HModel](#schemahmodel)|false|none|none|

<h2 id="tocS_HModelListWrapper">HModelListWrapper</h2>
<!-- backwards compatibility -->
<a id="schemahmodellistwrapper"></a>
<a id="schema_HModelListWrapper"></a>
<a id="tocShmodellistwrapper"></a>
<a id="tocshmodellistwrapper"></a>

```json
{
  "data": [
    {
      "created_at": "2020-10-19T10:35:37Z",
      "stats": {
        "accuracy": 0,
        "precision": {
          "computed": 0,
          "projected": 0
        },
        "recall": {
          "computed": 0,
          "projected": 0
        }
      },
      "training_time": 0,
      "model_id": "string",
      "name": "string",
      "ok_img_count": 0,
      "ng_img_count": 0,
      "status_text": "string",
      "version": "string",
      "image_url": "string",
      "precision": 0,
      "active": true,
      "algorithm_id": "string",
      "algorithm_type": "string",
      "context_id": 0,
      "status": "string",
      "updated_at": "2020-10-19T10:35:37Z",
      "recall": 0
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[[HModel](#schemahmodel)]|false|none|none|

<h2 id="tocS_ModelIdsQuery">ModelIdsQuery</h2>
<!-- backwards compatibility -->
<a id="schemamodelidsquery"></a>
<a id="schema_ModelIdsQuery"></a>
<a id="tocSmodelidsquery"></a>
<a id="tocsmodelidsquery"></a>

```json
{
  "model_ids": [
    "string"
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|model_ids|[string]|false|none|none|

<h2 id="tocS_ModelIdsQueryWrapper">ModelIdsQueryWrapper</h2>
<!-- backwards compatibility -->
<a id="schemamodelidsquerywrapper"></a>
<a id="schema_ModelIdsQueryWrapper"></a>
<a id="tocSmodelidsquerywrapper"></a>
<a id="tocsmodelidsquerywrapper"></a>

```json
{
  "data": {
    "model_ids": [
      "string"
    ]
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[ModelIdsQuery](#schemamodelidsquery)|false|none|none|

<h2 id="tocS_ImportModels">ImportModels</h2>
<!-- backwards compatibility -->
<a id="schemaimportmodels"></a>
<a id="schema_ImportModels"></a>
<a id="tocSimportmodels"></a>
<a id="tocsimportmodels"></a>

```json
{
  "models": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|models|string(binary)|false|none|none|

<h2 id="tocS_Predict">Predict</h2>
<!-- backwards compatibility -->
<a id="schemapredict"></a>
<a id="schema_Predict"></a>
<a id="tocSpredict"></a>
<a id="tocspredict"></a>

```json
{
  "item_ids": [
    "string"
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|item_ids|[string]|false|none|none|

<h2 id="tocS_PredictItemsResponse">PredictItemsResponse</h2>
<!-- backwards compatibility -->
<a id="schemapredictitemsresponse"></a>
<a id="schema_PredictItemsResponse"></a>
<a id="tocSpredictitemsresponse"></a>
<a id="tocspredictitemsresponse"></a>

```json
{
  "item_ids": [
    "string"
  ],
  "model_version": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|item_ids|[string]|false|none|none|
|model_version|string|false|none|none|

<h2 id="tocS_PredictItemsResponseWrapper">PredictItemsResponseWrapper</h2>
<!-- backwards compatibility -->
<a id="schemapredictitemsresponsewrapper"></a>
<a id="schema_PredictItemsResponseWrapper"></a>
<a id="tocSpredictitemsresponsewrapper"></a>
<a id="tocspredictitemsresponsewrapper"></a>

```json
{
  "data": {
    "item_ids": [
      "string"
    ],
    "model_version": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[PredictItemsResponse](#schemapredictitemsresponse)|false|none|none|

<h2 id="tocS_Annotation">Annotation</h2>
<!-- backwards compatibility -->
<a id="schemaannotation"></a>
<a id="schema_Annotation"></a>
<a id="tocSannotation"></a>
<a id="tocsannotation"></a>

```json
{
  "created_at": "2020-10-19T10:35:37Z",
  "annotation_id": 0,
  "x_min": 0,
  "x_max": 0,
  "y_min": 0,
  "label": 0,
  "y_max": 0,
  "notes": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|created_at|string(date-time)|true|none|none|
|annotation_id|integer(int32)|false|none|none|
|x_min|number¦null|false|none|none|
|x_max|number¦null|false|none|none|
|y_min|number¦null|false|none|none|
|label|integer(int32)¦null|false|none|none|
|y_max|number¦null|false|none|none|
|notes|string¦null|false|none|none|

<h2 id="tocS_ItemImageMeta">ItemImageMeta</h2>
<!-- backwards compatibility -->
<a id="schemaitemimagemeta"></a>
<a id="schema_ItemImageMeta"></a>
<a id="tocSitemimagemeta"></a>
<a id="tocsitemimagemeta"></a>

```json
{
  "height": 0,
  "name": "string",
  "file_size": 0,
  "width": 0,
  "url": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|height|integer(int32)|false|none|none|
|name|string|false|none|none|
|file_size|integer(int32)|false|none|none|
|width|integer(int32)|false|none|none|
|url|string|false|none|none|

<h2 id="tocS_AssessmentItem">AssessmentItem</h2>
<!-- backwards compatibility -->
<a id="schemaassessmentitem"></a>
<a id="schema_AssessmentItem"></a>
<a id="tocSassessmentitem"></a>
<a id="tocsassessmentitem"></a>

```json
{
  "model_id": "string",
  "annotations": [
    {
      "created_at": "2020-10-19T10:35:37Z",
      "annotation_id": 0,
      "x_min": 0,
      "x_max": 0,
      "y_min": 0,
      "label": 0,
      "y_max": 0,
      "notes": "string"
    }
  ],
  "detection_accuracy": 0,
  "images": [
    {
      "height": 0,
      "name": "string",
      "file_size": 0,
      "width": 0,
      "url": "string"
    }
  ],
  "result": "string",
  "detected_objects": 0,
  "label": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|model_id|string|false|none|none|
|annotations|[[Annotation](#schemaannotation)]|false|none|none|
|detection_accuracy|integer(int32)¦null|false|none|none|
|images|[[ItemImageMeta](#schemaitemimagemeta)]|false|none|none|
|result|string|false|none|none|
|detected_objects|integer(int32)¦null|false|none|none|
|label|string|false|none|none|

<h2 id="tocS_AssessmentItem1">AssessmentItem1</h2>
<!-- backwards compatibility -->
<a id="schemaassessmentitem1"></a>
<a id="schema_AssessmentItem1"></a>
<a id="tocSassessmentitem1"></a>
<a id="tocsassessmentitem1"></a>

```json
{
  "label": "string",
  "images": [
    {
      "height": 0,
      "name": "string",
      "file_size": 0,
      "width": 0,
      "url": "string"
    }
  ],
  "result": "string",
  "annotations": [
    {
      "created_at": "2020-10-19T10:35:37Z",
      "annotation_id": 0,
      "x_min": 0,
      "x_max": 0,
      "y_min": 0,
      "label": 0,
      "y_max": 0,
      "notes": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|label|string|false|none|none|
|images|[[ItemImageMeta](#schemaitemimagemeta)]|false|none|none|
|result|string|false|none|none|
|annotations|[[Annotation](#schemaannotation)]|false|none|none|

<h2 id="tocS_Item">Item</h2>
<!-- backwards compatibility -->
<a id="schemaitem"></a>
<a id="schema_Item"></a>
<a id="tocSitem"></a>
<a id="tocsitem"></a>

```json
{
  "item_id": "string",
  "assessments": [
    {
      "model_id": "string",
      "annotations": [
        {
          "created_at": "2020-10-19T10:35:37Z",
          "annotation_id": 0,
          "x_min": 0,
          "x_max": 0,
          "y_min": 0,
          "label": 0,
          "y_max": 0,
          "notes": "string"
        }
      ],
      "detection_accuracy": 0,
      "images": [
        {
          "height": 0,
          "name": "string",
          "file_size": 0,
          "width": 0,
          "url": "string"
        }
      ],
      "result": "string",
      "detected_objects": 0,
      "label": "string"
    }
  ],
  "name": "string",
  "user_assessment": {
    "label": "string",
    "images": [
      {
        "height": 0,
        "name": "string",
        "file_size": 0,
        "width": 0,
        "url": "string"
      }
    ],
    "result": "string",
    "annotations": [
      {
        "created_at": "2020-10-19T10:35:37Z",
        "annotation_id": 0,
        "x_min": 0,
        "x_max": 0,
        "y_min": 0,
        "label": 0,
        "y_max": 0,
        "notes": "string"
      }
    ]
  },
  "active": true,
  "is_training_data": true,
  "images": [
    {
      "height": 0,
      "name": "string",
      "file_size": 0,
      "width": 0,
      "url": "string"
    }
  ],
  "status": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|item_id|string|false|none|none|
|assessments|[[AssessmentItem](#schemaassessmentitem)]|false|none|none|
|name|string|false|none|none|
|user_assessment|[AssessmentItem1](#schemaassessmentitem1)|false|none|none|
|active|boolean|false|none|none|
|is_training_data|boolean|false|none|none|
|images|[[ItemImageMeta](#schemaitemimagemeta)]|false|none|none|
|status|string|false|none|none|

<h2 id="tocS_GetItemsResponse">GetItemsResponse</h2>
<!-- backwards compatibility -->
<a id="schemagetitemsresponse"></a>
<a id="schema_GetItemsResponse"></a>
<a id="tocSgetitemsresponse"></a>
<a id="tocsgetitemsresponse"></a>

```json
{
  "items": [
    {
      "item_id": "string",
      "assessments": [
        {
          "model_id": "string",
          "annotations": [
            {
              "created_at": "2020-10-19T10:35:37Z",
              "annotation_id": 0,
              "x_min": 0,
              "x_max": 0,
              "y_min": 0,
              "label": 0,
              "y_max": 0,
              "notes": "string"
            }
          ],
          "detection_accuracy": 0,
          "images": [
            {
              "height": 0,
              "name": "string",
              "file_size": 0,
              "width": 0,
              "url": "string"
            }
          ],
          "result": "string",
          "detected_objects": 0,
          "label": "string"
        }
      ],
      "name": "string",
      "user_assessment": {
        "label": "string",
        "images": [
          {
            "height": 0,
            "name": "string",
            "file_size": 0,
            "width": 0,
            "url": "string"
          }
        ],
        "result": "string",
        "annotations": [
          {
            "created_at": "2020-10-19T10:35:37Z",
            "annotation_id": 0,
            "x_min": 0,
            "x_max": 0,
            "y_min": 0,
            "label": 0,
            "y_max": 0,
            "notes": "string"
          }
        ]
      },
      "active": true,
      "is_training_data": true,
      "images": [
        {
          "height": 0,
          "name": "string",
          "file_size": 0,
          "width": 0,
          "url": "string"
        }
      ],
      "status": "string"
    }
  ],
  "current_page": 0,
  "end_page": 0,
  "count_per_page": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|items|[[Item](#schemaitem)]|false|none|none|
|current_page|integer(int32)|false|none|none|
|end_page|integer(int32)|false|none|none|
|count_per_page|integer(int32)|false|none|none|

<h2 id="tocS_GetItemsResponseWrapper">GetItemsResponseWrapper</h2>
<!-- backwards compatibility -->
<a id="schemagetitemsresponsewrapper"></a>
<a id="schema_GetItemsResponseWrapper"></a>
<a id="tocSgetitemsresponsewrapper"></a>
<a id="tocsgetitemsresponsewrapper"></a>

```json
{
  "data": {
    "items": [
      {
        "item_id": "string",
        "assessments": [
          {
            "model_id": "string",
            "annotations": [
              {
                "created_at": "2020-10-19T10:35:37Z",
                "annotation_id": 0,
                "x_min": 0,
                "x_max": 0,
                "y_min": 0,
                "label": 0,
                "y_max": 0,
                "notes": "string"
              }
            ],
            "detection_accuracy": 0,
            "images": [
              {
                "height": 0,
                "name": "string",
                "file_size": 0,
                "width": 0,
                "url": "string"
              }
            ],
            "result": "string",
            "detected_objects": 0,
            "label": "string"
          }
        ],
        "name": "string",
        "user_assessment": {
          "label": "string",
          "images": [
            {
              "height": 0,
              "name": "string",
              "file_size": 0,
              "width": 0,
              "url": "string"
            }
          ],
          "result": "string",
          "annotations": [
            {
              "created_at": "2020-10-19T10:35:37Z",
              "annotation_id": 0,
              "x_min": 0,
              "x_max": 0,
              "y_min": 0,
              "label": 0,
              "y_max": 0,
              "notes": "string"
            }
          ]
        },
        "active": true,
        "is_training_data": true,
        "images": [
          {
            "height": 0,
            "name": "string",
            "file_size": 0,
            "width": 0,
            "url": "string"
          }
        ],
        "status": "string"
      }
    ],
    "current_page": 0,
    "end_page": 0,
    "count_per_page": 0
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[GetItemsResponse](#schemagetitemsresponse)|false|none|none|

<h2 id="tocS_AddItemRequest">AddItemRequest</h2>
<!-- backwards compatibility -->
<a id="schemaadditemrequest"></a>
<a id="schema_AddItemRequest"></a>
<a id="tocSadditemrequest"></a>
<a id="tocsadditemrequest"></a>

```json
{
  "files": [
    "string"
  ],
  "training": true,
  "good": true,
  "model_id": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|files|[string]|false|none|none|
|training|boolean|true|none|none|
|good|boolean|false|none|none|
|model_id|string|false|none|none|

<h2 id="tocS_AddItemResponse">AddItemResponse</h2>
<!-- backwards compatibility -->
<a id="schemaadditemresponse"></a>
<a id="schema_AddItemResponse"></a>
<a id="tocSadditemresponse"></a>
<a id="tocsadditemresponse"></a>

```json
{
  "item_ids": [
    "string"
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|item_ids|[string]|false|none|none|

<h2 id="tocS_AddItemResponseWrapper">AddItemResponseWrapper</h2>
<!-- backwards compatibility -->
<a id="schemaadditemresponsewrapper"></a>
<a id="schema_AddItemResponseWrapper"></a>
<a id="tocSadditemresponsewrapper"></a>
<a id="tocsadditemresponsewrapper"></a>

```json
{
  "data": {
    "item_ids": [
      "string"
    ]
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[AddItemResponse](#schemaadditemresponse)|false|none|none|

<h2 id="tocS_ItemWrapper">ItemWrapper</h2>
<!-- backwards compatibility -->
<a id="schemaitemwrapper"></a>
<a id="schema_ItemWrapper"></a>
<a id="tocSitemwrapper"></a>
<a id="tocsitemwrapper"></a>

```json
{
  "data": {
    "item_id": "string",
    "assessments": [
      {
        "model_id": "string",
        "annotations": [
          {
            "created_at": "2020-10-19T10:35:37Z",
            "annotation_id": 0,
            "x_min": 0,
            "x_max": 0,
            "y_min": 0,
            "label": 0,
            "y_max": 0,
            "notes": "string"
          }
        ],
        "detection_accuracy": 0,
        "images": [
          {
            "height": 0,
            "name": "string",
            "file_size": 0,
            "width": 0,
            "url": "string"
          }
        ],
        "result": "string",
        "detected_objects": 0,
        "label": "string"
      }
    ],
    "name": "string",
    "user_assessment": {
      "label": "string",
      "images": [
        {
          "height": 0,
          "name": "string",
          "file_size": 0,
          "width": 0,
          "url": "string"
        }
      ],
      "result": "string",
      "annotations": [
        {
          "created_at": "2020-10-19T10:35:37Z",
          "annotation_id": 0,
          "x_min": 0,
          "x_max": 0,
          "y_min": 0,
          "label": 0,
          "y_max": 0,
          "notes": "string"
        }
      ]
    },
    "active": true,
    "is_training_data": true,
    "images": [
      {
        "height": 0,
        "name": "string",
        "file_size": 0,
        "width": 0,
        "url": "string"
      }
    ],
    "status": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[Item](#schemaitem)|false|none|none|

<h2 id="tocS_RequestAnnotation">RequestAnnotation</h2>
<!-- backwards compatibility -->
<a id="schemarequestannotation"></a>
<a id="schema_RequestAnnotation"></a>
<a id="tocSrequestannotation"></a>
<a id="tocsrequestannotation"></a>

```json
{
  "x_max": 0,
  "x_min": 0,
  "y_max": 0,
  "y_min": 0,
  "label": 0,
  "notes": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|x_max|integer(int32)¦null|false|none|none|
|x_min|integer(int32)¦null|false|none|none|
|y_max|integer(int32)¦null|false|none|none|
|y_min|integer(int32)¦null|false|none|none|
|label|integer(int32)¦null|false|none|none|
|notes|string|false|none|none|

<h2 id="tocS_AnnotateItemRequest">AnnotateItemRequest</h2>
<!-- backwards compatibility -->
<a id="schemaannotateitemrequest"></a>
<a id="schema_AnnotateItemRequest"></a>
<a id="tocSannotateitemrequest"></a>
<a id="tocsannotateitemrequest"></a>

```json
{
  "annotations": [
    {
      "x_max": 0,
      "x_min": 0,
      "y_max": 0,
      "y_min": 0,
      "label": 0,
      "notes": "string"
    }
  ]
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|annotations|[[RequestAnnotation](#schemarequestannotation)]|false|none|none|

<h2 id="tocS_License">License</h2>
<!-- backwards compatibility -->
<a id="schemalicense"></a>
<a id="schema_License"></a>
<a id="tocSlicense"></a>
<a id="tocslicense"></a>

```json
{
  "license_data": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|license_data|string(binary)|false|none|none|

<h2 id="tocS_LicenseResponse">LicenseResponse</h2>
<!-- backwards compatibility -->
<a id="schemalicenseresponse"></a>
<a id="schema_LicenseResponse"></a>
<a id="tocSlicenseresponse"></a>
<a id="tocslicenseresponse"></a>

```json
{
  "license_expiry": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|license_expiry|string|false|none|none|

<h2 id="tocS_LicenseResponseWrapper">LicenseResponseWrapper</h2>
<!-- backwards compatibility -->
<a id="schemalicenseresponsewrapper"></a>
<a id="schema_LicenseResponseWrapper"></a>
<a id="tocSlicenseresponsewrapper"></a>
<a id="tocslicenseresponsewrapper"></a>

```json
{
  "data": {
    "license_expiry": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[LicenseResponse](#schemalicenseresponse)|false|none|none|

<h2 id="tocS_LicenseHashResponse">LicenseHashResponse</h2>
<!-- backwards compatibility -->
<a id="schemalicensehashresponse"></a>
<a id="schema_LicenseHashResponse"></a>
<a id="tocSlicensehashresponse"></a>
<a id="tocslicensehashresponse"></a>

```json
{
  "hash_id": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|hash_id|string|false|none|none|

<h2 id="tocS_LicenseHashResponseWrapper">LicenseHashResponseWrapper</h2>
<!-- backwards compatibility -->
<a id="schemalicensehashresponsewrapper"></a>
<a id="schema_LicenseHashResponseWrapper"></a>
<a id="tocSlicensehashresponsewrapper"></a>
<a id="tocslicensehashresponsewrapper"></a>

```json
{
  "data": {
    "hash_id": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|data|[LicenseHashResponse](#schemalicensehashresponse)|false|none|none|
