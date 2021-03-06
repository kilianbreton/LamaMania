﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMXmlRpcLib;

namespace LamaPlugin
{
    public enum HomeComponentType
    {
        Tab,
        HomeModule,
    }

    /// <summary>
    /// Interface for HomeComponent UserControl
    /// </summary>
    public interface IHomeComponent : IBasePlugin
    {
        XmlRpcClient client { get; set; }

        HomeComponentType Type { get; set; }

        GetLamaProperty GetLamaProperty { get; set; }

        bool NeedXmlRpcConnection { get; set; }
    }
}
