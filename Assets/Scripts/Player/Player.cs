using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxPoints = 2;
    public float speed = 10;
    public Image uiPlayer;
    public string playerName;

    [Header("Key Setup")]
    public KeyCode KeyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode KeyCodeMoveDown = KeyCode.DownArrow;

    public Rigidbody2D myRigidbody2D;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    private void Awake()
    {
        ResetPlayer();
    }
    public void SetName(string s)
    {
        playerName = s;
    }
    public  void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }
    void Update()
    {
        if (Input.GetKey(KeyCodeMoveUp))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * speed);
            
        } 
        else if (Input.GetKey(KeyCodeMoveDown))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * -speed);
        }
    }
    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
        Debug.Log(currentPoints);

    }
    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }
    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if(currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            HighscoreManager.Instance.SavePlayerWin(this);
        }
    }
    
}
