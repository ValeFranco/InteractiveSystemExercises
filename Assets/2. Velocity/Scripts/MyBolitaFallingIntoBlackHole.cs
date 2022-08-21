using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyBolitaFallingIntoBlackHole : MonoBehaviour
{
    private MyVector2D position;
    private MyVector2D displacement;
    [SerializeField] private MyVector2D velocity;
    [SerializeField] private MyVector2D acceleration;
    [Range(0f,1f)] [SerializeField] private float dampingFactor;
    [SerializeField] Camera camara;

    private int currentAcceleration = 0;
    private readonly MyVector2D[] directions = new MyVector2D[4]
    {
        new MyVector2D(0,-9.8f),
        new MyVector2D(9.8f, 0),
        new MyVector2D(0, 9.8f),
        new MyVector2D(-9.8f, 0)
    };
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

        //CheckBounds(ref position.x, ref displacement.x, camara.orthographicSize);
        //CheckBounds(ref position.y, ref displacement.y, camara.orthographicSize);

        transform.position = new Vector3(position.x, position.y);//referenciar el mov de la bolita para que se mueva con los vectores
    }

    //private void CheckBounds(ref float x, ref float displacementX, float halfWidth)
    //{
    //    if(Mathf.Abs(x)> halfWidth)
    //    {
    //        displacementX = displacementX * -1;
    //        x = Mathf.Sign(x) * camara.orthographicSize;
    //    }
    //}
}
