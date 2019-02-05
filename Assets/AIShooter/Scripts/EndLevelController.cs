using UnityEngine;

public class EndLevelController : MonoBehaviour
{

    public string objectTag;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(objectTag)) return;
        
        Application.Quit();
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
