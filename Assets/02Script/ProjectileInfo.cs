using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileOwner { 
    Player,
    Enemy, 
}


public class ProjectileInfo : MonoBehaviour
{
    [SerializeField] public ProjectileOwner owner; 
}
