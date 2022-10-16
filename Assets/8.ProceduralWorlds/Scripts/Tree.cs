using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject branchPrefab;
    [SerializeField] private int totalLevels = 3;
    private int currentLevel=1;
    private Queue<GameObject> rootBranchesQueue = new Queue<GameObject>();

    private void Start()
    {
        GameObject rootBranch = Instantiate(branchPrefab, transform);
        rootBranchesQueue.Enqueue(rootBranch);
        GenerateTree();
    }

    private void Update()
    {
        
    }
    private void GenerateTree()
    {
        if(currentLevel>= totalLevels)
        {
            return;
        }
        ++currentLevel;
        Debug.Log(currentLevel);

        List<GameObject> branchesCreatedThisCycle = new List<GameObject>();

        while (rootBranchesQueue.Count > 0)
        {
            var rootBranch = rootBranchesQueue.Dequeue();

            var leftBranch = CreateBranch(rootBranch, 45f);
            var rightBranch = CreateBranch(rootBranch, -45f);

            branchesCreatedThisCycle.Add(leftBranch);
            branchesCreatedThisCycle.Add(rightBranch);
        }
        foreach (var newBranches in branchesCreatedThisCycle)
        {
            rootBranchesQueue.Enqueue(newBranches);
        }
       
        GenerateTree();
    }
    private GameObject CreateBranch(GameObject prevBranch, float relativeAngle)
    {
        GameObject newBranch = Instantiate(branchPrefab, transform);
        newBranch.transform.localPosition = prevBranch.transform.localPosition + prevBranch.transform.up;
        newBranch.transform.localRotation = prevBranch.transform.localRotation * Quaternion.Euler(0, 0, relativeAngle);

        return newBranch;
    }

    //private void PrintNumbrers (int number)
    //{
    //    if (number <= 10)
    //    {
    //        Debug.Log(number);
    //        PrintNumbrers(number + 1);
    //    }
    //}
}
