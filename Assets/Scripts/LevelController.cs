using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject policeCarPrefab;

    [SerializeField]
    private GameObject buttonRestart;
    [SerializeField]
    private GameObject buttonFon;

    [SerializeField]
    private GameObject player;

    public Boolean inGame = false;

    [SerializeField]
    private float radiusSpawn;

    private Int32 countRestart = 0;

    private float timerSpawn = 0f;

    private Int32 carInScene = 0;

    private Int32 score = 0;
    //private float benz = 0;

    [SerializeField]
    private GameObject textScore;
    [SerializeField]
    private GameObject boomEffect;

    private void Start()
    {
        //YandexGame.FullscreenShow();
    }

    private void FixedUpdate()
    {
        if (inGame)
        {
            score += 1;
            textScore.GetComponent<Text>().text = score.ToString();
            timerSpawn += 0.01f;
            if (timerSpawn > 3f)
            {
                timerSpawn = 0f;
                this.Tick();
            }
        }
    }

    public void DestroyCarPolice(Vector3 location)
    {
        Instantiate(boomEffect, location, Quaternion.identity);
        carInScene--;
    }

    private void Tick()
    {
        if (inGame) {
            if (this.carInScene < 2)
            {
                CreatePoliceCar();
                this.carInScene++;
            }
        }
    }

    public void StartGame()
    {
        inGame = true;
    }

    private void CreatePoliceCar()
    {
        if (this.player != null)
        {
            var pointSpawn = this.GetPointSpawn();
            if (this.policeCarPrefab != null)
                Instantiate(this.policeCarPrefab, pointSpawn, Quaternion.identity);
        }
    }

    private Vector3 GetPointSpawn()
    {
        var angle = UnityEngine.Random.Range(0, 360);
        var x = player.transform.position.x + this.radiusSpawn * MathF.Sin(angle);
        var z = player.transform.position.z + this.radiusSpawn * MathF.Cos(angle);

        return new Vector3(x, 0, z);
    }

    public void GameOver()
    {
        inGame = false;
        this.buttonRestart.SetActive(true);
        this.buttonFon.SetActive(true);
    }
}
