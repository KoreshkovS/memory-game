using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private GameControllerScript _gameController;
    [SerializeField] private string _functionOnClick;

    public void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.cyan;
        }
    }
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
    }
    private void OnMouseUp()
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
        if (_gameController != null)
        {
            _gameController.SendMessage(_functionOnClick);
        }
    }
    private void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }
}
