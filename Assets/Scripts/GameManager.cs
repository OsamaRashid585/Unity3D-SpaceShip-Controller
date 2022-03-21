using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _chickenOnePosX = -60;
    private float _chickenOnePosY = 30;
    public GameObject _chicken_One;

    private float _chickenTwoPosX = -90;
    private float _chickenTwoPosY = 100;
    public GameObject _chicken_Two;

    public GameObject _rock;

    private int wave = 0;

    private void Start()
    {

        wave = Random.Range(0, 3);
        if (wave == 0)
        {
            ChickenWaveTwo();
        }
        if (wave == 1)
        {
            ChickenWaveOne();
        }
        if (wave == 2)
        {
            RockWaveOne();
        }

    }

    private void Update()
    {
       
    }
    public void ChickenWaveOne()
    {
        if(GameObject.FindObjectsOfType<Chicken_One>().Length <= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Instantiate(_chicken_One, new Vector3(_chickenOnePosX, _chickenOnePosY, 0), Quaternion.identity);
                    _chickenOnePosX += 15;
                }
                _chickenOnePosX = -60;
                _chickenOnePosY -= 12;
            }
        }
    }
    public void ChickenWaveTwo()
    {
        if(GameObject.FindObjectsOfType<Chicken_two>().Length <= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Instantiate(_chicken_Two, new Vector3(_chickenTwoPosX, _chickenTwoPosY, 0), Quaternion.identity);
                    _chickenTwoPosX += 15;
                }
                _chickenTwoPosX = -90;
                _chickenTwoPosY -= 20;
            }
        }
    }
    public void RockWaveOne()
    {
        if (GameObject.FindObjectsOfType<Rock_One>().Length <= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Instantiate(_rock, new Vector3(Random.Range(-90, 90), Random.Range(60, 300), 0), Quaternion.identity);
                }
            }
        }
    }

}
