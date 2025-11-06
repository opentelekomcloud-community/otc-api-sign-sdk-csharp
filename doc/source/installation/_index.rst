Installation
===============

.. toctree::
   :maxdepth: 4
   :includehidden:

The latest state of the module can be installed directly from the GitHub repository.

TBD.


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

