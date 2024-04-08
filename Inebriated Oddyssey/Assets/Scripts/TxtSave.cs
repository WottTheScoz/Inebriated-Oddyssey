using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TxtSave : MonoBehaviour
{
    private string textsave = Directory.GetCurrentDirectory() + @"\Assets\SaveData\" + "TxtFile";

    // Start is called before the first frame update
    void Start()
    {
        //StreamWriter newStream = File.CreateText(textsave);
        TxtSaver();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TxtSaver()
    {
        /* hold this thanks
        using(StreamWriter newStream = File.CreateText(textsave)){
            StreamWriter.WriteLine("Game Loaded");
        }*/

        //other one is being mean let's see if maunal closing works

        if(!File.Exists(textsave)){
            StreamWriter newStream = File.CreateText(textsave);
            newStream.WriteLine("Game Loaded");
            newStream.Close();
        }


    }
}
