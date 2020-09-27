using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject Ball;
    public int leftScore, rightScore;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    private void Awake(){
        instance=this;
    }

    public void Scored(Scorer scorer){
        switch (scorer){
            case Scorer.Left:
                leftScore++;
                break;
            case Scorer.Right:
                rightScore++;
                break;
        }
        Ball.GetComponent<Ball>().Reset();
    }

    private void OnGUI(){
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

public enum Scorer {
    Left,
    Right
}

