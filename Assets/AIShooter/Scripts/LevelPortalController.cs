using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class LevelPortalController : MonoBehaviour
{
    public string objectTag;
    public string levelName;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(objectTag)) return;

        SceneManager.LoadScene(levelName);
    }
}
