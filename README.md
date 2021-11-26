[![Nuget](https://img.shields.io/nuget/v/Autofac.EasyPropinject?style=for-the-badge)](https://www.nuget.org/packages/Autofac.EasyPropInject/) [![Paypal Donate](https://www.paypalobjects.com/en_US/DK/i/btn/btn_donateCC_LG.gif)https://www.paypal.com/donate/?hosted_button_id=SVZHLRTQ6H4VL]


# Important!
Due to breaking changes to Autofac API  with version 6.x older  Autofac.EasyPropInject Readme can be found in 1.0.x (Autofac <=4>) and 1.1.x (Autofac >=5 < 6>).
master and 1.2.x will show code examples and info only for Autofac >= 6.

# Autofac.EasyPropInject
An extension i created to make it possible to to  inject properties by attribute, without any other helper libs in  .NET Core for [Autofac](https://github.com/autofac/Autofac).

# Install
## Nuget 
`Install-Package Autofac.EasyPropInject`

## DotNetCli
`dotnet add package Autofac.EasyPropInject`

# Contribute / Donations
If you got any Ideas to improve my projects feel free to send an pull request. 

If you like my work and want to support me (or want to buy me a coffee/beer) paypal donation are more than appreciated.
[![Paypal Donate](https://www.paypalobjects.com/en_US/DK/i/btn/btn_donateCC_LG.gif)https://www.paypal.com/donate/?hosted_button_id=SVZHLRTQ6H4VL]

# Usage
## Startup.cs
Go to  "ConfigureServices"
Make sure that you create the Autofac Container as usual for your Framework (Supported is .NET Standard 2+) like its described here:
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

    [FromAutofac(typeof(IUnitOfWork))]
    public UnitOfWorkBaseClass unit2 {get;set;}
}
```
Once ``IMyInterface`` is resolved and activated EasyPropInject Middleware will try to resolve the types of unit and unit2.
In this case EasyPropInject will try to resolve IUnitOfWork from current container and  will try to set and Instance of IUnitOfWork to unit2 and use it as UnitOfWorkBaseClass.
*Warning* 
Since the type casting feature new in 1.2.x of EasyPropInject is handy sometimes its truly unsafe and you should to be sure what you are doing.


# Whats new?
* 1.2.0 - Implemented Easy Prop Inject for Autofac 6.x and added the feature to load an property as different type from IContainer. See FromAutofacAttribute.
* 1.1.1 - Easy Prop Inject now supports Autofac 5.x
* 1.0.0 - Added Tests

