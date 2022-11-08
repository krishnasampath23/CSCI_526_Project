using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer;
    [SerializeField] private EdgeCollider2D _collider;
    private readonly List<Vector2> _points = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        _collider.transform.position -= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Eraser")){
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                TipScript.Ins.EraserLineOK();
        }

    }

    public void SetPosition( Vector2 pos){
        if(!CanAppend(pos)) return;

        _points.Add(pos);
        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount - 1, pos);
        _collider.points = _points.ToArray();
    }

    public bool CanAppend( Vector2 pos){
        if(_renderer.positionCount == 0) return true;

        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1),pos) > DrawManagerScript.RESOLUTION;

    }
}
