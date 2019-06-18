using System;
using System.Collections.Generic;
using System.Text;

namespace LamaLang
{
    public class BaseFR : BaseLang
    {
        public override Dictionary<string, Dictionary<string, string>> getLangDictionary()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> getScriptSettingsDictionary()
        {
            return new Dictionary<string, string>()
            {
                {"S_TimeLimit","Time Limit" },
                {"S_","" },
                {"","" },
  
            };
        }
    }
}
