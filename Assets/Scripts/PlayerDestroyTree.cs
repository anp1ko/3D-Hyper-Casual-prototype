using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyTree : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private int damage;

    [SerializeField] public List<Collider> _treesList;

    [SerializeField] private GameObject logPrefab;

    private void Start()
    {
        _treesList = new List<Collider>();
    }

    private void Update()
    {
        if (_treesList.Count == 0)
        {
            animator.SetBool("isDestroying", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            animator.SetBool("isDestroying", true);
        }

        _treesList.Add(other);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            animator.SetBool("isDestroying", false);
        }

        _treesList.Remove(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.activeSelf == false)
        {
            _treesList.Remove(other);
        }
    }

    public void DestroyTree()
    {
        foreach (var trees in _treesList)
        {
            if (trees.gameObject.activeSelf)
            {
                trees.GetComponent<Tree>().RemoveHealth(damage);
                Instantiate(logPrefab, trees.transform.position, Quaternion.identity);
            }
            else
            {
                animator.SetBool("isDestroying", false);
            }

        }
    }
}
