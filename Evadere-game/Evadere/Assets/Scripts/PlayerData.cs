using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private CharacterController charController;
    public int level;
    public Vector3 position;

    public PlayerData(int level, Vector3 position)
    {
        this.level = level;
        this.position = position;
    }
}
