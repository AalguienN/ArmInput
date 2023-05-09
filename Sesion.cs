using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using UnityEngine;

public class Session
{
    public static List<string> record;
    public Session() { 
        record = new List<string>();
    }

    public void Update(string input) {
        record.Add(input);
    }
    public void Save() {
        try
        {
            if (!Directory.Exists(Application.dataPath + "Sesiones/"))
                Directory.CreateDirectory("Sesiones/");
            string filePath = "Sesiones/Sesion_" +
                 "_" + DateTime.Now.Day +"-"+ DateTime.Now.Month + "-" + DateTime.Now.Year +"_("
                + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + ").txt";

            Debug.Log(record.Count());
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (string i in record) 
                    writer.Write(i);
            }
        }
        catch (Exception e) { Debug.LogError(e.ToString()); }
    }
}
