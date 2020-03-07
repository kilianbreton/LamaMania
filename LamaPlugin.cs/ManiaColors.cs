/* ----------------------------------------------------------------------------------
 * Project : LamaMania
 * Launch Authenticate Manage & Access ManiaPlanet Servers
 * Inspired by ServerMania by Cyrlaur
 * 
 * ----------------------------------------------------------------------------------
 * Author:	    Breton Kilian
 * Copyright:	April 2019 by Breton Kilian
 * ----------------------------------------------------------------------------------
 *
 * LICENSE: This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.If not, see<http://www.gnu.org/licenses/>.
 *
 * ----------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using static NTK.Other.NTKF;

namespace LamaPlugin
{
    /// <summary>
    /// Classe permettant de parser les couleurs maniaplanet et d'écrire le texte coloré dans un Control
    /// </summary>
    public class ManiaColors
    {
        private static bool running = false;
        private RichTextBox tb;
        private Color defaultColor = Color.White;
        private static List<string> nadeoCodes = new List<string>() { "$w", "$W", "$n", "$N", "$o", "$O", "$i", "$I", "$t", "$T", "$s", "$S", "$g", "$G", "$z", "$Z", "$<", "$>"};
        private static Dictionary<string, FontStyle> nadeoStyles = new Dictionary<string, FontStyle>()
        {
            {"$W", FontStyle.Bold },
            {"$O", FontStyle.Bold },
            {"$I", FontStyle.Italic },
            {"$Z", FontStyle.Regular },
        };

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Instanciation de la classe
        /// </summary>
        /// <param name="tb">RichtextBox du chat</param>
        public ManiaColors(RichTextBox tb)
        {
            this.tb = tb;
        }
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="defaultColor"></param>
        public ManiaColors(RichTextBox tb, Color defaultColor)
        {
            this.tb = tb;
            this.defaultColor = defaultColor;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes Publiques ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
        /// <summary>
        /// Ecrit le texte dans le control
        /// </summary>
        /// <param name="txt"></param>
        public void write(string txt)
        {
            while (running)
            {
                Thread.Sleep(50);   
            }
            running = true;

            string text = txt;
            Color color = defaultColor;
            List<FontStyle> fonts = new List<FontStyle>() { FontStyle.Regular };
            for(int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '$')
                {
                    string str = new string(new char[] { c, text[i + 1] });
                    //Check Styles codes
                    if (nadeoStyles.ContainsKey(str.ToUpper()))
                    {
                        //If $z clear style list
                        var style = nadeoStyles[str.ToUpper()];
                        if (style == FontStyle.Regular)
                            color = defaultColor;
                        fonts[0]= style;

                        text = text.Remove(i, 2); //remove code
                    }
                    else if (nadeoCodes.Contains(str))
                    {
                        if(str.ToUpper() == "$G")
                        {
                            color = defaultColor;
                        }
                        text = text.Remove(i, 2); //remove code
                    }
                    else
                    {
                        try
                        {
                            //Check colors codes
                            string colorCode = text.ToUpper().Substring(i + 1, 3);
                            color = parseColorCode(colorCode);
                            text = text.Remove(i, 4); //remove code
                        }catch(Exception)
                        {
                          //  Lama.log("ERROR", "[ManiaColors]>" + txt + " : " + e.Message);
                            break;
                        }
                    }
                    i--;
                }
                else //Write one by one
                {
                    writeRich(c.ToString(), color, fonts);
                }
            }
            running = false;
        }
        
        /// <summary>
        /// Obtient le texte sans les codes couleur
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string getText(string text)
        { 
            foreach(string str in nadeoCodes)
            {
                text = text.Replace(str, "");
            }
            text = text.Replace("$$", "<[{(DOL)}]>");
            while (text.Contains("$"))
            {
                if(text.IndexOf("$") + 3 < text.Length)
                {
                    text = text.Remove(text.IndexOf("$"), 4);
                    
                }

            }
            text = text.Replace("<[{(DOL)}]>", "$");


            return text;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes privées //////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Retourne un objet Color depuis un code couleur maniaplanet
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Color parseColorCode(string code)
        {
            Color ret;
            if (code.Length == 3)
            {
                ret = Color.FromArgb(1,hexaToInt(code[0]), hexaToInt(code[1]), hexaToInt(code[2]));
            }
            else
            {
                throw new Exception();
            }
          
           
            return ret;
        }

        /// <summary>
        /// Valeur hexadécimale vers entier (result x 17) 255/15=17
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        int hexaToInt(Char hex)
        {
            if (!int.TryParse(hex.ToString(), out int ret))
            {
                switch (hex)
                {
                    case 'A':
                        ret = 10;
                        break;
                    case 'B':
                        ret = 11;
                        break;
                    case 'C':
                        ret = 12;
                        break;
                    case 'D':
                        ret = 13;
                        break;
                    case 'E':
                        ret = 14;
                        break;
                    case 'F':
                        ret = 15;
                        break;
                }
            }
            return (ret)*17;
        }
      
        /// <summary>
        /// Ecrit dans la console de chat
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="fs"></param>
        void writeRich(String text, Color color, List<FontStyle> fs)
        {
            if (tb.InvokeRequired)
            {
                tb.Invoke(new Action<String, Color, List<FontStyle>>(writeRich), text, color, fs);
            }
            else
            {
                if (fs.Count > 0)
                    this.tb.SelectionFont = new Font(this.tb.Font, fs[0]);
                
                //this.tb.Font = new Font(FontFamily.GenericSansSerif,10,fs[0]);
                this.tb.SelectionColor = color;
                this.tb.AppendText(text);
                this.tb.ScrollToCaret();
            }
           
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GETTERS & SETTERS /////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Default color (White)
        /// </summary>
        public Color DefaultColor { get => defaultColor; set => defaultColor = value; }


    }
}
