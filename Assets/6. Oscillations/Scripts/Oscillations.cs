using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillations : MonoBehaviour
{
    [SerializeField] private float amplitud=1;
    [SerializeField] private float period = 1;
    Vector3 initialPosition;

    private void Start()
    {
        initialPosition = new Vector3(transform.position.x, transform.position.y);
    }
    private void Update()
    {
        //PRIMER EJERCICIO
        //float x = amplitud * Mathf.Sin(2f * Mathf.PI*(Time.time/period));
        //transform.position = initialPosition + new Vector3(x, x, 0);

        //SEGUNDO EJERCICIO
        float x = Mathf.Sin(5f * Time.time) + Mathf.Cos(Time.time / 3f) + Mathf.Sin(Time.time / 13f);
        transform.position = initialPosition + new Vector3(x, 0, 0);
    }
}
