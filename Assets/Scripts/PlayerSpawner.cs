using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!GameData.joinedPlayers[i]) continue;

            int characterIndex = GameData.selectedCharacters[i];

            GameObject player = Instantiate(
                playerPrefabs[characterIndex],
                spawnPoints[i].position,
                Quaternion.identity
            );

            PlayerController2D controller = player.GetComponent<PlayerController2D>();
            if (controller != null)
                controller.SetPlayerIndex(i);
        }
    }
}