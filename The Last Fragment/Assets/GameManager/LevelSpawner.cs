using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [Header("Configurações do Spawn")]
    [Tooltip("Arraste o Prefab do seu Personagem para cá")]
    public GameObject playerPrefab;

    [Tooltip("Arraste o objeto SpawnPoint da cena para cá")]
    public Transform spawnPoint;

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        // Verifica se o jogador já existe na cena (evita duplicar)
        GameObject existingPlayer = GameObject.FindGameObjectWithTag("Player");

        if (existingPlayer == null)
        {
            if (playerPrefab != null && spawnPoint != null)
            {
                // Instancia o personagem na posição e rotação do SpawnPoint
                Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
            }
            else
            {
                Debug.LogWarning("PlayerPrefab ou SpawnPoint não foram atribuídos no LevelSpawner!");
            }
        }
        else
        {
            // Se o player for reaproveitado com DontDestroyOnLoad entre fases:
            existingPlayer.transform.position = spawnPoint.position;
            existingPlayer.transform.rotation = spawnPoint.rotation;
        }
    }
}
