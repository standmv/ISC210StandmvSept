using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    
    public GameObject prefabBrick;
    public GameObject prefabDoubleBrick;
    void Start()
    {
        CargarMapa();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CargarMapa()
    {
        GameObject nuevaCelda = null;
        //Primero, lee el archivo de texto del mapa.
        var contenido = Resources.Load<TextAsset>("Map");
        //Segundo, recorre el contenido, y para cada celda:
        int i, j;
        j = 0;
        foreach (string LineaActual in contenido.text.Split('\n'))
        {
            i = 0;
            foreach (char celdaActual in LineaActual)
            {
                switch (celdaActual)
                {
                    case '+':
                        nuevaCelda = prefabBrick;
                        break;
                    case '*':
                        nuevaCelda = prefabDoubleBrick;
                        break;
                    default:
                        i++;
                        continue;
                }
                nuevaCelda = Instantiate(nuevaCelda, new Vector3(i + 1.5f, -j + 0.5f), Quaternion.identity);
                i++;
            }
            j++;
        }
        //Instacia los objecto
    }
}
