using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweensVale : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField, Range(0, 1)] private float normalizedTime;
    [SerializeField] private float duration=1;

    private float currentTime = 0;
    private Vector3 initialPosition;
    private Vector3 finalPosition;
    [SerializeField] private Color initialColor;
    [SerializeField] private Color finalColor;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartTween();
    }

    // Update is called once per frame
    void Update()
    {
        normalizedTime = currentTime / duration;
        transform.position = Vector3.Lerp(initialPosition, finalPosition, EaseInQuad(normalizedTime));
        spriteRenderer.color = Color.Lerp(initialColor, finalColor, EaseInQuad(normalizedTime));
        currentTime += Time.deltaTime;

        if ( normalizedTime>=1)
        {
            Debug.Log("Completed");
        }

        if (Input.GetKeyDown(KeyCode.Space)) StartTween();
    }

    private void StartTween()
    {
        currentTime = 0f;
        initialPosition = transform.position;
        finalPosition = targetTransform.position;
    }

    private float EaseInQuad(float x)
    {
        return x * x;
    }
}
