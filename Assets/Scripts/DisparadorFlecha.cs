﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorFlecha : MonoBehaviour
{
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform puntoOrigen;
    [SerializeField] float fuerza;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Fire();
        }
    }
    private void Fire()
    {
        GameObject proyectil = Instantiate(
            prefabProyectil, 
            puntoOrigen.transform.position, 
            puntoOrigen.transform.rotation);
        proyectil.GetComponent<Rigidbody>().AddForce(puntoOrigen.forward * fuerza);
    }
}
