using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public GameObject reelPrefab;
    public int numberOfReels = 5;
    public int numberOfRows = 3;

    private void Start()
    {
        CreateReels();
    }

    private void CreateReels()
    {
        for (int i = 0; i < numberOfReels; i++)
        {
            GameObject reel = Instantiate(reelPrefab, transform);
            reel.transform.localPosition = new Vector3(i, 0, 0);
            ReelController reelController = reel.GetComponent<ReelController>();
            reelController.numberOfRows = numberOfRows;
            reelController.Initialize();
        }
    }
}

