using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyBolitaFallingIntoBlackHole : MonoBehaviour
{
    
    [SerializeField] private MyVector2D velocity;
    private MyVector2D acceleration;
    [SerializeField] private Transform blackHole;
    private MyVector2D position;

    [SerializeField] Camera camara;


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
        position = new MyVector2D(transform.position.x, transform.position.y);
        MyVector2D blackHolePosition = new MyVector2D(blackHole.position.x, blackHole.position.y);
        acceleration = blackHolePosition - position;

        position.Draw(Color.red);
        velocity.Draw(Color.blue);
        acceleration.Draw(Color.green);
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
