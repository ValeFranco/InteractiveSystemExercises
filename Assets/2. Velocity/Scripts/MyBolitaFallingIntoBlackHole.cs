using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyBolitaFallingIntoBlackHole : MonoBehaviour
{
    private MyVector2D position;
    private MyVector2D displacement;
    [SerializeField] private MyVector2D velocity;
    [SerializeField] private MyVector2D acceleration;
    
    [SerializeField] Camera camara;
    [SerializeField] private Transform blackHole;


    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        Move(); //lo pongo aqui para tener un deltatime fijo
    }
    void Update() //se llama muchas veces en un segundo
    {
        position.Draw(Color.blue);
        displacement.Draw(position, Color.red); //position indica que el origen del vector va a ser siempre en la bolita
        acceleration.Draw(position, Color.green);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            acceleration = directions[(++currentAcceleration) % directions.Length];
            velocity *= 0; 
            //acceleration.x = acceleration.x+1f;
        }
    }

    public void Move()
    {
        //Euler integrator
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime; //(1f / 60f) time.delta time representa esta division 

        //Update position
        transform.position = new Vector3(position.x, position.y);//referenciar el mov de la bolita para que se mueva con los vectores
    }
}
