# EPiServer-13

AT THIS MOMENT WE HAVE TO CREATE EPISERVER 12 FIRST AND UPGRADE: [From 12 to 13 preview: A Developer's Guide to testing an Optimizely CMS 13 Alloy Site](https://world.optimizely.com/blogs/robert-svallin/dates/2026/1/from-12-to-13-a-developers-guide-to-upgrading-an-optimizely-cms-alloy-site/)

EPiServer 13 projects created from the Optimizely templates.

## Install/update the Optimizely templates

	dotnet new install EPiServer.Templates

## Install the Episerver CLI Tool (optional)

The Optimizely Command-line Interface (CLI) tool is optional but makes creating or updating databases easy.

	dotnet tool install EPiServer.Net.Cli --global --add-source https://nuget.optimizely.com/feed/packages.svc/

Update:

	dotnet tool update EPiServer.Net.Cli --global --add-source https://nuget.optimizely.com/feed/packages.svc/

## Command examples

\<project\> below, in the dotnet-episerver examples, is the path to the project file, relative or absolute. Eg. "src\MyCompany.Web\MyCompany.Web.csproj", "C:\Projects\Solution-1\Source\Project-1\Project-1.csproj". So if you use a relative path to the project file you need to "cd" to the correct directory before running the command.

	dotnet-episerver create-cms-database --help

	dotnet-episerver create-commerce-database --help

	dotnet-episerver update-database --help

	dotnet-episerver create-cms-database <project>

	dotnet-episerver create-commerce-database <project>

	dotnet-episerver update-database <project>

	dotnet new epi-alloy-mvc --help

	dotnet new epi-cms-empty --help

	dotnet new epi-commerce-empty --help

	dotnet new epi-cms-empty

	dotnet new epi-alloy-mvc

	dotnet new epi-alloy-mvc --name alloy-docker --output ./alloy-docker --enable-docker

	dotnet new epi-commerce-empty

## Projects

- [Alloy](/Source/Alloy)
- [Empty](/Source/Empty)

## Links

- [From 12 to 13 preview: A Developer's Guide to testing an Optimizely CMS 13 Alloy Site](https://world.optimizely.com/blogs/robert-svallin/dates/2026/1/from-12-to-13-a-developers-guide-to-upgrading-an-optimizely-cms-alloy-site/)
- [Configure a development environment](https://docs.developers.optimizely.com/content-management-system/docs/set-up-a-development-environment)
- [Install Optimizely (ASP.NET Core)](https://docs.developers.optimizely.com/content-management-system/docs/installing-optimizely-net-5)