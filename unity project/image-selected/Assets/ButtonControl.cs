using UnityEngine.UI;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public int photoIndex;
    public Color selectedColor;
    private PhotoControl.PhotoCategory currentCate;
    private GameMaster gh;
    private bool temp = true;

    private void Start()
    {
        FillRandomPhotos();
        FindObjectOfType<GameMaster>().cateCount[(int)currentCate]++;
    }

    public void Selected()
    {
        if (temp)
        {
            GetComponent<Image>().color = selectedColor;
            if (FindObjectOfType<GameMaster>().sceneCate == currentCate)
            {
                FindObjectOfType<GameMaster>().correctCount++;
            }
            else
            {
                FindObjectOfType<GameMaster>().wrongCount++;
            }
            temp = false;
        }
        else
        {
            temp = true;
            GetComponent<Image>().color = Color.white;
            if (FindObjectOfType<GameMaster>().sceneCate == currentCate)
            {
                FindObjectOfType<GameMaster>().correctCount--;
            }
            else
            {
                FindObjectOfType<GameMaster>().wrongCount--;
            }
        }
    }

    public void FillRandomPhotos()
    {
        gh = FindObjectOfType<GameMaster>();
        gameObject.GetComponent<Image>().sprite = gh.allPhotos[gh.photoNumbers[photoIndex]].photo;
        currentCate = gh.allPhotos[gh.photoNumbers[photoIndex]].photoCate;
    }


}
