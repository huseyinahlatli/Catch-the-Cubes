using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag.Equals("Ground"))
        {
            StartCoroutine(GameOverTime());
        }
    }

    IEnumerator GameOverTime()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0f;
        restartButton.SetActive(true);
    }
}
