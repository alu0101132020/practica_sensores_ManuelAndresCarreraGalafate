using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
        } else {
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude);
        }
    }

    public void Stop() {
        Input.location.Stop();
    }
}

