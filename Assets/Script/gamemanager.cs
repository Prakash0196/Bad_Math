using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public Text[] numbersText = new Text[5];
    public int[] numbers = new int[5];

    public float time;
    public float roundLength;
    public Text timeText;
    
    //buttons 
    public Button[] buttons;

    //answer 
    public float[] Answers;
    public float result;
    public float score;
    public Text scoreText;

    public float Level;
    public int[] maxScore = new int[30];

    public Text levelText;

    
    

    //Audio

    public AudioSource source;

    public AudioClip[] clips = new AudioClip[2];


    // Start is called before the first frame update
    void Start()
    {
        time = 0.1f ;
        source = gameObject.AddComponent<AudioSource>();
        
        for ( int i = 0 ; i < maxScore.Length ; i++)
        {
            maxScore[i] = (i+100)* (i+1);
        } // change
       // randomNums();
       //displayResults();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = "Time: " + time.ToString();
        displayResults();

        for ( int i = 0 ; i < maxScore.Length ; i++)
        {
            if(score >= maxScore[i])
            {
                Level = i+1;
                levelText.text = "LEVEL :" +Level.ToString();
            }
        }
        if (time <= 0)
        {
            time = roundLength;
            randomNums();
            result = (( numbers[0] * numbers[1]) / numbers[2] + numbers[3] - numbers[4] );
            displayResults();

            Answers[0] = result;
            Answers[1] = result + Random.Range(1,6);
            Answers[2 ] = result + Random.Range(1,6);
            ShuffleArray(Answers);

            for ( int i = 0 ; i < buttons.Length ; i++ )
            {
                buttons[i].image.color = Color.white;
            }
 
        }
    }

    void randomNums()
    {
        for (int i = 0 ; i < numbers.Length ; i++)
        {
            numbers[i]=Random.Range(0,10);
            numbersText[i].text=numbers[i].ToString();
        }
        if (numbers[2] == 0)
        {
            numbers[2] = Random.Range(1,10);
            numbersText[2].text = numbers[2].ToString();
        }
    }
    void displayResults ()
    {
        for ( int i = 0 ; i< buttons.Length ; i++ )
        {
            buttons[i].transform.GetChild(0).GetComponent<Text>().text = Answers[i].ToString();
        }
    }

    public static void ShuffleArray<T>(T[] arr)
    {
        for ( int i = arr.Length-1 ; i>0 ; i--)
        {
            int r = Random.Range(0,i);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp ;
        }
    }
    public void ButtonCheck ( int buttonNum)
    {
        if (buttons[buttonNum].transform.GetChild(0).GetComponent<Text>().text == result.ToString())

        {
            Debug.Log("Correct !");
            buttons[buttonNum].image.color = Color.green;
            score += 2* time;
            scoreText.text = "SCORE:" + score.ToString("0");
            source.PlayOneShot(clips[0]);

        }
        else
        {
            Debug.Log("Wrong !");
            buttons[buttonNum].image.color = Color.red;
            score-= 15;
            scoreText.text = "SCORE:" + score.ToString("0");
            source.PlayOneShot(clips[1]);


        }
        time = 0.3f;
        if (score >= 0)
        {
            scoreText.color = Color.green;
        }
        else
        {
            scoreText.color = Color.red;

        }

    }
}
