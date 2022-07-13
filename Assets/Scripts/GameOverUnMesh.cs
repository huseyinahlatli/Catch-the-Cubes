using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUnMesh : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    private void OnTriggerEnter(Collider other)
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
