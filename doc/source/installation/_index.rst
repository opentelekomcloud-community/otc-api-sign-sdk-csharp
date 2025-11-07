Installation
===============

.. toctree::
   :maxdepth: 4
   :includehidden:

The latest state of the module can be installed directly from the GitHub repository.

Install library from GitHub NuGet feed
--------------------------------------

.. note::

   For details see: `GitHub Documentation <https://docs.github.com/en/packages/working-with-a-github-packages-registry/working-with-the-nuget-registry>`_


To authenticate to GitHub Packages with the dotnet command-line interface
(CLI), create a nuget.config file in your project directory specifying
GitHub Packages as a source under packageSources for the dotnet CLI client.

You must replace:

* USERNAME with the name of your personal account on GitHub.
* TOKEN with your personal access token (classic).

.. code-block:: xml
   :caption: NuGet.Config

    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
        <packageSources>
            <clear />
            <add key="github" value="https://nuget.pkg.github.com/opentelekomcloud-community/index.json" />
        </packageSources>
        <packageSourceCredentials>
            <github>
                <add key="Username" value="USERNAME" />
                <add key="ClearTextPassword" value="TOKEN" />
            </github>
        </packageSourceCredentials>
    </configuration>


Add or update package reference in the project file using the .NET CLI:

.. code-block:: shell
   :caption: dotnet add package

    dotnet add package OpenTelekomCloud.API.Signing.Core --version 0.0.0-alpha.0

Alternative add the package reference to your project file:

.. code-block:: xml
   :caption: YOUR_PROJECT.csproj

    <project Sdk="Microsoft.NET.Sdk">

      <ItemGroup>
        <PackageReference Include="OpenTelekomCloud.API.Signing.Core" Version="*-*" />
      </ItemGroup>

    </project>


Install dotnet on Ubuntu
------------------------

.. code-block:: shell
   :caption: install dotnet

    wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh

    chmod +x ./dotnet-install.sh 

    mkdir -p ~/dotnet

    ./dotnet-install.sh --channel 8.0 --install-dir ~/dotnet --skip-non-versioned-files

    ./dotnet-install.sh --channel 6.0 --install-dir ~/dotnet --skip-non-versioned-files

    ./dotnet-install.sh --channel 3.1 --install-dir ~/dotnet --skip-non-versioned-files

    ./dotnet-install.sh --channel 2.1 --install-dir ~/dotnet --skip-non-versioned-files

    export DOTNET_ROOT=~/dotnet
    export PATH=$DOTNET_ROOT:$PATH

to build use

.. code-block:: shell
   :caption: install dotnet

    dotnet build


Installation using NuGet:
------------------------------

.. code-block:: shell
   :caption: dotnet add package

   TBD...



Troubleshooting C#
-------------------


Error: "No usable version of libssl was found"
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

.. code-block:: shell
   :caption: dotnet add package

   wget http://security.ubuntu.com/ubuntu/pool/main/o/openssl/libssl1.1_1.1.1f-1ubuntu2.24_amd64.deb
   sudo dpkg -i libssl1.1_1.1.1f-1ubuntu2.24_amd64.deb`

