using System;
using System.Reflection;
using System.Data;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Web;
using System.Collections.Generic;
using System.IO;

namespace Common
{
    /// <summary>
    /// xml操作类
    /// </summary>
    public sealed class XmlHelper
    {
        #region 字段定义
        /// <summary>
        /// XML文件的物理路径
        /// </summary>
        private string _filePath = string.Empty;
        /// <summary>
        /// Xml文档
        /// </summary>
        private XmlDocument _xml;
        /// <summary>
        /// XML的根节点
        /// </summary>
        private XmlElement _element;
        #endregion

        #region 构造方法
        /// <summary>
        /// 实例化XmlHelper对象
        /// </summary>
        /// <param name="xmlFilePath">Xml文件的相对路径</param>
        public XmlHelper(string xmlFilePath)
        {
            //获取XML文件的绝对路径
            _filePath = HttpContext.Current.Server.MapPath(xmlFilePath);
        }
        #endregion

        #region 获取XML的根节点(private)
        /// <summary>
        /// 获取XML的根节点
        /// </summary>
        private void CreateXMLElement()
        {
            //创建一个XML对象
            _xml = new XmlDocument();

            if (FilesHelper.Exists(_filePath))
            {
                //加载XML文件
                _xml.Load(this._filePath);

                //将XmlDocument对象放入缓存
            }
            //为XML的根节点赋值
            _element = _xml.DocumentElement;
        }
        #endregion

        #region 新建XML的根节点
        /// <summary>
        /// 新建XML的根节点
        /// </summary>
        public void CreateXMLElement(string nodeName)
        {
            FilesHelper.CreateFile(_filePath);//不存在文件则新建

            _xml = new XmlDocument();
            _xml.AppendChild(_xml.CreateNode(XmlNodeType.XmlDeclaration, "", ""));//版本声明
            _xml.AppendChild(_xml.CreateElement(nodeName));//创建根节点
            Save();
        }
        #endregion

        #region 获取指定XPath表达式的节点对象
        /// <summary>
        /// 获取指定XPath表达式的节点对象
        /// </summary>        
        /// <param name="xPath">XPath表达式,
        /// 范例1: @"Skill/First/SkillItem", 等效于 @"//Skill/First/SkillItem"
        /// 范例2: @"Table[USERNAME='a']" , []表示筛选,USERNAME是Table下的一个子节点.
        /// 范例3: @"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性.
        /// </param>
        public XmlNode GetNode(string xPath)
        {
            //创建XML的根节点
            CreateXMLElement();

            //返回XPath节点
            return _element.SelectSingleNode(xPath);
        }
        #endregion

        #region 获取根节点
        /// <summary>
        /// 获取根节点
        /// </summary>
        public XmlElement RootNode
        {
            get
            {
                //创建XML的根节点
                CreateXMLElement();

                //返回根节点
                return _element;
            }
        }
        #endregion

        #region 获取根节点的所有下级子节点
        /// <summary>
        /// 获取根节点的所有下级子节点
        /// </summary>
        public XmlNodeList ChildNodes
        {
            get
            {
                //创建XML的根节点
                CreateXMLElement();

                //返回根节点
                return _element.ChildNodes;
            }
        }
        #endregion

        #region 获取指定XPath表达式节点的值
        /// <summary>
        /// 获取指定XPath表达式节点的值
        /// </summary>
        /// <param name="xPath">XPath表达式,
        /// 范例1: @"Skill/First/SkillItem", 等效于 @"//Skill/First/SkillItem"
        /// 范例2: @"Table[USERNAME='a']" , []表示筛选,USERNAME是Table下的一个子节点.
        /// 范例3: @"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性.
        /// </param>
        public string GetValue(string xPath)
        {
            //创建XML的根节点
            CreateXMLElement();
            if (IsExistNode(xPath))
                //返回XPath节点的值
                return _element.SelectSingleNode(xPath).InnerText;
            else
                return "";
        }
        #endregion

        #region 获取指定XPath表达式节点的属性值
        /// <summary>
        /// 获取指定XPath表达式节点的属性值
        /// </summary>
        /// <param name="xPath">XPath表达式,
        /// 范例1: @"Skill/First/SkillItem", 等效于 @"//Skill/First/SkillItem"
        /// 范例2: @"Table[USERNAME='a']" , []表示筛选,USERNAME是Table下的一个子节点.
        /// 范例3: @"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性.
        /// </param>
        /// <param name="attributeName">属性名</param>
        public string GetAttributeValue(string xPath, string attributeName)
        {
            //创建XML的根节点
            CreateXMLElement();

            //返回XPath节点的属性值
            return _element.SelectSingleNode(xPath).Attributes[attributeName].Value;
        }
        #endregion

        #region 设置指定XPath表达式节点的属性
        /// <summary>
        /// 设置指定XPath表达式节点的属性
        /// </summary>
        /// <param name="xPath">XPath表达式,</param>
        /// <param name="attributeName">属性名称</param>
        /// <param name="attributeValue">属性值</param>
        public void SetAttributeValue(string xPath, string attributeName, string attributeValue)
        {
            //创建XML的根节点
            CreateXMLElement();

            //设置XPath节点的属性
            XmlElement element = (XmlElement)_element.SelectSingleNode(xPath);
            if (element != null)
            {
                element.SetAttribute(attributeName, attributeValue);
                //Save();
            }
        }
        #endregion

        #region  判断是否存在指定节点
        /// <summary>
        /// 判断是否存在指定节点 存在返回true
        /// </summary>
        /// <param name="XPath">指定的Xpath表达式</param>
        /// <returns></returns>
        public bool IsExistNode(string XPath)
        {
            if (!FilesHelper.Exists(_filePath))
            {
                return false;
            }
            //创建XML的根节点
            CreateXMLElement();

            //返回XPath节点
            XmlNode node = _element.SelectSingleNode(XPath);
            if (node == null)
                return false;
            else
                return true;
        }
        #endregion

        #region 新增节点

        #region 重载1
        /// <summary>
        /// 1. 功能：新增节点。
        /// 2. 使用条件：将任意节点插入到当前Xml文件中。
        /// </summary>        
        /// <param name="xmlNode">要插入的Xml节点</param>
        public void AppendNode(XmlNode xmlNode)
        {
            //创建XML的根节点
            CreateXMLElement();

            //导入节点
            XmlNode node = _xml.ImportNode(xmlNode, true);

            //将节点插入到根节点下
            _element.AppendChild(node);
        }
        #endregion

        #region 重载2
        /// <summary>
        /// 1. 功能：新增节点。
        /// 2. 使用条件：将DataSet中的第一条记录插入Xml文件中。
        /// </summary>        
        /// <param name="ds">DataSet的实例，该DataSet中应该只有一条记录</param>
        public void AppendNode(DataSet ds)
        {
            //创建XmlDataDocument对象
            XmlDataDocument xmlDataDocument = new XmlDataDocument(ds);

            //导入节点
            XmlNode node = xmlDataDocument.DocumentElement.FirstChild;

            //将节点插入到根节点下
            AppendNode(node);
        }
        #endregion

        #region 重载3
        /// <summary>
        /// 1. 功能：新增节点。
        /// </summary>        
        /// <param name="nodeName">节点名称</param>
        /// <param name="nodevalue">节点的值</param>
        /// <param name="xmlNode">要插入的Xml节点</param>
        public void AppendNode(string nodeName, string nodevalue)
        {
            //创建XML的根节点
            CreateXMLElement();

            //新建节点
            XmlElement ele = _xml.CreateElement(nodeName);
            ele.InnerText = nodevalue;

            //将节点插入到根节点下
            _element.AppendChild(ele);

            //Save();//保存Xml文件
        }
        #endregion

        #endregion

        #region 删除节点
        #region 重载1
        /// <summary>
        /// 删除指定XPath表达式的节点
        /// </summary>        
        /// <param name="xPath">XPath表达式,
        /// 范例1: @"Skill/First/SkillItem", 等效于 @"//Skill/First/SkillItem"
        /// 范例2: @"Table[USERNAME='a']" , []表示筛选,USERNAME是Table下的一个子节点.
        /// 范例3: @"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性.
        /// </param>
        public void RemoveNode(string xPath)
        {
            //创建XML的根节点
            CreateXMLElement();

            //获取要删除的节点
            XmlNode node = _xml.SelectSingleNode(xPath);
            if (node != null)
            {
                //删除节点
                _element.RemoveChild(node);
                Save();
            }
        }
        #endregion

        #region 重载2
        /// <summary>
        /// 删除指定XPath表达式的节点
        /// </summary>
        /// <param name="xPathArray">指定删除节点的XPath表达式的数组集合</param>
        public void RemoveNode(string[] xPathArray)
        {

            //创建XML的根节点
            CreateXMLElement();

            XmlNode node;
            foreach (string xpath in xPathArray)
            {
                //获取要删除的节点
                node = _xml.SelectSingleNode(xpath);

                if (node != null)
                {
                    //删除节点
                    _element.RemoveChild(node);
                    Save();
                }
            }
        }
        #endregion
        #endregion

        #region 保存XML文件
        /// <summary>
        /// 保存XML文件
        /// </summary>        
        public void Save()
        {
            //保存XML文件
            _xml.Save(this._filePath);
        }
        #endregion //保存XML文件

        #region  添加子节点到XML中 属性存储数据
        #region 重载1
        /// <summary>
        /// 添加子节点到XML中 属性存储数据 T.type.Name作为节点名称
        /// </summary>
        /// <param name="xPath">要添加到的节点，XPath表达式 '/*' 表示根节点</param>
        /// <param name="t">类型对象</param>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <returns>T 类型对象</returns>
        public void AppendNodeAsAttr<T>(string xPath, T t)
        {
            Type type = t.GetType();
            string val = "";
            XmlElement element;
            XmlNode node = GetNode(xPath);
            element = (XmlElement)node.AppendChild(_xml.CreateElement(type.Name));

            foreach (PropertyInfo p in type.GetProperties())
            {
                val = Convert.ToString(p.GetValue(t, null));
                if (val != "" && val != "0")
                {
                    element.SetAttribute(p.Name, val);
                }
            }
            //RootNode.AppendChild(element);
        }
        #endregion

        #region 重载2
        /// <summary>
        /// 添加子节点到XML中 属性存储数据
        /// </summary>
        /// <param name="t">类型对象</param>
        /// <param name="nodeName">节点名称</param>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <returns>T 类型对象</returns>
        //public void AppendNodeAsAttr<T>(string nodeName, T t)
        //{
        //    Type type = t.GetType();
        //    string val = "";
        //    XmlElement element;
        //    element = (XmlElement)RootNode.AppendChild(_xml.CreateElement(nodeName));

        //    foreach (PropertyInfo p in type.GetProperties())
        //    {
        //        val = Convert.ToString(p.GetValue(t, null));
        //        if (val != "" && val != "0")
        //        {
        //            element.SetAttribute(p.Name, val);
        //        }
        //    }
        //    RootNode.AppendChild(element);
        //}
        #endregion

        #region  重载3
        /// <summary>
        /// 添加子节点到XML中 属性存储数据
        /// </summary>
        /// <param name="t">类型对象</param>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <returns>T 类型对象</returns>
        public void AppendNodeAsAttr<T>(List<T> t)
        {
            if (t.Count > 0)
            {
                Type type = t[0].GetType();
                string val = "";
                XmlElement element, subElement;
                element = (XmlElement)RootNode.AppendChild(_xml.CreateElement(type.Name + "List"));
                foreach (T st in t)
                {
                    Type stype = st.GetType();
                    subElement = (XmlElement)element.AppendChild(_xml.CreateElement(stype.Name));

                    foreach (PropertyInfo p in type.GetProperties())
                    {
                        val = Convert.ToString(p.GetValue(st, null));
                        if (val != "" && val != "0")
                        {
                            subElement.SetAttribute(p.Name, val);
                        }
                    }
                }
                RootNode.AppendChild(element);
            }
        }
        #endregion

        #endregion

        #region 获取XML文件数据填充到目标实体类型T 节点存储数据
        /// <summary>
        /// 获取XML文件数据据填充到目标实体类型T  节点存储数据
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <returns>T 类型对象</returns>
        public T GetXmlData<T>()
        {
            T t = Activator.CreateInstance<T>();
            if (FilesHelper.Exists(_filePath))
            {
                Type type = t.GetType();
                foreach (PropertyInfo p in type.GetProperties())
                {
                    foreach (XmlNode mnode in ChildNodes)
                    {
                        if (p.Name == mnode.Name)
                        {
                            p.SetValue(t, Convert.ChangeType(mnode.InnerText, p.PropertyType), null);
                            break;
                        }
                    }
                }
            }
            return t;
        }
        #endregion

        #region 获取XML文件指定Xpath表达式节点的属性数据 属性存储数据
        #region 重载1
        public string GetXmlDataAsAttr(string XPath, string attrName)
        {
            if (IsExistNode(XPath))
            {
                XmlNode node = RootNode.SelectSingleNode(XPath);
                return node.Attributes[attrName].Value;
            }
            else
                return "";
        }
        #endregion

        #region 重载2
        /// <summary>
        /// 获取XML文件指定Xpath表达式节点的属性数据  属性存储数据
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <param name="XPath"> 指定要获取数据的节点Xpath</param>
        /// <returns>T 类型对象</returns>
        public T GetXmlDataAsAttr<T>(string XPath)
        {
            if (FilesHelper.Exists(_filePath))
            {
                T t = Activator.CreateInstance<T>();
                XmlNode xNode = RootNode.SelectSingleNode(XPath);

                if (xNode != null)
                {
                    Type type = t.GetType();
                    foreach (PropertyInfo p in type.GetProperties())
                    {
                        foreach (XmlAttribute attr in xNode.Attributes)
                        {
                            if (p.Name == attr.Name)
                            {
                                p.SetValue(t, Convert.ChangeType(attr.Value, p.PropertyType), null);
                                break;
                            }
                        }
                    }
                }
                return t;
            }
            else
                return default(T);
        }
        #endregion

        #endregion

        #region 获取指定XPath表达式的List对象节点的属性值
        /// <summary>
        /// 获取指定XPath表达式的List对象节点的属性值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="XPath">指定XPath表达式</param>
        /// <returns>T 对象的List对象</returns>
        public List<T> GetXmlDataListAsAttr<T>(string XPath)
        {
            List<T> list = new List<T>();
            if (IsExistNode(XPath))
            {
                XmlNode xNode = RootNode.SelectSingleNode(XPath);
                foreach (XmlNode subNode in xNode.ChildNodes)
                {
                    T t = Activator.CreateInstance<T>();
                    Type type = t.GetType();
                    foreach (PropertyInfo p in type.GetProperties())
                    {
                        foreach (XmlAttribute xAttr in subNode.Attributes)
                        {
                            if (p.Name == xAttr.Name)
                            {
                                p.SetValue(t, Convert.ChangeType(xAttr.Value, p.PropertyType), null);
                                break;
                            }
                        }
                    }
                    list.Add(t);
                }
            }
            return list;
        }
        #endregion

        #region 获取XML文件指定XPath表达式节点下所有节点的数据
        /// <summary>
        /// 获取XML文件指定XPath表达式节点下所有节点的数据
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <param name="XPath">指定的Xpath表达式</param>
        /// <returns>T 的列表 List </returns>
        public List<T> GetXmlDataList<T>(string XPath)
        {
            List<T> list = new List<T>();
            if (IsExistNode(XPath))
            {
                XmlNode xNode = RootNode.SelectSingleNode(XPath);
                foreach (XmlNode pnode in xNode.ChildNodes)
                {
                    T t = Activator.CreateInstance<T>();
                    Type type = t.GetType();
                    foreach (XmlNode mnode in pnode.ChildNodes)
                    {
                        foreach (PropertyInfo p in type.GetProperties())
                        {
                            if (p.Name == mnode.Name)
                            {
                                p.SetValue(t, Convert.ChangeType(mnode.InnerText, p.PropertyType), null);
                                break;
                            }
                        }
                    }
                    list.Add(t);
                }
            }
            return list;
        }
        #endregion



        #region 读取XML资源到DataSet中
        /// <summary>
        /// 读取XML资源到DataSet中
        /// </summary>
        /// <param name="source">XML资源，文件为路径，否则为XML字符串</param>
        /// <param name="xmlType">XML资源类型</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string source)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(source);
            return ds;
        }

        #endregion

        #region 静态方法

        #region 创建根节点对象
        /// <summary>
        /// 创建根节点对象
        /// </summary>
        /// <param name="xmlFilePath">Xml文件的相对路径</param>        
        private static XmlElement CreateRootElement(string xmlFilePath)
        {
            //定义变量，表示XML文件的绝对路径
            string filePath = "";

            //获取XML文件的绝对路径
            filePath = HttpContext.Current.Server.MapPath(xmlFilePath);

            //创建XmlDocument对象
            XmlDocument xmlDocument = new XmlDocument();
            //加载XML文件
            xmlDocument.Load(filePath);

            //返回根节点
            return xmlDocument.DocumentElement;
        }
        #endregion

        #region 获取指定XPath表达式节点的值

        #region  重载1
        /// <summary>
        /// 获取指定XPath表达式节点的值 InnerText
        /// </summary>
        /// <param name="xmlFilePath">Xml文件的相对路径</param>
        /// <param name="xPath">XPath表达式,
        /// 范例1: @"Skill/First/SkillItem", 等效于 @"//Skill/First/SkillItem"
        /// 范例2: @"Table[USERNAME='a']" , []表示筛选,USERNAME是Table下的一个子节点.
        /// 范例3: @"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性.
        /// </param>
        public static string GetValue(string xmlFilePath, string xPath)
        {
            //创建根对象
            XmlElement rootElement = CreateRootElement(xmlFilePath);
            XmlDocument xd = new XmlDocument();
            //返回XPath节点的值
            return rootElement.SelectSingleNode(xPath).InnerText;
        }
        #endregion

        #region  重载1
        /// <summary>
        /// 获取指定XPath表达式节点的值 InnerXml
        /// </summary>
        /// <param name="xmlFilePath">Xml文件的相对路径</param>
        /// <param name="xPath">XPath表达式,
        /// 范例1: @"Skill/First/SkillItem", 等效于 @"//Skill/First/SkillItem"
        /// 范例2: @"Table[USERNAME='a']" , []表示筛选,USERNAME是Table下的一个子节点.
        /// 范例3: @"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性.
        /// </param>
        public static string GetXmlValue(string xmlFilePath, string xPath)
        {
            //创建根对象
            XmlElement rootElement = CreateRootElement(xmlFilePath);
            XmlDocument xd = new XmlDocument();
            //返回XPath节点的值
            return rootElement.SelectSingleNode(xPath).InnerXml;
        }
        #endregion
        #endregion

        #region 获取指定XPath表达式节点的属性值
        /// <summary>
        /// 获取指定XPath表达式节点的属性值
        /// </summary>
        /// <param name="xmlFilePath">Xml文件的相对路径</param>
        /// <param name="xPath">XPath表达式,
        /// 范例1: @"Skill/First/SkillItem", 等效于 @"//Skill/First/SkillItem"
        /// 范例2: @"Table[USERNAME='a']" , []表示筛选,USERNAME是Table下的一个子节点.
        /// 范例3: @"ApplyPost/Item[@itemName='岗位编号']",@itemName是Item节点的属性.
        /// </param>
        /// <param name="attributeName">属性名</param>
        public static string GetAttributeValue(string xmlFilePath, string xPath, string attributeName)
        {
            //创建根对象
            XmlElement rootElement = CreateRootElement(xmlFilePath);

            //返回XPath节点的属性值
            return rootElement.SelectSingleNode(xPath).Attributes[attributeName].Value;
        }
        #endregion

        #region 设置XML文件中指定节点的值 基于计算表达式
        /// <summary>
        /// 设置XML文件中指定节点的值 基于计算表达式
        /// </summary>
        /// <param name="filePath">XML文件相对路径</param>
        /// <param name="xPath">指定的XPath表达式</param>
        /// <param name="xpathExpression">指定的XPath计算表达式 ：
        /// 如 ："Price/text()*10" 表示将Price/text()节点转换为数字再乘以10返回的数字作为XPath表达式节点的值；
        /// JW_ShopInfoModel/@intClickAmount+1 设置JW_ShopInfoModel节点的属性值+1
        /// </param>
        /// <returns></returns>
        public static void SetNodeValueEval(string filePath, string xPath, string xpathExpression)
        {
            bool flag = false;
            filePath = HttpContext.Current.Server.MapPath(filePath);
            if (FilesHelper.Exists(filePath))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(filePath);
                XPathNavigator navi = xd.CreateNavigator();

                XPathNavigator naviNode = navi.SelectSingleNode(xPath);
                if (naviNode != null)
                {
                    double val = (double)navi.Evaluate(xpathExpression);
                    naviNode.SetValue(val.ToString());
                    flag = true;
                }
                if (flag)
                    xd.Save(filePath);
            }
        }
        #endregion

        #region 设置XML文件中的指定节点内容
        /// <summary>
        /// 设置XML文件中的指定节点内容
        /// </summary>
        /// <param name="filePath">XML文件相对路径</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="nodeValue">更新内容</param>
        /// <returns></returns>
        public static void SetNodeValue(string filePath, string nodeName, string nodeValue)
        {
            bool flag = false;
            filePath = HttpContext.Current.Server.MapPath(filePath);

            XmlDocument xd = new XmlDocument();
            xd.Load(filePath);
            XmlElement xe = xd.DocumentElement;
            XmlNode xn = xe.SelectSingleNode("//" + nodeName);
            if (xn != null)
            {
                xn.InnerText = nodeValue;
                flag = true;
            }
            if (flag)
                xd.Save(filePath);
        }
        #endregion

        #region 获取xml文件中指定节点的数据
        /// <summary>
        /// 获取xml文件中指定节点的节点数据
        /// </summary>
        /// <param name="path">XML文件相对路径</param>
        /// <param name="nodeName">指定节点的名称</param>
        /// <returns>节点的InnerText值</returns>
        public static string GetNodeValue(string filePath, string nodeName)
        {
            string XmlString = "";
            filePath = HttpContext.Current.Server.MapPath(filePath);
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            System.Xml.XmlElement root = xml.DocumentElement;
            System.Xml.XmlNode node = root.SelectSingleNode("//" + nodeName);
            if (node != null)
            {
                XmlString = node.InnerText;
            }
            return XmlString;
        }
        #endregion

        #region 设置实体对象数据到XML中 节点存储数据
        /// <summary>
        /// 设置实体对象数据到XML中 节点存储数据
        /// </summary>
        /// <param name="filePath">XML文件相对路径 不存在将创建</param>
        /// <param name="t">类型对象</param>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <returns>T 类型对象</returns>
        public static void SetXmlData<T>(string filePath, T t)
        {
            string path = HttpContext.Current.Server.MapPath(filePath);
            FilesHelper.CreateFile(path);//不存在XML文件则新建

            Type type = t.GetType();
            XmlDocument xmlD = new XmlDocument();
            string val = "";
            XmlElement element;

            xmlD.AppendChild(xmlD.CreateNode(XmlNodeType.XmlDeclaration, "", ""));//版本声明
            xmlD.AppendChild(xmlD.CreateElement("JW_info"));//创建根节点 2010-08-17
            XmlElement rootElement = xmlD.DocumentElement;//根节点

            XmlNode node = rootElement.AppendChild(xmlD.CreateElement(type.Name));

            foreach (PropertyInfo p in type.GetProperties())
            {
                val = Convert.ToString(p.GetValue(t, null));
                if (val != "" && val != "0")
                {
                    element = xmlD.CreateElement(p.Name);
                    element.AppendChild(xmlD.CreateTextNode(val));
                    node.AppendChild(element);
                }
            }
            xmlD.Save(path);
        }
        #endregion

        #region 设置实体对象数据到XML中 属性存储数据
        /// <summary>
        /// 设置实体对象数据到XML中 属性存储数据
        /// </summary>
        /// <param name="filePath">XML文件相对路径 不存在将创建</param>
        /// <param name="t">类型对象</param>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <returns>T 类型对象</returns>
        public static void SetXmlDataAsAttr<T>(string filePath, T t)
        {
            string path = HttpContext.Current.Server.MapPath(filePath);
            FilesHelper.CreateFile(path);//不存在XML文件则新建

            Type type = t.GetType();
            XmlDocument xmlD = new XmlDocument();
            string val = "";
            XmlElement element;

            xmlD.AppendChild(xmlD.CreateNode(XmlNodeType.XmlDeclaration, "", ""));//版本声明
            xmlD.AppendChild(xmlD.CreateElement("JW_info"));//创建根节点 2010-08-17
            XmlElement rootElement = xmlD.DocumentElement;//根节点

            element = (XmlElement)rootElement.AppendChild(xmlD.CreateElement(type.Name));

            foreach (PropertyInfo p in type.GetProperties())
            {
                val = Convert.ToString(p.GetValue(t, null));
                if (val != "" && val != "0")
                {
                    element.SetAttribute(p.Name, val);
                }
            }
            rootElement.AppendChild(element);
            xmlD.Save(path);
        }
        #endregion

        #region 获取XML文件数据填充到目标实体类型T  节点存储数据
        /// <summary>
        /// 获取XML文件数据据填充到目标实体类型T  节点存储数据
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <param name="filePath">XML文件相对路径</param>
        /// <returns>T 类型对象</returns>
        public static T GetXmlData<T>(string filePath)
        {
            filePath = HttpContext.Current.Server.MapPath(filePath);
            T t = Activator.CreateInstance<T>();
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);

            if (FilesHelper.Exists(filePath))
            {
                Type type = t.GetType();
                foreach (PropertyInfo p in type.GetProperties())
                {
                    foreach (XmlNode mnode in xml.DocumentElement.ChildNodes)
                    {
                        if (p.Name == mnode.Name)
                        {
                            p.SetValue(t, Convert.ChangeType(mnode.InnerText, p.PropertyType), null);
                            break;
                        }
                    }
                }
            }
            return t;
        }
        #endregion

        #region 获取XML文件数据填充到目标实体类型T  属性存储数据
        /// <summary>
        /// 获取XML文件数据据填充到目标实体类型T  属性存储数据
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <param name="filePath">XML文件相对路径</param>
        /// <param name="XPath"> 指定要获取数据的节点Xpath</param>
        /// <returns>T 类型对象</returns>
        public static T GetXmlDataAsAttr<T>(string filePath, string XPath)
        {
            filePath = HttpContext.Current.Server.MapPath(filePath);
            if (FilesHelper.Exists(filePath))
            {
                T t = Activator.CreateInstance<T>();
                XmlDocument xml = new XmlDocument();
                xml.Load(filePath);

                XmlNode xNode = xml.DocumentElement.SelectSingleNode(XPath);

                if (xNode != null)
                {
                    Type type = t.GetType();
                    foreach (PropertyInfo p in type.GetProperties())
                    {
                        foreach (XmlAttribute attr in xNode.Attributes)
                        {
                            if (p.Name == attr.Name)
                            {
                                p.SetValue(t, Convert.ChangeType(attr.Value, p.PropertyType), null);
                                break;
                            }
                        }
                    }
                }
                return t;
            }
            else
                return default(T);
        }
        #endregion

        #region 设置实体对象列表List<T>数据到XML中
        /// <summary>
        /// 设置实体对象列表List 数据到XML中
        /// </summary>
        /// <param name="filePath">XML文件相对路径 不存在将创建</param>
        /// <param name="t">类型对象</param>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <returns>T 类型对象</returns>
        public static void SetXmlDataList<T>(string filePath, List<T> t)
        {
            if (t.Count > 0)
            {
                string path = HttpContext.Current.Server.MapPath(filePath);
                FilesHelper.CreateFile(path);//不存在XML文件则新建

                XmlDocument xmlD = new XmlDocument();
                string val = "";
                XmlElement element;
                XmlNode node;

                xmlD.AppendChild(xmlD.CreateNode(XmlNodeType.XmlDeclaration, "", ""));//版本声明

                xmlD.AppendChild(xmlD.CreateElement(t[0].GetType().Name + "List"));
                XmlElement rootElement = xmlD.DocumentElement;//根节点

                foreach (T st in t)
                {
                    Type type = st.GetType();
                    node = rootElement.AppendChild(xmlD.CreateElement(type.Name));
                    foreach (PropertyInfo p in type.GetProperties())
                    {
                        val = Convert.ToString(p.GetValue(st, null));
                        if (val != "")
                        {
                            element = xmlD.CreateElement(p.Name);
                            element.AppendChild(xmlD.CreateTextNode(val));
                            node.AppendChild(element);
                        }
                    }
                }
                xmlD.Save(path);
            }
        }
        #endregion

        #region 添加子节点 属性存储数据
        /// <summary>
        /// 添加子节点 属性存储数据
        /// </summary>
        /// <param name="filePath">XML文件相对路径</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="t">类型对象</param>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <returns></returns>
        public static void AppendNodeAsAttr<T>(string filePath, string nodeName, T t)
        {
            filePath = HttpContext.Current.Server.MapPath(filePath);
            if (FilesHelper.Exists(filePath))
            {
                string val = "";
                Type type = t.GetType();
                XmlDocument xmlD = new XmlDocument();
                xmlD.Load(filePath);
                XmlElement rootElement = xmlD.DocumentElement;
                XmlElement element = (XmlElement)rootElement.AppendChild(xmlD.CreateElement(nodeName));

                foreach (PropertyInfo p in type.GetProperties())
                {
                    p.GetValue(t, null);
                    val = Convert.ToString(p.GetValue(t, null));
                    if (val != "" && val != "0")
                    {
                        element.SetAttribute(p.Name, val);
                    }
                }
                rootElement.AppendChild(element);
                xmlD.Save(filePath);
            }
            else
            {
                SetXmlDataAsAttr(filePath, t);
            }
        }
        #endregion

        #region 删除节点
        /// <summary>
        /// 删除指出定XML文件的指定节点
        /// </summary>
        /// <param name="strPath">XML文件相对路径</param>
        /// <param name="XPath">XPath表达式</param>
        public static void RemoveNode(string strPath, string XPath)
        {
            //strPath = HttpContext.Current.Server.MapPath(strPath);
            XmlHelper uxml = new XmlHelper(strPath);
            uxml.RemoveNode(XPath);
        }
        #endregion

        #endregion

    }
}
