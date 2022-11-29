using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawManagerScript : MonoBehaviour
{
    [SerializeField] private Line _linePrefab;
    private Line _currentLine;
    public const float RESOLUTION = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (CanvasScript.GamePaused ||
            StaticScript.lines_drawn >= StaticScript.lines_limit)
            return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (_currentLine == null)
                _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
            _currentLine.SetPosition(mousePos);
        }
        if (Input.GetMouseButtonUp(0)) {
            if (_currentLine != null) {
                TipScript.Ins.DrawLinesOK();
                StaticScript.lines_drawn += 1;
                _currentLine = null;
            }
        }
    }
}
