.. _api-sign-0002:

What Should I Do If "The API does not exist or has not been published in the environment." is displayed?
--------------------------------------------------------------------------------------------------------

.. toctree::
   :hidden:

If an open API of a cloud service failed to be called,
troubleshoot the failure by performing the following operations:

1. The domain name, request method, or path used for calling the API is incorrect.

   - For example, an API created using the POST method is called with GET.
   - Missing a slash (/) in the access URL will lead to a failure in matching the URL in the API details.

     For example, URLs **https://vpc.region.otc.t-systems.com/test/** and
     **https://vpc.region.otc.t-systems.com/test** represent two different APIs.
    
2. The domain name is resolved incorrectly. If the domain name, request method,
   and path for calling the API are correct, the API may not be correctly resolved.   
