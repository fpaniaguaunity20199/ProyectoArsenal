using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    Vector3 prevPos;
    Vector3 currentPos;
    Vector3 difPos;
    bool primeraVez = true;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<BoxCollider>().enabled = false;
        transform.SetParent(other.transform);
        Destroy(this);//Destruimos el SCRIPT para que no continúe con la rotación.
    }

    private void FixedUpdate()
    {
        /*
         * Calculamos el vector que lleva desde la posición anterior
         * a la actual. Este vector contiene la distancia (magnitud) y la dirección.
         * 
         * Dicho vector representa el punto hacia donde debe mirar la flecha para que tenga un
         * comportamiento parabólico.
         */
        currentPos = transform.position;
        if (!primeraVez)
        {
            difPos = currentPos - prevPos;
            this.transform.forward = difPos.normalized;//La normalización de difPos no es necesaria
        }
        else
        {
            primeraVez = false;
        }
        prevPos = currentPos;
    }
    
}
