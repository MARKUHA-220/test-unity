using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Gun : MonoBehaviour
{
    [SerializeField] private float range = 20f;
    [SerializeField] private float verticalRange = 20f;
    [SerializeField] private EnemyManeger enemyManeger;

    private BoxCollider gunTrigger;

    private void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.isTrigger = true;
        gunTrigger.size = new Vector3(1f, verticalRange, range);
        gunTrigger.center = new Vector3(0f, 0f, range * 0.5f);

        if (enemyManeger == null)
        {
            enemyManeger = FindObjectOfType<EnemyManeger>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null && enemyManeger != null)
        {
            enemyManeger.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null && enemyManeger != null)
        {
            enemyManeger.RemoveEnemy(enemy);
        }
    }
}
