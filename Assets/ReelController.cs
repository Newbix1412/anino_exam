using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelController : MonoBehaviour
{
    public int numberOfRows = 3;
    public float spinSpeed = 5f;

    private Transform[] rows;

    public void Initialize()
    {
        rows = new Transform[numberOfRows];
        for (int i = 0; i < numberOfRows; i++)
        {
            rows[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {
        SpinReel();
    }

    private void SpinReel()
    {
        transform.Translate(Vector3.down * spinSpeed * Time.deltaTime);
        if (transform.position.y <= -numberOfRows)
        {
            transform.position += new Vector3(0, numberOfRows, 0);
        }
    }
}
