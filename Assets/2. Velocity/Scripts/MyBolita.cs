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
        displacement.Draw(position, Color.red); //position indica que el origen del vector va a ser siempre en la bolita
    }

    public void Move()
    {
        position = position + displacement;

        if (Mathf.Abs(position.x) > camara.orthographicSize)
        {
            displacement.x = displacement.x * -1;
            position.x = Mathf.Sign(position.x) * camara.orthographicSize;
        }
        transform.position = new Vector3(position.x, position.y); //referenciar el mov de la bolita para que se mueva con los vectores
    }

    private void CheckBounds()
    {

    }
}
