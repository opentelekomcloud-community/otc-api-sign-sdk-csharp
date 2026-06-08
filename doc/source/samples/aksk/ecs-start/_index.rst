Start ECS using AK/SK signing
=================================

.. toctree::
   :maxdepth: 3
   :includehidden:


Samples on how to start an ECS instance using an ak/sk request signing.


For complete source code, see :github_repo_master:`samples-doc/aksksigning/ecs-start<samples-doc/aksksigning>` on GitHub.

Requirements
------------

.. list-table:: Environment variables
    :widths: 20 20 25
    :header-rows: 1

    * - Environment variable name
      - Value
      - Remarks

    * - ECS_INSTANCE_ID
      - <ID of ecs instance>
      - ID of the ecs instance to start

    * - OTC_SDK_PROJECT_ID
      - <Project ID>
      - Needed if ecs instance is in a sub project see :api_usage:`Obtaining a Project ID<guidelines/calling_apis/obtaining_required_information.html#obtaining-a-project-id>`

    * - OTC_SDK_AK
      - <Access Key>
      - see: :api_usage:`Generating AK and SK<guidelines/calling_apis/ak_sk_authentication/generating_an_ak_and_sk.html#apig-en-api-180328005>`

    * - OTC_SDK_SK
      - <Secret Key>
      - see: :api_usage:`Generating AK and SK<guidelines/calling_apis/ak_sk_authentication/generating_an_ak_and_sk.html#apig-en-api-180328005>`

Installation and Running
-------------------------

.. code-block:: bash
   :caption: Install and run the sample

   # clone the repository
   git clone https://github.com/opentelekomcloud-community/otc-api-sign-sdk-csharp.git

   # change to root directory of the repository   
   cd otc-api-sign-sdk-csharp

   cd samples-doc/aksksigning/ecs-start-sync
   # or
   cd samples-doc/aksksigning/ecs-start-async

   dotnet build

   # Running the sample with framework net8.0
   dotnet run --project ecs-start-sync.csproj --framework net8.0
   # or
   dotnet run --project ecs-start-async.csproj --framework net8.0


.. tabs::

   .. tab:: Using: HttpWebRequest

        Request Signing and API Calling using HttpWebRequest


        project file

        .. literalinclude:: ../../../../../samples-doc/aksksigning/ecs-start-sync/ecs-start-sync.csproj
          :language: xml
          :caption: ecs-start.csproj

        Source code
        

        .. literalinclude:: ../../../../../samples-doc/aksksigning/ecs-start-sync/Program.cs
          :language: csharp
          :caption: Program.cs

   .. tab:: Using: HttpRequestMessage

         Request Signing and API Calling using HttpRequestMessage


         project file

         .. literalinclude:: ../../../../../samples-doc/aksksigning/ecs-start-async/ecs-start-async.csproj
           :language: xml
           :caption: ecs-start.csproj

         Source code

         .. literalinclude:: ../../../../../samples-doc/aksksigning/ecs-start-async/Program.cs
           :language: csharp
           :caption: Program.cs
