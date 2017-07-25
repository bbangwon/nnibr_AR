﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour, ITrackableEventHandler {

    private TrackableBehaviour mTrackableBehaviour;

    public GameObject particle;

    public GameObject hama;
    public GameObject bat;
    public GameObject gunbird;
    public GameObject gaori;
    public GameObject pig;
    public GameObject snake;

    bool start = false;

    public GameObject ImageUI;

    

    private void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                TrackableBehaviour.Status previousStatus,
                                TrackableBehaviour.Status newStatus)
    {
        if ((newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED) && !start)
        {
            ImageUI.SetActive(false);
            StartCoroutine(CreateAnimal());
            start = true;
        }
    }

    public void UIOnClick()
    {
        ImageUI.SetActive(false);
    }

    IEnumerator CreateAnimal()
    {
        //파티클 보이기
        yield return new WaitForSeconds(1f);
        particle.transform.position = pig.transform.position;
        particle.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        pig.SetActive(true);
        
        LeanTween.moveY(particle, 20f, 2f).setOnComplete(() => {
            particle.SetActive(false);
        });

        yield return new WaitForSeconds(3f);
        Vector3 pos = hama.transform.position;
        pos.x -= 0.8f;
        particle.transform.position = pos;
        particle.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        hama.SetActive(true);
        
        LeanTween.moveY(particle, 20f, 3f).setOnComplete(() => {
            particle.SetActive(false);
        });

        yield return new WaitForSeconds(3f);
        particle.transform.position = snake.transform.position;
        particle.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        snake.SetActive(true);
        
        LeanTween.moveY(particle, 20f, 3f).setOnComplete(() => {
            particle.SetActive(false);
        });

        yield return new WaitForSeconds(3f);
        particle.transform.position = bat.transform.position;
        particle.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        bat.SetActive(true);
        
        LeanTween.moveY(particle, 20f, 3f).setOnComplete(() => {
            particle.SetActive(false);
        });

        yield return new WaitForSeconds(3f);
        particle.transform.position = gaori.transform.position;
        particle.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        gaori.SetActive(true);
        
        LeanTween.moveY(particle, 20f, 3f).setOnComplete(() => {
            particle.SetActive(false);
        });

        yield return new WaitForSeconds(3f);
        particle.transform.position = gunbird.transform.position;
        particle.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        gunbird.SetActive(true);
        
        LeanTween.moveY(particle, 20f, 3f).setOnComplete(() => {
            particle.SetActive(false);
        });
    }

    public void OnResetButton()
    {
        SceneManager.LoadScene("ar");
    }
}
