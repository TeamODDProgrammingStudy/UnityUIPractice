using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using UnityEngine;

public class DataExporter : MonoBehaviour
{
    public string Path;
    public string FileName;
    public int Id;
    public string[] Scripts;

    public void ExportJsonData()
    {
        var data = new DialogScripts
        {
            Scripts = Scripts,
            ScriptsId = Id
        };
        var json = JsonConvert.SerializeObject(data);
        File.WriteAllText(Path + "/" + FileName + ".json",json);
    }
    public void ExportXMLData()
    {
        var data = new DialogScripts
        {
            Scripts = Scripts,
            ScriptsId = Id
        };

        XmlSerializer serializer = new XmlSerializer(typeof(DialogScripts));
        FileStream fileStream = new FileStream(Path + "/" + FileName + ".xml", FileMode.Create);
        serializer.Serialize(fileStream,data);
        fileStream.Close();
    }
}
