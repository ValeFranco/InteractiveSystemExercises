using System;
using UnityEngine;


[Serializable] //indica que un tipo dE dato es serializable
public struct MyVector2D
{
    public float x;
    public float y;

    public float magnitude => Mathf.Sqrt(x * x + y * y); //raiz cuadrada de x al cuadrado + y al cuadrado  
    public MyVector2D normalized
    {
        get
        {
            if(magnitude <= 0.0001)
            {
                return new MyVector2D(0, 0);
            }
            return new MyVector2D(x / magnitude, y / magnitude); //es 1
        }
    }  

    public MyVector2D(float x, float y) //constructor
    {
        this.x = x;
        this.y = y;
    }

    public void Normalize()
    {
        float tolerance = 0.0001f;
        if (magnitude <= tolerance)
        {
            x = 0;y = 0;
            return; //que no haga nada
        }
        x /= magnitude; y /= magnitude; 
    }
    //public MyVector2D Sum(MyVector2D a) //funcion devuelve un vector
    //{
    //    return new MyVector2D(
    //        x + a.x,
    //        y + a.y
    //    );
    //}

    //public MyVector2D Sub(MyVector2D a) //funcion devuelve un vector
    //{
    //    return new MyVector2D(
    //        x - a.x,
    //        y - a.y
    //    );
    //}

    //public MyVector2D Scale(float a)
    //{
    //    return new MyVector2D(
    //        x * a,
    //        y * a
    //    ); ;
    //}

    //public static MyVector2D operator +(MyVector2D a, MyVector2D b) // si algo es estatico es por que decimos que esta funcion no es del objeto, sino de la clase
    //{                                                               //esat funcion es para que se puedan sumar dos vectores on el + sin porblema para esto se pone operator y el simbolo 
    //    return new MyVector2D(
    //        a.x + b.x,
    //        a.y + b.y
    //    );
    //}
    //public static MyVector2D operator -(MyVector2D a, MyVector2D b)
    //{                                                             
    //    return new MyVector2D(
    //        a.x - b.x,
    //        a.y - b.y
    //    );
    //}

    //public static MyVector2D operator *(MyVector2D a, float b)
    //{
    //    return new MyVector2D(
    //        a.x + b,
    //        a.y + b
    //    );
    //}

    public static MyVector2D operator +(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(a.x + b.x, a.y + b.y);
    }
    public static MyVector2D operator -(MyVector2D a, MyVector2D b)
    {
        return new MyVector2D(a.x - b.x, a.y - b.y);
    }
    public static MyVector2D operator *(MyVector2D a, float b)
    {
        return new MyVector2D(a.x * b, a.y * b);
    }
    public static MyVector2D operator *(float b, MyVector2D a)
    {
        return new MyVector2D(a.x * b, a.y * b);
    }
    public static MyVector2D operator /(MyVector2D a, float b)
    {
        return new MyVector2D(a.x / b, a.y / b);
    }

    public void Draw(Color color)
    {
        Debug.DrawLine(
            Vector3.zero,
            new Vector3(x, y, 0),
            color
        );
    }
    public void Draw(MyVector2D newOrigin, Color color) //cambiar origen vector, no origen 0,0,0
    {
        Debug.DrawLine(
            new Vector3(newOrigin.x, newOrigin.y),
            new Vector3(newOrigin.x + x, newOrigin.y + y, 0),  //por que no quiero que al modificar uno el otro cambie su direcci?n
            color
        );
    }

    //public override string ToString() //To string le dice a c# que cuando quiero convertir objeto en texto lo hace
    //{
    //    return $"[{x}, {y}]";
    //}
}
