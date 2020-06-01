using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public float[] position;

    public PlayerData(int level, float[] position)
    {
        this.level = level;
        this.position = new float[3];
        this.position[0] = position[0];
        this.position[1] = position[1];
        this.position[2] = position[2];
    }
}