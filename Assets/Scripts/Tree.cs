using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    [SerializeField] private float respawnTime;

    private Vector3 _startPosition;

    private PlayerDestroyTree _playerDestroyTree;

    [SerializeField] private GameObject treePrefab;

    public int Health => health;
    public int MaxHealth => maxHealth;

    private void Awake()
    {
        health = maxHealth;
        _startPosition = transform.position;
        _playerDestroyTree = GameObject.FindWithTag("Player").GetComponent<PlayerDestroyTree>();
    }

    private void Update()
    {
        Death();
    }

    public void RemoveHealth(int amount)
    {
        if (amount > 0)
        {
            health -= amount;
        }
    }

    private void Death()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
            _playerDestroyTree._treesList.Remove(this.GetComponent<Collider>());
            Invoke(nameof(Respawn), respawnTime);
        }
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
        health = maxHealth;
    }
}
