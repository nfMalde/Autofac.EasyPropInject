﻿using Autofac.EasyPropInject.Annotations;

namespace Autofac.EasyPropInject.Testing.mocks
{
    public interface IMock2
    {
        IMock3 Mock3Property { get; set; }

        string GetString();
    }

    public class Mock2 : IMock2
    {
        [FromAutofac]
        public IMock3 Mock3Property { get; set; }

        public string GetString()
        {
            return "Mock2:String";
        }
    }
}