# Autofac.EasyPropInject
An extension i created to make it possible to to  inject properties by attribute, without any other helper libs in  .NET Core for [Autofac](https://github.com/autofac/Autofac).

# Important
This Branch is inactive besides minor fixes. We recommend to update your Autofac Dependency to 6.x.
Easy Prop Inject 1.0.x supports all Autofac 4.x Versions

Autofac 6 Users please have a look at branch 1.2.x.
Autofac 5.14+ Users please have a look at branch master and 1.1.x 

# Install
## Nuget
`Install-Package Autofac.EasyPropInject`
## DotNetCli
`dotnet add package Autofac.EasyPropInject`


# Usage
## Startup.cs
Go to  "ConfigureServices"
Make sure that you create the Autofac Container as usual for your Framework (Supported is .NET CORE 2.x) like its described here:
https://autofac.readthedocs.io/en/latest/integration/index.html


and then you create the instance BEFORE any registration.
```c#
   public IServiceProvider ConfigureServices(IServiceCollection services)
   {
          ......
          var builder = new ContainerBuilder().AddEasyPropInject();
          
          //Add you services now as usual 
    }
    
```

## Usage in the Code
```c#
using Autofac.EasyPropInject.Annotations;
public class MyClass:IMyInterface 
{ 
    public MyClass(ISomeOtherInterface someService) 
    { 
      
    }
    
    [FromAutofac]
    public IUnitOfWork unit { get;set; }
}
```
After "MyClass" is  activated by autofac,  "IUnitOfWork unit" will be resolved and set to the property.
