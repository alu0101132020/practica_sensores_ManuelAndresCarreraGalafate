using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Script auxiliar para manejar la cámara**/
public class CameraScript : MonoBehaviour
{
    // Velocidades regulables para la cámara
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    // A continuación tendremos las propiedades que permitirán los mivimentos de guiñada
    // y cabeceo de la cámara (movimientos en el eje X e Y respectivamente).
    // Guiñada
    private float yaw = 0.0f;
    // Cabeceo
    private float pitch = 0.0f;

    void Start()
    {

    }
    
    // Actualizaremos en cada frame la posición de la cámara a través del input.
    void Update()
    {

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }
}
