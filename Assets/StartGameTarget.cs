using System.Diagnostics;
using UnityEngine;

public class StartGameTarget : MonoBehaviour
{
    public GameStartUI gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            gameManager.BeginGameplay();
        }
    }
}
