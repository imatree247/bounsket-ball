using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons4start : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadscene(string scenename)
    {
        SceneManager.LoadScene(scenename, LoadSceneMode.Single);
    }
}
