using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupLog : MonoBehaviour
{
    public List<GameObject> logList = new List<GameObject>();

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Log"))
        {
            logList.Add(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
