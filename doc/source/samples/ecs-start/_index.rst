Start ECS using AK/SK signing
=================================

.. toctree::
   :includehidden:
   :maxdepth: 10


Samples on how to start an ECS instance using an ak/sk request signing.


For complete source code, see :github_repo_master:`samples-doc/ecs-start<samples-doc/ecs-start>` on GitHub.

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

   cd samples-doc/ecs-start
   
   dotnet build

   # Running the sample with framework net8.0
   dotnet run --project ecs-start.csproj --framework net8.0
   


Project file
-------------------------

.. literalinclude:: ../../../../samples-doc/ecs-start/ecs-start.csproj
  :language: xml
  :caption: ecs-start.csproj

Source code
-------------------------

.. literalinclude:: ../../../../samples-doc/ecs-start/Program.cs
  :language: csharp
  :caption: Program.cs
  
