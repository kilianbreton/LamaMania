using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NTK.IO.Ini;
using NTK.IO;



namespace LamaMania
{

    /// <summary>
    /// 
    /// </summary>
    public enum PathVariable
    {
        /// <summary>
        /// 
        /// </summary>
        CURRENT,
        /// <summary>
        /// 
        /// </summary>
        APPDATA,
        /// <summary>
        /// 
        /// </summary>
        DOCUMENTS,
        /// <summary>
        /// 
        /// </summary>
        TEMP,
        /// <summary>
        /// 
        /// </summary>
        PROGRAMS,
        /// <summary>
        /// 
        /// </summary>
        DESKTOP,
    }
    
    public enum ServerMode
    {
        EXTERNAL,
        APPDATA,
        DOCUMENTS
    }
    
    
    /// <summary>
    /// Gère les emplacements en fonction du fichier ini
    /// </summary>
    public class EnvironmentManager
    {
        private IniDocument configIni;
        private string mainMode;
        private ServerMode serverMode;
        private string configPath;
        private string ressourcesPath;
        private string cachePath;




        /// <summary>
        /// 
        /// </summary>
        public EnvironmentManager()
        {
            this.configIni = new IniDocument("LamaMania.ini");
            IniGroup main = this.configIni.getGroup("MAIN");
            this.mainMode = main.getValue("Mode");

            IniGroup cfg = this.configIni.getGroup(mainMode);
            this.cachePath = cfg.getValue("CachePath");
            this.configPath = cfg.getValue("ConfigPath");
            this.ressourcesPath = cfg.getValue("RessourcesPath");



        }



        private string getTruePath(string v)
        {
            switch (v.ToUpper())
            {
                case "$EXTERNAL$":
                    return v;
  
                case "$CURRENT_PATH$":
                case "$CURRENTPATH$":
                    return Directory.GetCurrentDirectory();

                case "$TEMP$":
                    return Path.GetTempPath();

                case "$DOCUMENTS$":
                    return v;
                case "$APPDATA$":
                    return v;
                case "$PROGRAMS$":
                    return v;
                case "$DESKTOP$":
                    return v;
                case "$PROGRAM_FILES$":
                case "$PROGRAMFILES$":
                    return v;
                default:
                    return v;
            }


        }


    }
}
