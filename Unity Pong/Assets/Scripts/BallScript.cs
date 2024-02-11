using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 10;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private TextMeshPro playerScore;
    [SerializeField] private TextMeshPro AIScore;

    private int hitCounter;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

}
