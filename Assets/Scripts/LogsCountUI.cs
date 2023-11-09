using UnityEngine;
using UnityEngine.UI;

public class LogsCountUI : MonoBehaviour
{
    [SerializeField] private PlayerPickupLog playerPickupLog;
    
    [SerializeField] private Text logsCountText;

    private void Update()
    {
        logsCountText.text = playerPickupLog.logList.Count.ToString();
    }
}
