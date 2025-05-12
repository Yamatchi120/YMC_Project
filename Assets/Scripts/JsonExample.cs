using System.Collections.Generic;
using UnityEngine;

public class JsonExample : MonoBehaviour
{
    void Start()
    {
        Vector3 obj = transform.position;
        JTestClass jtc = new JTestClass(true, obj);
        string jsonData = ObjectToJson(jtc);
        Debug.Log(jsonData);

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
}
