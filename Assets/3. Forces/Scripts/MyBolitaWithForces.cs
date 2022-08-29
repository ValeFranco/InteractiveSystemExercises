using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyBolitaWithForces : MonoBehaviour
{
    private MyVector2D position;
    [SerializeField] private MyVector2D velocity;
    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private float mass = 1f;

    [Header("Forces")]
    [SerializeField] private MyVector2D gravity;
    [SerializeField] private MyVector2D wind;
    private MyVector2D netForce;
    private MyVector2D weight;

    [Range(0f,1f)] [SerializeField] private float dampingFactor;
    [Range(0f, 1f)] [SerializeField] private float frictionCoeficent;
    [SerializeField] Camera camara;

    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        netForce = new MyVector2D(0, 0); //cada vez que inicia receteamos net force para que no incremente a lo loco

        //weight
        weight = mass * gravity;
        ApplyForce(weight);

        //Friction
        MyVector2D friction = -frictionCoeficent * weight.magnitude * velocity.normalized;
        ApplyForce(friction);
        friction.Draw(position, Color.black);

        //wind
        ApplyForce(wind);

        Move(); //lo pongo aqui para tener un deltatime fijo
    }
    void Update() //se llama muchas veces en un segundo
    {
        position.Draw(Color.blue);
        velocity.Draw(position, Color.red); //position indica que el origen del vector va a ser siempre en la bolita
        //acceleration.Draw(position, Color.green); 
    }

    public void Move()
    {
        //Euler integrator
        velocity = velocity + acceleration * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime; //(1f / 60f) time.delta time representa esta division 

        //check horizontal bounds
        if (Mathf.Abs(position.x) > camara.orthographicSize) 
        {
            velocity.x = velocity.x * -1;
            position.x = Mathf.Sign(position.x) * camara.orthographicSize;
            //Mathf.Sign devuelve 1(positivo) 0 -1(negativo) dependiendo del signo 
            velocity *= dampingFactor; 
        }

        //check vertical bounds
        if (Mathf.Abs(position.y) > camara.orthographicSize) 
        {
            velocity.y = velocity.y * -1;
            position.y = Mathf.Sign(position.y) * camara.orthographicSize;
            velocity *= dampingFactor;
        }
        transform.position = new Vector3(position.x, position.y);//referenciar el mov de la bolita para que se mueva con los vectores
    }

    private void ApplyForce(MyVector2D force)
    {
         netForce += force;
         acceleration = netForce / mass;
    }
}
