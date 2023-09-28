using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImageScript : MonoBehaviour
{
    [SerializeField] private GameObject _imageUnknown;
    [SerializeField] private GameControllerScript _gameController;

    private int spriteID;

    public int SpriteID { get => spriteID; }

    public void OnMouseDown()
    {
        if (_imageUnknown.activeSelf && _gameController.canOpen)
        {
            _imageUnknown.SetActive(false);
            _gameController.ImageOpened(this);
        }
    }
    public void ChangeSprite(int id, Sprite image)
    {
        spriteID = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

   public void Close()
    {
        _imageUnknown.SetActive(true);
    }
}
