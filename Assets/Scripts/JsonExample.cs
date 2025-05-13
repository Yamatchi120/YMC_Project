using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class JsonExample : MonoBehaviour
{
    void Start()
    {
        Vector3 obj = transform.position;
        JTestClass jtc = new JTestClass(true, obj);
        string jsonData = ObjectToJson(jtc);
        CreateJsonFile(Application.dataPath, 
            "JTestClass", jsonData);

        // Debug.Log(jsonData);

        var jtc2 = JsonToObject<JTestClass>(jsonData);
        jtc2.Print();
    }

    string ObjectToJson(object obj)
    {
        return JsonUtility.ToJson(obj);
    }

    T JsonToObject<T>(string jsonData)
    {
        return JsonUtility.FromJson<T>(jsonData);
    }

    void CreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream
            (string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
}
