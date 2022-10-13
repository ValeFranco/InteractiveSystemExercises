using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] int m_totalPoints = 10;
    [SerializeField] float m_distanceFactor = 10;
    [SerializeField] float m_amplitude = 1;
    [SerializeField] GameObject m_prefab;
    private GameObject[] m_allPoints;

    [SerializeField] LineRenderer m_lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        m_allPoints = new GameObject[m_totalPoints];
        for (int i = 0; i < m_totalPoints; ++i)
        {
            m_allPoints[i] = Instantiate(m_prefab, transform); 
        }
    }

    void Update()
    {
        for (int i = 0; i < m_allPoints.Length; ++i)
        {      
            float x = i * m_distanceFactor;
            float y = m_amplitude * Mathf.Sin(x + Time.time);
            m_allPoints[i].transform.localPosition = new Vector3(x, y, 0);
        }
    }
}
