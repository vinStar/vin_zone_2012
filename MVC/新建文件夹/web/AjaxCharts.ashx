<%@ WebHandler Language="C#" Class="AjaxCharts" %>

using System;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections.Generic;

public class chart
{
    public string name { get; set; }
    public double number { get; set; }
}
public static class JSONExtension
{
    /// <summary>
    /// Convert the object to JSON string
    /// </summary>
    /// <param name="o">The object which is to be converted to JSON string.</param>
    /// <returns>Returns the JSON string.</returns>
    public static string ToJSON(this object o)
    {
        return new JavaScriptSerializer().Serialize(o);
    }
}



public class AjaxCharts : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text";
        StringBuilder sb = new StringBuilder();

        sb.Append("       var options = new Highcharts.Chart({");
        sb.Append("         chart: {  renderTo: 'container'   }, ");
        sb.Append("       title: {  text: 'fruit'              }, ");
        sb.Append("       series: [{ ");
        sb.Append("        type: 'pie', ");
        sb.Append("       name: 'fruit', ");
        sb.Append("      data: ");
        sb.Append("              [ ");
        sb.Append("                [\"Apples\", 20.0], ");
        sb.Append("              [\"Pears\", 80.0] ");
        sb.Append("        ] ");
        sb.Append("     }] ");
        sb.Append("      }); ");


        context.Response.Write(sb.ToString());
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