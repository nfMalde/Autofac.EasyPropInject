[![Nuget](https://img.shields.io/nuget/v/Autofac.EasyPropinject?style=flat-square)](https://www.nuget.org/packages/Autofac.EasyPropInject/) 
 [![Paypal Donate](https://img.shields.io/badge/DONATE%E2%99%A5-PAYPAL-blue?style=flat-square&logo=paypal)](https://www.paypal.com/donate/?hosted_button_id=SVZHLRTQ6H4VL)
 [![Github](https://img.shields.io/badge/nfMalde-Autofac.EasyPropInject-lightgrey?style=flat-square&logo=github)](https://github.com/nfMalde/Autofac.EasyPropInject)


# Important!
Due to new Autofac v.8 Version - older versions stay as they are. Updates only occur to latest version released.


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

 [![Paypal Donate](https://img.shields.io/badge/DONATE%E2%99%A5-PAYPAL-blue?style=for-the-badge&logo=paypal)](https://www.paypal.com/donate/?hosted_button_id=SVZHLRTQ6H4VL)

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
          
          //Add your services now as usual 
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


    [FromAutofac] //Since Autofac.EasyPropInject@1.2.5: Support for protected properties
    protected IMyService serviceProtected {get;set;}

    [FromAutofac] //Since Autofac.EasyPropInject@1.2.5: Support for private properties
    private IMyService2 servicePrivate {get;set;}

    [FromAutofac(typeof(IUnitOfWork))]
    public UnitOfWorkBaseClass unit2 {get;set;}
}
```
Once ``IMyInterface`` is resolved and activated EasyPropInject Middleware will try to resolve the types of unit and unit2.
In this case EasyPropInject will try to resolve IUnitOfWork from current container and  will try to set and Instance of IUnitOfWork to unit2 and use it as UnitOfWorkBaseClass.
*Warning* 
Since the type casting feature new in 1.2.x of EasyPropInject is handy sometimes its truly unsafe and you should to be sure what you are doing.


# Whats new?
* 2.0.0 - Upgraded to latest Autofac (8.x)
* 1.2.5 - Upgraded to Autofac 6.3.x, Added support for private and protected properties See tests for example (https://github.com/nfMalde/Autofac.EasyPropInject/blob/1.2.x/tests/Autofac.EasyPropInject.Testing/InjectionTests.cs)
* 1.2.4 - Upgraded to Autofac 6.2.x
* 1.2.3 - Upgraded to Autofac 6.1.x
* 1.2.0 - Implemented Easy Prop Inject for Autofac 6.x and added the feature to load an property as different type from IContainer. See FromAutofacAttribute.
* 1.1.1 - Easy Prop Inject now supports Autofac 5.x
* 1.0.0 - Added Tests
