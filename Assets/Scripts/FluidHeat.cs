using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FluidHeat : MonoBehaviour
{
    public float Df;            // diametro interno del tubo captador                                   (m)
    public float Ht;            // coeficiente de transferencia de calor entre las
                                // tubo y el fluido                                                     (W/(mºC))
    private float Qf;           // flujo de calor en el volumen de fluido considerado                   (W == J/s)
    private float Qa;           // flujo de calor de las perdidas en el absorbedor                      (W)
    private float Qs;           // flujo de calor recibido del sol                                      (W)
    private float Tm;           // temperatura del tubo absorbedor (metal)                              (ºC)
    private float Tf;           // temperatura del fluido                                               (ºC)
    private float Ta;           // temperatura ambiente                                                 (ºC)
    private float rhom;         // masa especifica del metal del tubo absorbedor                        (kg/m3)
    private float rhof;         // masa especifica del fluido (agua sobrecalentada)                     (kg/m3)
    private float cm;           // calor especifico del metal                                           (J/(kgºC))
    private float cf;           // calor especifico del fluido                                          (J/(kgºC))
    private float Am;           // area de la superficie de metal en contacto con el fluido             (m2)
    private float Af;           // area de la superficie exterior del volumen del fluido considerado
    private float deltaTime;    // intervalo de tiempo de discretizacion                                (s)
    private float deltaX;       // longitud de tubo considerada por cada paso                           (m)
    private int n;              // contador para el numero de partes resultantes de la
                                // discretizacion del sistema del captador
    private int k;              // contador de los instantes de tiempo en que se realiza
                                // la discretizacion temporal del sistema
    private int M;              // numero de intervalos de tiempo considerados para la discretizacion
    private double pi = 3.14159265359;
    private float timef;        // variable de tiempo, considerando el primer instante como 0
                                // vamos a empezar considerandola float, y si luego debemos
                                // cambiar el tipo, lo cambiamos.

    // Interesa, creo, dar una ruta absoluta; o subirlo a Git o algo asi, de modo que no de
    // problemas se ejecute donde se ejecute. Pero por ahora  y para las pruebas, lo dejamos asi.
    string filePath = @"C:\Users\Pablo\OneDrive - UNIVERSIDAD DE SEVILLA\TFG\0_Integracion\Assets\DataFiles\datos.csv";
    // Para la estructura de datos que tenemos almacenada en .csv:
    // Primera columna: hora
    // Segunda columna: caudal (m3/s)
    // Tercera columna: temperatura de entrada (ºC)
    // Cuarta columna:  temperatura de salida (ºC)
    // Quinta columna:  *todos los valores estan a 100. No se que es.
    // Sexta columna:   irradiancia (W/m2)
    // Septima columna: temperatura ambiente (ºC)

    /*  ECUACIONES
        Qf = Df*pi*Ht*(Tm(k,n) - Tf(k,n));
        Qa = Dm*pi*(a*(Tm*(k,n) - Ta(k)))^3 + b*(Tm*(k,n) - Ta(k)));

        Tm(k,n) = Tm(k-1,n) + deltaTime*(Qs(k-1)/(rhom*cm*Am) - Qa(k-1,n)/(rhom*cm*Am) - Qf(k-1,n)/(rhom*cm*Am));
        Tf(k,n) = Tf(k-1,n) + deltaTime*((q(k-1)/Af)*((Tf(k,n) - Tf(k,n-1))/deltaX) + Qf(k-1,n)/(rhof*cf*Af));
    */


    // Start is called before the first frame update
    void Start()
    {
        // En el arranque debemos definir varios parametros
        deltaTime = timef/(M - 1);

        // Read the CSV file
        string[] lines = File.ReadAllLines(filePath);
        // Process the data
        foreach (string line in lines)
        {
            string[] values = line.Split(',');
            // Process each value as needed
            Debug.Log("Value from .csv file: " + values[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
            Tendremos que actualizar el valor de la ecuacion para
            cada instante en que tenemos medidas reales de la planta.
            Hay dos opciones: o creamos una tabla de modo que solo se
            actualice la ecuacion en los instantes en que tenemos medidas;
            o interpolamos las medidas que tenemos de manera que, para cada
            instante (atencion a la granularidad de la medida del tiempo)
            tengamos un valor de las mismas.
        */

    }
}
