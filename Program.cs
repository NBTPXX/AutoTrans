using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace RimTrans
{
    static class StaticVars
    {
        public const string DIRBASE = "Mods\\";
        public const string DIRDEFS = "Defs\\";
        public const string DIRLANGUAGES = "Languages\\";

        public const string UserDictCSV = "ymldict.csv";
        public const string DirOldBase = "old\\";
        public const string DIRCN = "chn\\";
        public const string DIRCNen = "chn\\english\\";
        public const string DIRCNcn = "chn\\simp_chinese\\";
    }
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmTranslator());
        }
    }
    public class NodeInfo
    {
        public string TypeFolder { get; set; }
        public string SubFolder { get; set; }
        public string FileName { get; set; }
        public string NodeName { get; set; }
        public string NodeText { get; set; }
        public string FilePath
        {
            get
            {
                if (SubFolder == "") { return TypeFolder + "\\" + FileName; }
                return TypeFolder + "\\" + SubFolder + "\\" + FileName;
            }
        }
        public string NodeKey
        {
            get
            {
                return (FilePath + "." + NodeName).ToLower();
            }
        }
    }
    public class XMLdata
    {
        private bool isedited;
        private string contentdest, contenteng;  //翻译后内容
        private NodeInfo nodeinfo;

        private XMLdata()
        {
            isedited = false;
            contenteng = "";
            contentdest = "";
            nodeinfo = new NodeInfo();
        }
        public XMLdata(NodeInfo Info) : this()
        {
            nodeinfo = NewNodeinfo(Info);
        }
        public XMLdata(NodeInfo Info, bool IsEnglishorDest) : this()
        {
            if (IsEnglishorDest == true)
            {
                nodeinfo = NewNodeinfo(Info.FileName, Info.NodeName, "", Info.SubFolder, Info.TypeFolder);
                contenteng = Info.NodeText;
            }
            else
            {
                nodeinfo = NewNodeinfo(Info.FileName, Info.NodeName, "", Info.SubFolder, Info.TypeFolder);
                contentdest = Info.NodeText;
            }
        }

        private NodeInfo NewNodeinfo(string filename, string nodename, string nodetext, string subfolder, string typefolder)
        {
            return new NodeInfo() { FileName = filename, NodeName = nodename, NodeText = nodetext, SubFolder = subfolder, TypeFolder = typefolder };
        }
        private NodeInfo NewNodeinfo(NodeInfo Info)
        {
            return new NodeInfo() { FileName = Info.FileName, NodeName = Info.NodeName, NodeText = Info.NodeText, SubFolder = Info.SubFolder, TypeFolder = Info.TypeFolder };
        }
        public string LabelName
        {
            get
            {
                return nodeinfo.NodeName;
            }
        }
        public string ContentEng
        {
            get
            {
                if (contenteng == "") { return nodeinfo.NodeText; }
                return contenteng;
            }
        }

        public string ContentDest
        {
            get
            {
                if (contentdest == "") { return ContentEng; }
                return contentdest;
            }
        }



        public string TypeFolder
        {
            get
            {
                return nodeinfo.TypeFolder;
            }
        }
        public string SubFolder
        {
            get
            {
                return nodeinfo.SubFolder;
            }
        }
        public string FileName
        {
            get
            {
                return nodeinfo.FileName;
            }
        }

        public string FilePath
        {
            get
            {
                return nodeinfo.FilePath;
            }
        }
        public string NodeKey()
        {
            return nodeinfo.NodeKey.ToLower();
        }


        public void ApplyLine(string ApplyText)
        {
            contentdest = ApplyText;
            isedited = true;
        }

        public void SetDest(string ApplyText)
        {
            contentdest = ApplyText;
        }
        public bool IsEdited
        {
            get
            {
                return isedited;
            }
        }

        public bool SameInToAndFrom()
        {
            if (contenteng != "" && contenteng != contentdest)
            {
                return false;
            }
            if (nodeinfo.NodeText != contentdest) { return false; }
            return true;
        }
    }
    public static class XMLTools
    {

        private static string GetTranslationFromBaiduFanyi(string q)
        {
            // 源语言
            string from = "en";
            // 目标语言    
            string to = Situation.Sit;
            // 改成您的APP ID
            string appId = Situation.Id;
            Random rd = new Random();
            string salt = rd.Next(100000).ToString();
            // 改成您的密钥
            string secretKey = Situation.Key;
            string sign = EncryptString(appId + q + salt + secretKey);
            string url = "http://api.fanyi.baidu.com/api/trans/vip/translate?";
            url += "q=" + HttpUtility.UrlEncode(q);
            url += "&from=" + from;
            url += "&to=" + to;
            url += "&appid=" + appId;
            url += "&salt=" + salt;
            url += "&sign=" + sign;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = 6000;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            Console.WriteLine(retString);
            Console.ReadLine();
            Root dst = JsonConvert.DeserializeObject<Root>(retString);
            if (dst.Error_code == "52003")
            {
                Situation.check = "未授权用户";
            }
            else if (dst.Error_code == "52001")
            {
                Situation.check = "请求超时";
            }
            else if (dst.Error_code == "52002")
            {
                Situation.check = "系统错误";
            }
            else if (dst.Error_code == "54000")
            {
                Situation.check = "必填参数为空";
            }
            else if (dst.Error_code == "54001")
            {
                Situation.check = "签名错误";
            }
            else if (dst.Error_code == "54003")
            {
                Situation.check = "访问频率受限";
            }
            else if (dst.Error_code == "52004")
            {
                Situation.check = "账户余额不足";
            }
            else if (dst.Error_code == "52005")
            {
                Situation.check = "长query请求过于频繁";
            }
            else if (dst.Error_code == "58000")
            {
                Situation.check = "客户端IP非法";
            }
            else if (dst.Error_code == "58001")
            {
                Situation.check = "译文语言方向不支持";
            }
            else if (dst.Error_code == "58002")
            {
                Situation.check = "服务器当前已关闭";
            }
            else if (dst.Error_code == "90107")
            {
                Situation.check = "认证未通过或未生效";
            }
            else if (dst.Error_code == null) 
            {
                Situation.check = "登陆成功";
                string result = dst.Trans_result[0].Dst;
                return result;
            }
            return "";
            //解析json
        }
        public static string EncryptString(string str)
        {
            MD5 md5 = MD5.Create();
            // 将字符串转换成字节数组
            byte[] byteOld = Encoding.UTF8.GetBytes(str);
            // 调用加密方法
            byte[] byteNew = md5.ComputeHash(byteOld);
            // 将加密结果转换为字符串
            StringBuilder sb = new StringBuilder();
            foreach (byte b in byteNew)
            {
                // 将字节转换成16进制表示的字符串，
                sb.Append(b.ToString("x2"));
            }
            // 返回加密的字符串
            return sb.ToString();
        }
        public static string GetTranslatedTextFromAPI(string TexttoTranslate)
        {
            if (TexttoTranslate != "") 
            {
                string result = GetTranslationFromBaiduFanyi(TexttoTranslate);
                return result;
            }
            else
            return "Nothing";
        }
        // 用于从baidu 翻译API获取翻译。
        public class Trans_resultItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string Src { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Dst { get; set; }
        }
        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public string Error_code { get; set; }
            /// <summary>
            /// 
            /// </summary>

            public string Error_msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string From { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string To { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Trans_resultItem> Trans_result { get; set; }
        }
        public static string RegexGetWith(string RegText, string RegexRule)
        {
            Regex Reggetname = new Regex(RegexRule, RegexOptions.None);
            StringBuilder returnString = new StringBuilder();
            var matches = Reggetname.Matches(RegText);

            foreach (var item in matches)
            {
                returnString.Append(item.ToString());
            }
            return returnString.ToString();
        }
        public static string RegexGetName(string RegText)
        {
            return RegexGetWith(RegText, "(^.*?):.*?(?=\")");
        }
        public static string RegexGetValue(string RegText)
        {
            return RegexGetWith(RegText, "(?<=(\\s\")).+(?=\")");
        }
        public static string RegexGetNameOnly(string RegText)
        {
            RegText = RegText.Replace(" ", "");
            return RegexGetWith(RegText, "^.*(?=:)");
        }
        public static string RegexRemoveColorSign(string RegText)
        {
            return RegexGetWith(RegText, "(?<=(§.)).+(?=(§!))");
        }
        private static string RegexStringWordBoundry(string input)
        {
            return @"(\W|^)" + input + @"(\W|$)";
        }
        public static bool RegexContainsWord(string input, string WordToMatch)
        {
            if (Regex.IsMatch(input, RegexStringWordBoundry(WordToMatch), RegexOptions.IgnoreCase)) { return true; }
            return false;
        }
        // 用于截取

        public static void OpenWithBrowser(string TextToTranslate, string APIEngine)
        {
            StringBuilder StrOpeninBrowser = new StringBuilder();
            StrOpeninBrowser.Append("http://fanyi.baidu.com/?#en/zh/");
            StrOpeninBrowser.Append(TextToTranslate);
            System.Diagnostics.Process.Start(StrOpeninBrowser.ToString());
        }
        // 用于默认浏览器打开翻译网页
        public static string RemoveReturnMark(string input)
        {
            StringBuilder RemoveReturnText = new StringBuilder();
            RemoveReturnText.Append(input);
            RemoveReturnText.Replace("\r", "");
            RemoveReturnText.Replace("\n", "");
            return RemoveReturnText.ToString();
        }
        // 用于移除换行符。
        public static string ReplaceWithUserDict(string input, Dictionary<string, string> dict)
        {
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Regex rgx = new Regex(RegexStringWordBoundry(kvp.Key), RegexOptions.IgnoreCase);
                input = rgx.Replace(input, " " + kvp.Key + "<" + kvp.Value + "> ");
            }
            return input;
        }

        public static List<XMLdata> ReadFolder(string modname, string language)
        {
            string OriPath = StaticVars.DIRBASE + modname + "\\Defs\\";
            string EngPath = StaticVars.DIRBASE + modname + "\\Languages\\English\\";
            string ChnPath = StaticVars.DIRBASE + modname + "\\Languages\\" + language + "\\";
            List<NodeInfo> nodeori = new List<NodeInfo>();
            List<NodeInfo> nodeeng = new List<NodeInfo>();
            List<NodeInfo> nodechn = new List<NodeInfo>();
            XmlDocument xdoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings() { IgnoreComments = true };

            NodeInfo XNodeInfo = new NodeInfo() { FileName = "", SubFolder = "", TypeFolder = "", NodeName = "", NodeText = "" };
            XMLdata Xdata;
            List<XMLdata> lstXMLdata = new List<XMLdata>();
            Dictionary<string, NodeInfo> DestDict = new Dictionary<string, NodeInfo>();
            Dictionary<string, NodeInfo> EngDict = new Dictionary<string, NodeInfo>();

            XNodeInfo.TypeFolder = "Keyed";
            if (Directory.Exists(EngPath + "Keyed\\"))
            {
                nodeeng.AddRange(ReadFileList(Directory.GetFiles(EngPath + "Keyed\\")));
            }
            else if (Directory.Exists(ChnPath + "Keyed\\"))
            {
                nodeeng.AddRange(ReadFileList(Directory.GetFiles(ChnPath + "Keyed\\")));
            }
            if (Directory.Exists(ChnPath + "Keyed\\"))
            {
                nodechn.AddRange(ReadFileList(Directory.GetFiles(ChnPath + "Keyed\\")));
            }
            // 读取Keyed下的中文和英文文本

            XNodeInfo.TypeFolder = "DefInjected";
            if (Directory.Exists(EngPath + "\\DefInjected\\"))
            {
                foreach (string dir in Directory.GetDirectories(EngPath + "\\DefInjected\\"))
                {
                    XNodeInfo.SubFolder = Path.GetFileName(dir);
                    nodeeng.AddRange(ReadFileList(Directory.GetFiles(Path.GetFullPath(dir))));
                }
            }
            else if (Directory.Exists(ChnPath + "\\DefInjected\\"))
            {
                foreach (string dir in Directory.GetDirectories(ChnPath + "\\DefInjected\\"))
                {
                    XNodeInfo.SubFolder = Path.GetFileName(dir);
                    nodeeng.AddRange(ReadFileList(Directory.GetFiles(Path.GetFullPath(dir))));
                }
            }
            if (Directory.Exists(ChnPath + "\\DefInjected\\"))
            {
                foreach (string dir in Directory.GetDirectories(ChnPath + "\\DefInjected\\"))
                {
                    XNodeInfo.SubFolder = Path.GetFileName(dir);
                    nodechn.AddRange(ReadFileList(Directory.GetFiles(Path.GetFullPath(dir))));
                }
            }
            // 读取DefInjected下的中文和英文文本

            foreach (NodeInfo no in nodechn)
            {
                DestDict.Add(no.NodeKey, new NodeInfo() { FileName = no.FileName, NodeName = no.NodeName, NodeText = no.NodeText, SubFolder = no.SubFolder, TypeFolder = no.TypeFolder });
            }
            // 把中文内容生成词典

            foreach (NodeInfo no in nodeeng)
            {
                EngDict.Add(no.NodeKey, new NodeInfo() { FileName = no.FileName, NodeName = no.NodeName, NodeText = no.NodeText, SubFolder = no.SubFolder, TypeFolder = no.TypeFolder });
            }
            // 将英文文本生成词典

            ////////////////////

            // 读取Def文件夹中有关英文文本的定义部分
            nodeori = ReadOriginal(OriPath);
            foreach (NodeInfo ss in nodeori)
            {
                Xdata = new XMLdata(ss);
                lstXMLdata.Add(Xdata);
            }
            // 将定义的英文文本生成初始总表

            foreach (XMLdata data in lstXMLdata)
            {
                EngDict.TryGetValue(data.NodeKey(), out NodeInfo s);
                if (s != null)
                {
                    string t = s.NodeText;
                    data.SetDest(t);
                }
                EngDict.Remove(data.NodeKey());
            }
            // 从英文词典中查询词条并插入到总表中。

            foreach (NodeInfo ss in EngDict.Values)
            {
                Xdata = new XMLdata(ss, true);
                lstXMLdata.Add(Xdata);
            }
            // 英文字典剩余的部分追加到总表。用以保留自己额外添加的文本
            ////////////////////

            foreach (XMLdata data in lstXMLdata)
            {
                DestDict.TryGetValue(data.NodeKey(), out NodeInfo s);
                if (s != null)
                {
                    string t = s.NodeText;
                    data.SetDest(t);
                }

                DestDict.Remove(data.NodeKey());
            }
            // 从中文字典中查询词条并插入到总表中。

            foreach (NodeInfo ss in DestDict.Values)
            {
                Xdata = new XMLdata(ss, false);
                lstXMLdata.Add(Xdata);
            }
            // 中文字典剩余的部分追加到总表。用以保留自己额外添加的文本

            return lstXMLdata;
            ////////////////////////////////// 以下是调用到的子函数

            List<NodeInfo> ReadFileList(string[] list)
            {
                List<NodeInfo> data = new List<NodeInfo>();
                if (list.Length > 0)
                {
                    foreach (string str in list)
                    {
                        XNodeInfo.FileName = Path.GetFileName(str);
                        xdoc.Load(XmlReader.Create(str, settings));

                        XmlNode xn = xdoc.ChildNodes[1];
                        foreach (XmlNode nn in xn.ChildNodes)
                        {
                            data.Add(new NodeInfo() { FileName = XNodeInfo.FileName, NodeName = nn.Name, NodeText = nn.InnerText, SubFolder = XNodeInfo.SubFolder, TypeFolder = XNodeInfo.TypeFolder });
                        }
                    }
                }
                return data;
            }

            List<NodeInfo> ReadOriginal(string path)
            {
                List<NodeInfo> data = new List<NodeInfo>();
                NodeInfo nodels = new NodeInfo();
                string dename = "";
                if (!Directory.Exists(path)) { return data; }

                foreach (string folders in Directory.GetDirectories(path))
                {
                    foreach (string file in Directory.GetFiles(folders))
                    {
                        nodels = new NodeInfo() { TypeFolder = "DefInjected" };

                        nodels.FileName = Path.GetFileName(file);
                        xdoc.Load(XmlReader.Create(file, settings));
                        XmlNode n = xdoc.ChildNodes[1];
                        XmlNodeList lst = n.ChildNodes;
                        foreach (XmlNode xn in lst)
                        {
                            nodels.SubFolder = xn.Name;
                            foreach (XmlNode xnn in xn.ChildNodes)
                            {
                                if (xnn.Name == "defName") { dename = xnn.InnerText; }
                                switch (xnn.Name.ToLower())
                                {
                                    case "defname":
                                        dename = xnn.InnerText;
                                        break;
                                    default:
                                        break;
                                }
                                if (dename != "")
                                {
                                    switch (xnn.Name.ToLower())
                                    {
                                        case "label":
                                        case "description":
                                        case "deathmessage":
                                        case "jobstring":

                                            nodels.NodeName = GetNodeName(dename, xnn.Name.ToLower());
                                            nodels.NodeText = xnn.InnerText;
                                            data.Add(Getnewnode(nodels));
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            dename = "";
                        }
                    }
                }
                return data;
            }
        }
        private static NodeInfo Getnewnode(NodeInfo input)
        {
            return new NodeInfo() { FileName = input.FileName, NodeName = input.NodeName, NodeText = input.NodeText, SubFolder = input.SubFolder, TypeFolder = input.TypeFolder };
        }
        private static string GetNodeName(string defName, string typeName)
        {
            return defName + "." + typeName;
        }
        public static void SaveMod(string modname, List<XMLdata> indata, string language)
        {
            Dictionary<string, List<XMLdata>> dictfiles = new Dictionary<string, List<XMLdata>>();

            string ChnPath = StaticVars.DIRBASE + modname + "\\Languages\\" + language;
            if (!Directory.Exists(ChnPath)) { Directory.CreateDirectory(ChnPath); }
            foreach (XMLdata indatasingle in indata)
            {
                List<XMLdata> newlist;
                if (dictfiles.ContainsKey(indatasingle.FilePath))
                {
                    dictfiles.TryGetValue(indatasingle.FilePath, out List<XMLdata> list);
                    list.Add(indatasingle);
                    dictfiles.Remove(indatasingle.FilePath);
                    dictfiles.Add(indatasingle.FilePath, list);
                }
                else
                {
                    newlist = new List<XMLdata>();
                    newlist.Add(indatasingle);
                    dictfiles.Add(indatasingle.FilePath, newlist);
                }
            }
            foreach (List<XMLdata> lst in dictfiles.Values)
            {
                string path = ChnPath + lst[0].FilePath;

                if (!Directory.Exists(Path.GetDirectoryName(path))) { Directory.CreateDirectory(Path.GetDirectoryName(path)); }

                XmlTextWriter xml = new XmlTextWriter(path, Encoding.UTF8);

                xml.Formatting = System.Xml.Formatting.Indented;
                xml.WriteStartDocument();
                xml.WriteStartElement("LanguageData");

                foreach (XMLdata dat in lst)
                {
                    xml.WriteStartElement(dat.LabelName);
                    xml.WriteString(dat.ContentDest);
                    xml.WriteEndElement();
                }
                xml.WriteEndElement();
                xml.WriteEndDocument();
                xml.Flush();
                xml.Close();
            }

        }
    }
    public class Situation
    {
        public static string Sit = "";
        public static string Id = "";
        public static string Key = "";
        public static string check = "";
    }
}