<%@ WebHandler Language="C#" Class="AjaxCharts" %>

using System;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections.Generic;

[Serializable]
public class chartPieTest
{
    public string Name { get; set; }
    public float Data { get; set; }
}

[Serializable]
public class chartBarTest
{
    public string Name { get; set; }
    public float[] Data { get; set; }
}

[Serializable]
public class chartLineTest
{
    public string Name { get; set; }
    public float[] Data { get; set; }
}

[Serializable]
public class Charts
{
    public string ChartName { get; set; }
    public List<chartPieTest> Datas { get; set; }
}


public static class JSONExtension
{

    //chartTest c1=new chartTest(){


    static System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();

    /// <summary>
    /// Convert the object to JSON string
    /// </summary>
    /// <param name="o">The object which is to be converted to JSON string.</param>
    /// <returns>Returns the JSON string.</returns>
    public static string ToJSON(this object o)
    {
        return js.Serialize(o);
        //return new JavaScriptSerializer().Serialize(o);
    }
}



public class AjaxCharts : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/json";
        string chartType = HttpContext.Current.Request.QueryString["chartType"];//
        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
        //方法选择器 
        switch (chartType)
        {
            //Pie
            case "chartPie":
                WritePie(context, js);
                break;
            case "chartBar":
                WriteBar(context, js);
                break;
            case "chartLine":
                WriteLine(context, js);
                break;
        }
    }


    void WritePie(HttpContext context, System.Web.Script.Serialization.JavaScriptSerializer js)
    {
        List<chartPieTest> list = new List<chartPieTest>();
        chartPieTest ch = new chartPieTest();
        ch.Name = "Apples";
        ch.Data = 60;
        list.Add(ch);
        ch = new chartPieTest();
        ch.Name = "Pears";
        ch.Data = 20;
        list.Add(ch);
        ch = new chartPieTest();
        ch.Name = "Bananas";
        ch.Data = 20;
        list.Add(ch);
        context.Response.Write(js.Serialize(list));

    }
    void WriteBar(HttpContext context, System.Web.Script.Serialization.JavaScriptSerializer js)
    {
        List<chartBarTest> listBar = new List<chartBarTest>();
        chartBarTest chartBar = new chartBarTest();
        chartBar.Name = "Apples";
        chartBar.Data = new float[] { 20, 40, 60 };
        listBar.Add(chartBar);
        chartBar = new chartBarTest();
        chartBar.Name = "Pears";
        chartBar.Data = new float[] { 30, 50, 270 };
        listBar.Add(chartBar);
        chartBar = new chartBarTest();
        chartBar.Name = "Bananas";
        chartBar.Data = new float[] { 40, 60, 80 };
        listBar.Add(chartBar);
        context.Response.Write(js.Serialize(listBar));

    }
    void WriteLine(HttpContext context, System.Web.Script.Serialization.JavaScriptSerializer js)
    {
        List<chartLineTest> listLine = new List<chartLineTest>();
        chartLineTest chartLine = new chartLineTest();
        chartLine.Name = "Apples";
        chartLine.Data = new float[] { 40, 20, 60, 80 };
        listLine.Add(chartLine);
        chartLine = new chartLineTest();
        chartLine.Name = "Pears";
        chartLine.Data = new float[] { 50, 30, 70, 90 };
        listLine.Add(chartLine);
        chartLine = new chartLineTest();
        chartLine.Name = "Bananas";
        chartLine.Data = new float[] { 60, 40, 80, 100 };
        listLine.Add(chartLine);
        context.Response.Write(js.Serialize(listLine));
    }

    public static string Serialize<T>(T obj)
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
        MemoryStream ms = new MemoryStream();
        serializer.WriteObject(ms, obj);
        string retVal = System.Text.Encoding.UTF8.GetString(ms.ToArray());
        return retVal;
    }

    public static T Deserialize<T>(string json)
    {
        T obj = Activator.CreateInstance<T>();
        MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
        obj = (T)serializer.ReadObject(ms);
        ms.Close();
        return obj;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}