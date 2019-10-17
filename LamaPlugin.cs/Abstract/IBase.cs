using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamaPlugin
{
    /// <summary>
    /// LamaProperty name
    /// </summary>
    public enum LamaProperty
    {
        /// <summary>
        /// [Bool]
        /// </summary>
        CONNECTED,
        /// <summary>
        /// [Int]
        /// </summary>
        CURRENTMAPID,
        /// <summary>
        /// [Bool]
        /// </summary>
        INVISIBLESERVER,
        /// <summary>
        /// 
        /// </summary>          
        LANG,
        /// <summary>
        /// [Bool]
        /// </summary>
        LAUNCHED,
        /// <summary>
        /// [NTK.IO.Xml.XmlDocument]
        /// </summary>      
        MAINCONFIG,
        /// <summary>
        /// [Int]
        /// </summary>   
        MAXPLAYERS,
        /// <summary>
        /// [Int]
        /// </summary>    
        MAXSPECTATORS,
        /// <summary>
        /// [Int]
        /// </summary>    
        NBPLAYERS,
        /// <summary>
        /// [Int]
        /// </summary>      
        PREVIOUSMAPID,
        /// <summary>
        /// [Bool]
        /// </summary>            
        REMOTE,
        /// <summary>
        /// [String]
        /// </summary>           
        REMOTEADRS,
        /// <summary>
        /// [Int]
        /// </summary>      
        REMOTEPORT,
        /// <summary>
        /// [Dictionnary(String,String)]
        /// </summary>         
        SCRIPTSETTINGSLOCALES,
        /// <summary>
        /// [Int]
        /// </summary>     
        STARTMODE,
        /// <summary>
        /// [Bool]
        /// </summary>   
        INEDITMODE,

    }


    public delegate object GetLamaProperty(LamaProperty name);


    public interface IBase
    {
        string Author { get; set; }
        string PluginName { get; set; }
        string Version { get; set; }
        string PluginFolder { get; set; }

        PluginType PluginType { get; set; }

        List<Requirement> Requirements { get; set; }

        OnError OnError { get; set; }
        Logger Log { get; set; }
    }
}
