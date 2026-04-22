using System.Collections.Generic;
using UnityEngine;

public class EnemyManeger : MonoBehaviour
{
    public List<Enemy> enemiesInTrigger = new List<Enemy>();

    public void AddEnemy(Enemy enemy)
    {
        if (enemy != null && !enemiesInTrigger.Contains(enemy))
        {
            enemiesInTrigger.Add(enemy);
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (enemy != null)
        {
            enemiesInTrigger.Remove(enemy);
        }
    }
}
