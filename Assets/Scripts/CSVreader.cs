using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVreader : MonoBehaviour
{
    void Start()
    {
        string filePath = @"C:\Users\Pablo\OneDrive - UNIVERSIDAD DE SEVILLA\TFG\0_Integracion\Assets\DataFiles\datos.csv";
        Debug.Log("Reading .csv file: " + filePath);

        if (File.Exists(filePath))
        {
            // Code to read and process the .csv file
            // ...

            // Print a specific value from the .csv file
            //Debug.Log("Value from .csv file: " + value);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }
}
