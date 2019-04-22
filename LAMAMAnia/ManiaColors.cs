using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NTK.Other.NTKF;

namespace LAMAMAnia
{
    /// <summary>
    /// Classe permettant de parser les couleurs maniaplanet et d'écrire le texte coloré dans un Control
    /// </summary>
    public class ManiaColors
    {
        private String text;
        private RichTextBox tb;
        private Label label;
        private bool unColorMode = false; //Ignore les codes couleurs


        public ManiaColors(RichTextBox tb)
        {
            this.tb = tb;
        }

        /// <summary>
        /// Ecrit le texte dans le control
        /// </summary>
        /// <param name="text"></param>
        public void write(String text)
        {
            String tmp = "";
            List<FontStyle> styles = new List<FontStyle>();
            Color color = Color.White;
            String textUp = text.ToUpper();
            bool haveDol = false;

            
            for(int i = 0; i < textUp.Length; i++)
            {
                char c = text[i];
                if (c == '$')
                {
                    if (haveDol)
                    {
                        //write & reset
                        writeRich(tmp, color, styles);
                        tmp = "";
                    }
                    else
                    {
                        haveDol = true;
                    }
                   
                    switch (textUp[i + 1])
                    {

                        case '$':   //Display Dol
                            tmp += "$";
                            break;
                        case 'O':   //Bold
                            styles.Add(FontStyle.Bold);
                            break;
                        case 'W':   //Wide
                            styles.Add(FontStyle.Bold);
                            break;
                        case 'Z':   //Reset
                            color = Color.White;
                            styles.Clear();
                            break;
                        case 'I':   //Italic
                            styles.Add(FontStyle.Italic);
                            break;
                        default:    //Colors
                            string colorCode = textUp.Substring(i+1, 3);
                            color = parseColorCode(colorCode);
                            i += 2;
                            break;
                    }
                    i++;
                }
                else
                {
                    tmp += c;
                }
            }
            if (tmp.Length > 0)
            {
                writeRich(tmp, color, styles);
            }
        }


        public string getText(string text)
        {
            String tmp = "";
            List<FontStyle> styles = new List<FontStyle>();
            Color color = Color.White;
            String textUp = text.ToUpper();
            bool haveDol = false;


            for (int i = 0; i < textUp.Length; i++)
            {
                char c = text[i];
                if (c == '$')
                {
                    if (haveDol)
                    {
                      
                    }
                    else
                    {
                        haveDol = true;
                    }

                    switch (textUp[i + 1])
                    {

                        case '$':   //Display Dol
                            tmp += "$";
                            break;
                        case 'O':   //Bold
                            styles.Add(FontStyle.Bold);
                            break;
                        case 'W':   //Wide
                            styles.Add(FontStyle.Bold);
                            break;
                        case 'Z':   //Reset
                            color = Color.White;
                            styles.Clear();
                            break;
                        case 'I':   //Italic
                            styles.Add(FontStyle.Italic);
                            break;
                        default:    //Colors
                         
                            i += 2;
                            break;
                    }
                    i++;
                }
                else
                {
                    tmp += c;
                }
            }
            return tmp;
        }


        private Color parseColorCode(string code)
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

        int hexaToInt(Char hex)
        {
            int ret = 0;
            switch (hex)
            {
                case '0':
                    ret = 0;
                    break;
                case '1':
                    ret = 1;
                    break;
                case '2':
                    ret = 2;
                    break;
                case '3':
                    ret = 3;
                    break;
                case '4':
                    ret = 4;
                    break;
                case '5':
                    ret = 5;
                    break;
                case '6':
                    ret = 6;
                    break;
                case '7':
                    ret = 7;
                    break;
                case '8':
                    ret = 8;
                    break;
                case '9':
                    ret = 9;
                    break;
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
            return (ret)*17;
        }
      
        private void writeRich(String text, Color color, List<FontStyle> fs)
        {
            if (fs.Count > 0)
                this.tb.SelectionFont = new Font(this.tb.Font,fs[0]);

            //this.tb.Font = new Font(FontFamily.GenericSansSerif,10,fs[0]);
            this.tb.SelectionColor = color;
            this.tb.AppendText(text);
            this.tb.ScrollToCaret();
        }


    }
}
