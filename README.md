# com-danliris-service-deal-tracking

DanLiris Application is a enterprise project that aims to manage the business processes of a textile factory, PT. DanLiris.
This application is a microservices application consisting of services based on .NET Core and Aurelia Js which part of  NodeJS Frontend Framework. This application show how to implement microservice architecture principles. com-danliris-service-finance-accounting repository is part of service that will serve system authentication.

## Prerequisites
* Windows, Mac or Linux
* [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/vs/whatsnew/)
* [IIS Web Server](https://www.iis.net/) 
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
* [.NET Core SDK](https://www.microsoft.com/net/download/core#/current) (v2.0.9,  SDK 2.1.202, ASP.NET Core Runtime 2.0.9 )


## Getting Started

- Fork the repository and then clone the repository using command  `git clone https://github/YOUR-USERNAME/com-danliris-service-deal-tracking.git`  checkout the `dev` branch.


### Command Line

- Install the latest version of the .NET Core SDK from this page <https://www.microsoft.com/net/download/core>
- Next, navigate to root project or wherever your folder is on the command line in administrator mode.
- Create empty database.
- Setting connection to database using Connection Strings in appsettings.json. Your appsettings.json look like this:

```
{
  "Logging": {
    "IncludeScopes": false,
    "Debug": {
      "LogLevel": {
        "Default": "Warning"
      }
    },
    "Console": {
      "LogLevel": {
        "Default": "Warning"
      }
    }
  },

  "ConnectionStrings": {
    "DefaultConnection": "Server=YourDbServer;Database=com-danliris-service-finance-accounting;Trusted_Connection=True;MultipleActiveResultSets=true",
  },
  "ClientId": "your ClientId",
  "Secret": "Your Secret",
  "ASPNETCORE_ENVIRONMENT": "Development"
}
```
and  Your appsettings.Developtment.json look like this :
```
{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  }
}
```
- Make sure port application has no conflict, setting port application in launchSettings.json
```
com-danliris-service-deal-tracking
 ┣ Com.DanLiris.Service.DealTracking.WebApi
    ┗ Properties
       ┗ launchSettings.json
```

file launchSettings.json look like this :
```
{
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:34787/",
      "sslPort": 0
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "Com.DanLiris.Service.DealTracking.WebApi": {
      "commandName": "Project",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      },
      "applicationUrl": "http://localhost:5000"
    }
  }
}
```
- Call `dotnet run`.
- Then open the `http://localhost:22160/swagger/index.html` URL in your browser.

### Visual Studio

- Download Visual Studio 2019 (any edition) from https://www.visualstudio.com/downloads/ .
- Open `Com.DanLiris.Service.DealTracking.sln` and wait for Visual Studio to restore all Nuget packages.
- Create empty database.
- Setting connection to database using ConnectionStrings in appsettings.json and appsettings.Developtment.json.
- Make sure port application has no conflict, setting port application in launchSettings.json.
```
com-danliris-service-deal-tracking
 ┣ Com.DanLiris.Service.DealTracking.WebApi
    ┗ Properties
       ┗ launchSettings.json
```
- Ensure `Com.DanLiris.Service.DealTracking.WebApi` is the startup project and run it and the browser will launched in new tab http://localhost:22160/swagger/index.html


### Run Unit Tests in Visual Studio 
1. You can run all test suite, specific test suite or specific test case on test explorer.
2. Choose Tab Menu **Test** to select differnt menu test.
3. Select **Run All Test** or press (Ctrl + R, A ) to run all test suite.
4. Select **Test Explorer** or press (Ctrl + E, T ) to determine  test suite to run specifically.
5. Select **Analyze Code Coverage For All Test** to generate code coverage. 


## Knows More Details
### Root directory and description

```
com-danliris-service-auth
 ┣ Com.DanLiris.Service.DealTracking.Lib
 ┣ Com.DanLiris.Service.DealTracking.Test
 ┣ Com.DanLiris.Service.DealTracking.WebApi
 ┣ TestResults
 ┣ .codecov.yml
 ┣ .gitignore
 ┣ .travis.yml
 ┣ Com.Danliris.Service.Auth.sln
 ┗ README.md
 ```

**1. Com.DanLiris.Service.DealTracking.Lib**

This folder consists of various libraries, domain Models, View Models, and Business Logic.The Model and View Models represents the data structure. Business Logic has responsibility  to organize, prepare, manipulate, and organize data. The tasks are include entering data into databases, updating data, deleting data, and so on. The model carries out its work based on instructions from the controller.


AutoMapperProfiles:

- Colecction class to setup mapping data 

BusinessLogic

- Colecction of classes to prepare, manipulate, and organize data, including CRUD (Create, Read, Update, Delete ) on database.

Models:

- The Model is a collection of objects that Representation of data structure which hold the application data and it may contain the associated business logic.

ViewModels

- The View Model refers to the objects which hold the data that needs to be shown to the user.The View Model is related to the presentation layer of our application. They are defined based on how the data is presented to the user rather than how they are stored.

Configs

- Collection of classes to setup entity model  that will be used in EF framework to generate schema database.

Migrations

- Collection of classes that generated by EF framework  to setup database and the tables.


Services

- Collection of classes and interfaces to validation and authentication user.


Utilities

- Collection of classes that frequently used as utility and  helper classes that frequently used in various cases.


The folder tree in this folder is:

```
com-danliris-service-deal-tracking
 ┣ Com.DanLiris.Service.DealTracking.Lib
 ┃ ┣ AutoMapperProfiles
 ┃ ┃ ┣ ActivityProfile.cs
 ┃ ┃ ┣ BoardProfile.cs
 ┃ ┃ ┣ DealProfile.cs
 ┃ ┃ ┣ MasterProfile.cs
 ┃ ┃ ┗ StageProfile.cs
 ┃ ┣ bin
 ┃ ┃ ┗ Debug
 ┃ ┃ ┃ ┗ netcoreapp2.0
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.deps.json
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.dll
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.pdb
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.runtimeconfig.dev.json
 ┃ ┃ ┃ ┃ ┗ Com.DanLiris.Service.DealTracking.Lib.runtimeconfig.json
 ┃ ┣ BusinessLogic
 ┃ ┃ ┣ Facades
 ┃ ┃ ┃ ┣ ActivityFacade.cs
 ┃ ┃ ┃ ┣ BoardFacade.cs
 ┃ ┃ ┃ ┣ CompanyFacade.cs
 ┃ ┃ ┃ ┣ ContactFacade.cs
 ┃ ┃ ┃ ┣ DealFacade.cs
 ┃ ┃ ┃ ┣ ReasonFacade.cs
 ┃ ┃ ┃ ┗ StageFacade.cs
 ┃ ┃ ┣ Implementation
 ┃ ┃ ┃ ┣ ActivityLogic.cs
 ┃ ┃ ┃ ┣ BoardLogic.cs
 ┃ ┃ ┃ ┣ CompanyLogic.cs
 ┃ ┃ ┃ ┣ ContactLogic.cs
 ┃ ┃ ┃ ┣ DealLogic.cs
 ┃ ┃ ┃ ┣ ReasonLogic.cs
 ┃ ┃ ┃ ┗ StageLogic.cs
 ┃ ┃ ┗ Interfaces
 ┃ ┃ ┃ ┣ IActivityFacade.cs
 ┃ ┃ ┃ ┣ IBoardFacade.cs
 ┃ ┃ ┃ ┣ ICompanyFacade.cs
 ┃ ┃ ┃ ┣ IContactFacade.cs
 ┃ ┃ ┃ ┣ IDealFacade.cs
 ┃ ┃ ┃ ┣ IReasonFacade.cs
 ┃ ┃ ┃ ┗ IStageFacade.cs
 ┃ ┣ Migrations
 ┃ ┃ ┣ 20180613032216_Initial.cs
 ┃ ┃ ┣ 20180613032216_Initial.Designer.cs
 ┃ ┃ ┗ DealTrackingDbContextModelSnapshot.cs
 ┃ ┣ Models
 ┃ ┃ ┣ Activity.cs
 ┃ ┃ ┣ ActivityAttachment.cs
 ┃ ┃ ┣ Board.cs
 ┃ ┃ ┣ Company.cs
 ┃ ┃ ┣ Contact.cs
 ┃ ┃ ┣ Deal.cs
 ┃ ┃ ┣ Reason.cs
 ┃ ┃ ┗ Stage.cs
 ┃ ┣ obj
 ┃ ┃ ┣ Debug
 ┃ ┃ ┃ ┗ netcoreapp2.0
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.AssemblyInfo.cs
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.AssemblyInfoInputs.cache
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.assets.cache
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.csproj.CoreCompileInputs.cache
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.csproj.FileListAbsolute.txt
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.csprojAssemblyReference.cache
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.dll
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.genruntimeconfig.cache
 ┃ ┃ ┃ ┃ ┗ Com.DanLiris.Service.DealTracking.Lib.pdb
 ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.csproj.nuget.dgspec.json
 ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.csproj.nuget.g.props
 ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.csproj.nuget.g.targets
 ┃ ┃ ┣ project.assets.json
 ┃ ┃ ┗ project.nuget.cache
 ┃ ┣ Services
 ┃ ┃ ┣ AzureStorageService.cs
 ┃ ┃ ┣ HttpClientService.cs
 ┃ ┃ ┣ IAzureStorageService.cs
 ┃ ┃ ┣ IdentityService.cs
 ┃ ┃ ┣ IHttpClientService.cs
 ┃ ┃ ┣ IIdentityService.cs
 ┃ ┃ ┣ IValidateService.cs
 ┃ ┃ ┗ ValidateService.cs
 ┃ ┣ Utilities
 ┃ ┃ ┣ BaseClass
 ┃ ┃ ┃ ┣ BaseLogic.cs
 ┃ ┃ ┃ ┗ BaseModel.cs
 ┃ ┃ ┣ BaseInterface
 ┃ ┃ ┃ ┣ IBaseFacade.cs
 ┃ ┃ ┃ ┗ IBaseLogic.cs
 ┃ ┃ ┣ BaseViewModel.cs
 ┃ ┃ ┣ CodeGenerator.cs
 ┃ ┃ ┣ QueryHelper.cs
 ┃ ┃ ┗ ServiceValidationException.cs
 ┃ ┣ ViewModels
 ┃ ┃ ┣ Integration
 ┃ ┃ ┃ ┣ CurrencyViewModel.cs
 ┃ ┃ ┃ ┗ UomViewModel.cs
 ┃ ┃ ┣ ActivityAttachmentViewModel.cs
 ┃ ┃ ┣ ActivityViewModel.cs
 ┃ ┃ ┣ BoardViewModel.cs
 ┃ ┃ ┣ CompanyViewModel.cs
 ┃ ┃ ┣ ContactViewModel.cs
 ┃ ┃ ┣ DealViewModel.cs
 ┃ ┃ ┣ MoveActivityViewModel.cs
 ┃ ┃ ┣ ReasonViewModel..cs
 ┃ ┃ ┣ StageDealViewModel.cs
 ┃ ┃ ┗ StageViewModel.cs
 ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.csproj
 ┃ ┗ DealTrackingDbContext.cs

 ```

**2. Com.DanLiris.Service.DealTracking.WebApi**

This folder consists of controller API. The controller has responsibility to processing data and  HTTP requests and then send it to a web page. All responses from the HTTP requests API are formatted as JSON (JavaScript Object Notation) objects containing information related to the request, and any status.

The folder tree in this folder is:
```
com-danliris-service-deal-tracking
 ┣ Com.DanLiris.Service.DealTracking.WebApi
 ┃ ┣ bin
 ┃ ┃ ┗ Debug
 ┃ ┃ ┃ ┗ netcoreapp2.0
 ┃ ┃ ┃ ┃ ┣ Properties
 ┃ ┃ ┃ ┃ ┃ ┗ launchSettings.json
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.dll
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.pdb
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.deps.json
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.dll
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.pdb
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.runtimeconfig.dev.json
 ┃ ┃ ┃ ┃ ┗ Com.DanLiris.Service.DealTracking.WebApi.runtimeconfig.json
 ┃ ┣ Controllers
 ┃ ┃ ┗ v1
 ┃ ┃ ┃ ┣ ActivityController.cs
 ┃ ┃ ┃ ┣ BoardController.cs
 ┃ ┃ ┃ ┣ CompanyController.cs
 ┃ ┃ ┃ ┣ ContactController.cs
 ┃ ┃ ┃ ┣ DealController.cs
 ┃ ┃ ┃ ┣ MoveActivityController.cs
 ┃ ┃ ┃ ┣ ReasonController.cs
 ┃ ┃ ┃ ┗ StageController.cs
 ┃ ┣ obj
 ┃ ┃ ┣ Debug
 ┃ ┃ ┃ ┗ netcoreapp2.0
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.AssemblyInfo.cs
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.AssemblyInfoInputs.cache
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.assets.cache
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.csproj.CopyComplete
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.csproj.CoreCompileInputs.cache
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.csproj.FileListAbsolute.txt
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.csprojAssemblyReference.cache
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.dll
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.genruntimeconfig.cache
 ┃ ┃ ┃ ┃ ┗ Com.DanLiris.Service.DealTracking.WebApi.pdb
 ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.csproj.nuget.dgspec.json
 ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.csproj.nuget.g.props
 ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.csproj.nuget.g.targets
 ┃ ┃ ┣ project.assets.json
 ┃ ┃ ┗ project.nuget.cache
 ┃ ┣ Properties
 ┃ ┃ ┗ launchSettings.json
 ┃ ┣ Utilities
 ┃ ┃ ┣ BaseController.cs
 ┃ ┃ ┣ Common.cs
 ┃ ┃ ┗ ResultFormatter.cs
 ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.csproj
 ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.csproj.user
 ┃ ┣ Program.cs
 ┃ ┗ Startup.cs
 ```

**3. Com.DanLiris.Service.DealTracking.Test**

This folder is collection of classes to run code testing. The automation type testing used in this app is  a unit testing with using moq and xunit libraries.

DataUtils:

- Colecction class to seed data as data input in unit test 

The folder tree in this folder is:

```
com-danliris-service-deal-tracking
 ┣ Com.DanLiris.Service.DealTracking.Test
 ┃ ┣ AutoMapperProfiles
 ┃ ┃ ┣ ActivityProfileTest.cs
 ┃ ┃ ┣ BoardProfileTest.cs
 ┃ ┃ ┣ DealProfileTest.cs
 ┃ ┃ ┣ MasterProfileTest.cs
 ┃ ┃ ┗ StageProfileTest.cs
 ┃ ┣ bin
 ┃ ┃ ┗ Debug
 ┃ ┃ ┃ ┗ netcoreapp2.0
 ┃ ┃ ┃ ┃ ┣ Properties
 ┃ ┃ ┃ ┃ ┃ ┗ launchSettings.json
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.dll
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Lib.pdb
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.deps.json
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.dll
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.pdb
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.runtimeconfig.dev.json
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.runtimeconfig.json
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.dll
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.WebApi.pdb
 ┃ ┃ ┃ ┃ ┣ xunit.runner.reporters.netstandard15.dll
 ┃ ┃ ┃ ┃ ┣ xunit.runner.utility.netstandard15.dll
 ┃ ┃ ┃ ┃ ┗ xunit.runner.visualstudio.dotnetcore.testadapter.dll
 ┃ ┣ BusinessLogic
 ┃ ┃ ┣ DataUtils
 ┃ ┃ ┃ ┣ ActivityDataUtil.cs
 ┃ ┃ ┃ ┣ BoardDataUtil.cs
 ┃ ┃ ┃ ┣ CompanyDataUtil.cs
 ┃ ┃ ┃ ┣ ContactDataUtil.cs
 ┃ ┃ ┃ ┣ DealLDataUtil.cs
 ┃ ┃ ┃ ┣ ReasonDataUtil.cs
 ┃ ┃ ┃ ┗ StageDataUtil.cs
 ┃ ┃ ┣ Facades
 ┃ ┃ ┃ ┣ ActivityFacadeTest.cs
 ┃ ┃ ┃ ┣ BoardFacadeTest.cs
 ┃ ┃ ┃ ┣ CompanyFacadeTest.cs
 ┃ ┃ ┃ ┣ ContactFacadeTest.cs
 ┃ ┃ ┃ ┣ DealFacadeTest.cs
 ┃ ┃ ┃ ┣ ReasonFacadeTest.cs
 ┃ ┃ ┃ ┗ StageFacadeTest.cs
 ┃ ┃ ┣ Implementation
 ┃ ┃ ┃ ┣ ActivityLogicTest.cs
 ┃ ┃ ┃ ┣ BoardLogicTest.cs
 ┃ ┃ ┃ ┣ CompanyLogicTest.cs
 ┃ ┃ ┃ ┣ ContactLogicTest.cs
 ┃ ┃ ┃ ┣ DealLogicTest.cs
 ┃ ┃ ┃ ┣ ReasonLogicTest.cs
 ┃ ┃ ┃ ┗ StageLogicTest.cs
 ┃ ┃ ┗ Utils
 ┃ ┃ ┃ ┣ BaseDataUtil.cs
 ┃ ┃ ┃ ┗ BaseFacadeTest.cs
 ┃ ┣ Models
 ┃ ┣ obj
 ┃ ┃ ┣ Debug
 ┃ ┃ ┃ ┗ netcoreapp2.0
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.AssemblyInfo.cs
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.AssemblyInfoInputs.cache
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.assets.cache
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.csproj.CopyComplete
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.csproj.CoreCompileInputs.cache
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.csproj.FileListAbsolute.txt
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.csprojAssemblyReference.cache
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.dll
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.genruntimeconfig.cache
 ┃ ┃ ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.pdb
 ┃ ┃ ┃ ┃ ┗ Com.DanLiris.Service.DealTracking.Test.Program.cs
 ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.csproj.nuget.dgspec.json
 ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.csproj.nuget.g.props
 ┃ ┃ ┣ Com.DanLiris.Service.DealTracking.Test.csproj.nuget.g.targets
 ┃ ┃ ┣ project.assets.json
 ┃ ┃ ┗ project.nuget.cache
 ┃ ┣ Services
 ┃ ┃ ┣ AzureStorageServiceTest.cs
 ┃ ┃ ┗ ValidateServiceTest.cs
 ┃ ┣ Utilities
 ┃ ┃ ┗ QueryHelperTest.cs
 ┃ ┣ ViewModels
 ┃ ┃ ┣ Integration
 ┃ ┃ ┃ ┣ CurrencyViewModelTest.cs
 ┃ ┃ ┃ ┗ UomViewModelTest.cs
 ┃ ┃ ┣ ActivityAttachmentViewModelTest.cs
 ┃ ┃ ┣ ActivityViewModelTest.cs
 ┃ ┃ ┣ BaseViewModelTest.cs
 ┃ ┃ ┣ BoardViewModelTest.cs
 ┃ ┃ ┣ CompanyViewModelTest.cs
 ┃ ┃ ┣ ContactViewModelTest.cs
 ┃ ┃ ┣ DealViewModelTest.cs
 ┃ ┃ ┣ MoveActivityViewModelTest.cs
 ┃ ┃ ┣ ReasonViewModelTest.cs
 ┃ ┃ ┣ StageDealViewModelTest.cs
 ┃ ┃ ┗ StageViewModelTest.cs
 ┃ ┣ WebApi
 ┃ ┃ ┣ Controllers
 ┃ ┃ ┃ ┗ v1
 ┃ ┃ ┃ ┃ ┣ ActivityControllerTest.cs
 ┃ ┃ ┃ ┃ ┣ BoardControllerTest.cs
 ┃ ┃ ┃ ┃ ┣ CompanyControllerTest.cs
 ┃ ┃ ┃ ┃ ┣ ContactControllerTest.cs
 ┃ ┃ ┃ ┃ ┣ DealControllerTest.cs
 ┃ ┃ ┃ ┃ ┣ MoveActivityControllerTest.cs
 ┃ ┃ ┃ ┃ ┣ ReasonControllerTest.cs
 ┃ ┃ ┃ ┃ ┗ StageControllerTest.cs
 ┃ ┃ ┗ Utilities
 ┃ ┃ ┃ ┣ BaseControllerTest.cs
 ┃ ┃ ┃ ┗ ResultFormatterTest.cs
 ┃ ┣ Com.DanLiris.Service.DealTracking.Test.csproj
 ┃ ┣ coverage.json
 ┃ ┗ HttpClientTestService.cs
```

**TestResults**

- Collections of files generated by the system for purposes of unit test code coverage.


**DealTrackingDbContext.cs**

This file contain context class that derives from DbContext in entity framework. DbContext is an important class in Entity Framework API. It is a bridge between domain or entity classes and the database. DbContext and context class  is the primary class that is responsible for interacting with the database.


**File Program.cs**

Important class that contains the entry point to the application. The file has the Main() method used to run the application and it is used to create an instance of WebHostBuilder for creating a host for the application. The Startup class to be used by the application is specified in the Main method.

**File Startup.cs**

This file contains Startup class. The Startup class configures services and the app's request pipeline.Optionally includes a ConfigureServices method to configure the app's services. A service is a reusable component that provides app functionality. Services are registered in ConfigureServices and consumed across the app via dependency injection (DI) or ApplicationServices.This class also Includes a Configure method to create the app's request processing pipeline.

**File .codecov.yml**

This file is used to configure code coverage in unit tests.

**File .travis.yml**

Travis CI (continuous integration) is configured by adding a file named .travis.yml. This file in a YAML format text file, located in root directory of the repository. This file specifies the programming language used, the desired building and testing environment (including dependencies which must be installed before the software can be built and tested), and various other parameters.

**File .codecov.yml**

This file is used to configure code coverage in unit tests.

**Com.DanLiris.Service.DealTracking**

File .sln is extention for *solution* aka file solution for .Net Core, this file is used to manage all project by code editor.

 ### Validation
Data validation using **IValidatableObject**