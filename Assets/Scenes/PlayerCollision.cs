using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverCanvas;

    private void Start()
    {
        // Hide the UI when the game starts
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }
    }
// Replace OnCollisionEnter with OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        // Notice we use 'other.gameObject' instead of 'collision.gameObject'
        if (other.gameObject.CompareTag("Boulder"))
        {
            Debug.Log("Boulder Hit Player's Head!");
            StartCoroutine(GameOverSequence());
        }
    }

    IEnumerator GameOverSequence()
    {
        // 1. Show the Game Over Canvas
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
            
            // 2. Position it exactly 1.5 meters in front of the player's face
            Transform camTransform = Camera.main.transform;
            gameOverCanvas.transform.position = camTransform.position + camTransform.forward * 1.5f;
            
            // 3. Make the UI face the player
            gameOverCanvas.transform.rotation = Quaternion.LookRotation(gameOverCanvas.transform.position - camTransform.position);
        }

        // 4. Wait for 3 seconds so the player can read it
        yield return new WaitForSeconds(3f);

        // 5. Restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}