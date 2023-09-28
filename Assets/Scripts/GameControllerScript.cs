using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public const int columns = 4;
    public const int rows = 2;
    public const float xSpace = 4f;
    public const float ySpace = -5f;
    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    [SerializeField] private MainImageScript startObject;
    [SerializeField] private Sprite[] images;
    [SerializeField] private TextMesh _scoreText;
    [SerializeField] private TextMesh _attemptsText;

    private MainImageScript firstOpen;
    private MainImageScript secondOpen;
    private int score = 0;
    private int attempts = 0;


    private int[] Randomiser(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for (int i = 0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    private void Start()
    {
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3 };
        locations = Randomiser(locations);
        Vector3 startPosition = startObject.transform.position;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                MainImageScript gameImage;
                if (i==0 && j==0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as MainImageScript;
                }

                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (xSpace * i) + startPosition.x;
                float positionY = (ySpace * j) + startPosition.y;


                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    public void ImageOpened(MainImageScript startObject)
    {
        if (firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    private IEnumerator CheckGuessed()
    {
        if (firstOpen.SpriteID == secondOpen.SpriteID)
        {
            score++;
            _scoreText.text = "Score: " + score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            firstOpen.Close();
            secondOpen.Close();

        }
        attempts++;
        _attemptsText.text = "Attempts: " + attempts;

        firstOpen = null;
        secondOpen = null;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
