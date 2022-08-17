using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyBolita : MonoBehaviour
{
    [SerializeField] private MyVector2D displacement;
     private MyVector2D position;
    [SerializeField] Camera camara;
    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    void Update()
    {
        position.Draw(Color.blue);
        displacement.Draw(Color.red);
    }

    public void Move()
    {
        position = position + displacement;

        if(position.x > camara.orthographicSize)
        {
            displacement.x = displacement.x * -1;
            position.x = camara.orthographicSize;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y); //referenciar el mov de la bolita para que se mueva con los vectores
    }

    private void CheckBounds()
    {

    }
}
