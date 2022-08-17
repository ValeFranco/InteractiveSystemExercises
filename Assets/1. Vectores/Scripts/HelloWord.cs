using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWord : MonoBehaviour
{
    [SerializeField] private MyVector2D myFirstVector = new MyVector2D(2, 3);
    [SerializeField] private MyVector2D mySecondVector = new MyVector2D(3, 4);
    [Range(0, 1)] [SerializeField] float scalar = 0;
    void Start()
    {
        //MyVector2D a = new MyVector2D(3, 4);
        //MyVector2D b = new MyVector2D(5, 6);
        //MyVector2D d = a.Sum(b);
        //MyVector2D c = a.Scale(2);
        //Debug.Log(d);

        //MyVector2D e = a - b;
        //MyVector2D f = a * 2f;

        //Vector2 au = new Vector2(2, 3);
        //Vector2 bu = new Vector2(4, 5);
        //Vector2 dv = au + bu;
    }
    void Update()
    {
        // Debug.DrawLine(Vector3.zero, Vector3.one, Color.green);

        //Debug.DrawLine(Vector3.zero,new Vector3(myFirstVector.x, myFirstVector.y,0), Color.green);
        //myFirstVector.Draw(Color.red);

        //clase siguiente
        // Debug.DrawLine(Vector3.zero, new Vector3(myFirstVector.x,myFirstVector.y,0), Color.red);

        //SUMA
        //myFirstVector.Draw(Color.red);
        //mySecondVector.Draw(myFirstVector,Color.green);

        //MyVector2D result = myFirstVector + mySecondVector;
        //result.Draw(Color.yellow);

        //RESTA
        myFirstVector.Draw(Color.red);
        mySecondVector.Draw(Color.green);

        MyVector2D result = (mySecondVector - myFirstVector) * scalar;  
        result.Draw(Color.yellow);
        result.Draw(myFirstVector, Color.yellow);

        //SUMA PARA AZUL
        MyVector2D result2 = myFirstVector + result;
        result2.Draw( Color.blue);

    }
}
