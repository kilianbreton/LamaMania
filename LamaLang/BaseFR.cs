using System;
using System.Collections.Generic;
using System.Text;

namespace LamaLang
{
    public class BaseFR : BaseLang
    {
        public BaseFR(string name) : base(name)
        {
            NodeLang main = this.addChild("main");
            NodeLang home = main.addChild("home");
            home.addChild("", "");
            home.addChild("", "");
            home.addChild("", "");
            home.addChild("", "");
            home.addChild("", "");
            home.addChild("", "");
            home.addChild("", "");

            NodeLang users = main.addChild("users");
            users.addChild("", "");
            users.addChild("", "");
            users.addChild("", "");
            users.addChild("", "");
            users.addChild("", "");
            users.addChild("", "");
            users.addChild("", "");


        }
    }
}
