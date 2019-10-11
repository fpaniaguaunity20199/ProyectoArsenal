using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorSnipper : MonoBehaviour
{
    [SerializeField] Transform puntoDisparo;
    [SerializeField] float fuerza;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Fire();
        }
    }

    private void Fire()
    {
        RaycastHit rch;
        bool hayImpacto = Physics.Raycast(
            puntoDisparo.position,
            puntoDisparo.forward,
            out rch);
        if (hayImpacto)
        {
            print(rch.collider.gameObject.name);
            if (rch.collider.gameObject.GetComponent<Rigidbody>() != null)
            {
                rch.collider.gameObject.GetComponent<Rigidbody>().
                    AddForce(puntoDisparo.forward * fuerza);
            }
        }
    }
}
