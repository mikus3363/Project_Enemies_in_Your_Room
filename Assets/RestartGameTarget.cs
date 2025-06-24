using System.Diagnostics;
using UnityEngine;

public class RestartGameTarget : MonoBehaviour
{
    public GameStartUI gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            gameManager.StartGame();
        }
    }
}
