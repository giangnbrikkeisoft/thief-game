using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "DataLevel/Level")]
public class DataLevel : ScriptableObject
{
    [SerializeField]
    private GameObject level;
    public GameObject levelData
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    [SerializeField]
    private float carrotPoint;
    public float carrotPointData
    {
        get
        {
            return carrotPointData;
        }
        set
        {
            carrotPointData = value;
        }
    }

    [SerializeField]
    private float pearPoint;
    public float pearPointData
    {
        get
        {
            return pearPoint;
        }
        set
        {
            pearPoint = value;
        }
    }

    [SerializeField]
    private float coin;
    public float coinData
    {
        get
        {
            return coin;
        }
        set
        {
            coin = value;
        }
    }

    [SerializeField]
    private Vector3 playerPosition;
    public Vector3 playerPositionData
    {
        get
        {
            return playerPosition;
        }
        set
        {
            playerPosition = value;
        }
    }
}
