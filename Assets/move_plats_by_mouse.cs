using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 1. Create a static reference to this script
    public static GameManager Instance { get; private set; }

    // 2. Add your global variables here
    public GameObject drag = null;
    public bool candrag = true;
    private Camera mainCamera;
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        mainCamera = Camera.main;
        candrag = true;
}
    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this duplicate
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set this as the active instance and keep it alive across scenes
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (!candrag)
            drag = null;
        if (drag != null && Mouse.current != null)
        {
            Vector3 mpos = Mouse.current.position.ReadValue();

            mpos = mainCamera.ScreenToWorldPoint(mpos);

            // 3. Reset Z to 0 so the object stays on the 2D plane (and isn't behind the camera)
            mpos.z = -.5f;
            drag.transform.position = mpos;

            // Optional: Stop dragging when you let go of the left mouse button
            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                drag = null;
            }
        }
    }

}
