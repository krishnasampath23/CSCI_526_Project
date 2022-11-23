using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManagerScript : MonoBehaviour
{
    [SerializeField] private Line _linePrefab;
    private Line _currentLine;
    public const float RESOLUTION = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (CanvasScript.GamePaused) return;

        if (StaticScript.lines_drawn < StaticScript.lines_limit)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
                _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
            if (Input.GetMouseButtonUp(0)) {
                TipScript.Ins.DrawLinesOK();
                StaticScript.lines_drawn += 1;
            }
            if (Input.GetMouseButton(0))
                _currentLine.SetPosition(mousePos);
        }
    }
}
