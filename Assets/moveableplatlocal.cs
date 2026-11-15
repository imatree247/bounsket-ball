using UnityEngine;
using UnityEngine.EventSystems;
public class moveableplatlocal : MonoBehaviour, IPointerDownHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.drag = gameObject;
    }
}
