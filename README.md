# Autofac.EasyPropInject
An extension i created to make it possible to to  inject properties by attribute, without any other helper libs in  .NET Core for [Autofac](https://github.com/autofac/Autofac).

# Install
## Nuget
`Install-Package Autofac.EasyPropInject -Version 1.0.0`
## DotNetCli
`dotnet add package Autofac.EasyPropInject --version 1.0.0`


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
using Autofac.EasyPropInject.Annotations
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
