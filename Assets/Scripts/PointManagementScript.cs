using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManagementScript : MonoBehaviour
{
    public Text pointsText { get; private set; }
    public PlayerMovementScript playerMovementScript { get; private set; }

    private void Start()
    {
        pointsText = this.transform.Find("Points").GetComponent<Text>();
        playerMovementScript = GameObject.FindObjectOfType<PlayerMovementScript>();
    }

    private void Update()
    {
        pointsText.text = playerMovementScript.points.ToString();
    }
}
