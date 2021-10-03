using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static NTK.Other.NTKF;
using CGE.OUT;
using NTK.IO.Xml;
using CGE;
using CGE.IN;

namespace LamaController
{
    public class LamaCLI
    {
        public LamaCLI()
        {

        }

        public void start()
        {
            CLIReadLineWithEvents cli = new CLIReadLineWithEvents();
            string cmd = "";
            while(cmd.ToUpper() != "Q")
            {
                
                Console.Write("Lama>");
                //cmd = cli.ReadLine();
                cmd = "MAKE LOCALESSCRIPTSETTINGS";
                switch (cmd.ToUpper().Trim())
                {
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // HELP ///////////////////////////////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case "CLEAR":
                    case "CLS":
                        Console.Clear();
                        break;
                    case "HELP":
                        Console.WriteLine("MAKE                             Make file :                                         - Try: HELP MAKE");
                        Console.WriteLine("GET                              Get data in config, ENV or get files from web       - Try: HELP GET");
                        Console.WriteLine("UPDATE                           Update LamaController                               - Try: HELP UPDATE");
                        Console.WriteLine("");

                        break;

                    case "HELP MAKE":
                        Console.WriteLine(" Locales :");
                        Console.WriteLine("     - LocalesGlobalLamaManiaLang ");
                        Console.WriteLine("     - LocalesUAsecoConfig ");
                        Console.WriteLine("     - LocalesScriptSettings ");
                        Console.WriteLine("     - LocalesFromXmlFile #PATH ");
                        Console.WriteLine(" Config :");
                        Console.WriteLine("     - ConfigLamaController ");
                        Console.WriteLine("     - ConfigLamaMania ");
                        break;
                    case "HELP UPDATE":
                        Console.WriteLine(" - All ");
                        Console.WriteLine(" - LamaController ");
                        Console.WriteLine(" - LamaMania ");
                        Console.WriteLine(" - DedicatedServer ");
                        Console.WriteLine(" - UAseco ");
                        Console.WriteLine(" - Plugins");
                        Console.WriteLine(" - Plugin #PLUGIN_NAME");

                        break;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // COMMANDS ///////////////////////////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////
                    default:
                        if(cmd.ToUpper().Contains("MAKE "))
                        {
                            switch(subsep(cmd.ToUpper(),"MAKE ").ToUpper())
                            {
                                case "LOCALESSCRIPTSETTINGS":
                                    XmlDocument localesScript = new XmlDocument(@"Config\locales\base\ScriptSettings.xml");
                                    XmlNode root = localesScript["locales"];

                                    Console.Write("Language Name : ");
                                    root.addAttribute("lang", Console.ReadLine());

                                    XmlNode scriptSet = root["ScriptSettings"];
                                    XmlAppender xmla = new XmlAppender(scriptSet);
                                    bool abandon = false;
                                    Dictionary<string, string> dic = new Dictionary<string, string>();
                                    while (xmla.next() && !abandon)
                                    {
                                        /*         XmlNode n = xmla.get();
                                                 Console.Write(n.Name + " [" + n.Value + "] : ");
                                                 string res = Console.ReadLine();
                                                 if (res != "" && res != "!q")
                                                     n.Value = res;
                                                 if (res == "!q")
                                                     abandon = true;*/

                                        XmlNode n = xmla.get();
                                        if(!dic.ContainsKey(n.Name))
                                            dic.Add(n.Name, n.Value);
                                      
                                    }
                                    NDataList dl = new NDataList(dic, false);
                                    dl.DefaultBackColor = ConsoleColor.Black;
                                    dl.DefaultForeColor = ConsoleColor.White;
                                    dl.show();

                                    localesScript.saveAs(@"D:\scrptset.xml");

                                    break;
                            }
                        }
                        else if(cmd.ToUpper().Contains("GET "))
                        {

                        }
                        else if (cmd.ToUpper().Contains("UPDATE "))
                        {
                            Loading loader;
                            switch (subsep(cmd.ToUpper(), "UPDATE ").ToUpper())
                            {
                                case "ALL":
                                    loader = new Loading("Connect to LamaMania.fr", true);
                                    Thread.Sleep(500);
                                    loader.stop();
                                    Thread.Sleep(100);
                                    loader = new Loading("Connect to LamaMania.fr", true);
                                    Thread.Sleep(500);
                                    loader.stop();
                                    break;
                                case "LAMACONTROLLER":
                                    break;
                                case "LAMAMANIA":
                                    break;
                                case "DEDICATEDSERVER":
                                    break;
                                case "UASECO":
                                    break;
                                case "PLUGINS":
                                    break;
                                default:
                                    if(cmd.ToUpper().Contains(" PLUGIN "))
                                    {
                                        string name = subsep(cmd.ToUpper(), " PLUGIN ");
                                        loader = new Loading("Load : " + name, true);
                                        Thread.Sleep(1000);
                                        loader.stop();
                                        Thread.Sleep(100);
                                        loader = new Loading("Update : " + name, true);
                                        Thread.Sleep(5000);
                                        loader.stop();
                                        
                                      
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid command");
                                    }
                                    break;

                            }
                        }
                        break;
                }

            } 
        }
    }
}
