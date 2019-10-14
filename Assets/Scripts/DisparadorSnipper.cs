using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorSnipper : MonoBehaviour
{
    [SerializeField] Transform puntoDisparo;
    [SerializeField] GameObject prefabMarca;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Fire();
        }
        Debug.DrawRay(puntoDisparo.position, puntoDisparo.forward * 100, Color.green);
    }

    private void Fire()
    {
        RaycastHit rch;
        /*
        bool hayImpacto = Physics.Raycast(
            puntoDisparo.position,
            puntoDisparo.forward,
            out rch);
        */
        Ray rayito = new Ray(puntoDisparo.position, puntoDisparo.forward);
        bool hayImpacto = Physics.Raycast(rayito, out rch);
        if (hayImpacto)
        {
            Debug.DrawRay(puntoDisparo.position, puntoDisparo.forward * rch.distance, Color.red, Mathf.Infinity);
            print(rch.collider.gameObject.name);
            //GameObject impacto = Instantiate(prefabMarca, rch.point, Quaternion.identity);//Impacto independiente
            GameObject impacto = Instantiate(prefabMarca, rch.transform);
            impacto.transform.position = rch.point;
            impacto.transform.rotation = Quaternion.FromToRotation(Vector3.back, rch.normal);
            impacto.transform.Translate(Vector3.back * 0.01f);
            //Debug.DrawRay(rch.point, rch.normal, Color.blue, 10);
        }
    }
}
