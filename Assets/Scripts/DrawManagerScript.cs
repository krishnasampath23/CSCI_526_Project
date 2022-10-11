using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManagerScript : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Line _linePrefab;
    private Line _currentLine;
    public const float RESOLUTION = 0.1f;
    
    void Start()
    {
        _cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticScript.timeLeft > 0)
        {
            Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0)) _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);

            if (Input.GetMouseButton(0)) _currentLine.SetPosition(mousePos);
        }
    }
}
