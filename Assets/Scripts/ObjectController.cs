using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float moveSpeed;
    private List<Color> randomColors = new List<Color>();
    public bool isGameOver = false;

    public static ObjectController instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;

        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            _rigidbody.isKinematic = false;

        if(transform.position.z > 5)
        {
            Time.timeScale = 0f;
        }
    }

    private void FixedUpdate()
    {
        if (_rigidbody.isKinematic)
            transform.Translate(0, 0, (1.0f * moveSpeed * Time.deltaTime));
    }
}
