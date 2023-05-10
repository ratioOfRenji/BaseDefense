using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EnemyList: ScriptableObject
{
    public List<Enemy> value = new List<Enemy>();
}
