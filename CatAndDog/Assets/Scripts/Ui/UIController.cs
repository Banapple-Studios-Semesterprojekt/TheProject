using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    //Timer Variabels 
    public int Timer=0;
    private bool time=true;
    public TMP_Text Timer_Text;


    //collecterbel Variabels
    public int catFood = 0;
    public int dogFood = 0;
    public TMP_Text catFoodScore;
    public TMP_Text dogFoodScore;
    [SerializeField] GameObject CatFoodScore;
    [SerializeField] GameObject DogFoodScore;
    public float scoretimercat = 0;
    public float scoretimerdog = 0;


    // Unlock Variabels 
    public GameObject UnlockerScren;
    public TMP_Text Unlocke_Titel;
    public TMP_Text Unlocke_Text;
    public Image Unlocke_Image;
    [SerializeField] Sprite[] Unlocke_icon;
    [SerializeField] string[] Unlocke_text;
    private Bark bark;

    private void Start()
    {
        //find Bark and start timer
        bark = FindAnyObjectByType<Bark>();
        StartCoroutine(timer());
    }

    private void Update()
    {
        //if the svoretimer is bigger than one move ther svore text into view and decreas scoretime, else make sure the score text is out of frame
        if (scoretimercat >= 0)
        {
            if (CatFoodScore.transform.position.x > 1850)
            {
            CatFoodScore.transform.position = new Vector2(-10+CatFoodScore.transform.position.x, CatFoodScore.transform.position.y);
            }
            scoretimercat -=1*Time.deltaTime;
        }
        else
        {
            if (CatFoodScore.transform.position.x < 2150)
            {
             CatFoodScore.transform.position = new Vector2(10 + CatFoodScore.transform.position.x, CatFoodScore.transform.position.y);
            }
        }

        if (scoretimerdog >= 0)
        {
            if (DogFoodScore.transform.position.x > 1850)
            {
                DogFoodScore.transform.position = new Vector2(-10 + DogFoodScore.transform.position.x, DogFoodScore.transform.position.y);
            }
            scoretimerdog -= 1 * Time.deltaTime;
        }
        else
        {
            if (DogFoodScore.transform.position.x < 2150)
            {
                DogFoodScore.transform.position = new Vector2(10 + DogFoodScore.transform.position.x, DogFoodScore.transform.position.y);
            }
        }
    }
    public void stoptimer()
    {
        //stop timer
        StopCoroutine(timer());
        time = false;
    }
    IEnumerator timer()
    {
        //count the timer up format it to the timer in the corner 
        int sec = 0;
        int min = 0;
        string minstring=null;
        while (time)
        {
           yield return new WaitForSeconds(1);
           Timer++;
            sec++;
            if (sec==60)
            {
                min++;
                sec -= 60;
            }
            if (min<10)
            {
                minstring = "0"+min.ToString();
            }
            else
            {
                minstring = min.ToString();
            }

            if (sec<10)
            {
                Timer_Text.SetText(minstring + ":"+"0"+sec.ToString());
            }
            else
            {
               Timer_Text.SetText(minstring+":"+sec.ToString()); 
            }
            
            
        }
        

    }
    public void Updatescore()
    {
        //set scorer text to score
        catFoodScore.SetText("x " + catFood.ToString());
        dogFoodScore.SetText("x " + dogFood.ToString());
    }

    public void Unlocker(int unlock)
    {
        // Switch case to controle unlock
        switch (unlock)
        {
            case 1:
                bark.canBark = true;
                Unlocke_Text.text = Unlocke_text[0];
                Unlocke_Titel.text = Unlocke_text[1];
                Unlocke_Image.sprite = Unlocke_icon[0];
                StartCoroutine(ULScrenn());
                break;
        }
    }



    IEnumerator ULScrenn()
    {
        // unlock scenn anymation controle
        bool active = true;
        while (active)
        {
            UnlockerScren.SetActive(true);
            yield return new WaitForSeconds(4);
            UnlockerScren.SetActive(false);
            active = false;
            StopCoroutine(ULScrenn());
        }
    }
}
