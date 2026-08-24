using UnityEngine;
using UnityEngine.SceneManagement;

public class PosicionarPlayer : MonoBehaviour
{
    private void Start()
    {
        GameObject spawn = GameObject.Find("SpawnPlayer");

        if (spawn != null)
        {
            transform.position = spawn.transform.position;
        }
    }
}