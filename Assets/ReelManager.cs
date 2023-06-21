using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelManager : MonoBehaviour
{
    public Sprite[] symbols; // Array of symbols for the reel
    private int[] currentSymbolIndices; // Array to store the current symbol index for each row

    public GameObject[] rows; // Array of row GameObjects

    private bool isSpinning = false; // Flag to track if the reel is currently spinning

    // Start the spinning animation
    public void StartSpinning()
    {
        if (!isSpinning)
        {
            isSpinning = true;
            StartCoroutine(Spin());
        }
    }

    // Stop the spinning animation
    public void StopSpinning()
    {
        if (isSpinning)
        {
            isSpinning = false;
        }
    }

    // Coroutine for spinning animation
    private IEnumerator Spin()
    {
        float spinDuration = 3f; // Duration of the spinning animation
        float spinSpeed = 10f; // Speed of the spinning animation
        int spinIterations = 10; // Number of iterations for the spinning animation

        int[] targetIndices = new int[rows.Length]; // Array to store the target symbol index for each row

        for (int i = 0; i < rows.Length; i++)
        {
            targetIndices[i] = Random.Range(0, symbols.Length); // Set a random target symbol index for each row
        }

        float elapsedTime = 0f;
        int currentIteration = 0;

        while (currentIteration < spinIterations)
        {
            elapsedTime += Time.deltaTime;

            // Calculate the current symbol index based on the progress of the animation
            for (int i = 0; i < rows.Length; i++)
            {
                float t = Mathf.Clamp01(elapsedTime / spinDuration);
                int currentIndex = Mathf.RoundToInt(Mathf.Lerp(currentSymbolIndices[i], targetIndices[i], t));
                currentSymbolIndices[i] = currentIndex;
                UpdateDisplayedSymbol(i);
            }

            yield return null;

            if (elapsedTime >= spinDuration)
            {
                currentIteration++;
                elapsedTime = 0f;

                // Set new target indices for the next iteration
                for (int i = 0; i < rows.Length; i++)
                {
                    targetIndices[i] = Random.Range(0, symbols.Length);
                }
            }
        }

        isSpinning = false;
    }

    // Update the displayed symbol on the specified row
    private void UpdateDisplayedSymbol(int rowIndex)
    {
        SpriteRenderer spriteRenderer = rows[rowIndex].GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = symbols[currentSymbolIndices[rowIndex]];
    }
}