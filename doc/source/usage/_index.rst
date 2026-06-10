Usage
=====

.. toctree::
   :hidden:

Overview
--------

This document describes how to call cloud service APIs registered with API Gateway
using the AK/SK signature authentication.
You need to obtain the API information and AK/SK by referring to 
:otc_docs:`Obtaining Required Information <api-usage/guidelines/calling_apis/obtaining_required_information.html>` and Obtaining an AK/SK first,
and then perform signature authentication based on this document.

- For the authentication of certain cloud service APIs that are not registered
  with API Gateway, see the API Reference of the corresponding service.

- For the APIs provided by a cloud service, see the API Reference of the cloud service.
  The API Reference contains a section named "Calling APIs" that describes API
  authentication methods.

- AK/SK authentication supports API requests with a body less than or
  equal to 12 MB. For API requests with a larger body, token authentication
  is recommended.
  The description and example of token-based authentication are included in the 
  section "Authentication" in the API reference of each cloud service.

- The local time on the client must be synchronized with the clock server to avoid a
  large offset in the value of the X-Sdk-Date request header.
  API Gateway checks the time format and compares the time with the time when
  API Gateway receives the request.
  If the time difference exceeds 15 minutes, API Gateway will reject the request.


Signing Requests
-----------------

Using Access Key and Secret Key
""""""""""""""""""""""""""""""""""

.. code-block:: csharp

    Signer signer = new Signer
    {
        Key = <Access Key>,
        Secret = <Secret Key>
    };

    HttpRequest r = new HttpRequest(<method>, <request URL>);

    r.headers.Add(<header>, <value>);

    // set content type and body for PUT and POST requests
    r.headers.Add("content-type", "application/json");
    r.body = <request body>;

    HttpWebRequest req = signer.Sign(r);



Using temporary Access Key, Secret Key and Security Token
""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""

To obtain temporary Access Key, Secret Key and Security Token see:
:otc_docs:`Obtaining a Temporary AK/SK <identity-access-management/api-ref/apis/access_key_management/obtaining_a_temporary_ak_sk.html>` in
**Identity and Access Management** documentation.


.. code-block:: csharp

    Signer signer = new Signer
    {
        Key = <temporary Access Key>,
        Secret = <temporary Secret Key>,
        SecurityToken = <temporary Security Token>
    };

    // set headers    
    r.headers.Add(<header>, <value>);

    // set content type and body for PUT and POST requests
    r.headers.Add("content-type", "application/json");
    r.body = <request body>;

    HttpWebRequest req = signer.Sign(r);


Using temporary Access Key Secret Key and Security Token of an Agency
""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""


FunctionGraph **Event** functions
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Using FunctionGraph **Event** functions, the **temporary Access Key**, **temporary Secret Key** and 
**temporary Security Token**
of a configured agency can be obtained by the **IFunctionContext** object of the function.

.. code-block:: csharp

    // handler of an Event function
    public Stream Handler(Stream inputEvent, IFunctionContext context)
    {
        Signer signer = new Signer
        {
          Key = context.SecurityAccessKey,
          Secret = context.SecuritySecretKey,
          SecurityToken = context.SecurityToken
        };

    }

FunctionGraph **HTTP** functions
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Using FunctionGraph **HTTP** functions, the **temporary Access Key**, **temporary Secret Key** and 
**temporary Security Token**
of a configured agency can be obtained from request header parameters.

For details see: `Transferring Secret Keys through the request header <https://opentelekomcloud-community.github.io/otc-functiongraph-csharp-runtime/devguide/http_function/transferringKeys.html>`_
in **Developer Guide: FunctionGraph csharp Runtime** documentation.


Headers
-----------------

Sign body if needed
"""""""""""""""""""""""""""""""""""

If the body of the request should not be signed, 
add the **X-Sdk-Content-Sha256** header parameter to 
the request header and set the parameter value to **UNSIGNED-PAYLOAD**.

.. code-block:: csharp

    r.headers.Add("X-Sdk-Content-Sha256", "UNSIGNED-PAYLOAD");


How to call APIs in a Subproject
"""""""""""""""""""""""""""""""""""

To access resources in a subproject by calling APIs, add the **X-Project-Id** header parameter to
the request header and set the parameter value to the subproject ID.

.. code-block:: csharp

    r.headers.Add("X-Project-Id", <Project ID>);

For details about how to obtain the value of **X-Project-Id**,
see :otc_docs:`Obtaining Required Information <api-usage/guidelines/calling_apis/obtaining_required_information.html>`
in **API Usage** documentation.

How to call APIs of a Global Service
"""""""""""""""""""""""""""""""""""""

Global Services are services that are not deployed in a specific region.
Examples of global services include

- Identity and Access Management (**IAM**),
- Object Storage Service (**OBS**)

To call APIs of a Global Service, add the **X-Domain-Id** header parameter to 
the request header and set the parameter value to the domain ID.

.. code-block:: csharp

    r.headers.Add("X-Domain-Id", <Domain ID>);

For details about how to obtain the value of **X-Domain-Id**,
see :otc_docs:`Obtaining Required Information <api-usage/guidelines/calling_apis/obtaining_required_information.html>`
in **API Usage** documentation.

How to call APIs of an API Environment
"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""

An API can be called in different environments, such as production,testing, and development environments.

To call APIs of an API Environment, add the **x-stage** header parameter to 
the request header and set the parameter value to the environment ID.

.. code-block:: csharp

    r.headers.Add("x-stage", <Environment>);


For details about environments see:

- :otc_docs:`Basic concepts <api-gateway/umn/service_overview/basic_concepts.html>`
  in **API Gateway** documentation

- :otc_docs:`Managing Environments <api-gateway/umn/api_policies/managing_environments.html>`
  in **API Gateway** documentation.
