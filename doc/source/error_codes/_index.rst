Error codes
===================

.. toctree::
   :hidden:

If an error code starting with a cloud service name is displayed when you call an API,
rectify the fault by referring to section "Error Code" in the API reference manual of
the cloud service. If an error code starting with APIGW is displayed when you call an API,
seek solutions in the following table.

.. list-table:: Table 1 Error codes
    :header-rows: 1
    :widths: 14 24 10 24 28

    *  - Error Code
       - Error Message
       - HTTP Status Code
       - Description
       - Corrective Action
    *  - APIGW.0101
       - The API does not exist or has not been published in the environment.
       - 404
       - The API does not exist or has not been published in the environment.
       - Rectify the fault by following the instructions in :ref:`api-sign-0002`.
    *  - APIGW.0101
       - The API does not exist.
       - 404
       - The request method does not exist.
       - Check whether the request method is the same as the method specified for the API.
    *  - APIGW.0103
       - The backend does not exist.
       - 404
       - The backend service is not found.
       - Contact technical support.
    *  - APIGW.0104
       - The plug-ins do not exist.
       - 400
       - No plugin configurations are found.
       - Contact technical support.
    *  - APIGW.0105
       - The backend configurations do not exist.
       - 400
       - No backend configurations are found.
       - Contact technical support.
    *  - APIGW.0106
       - Orchestration error.
       - 400
       - Orchestration error.
       - Check whether the frontend and backend parameters are properly set for the API.
    *  - APIGW.0201
       - API request error.
       - 400
       - Invalid request parameters.
       - Set valid request parameters.
    *  - APIGW.0201
       - Request entity too large.
       - 413
       - The request body exceeds 12 MB.
       - Reduce the size of the request body.
    *  - APIGW.0201
       - Request URI too large.
       - 414
       - The request URI is too large.
       - Reduce the size of the request URI.
    *  - APIGW.0201
       - Request headers too large.
       - 494
       - The request headers are too large.
       - Reduce the size of the request headers.
    *  - APIGW.0201
       - Backend unavailable.
       - 502
       - The backend service is currently unavailable.
       - Check whether the backend address configured for the API is accessible.
    *  - APIGW.0201
       - Backend timeout.
       - 504
       - The backend service timed out.
       - Increase the timeout duration of the backend service or shorten the processing time.
    *  - APIGW.0301
       - Incorrect IAM authentication information.
       - 401
       - The IAM authentication information is incorrect.
       - Rectify the fault by following the instructions in Common Errors Related to IAM Authentication Information.
    *  - APIGW.0302
       - The IAM user is not authorized to access the API.
       - 403
       - The IAM user is not allowed to access the API.
       - Check whether the user has been blacklisted or whitelisted.
    *  - APIGW.0303
       - Incorrect app authentication information.
       - 401
       - The app authentication information is incorrect.
       - Perform the following checks for app authentication:

           - Check whether the request method, path, query parameters, and request body are consistent with those used for signing.
           - Check whether the client time is correct.
           - Check whether the signing code is correct by referring to Calling APIs Through App Authentication.
           
         In the case of AppCode-based simple authentication, check whether the request contains the **X-Apig-AppCode** header.
         
    *  - APIGW.0304
       - The app is not authorized to access the API.
       - 403
       - The app is not allowed to access the API.
       - Check whether the app has been authorized to access the API.
    *  - APIGW.0305
       - Incorrect authentication information.
       - 401
       - The authentication information is incorrect.
       - Check whether the authentication information is correct.
    *  - APIGW.0306
       - API access denied.
       - 403
       - Access to the API is not allowed.
       - Check whether you have been authorized to access the API.
    *  - APIGW.0307
       - The token must be updated.
       - 401
       - The token needs to be updated.
       -  - Obtain a new token from IAM.
          - An API of another region may have been called. Check the API URL.
    *  - APIGW.0308
       - The throttling threshold has been reached.
       - 429
       - The request throttling threshold is reached.
       -  - Try again after the throttling resumes. By default, an API can be accessed a maximum of 200 times per second.
          - The rate limits of cloud service APIs cannot be adjusted. Try again after the throttling resumes.
          - To adjust the rate limit of an API you have created in API Gateway, contact technical support by submitting a service ticket.
    *  - APIGW.0310
       - The project is unavailable.
       - 403
       - The project is currently unavailable.
       - Select another project and try again.
    *  - APIGW.0311
       - Incorrect debugging authentication information.
       - 401
       - The debugging authentication information is incorrect.
       - Contact technical support.
    *  - APIGW.0401
       - Unknown client IP address.
       - 403
       - The client IP address cannot be identified.
       - Contact technical support.
    *  - APIGW.0402
       - The IP address is not authorized to access the API.
       - 403
       - The IP address is not allowed to access the API.
       - Check whether the IP address has been blacklisted or whitelisted.
    *  - APIGW.0404
       - Access to the backend IP address has been denied.
       - 403
       - The backend IP address cannot be accessed.
       - The backend IP address or the IP address of the backend domain cannot be accessed. Check whether the IP address exists or has been blacklisted or whitelisted.
    *  - APIGW.0501
       - The app quota has been used up.
       - 405
       - The app quota has been reached.
       - Increase the app quota.
    *  - APIGW.0502
       - The app has been frozen.
       - 405
       - The app has been frozen.
       - Account balance is insufficient. Go to the Funds Management page to top up your account.
    *  - APIGW.0601
       - Internal server error.
       - 500
       - Internal error.
       - Contact technical support.
    *  - APIGW.0602
       - Bad request.
       - 400
       - Invalid request.
       - Check whether the request is valid.
    *  - APIGW.0605
       - Domain name resolution failed.
       - 500
       - Domain name resolution failed.
       - Check whether the domain name is correct and has been bound to a correct backend address.
    *  - APIGW.0606
       - Failed to load the API configurations.
       - 500
       - API configurations are not loaded.
       - Contact technical support.
    *  - APIGW.0607
       - The following protocol is supported: {xxx}
       - 400
       - The protocol is not supported. Only xxx is supported. xxx indicates the protocol in a response.
       - Use HTTP or HTTPS to access the API.
    *  - APIGW.0608
       - Failed to obtain the admin token.
       - 500
       - The tenant information cannot be obtained.
       - Contact technical support.
    *  - APIGW.0609
       - The VPC backend does not exist.
       - 500
       - The VPC backend service cannot be found.
       - Contact technical support.
    *  - APIGW.0610
       - No backend available.
       - 502
       - No backend services are available.
       - Check whether all backends are available.
    *  - APIGW.0611
       - The backend port does not exist.
       - 500
       - The backend port is not found.
       - Contact technical support.
    *  - APIGW.0612
       - An API cannot call itself.
       - 500
       - An API cannot call itself.
       - Modify the backend configurations, and ensure that the number of layers the API is recursively called does not exceed 10.
    *  - APIGW.0613
       - The IAM service is currently unavailable.
       - 503
       - IAM is currently unavailable.
       - Contact technical support.
    *  - APIGW.0705
       - Backend signature calculation failed.
       - 500
       - Backend signature calculation failed.
       - Contact technical support.
    *  - APIGW.0801
       - The service is unavailable in the currently selected region.
       - 403
       - The service is inaccessible in the current region.
       - Check whether the service supports cross-region access.
    *  - APIGW.0802
       - The IAM user is forbidden in the currently selected region.
       - 403
       - The IAM user is not allowed to access the region.
       - Contact technical support.
