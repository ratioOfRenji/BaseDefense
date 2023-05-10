using UnityEngine;


public class Enemy : MonoBehaviour
{
   [SerializeField]
   private EnemyList _activeEnemiesList;
    [SerializeField]
    private IntValue _enemiesDefeated;

    protected void OnEnable()
    {
        _activeEnemiesList.value.Add(this);
    }
    protected void OnDisable()
    {
        _activeEnemiesList.value.Remove(this);
        _enemiesDefeated.Value++;
    }
}
