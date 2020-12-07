## Manuel Andrés Carrera Galafate

# Práctica 6. Sensores en Unity - Interfaces Inteligentes


## Descripción
En esta práctica crearemos una serie de Scripts que nos permitirán utilizar los sensores del teléfono para interactuar con escenas.

## Desarrollo

### Configuración previa.

Para probar las distintas funcionalidades crearemos 3 escenas donde en cada una de ellas la cámara tendrá asociada uno de los scripts que servirán para usar las funcionalidades / sensores del móvil. Respectivamente serán una para la brújula, otra para el acelerómetro y otra para el GPS.

Además dispondremos de un script auxiliar para el movimiento de la cámara para probar algunas de los scripts en el entorno de Unity (en lugar de exportar directamente al móvil).

### Script auxiliar.

```cs
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
```

No hay mucho que explicar, un script que nos permitirá mover la cámara (en guiñada o cabeceo) a partir de los inputs del ratón.

### Script brújula.

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compassCanvas : MonoBehaviour
{
    void Start()
    {
        Input.compass.enabled = true;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, Input.compass.trueHeading);
    }
}
```
Este script está planteado para utilizar una imagen de una brújula en un canvas que se vea en la pantalla del jugador. Inicialmente encenderemos la brújula en el Start, y a continuación gracias al Update, en cada frame rotaremos la imagen para que el Norte de la imagen siga señalando al norte de una brújula convencional.

Cabe a destacarse que el script debe añadirse como componente sobre la imagen.

### Script acelerómetro.

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerate : MonoBehaviour
{
    float speed;
    void Start()
    {
        speed = 1;
    }

    void Update()
    {
        transform.Translate(Input.acceleration.x * speed, 0, Input.acceleration.z * speed);
    }
}

```
Este script se añadirá a la cámara principal de la escena. Utilizaremos las propiedades del acelerómetro para modificar las posiciones X y Z de la cámara para poder permitir movimientos a través del movimiento del móvil, a través de la función Translate de Unity.

### Script GPS

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gps : MonoBehaviour
{
    void Start()
    {
        // Iniciamos el GPS
        Input.location.Start();
    }

    void Update()
    {
        // Comprobamos que el GPS esté funcionando. Si es así se imprimen varias propiedades que nos proporciona, si no es así, se imprime un mensaje de error.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
        } else {
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude);
        }
    }
    // Función pública que nos permite desde otros componentes parar la detección GPS.
    public void Stop() {
        Input.location.Stop();
    }
}
```

Este código se puede añadir a cualquier elemento de la escena. Imprime propiedades del GPS del móvil si el servicio está activo, y nos da la función Stop como interfaz para parar la búsqueda por GPS. Convendría añadir una función para volver a inciarla si la quisieramos añadir como una funcionalidad que vaya como un interruptor.

## Conclusión

Gracias a las interfaces que nos presta Unity tenemos desde su entorno maneras muy fáciles de acceder a los sensores del móvil y poder trabajar con ellos. Probablemente utilicemos uno o varios de ellos en nuestro proyecto final buscando funcionalidades interesantes para la aplicación.