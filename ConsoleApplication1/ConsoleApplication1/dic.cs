using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class dic
    {
        public string Jezyki(string podanyJezyk)
        {
            Dictionary<string, string> mojDic = new Dictionary<string, string>()
            {
                {"polski","polish"},
                {"angielski","english"},
                {"niemiecki","deutch"}
            };

            return (mojDic.ContainsKey(podanyJezyk)) ? mojDic[podanyJezyk] : "nieznany";
            
        }
    }
}