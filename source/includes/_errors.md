
# t(:genericErrors)

## 401 Unauthorized

```csharp
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

```python
hacarus_visual_inspection.errors.APIError: No permission to access this resource! (401)
```

<div class="hacarus-content lang-specific csharp">
t(:errorUnauthorized, authorize: 'Authorize')
</div>

<div class="hacarus-content lang-specific python">
t(:errorUnauthorized, authorize: 'authorize')
</div>


## 403 Forbidden

```csharp
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
```python
hacarus_visual_inspection.errors.APIError: Invalid license! (403)
```

<div class="hacarus-content lang-specific csharp">
t(:errorNoLicense, activateLicense: 'ActivateLicense')
</div>

<div class="hacarus-content lang-specific python">
t(:errorNoLicense, activateLicense: 'activate_license')
</div>


<!-- 
# Errors

<aside class="notice">
This error section is stored in a separate file in <code>includes/_errors.md</code>. Slate allows you to optionally separate out your docs into many files...just save them to the <code>includes</code> folder and add them to the top of your <code>index.md</code>'s frontmatter. Files are included in the order listed.
</aside>

The Kittn API uses the following error codes:


Error Code | Meaning
---------- | -------
400 | Bad Request -- Your request is invalid.
401 | Unauthorized -- Your API key is wrong.
403 | Forbidden -- The kitten requested is hidden for administrators only.
404 | Not Found -- The specified kitten could not be found.
405 | Method Not Allowed -- You tried to access a kitten with an invalid method.
406 | Not Acceptable -- You requested a format that isn't json.
410 | Gone -- The kitten requested has been removed from our servers.
418 | I'm a teapot.
429 | Too Many Requests -- You're requesting too many kittens! Slow down!
500 | Internal Server Error -- We had a problem with our server. Try again later.
503 | Service Unavailable -- We're temporarily offline for maintenance. Please try again later. -->
