using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Light StandingLampLight;
    public Light CeilingLampLight;
    public GameObject UFO;
    public Camera mainCamera;
    public Camera secondCamera;
    public Camera thirdCamera; 
    public ParticleSystem UFOBeam;
    public GameObject creditsCanvas; 
    public AudioSource flickerAudioSource; 
    public TrailRenderer UFOTrail; 

    private Coroutine flickerCoroutine;

    void Start()
    {

        StandingLampLight.intensity = 0.5f;
        CeilingLampLight.intensity = 0f;

        mainCamera.GetComponent<AudioListener>().enabled = true;
        secondCamera.GetComponent<AudioListener>().enabled = false;
        thirdCamera.GetComponent<AudioListener>().enabled = false;

        StartCoroutine(UFOFlybySequence());
    }

    void Update()
    {
        
    }

    IEnumerator UFOFlybySequence()
    {
        Animator UFOAnimator = UFO.GetComponent<Animator>();
        UFOAnimator.SetTrigger("Flyby");

        UFOTrail.emitting = true;

        yield return new WaitForSeconds(UFOAnimator.GetCurrentAnimatorStateInfo(0).length);
        UFOTrail.emitting = false;
    }

    IEnumerator FlickerLights()
    {
        while (true)
        {
            StandingLampLight.intensity = Random.Range(0.1f, 0.8f);
            CeilingLampLight.intensity = Random.Range(0f, 0.8f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void StartFlickerLights()
    {
        flickerCoroutine = StartCoroutine(FlickerLights());
        if (flickerAudioSource != null)
        {
            flickerAudioSource.Play();
        }
    }

    public void StopFlickerLights()
    {
        if (flickerCoroutine != null)
        {
            StopCoroutine(flickerCoroutine);
            flickerCoroutine = null;

            StandingLampLight.intensity = 0.5f;
            CeilingLampLight.intensity = 0f;
        }

        if (flickerAudioSource != null)
        {
            flickerAudioSource.Stop();
        }
    }

    public void SwitchToSecondCamera()
    {
        mainCamera.enabled = false;
        mainCamera.GetComponent<AudioListener>().enabled = false;
        secondCamera.enabled = true;
        secondCamera.GetComponent<AudioListener>().enabled = true;
        thirdCamera.enabled = false;
        thirdCamera.GetComponent<AudioListener>().enabled = false;
    }

    public void SwitchToMainCamera()
    {
        mainCamera.enabled = true;
        mainCamera.GetComponent<AudioListener>().enabled = true;
        secondCamera.enabled = false;
        secondCamera.GetComponent<AudioListener>().enabled = false;
        thirdCamera.enabled = false;
        thirdCamera.GetComponent<AudioListener>().enabled = false;
    }

    public void SwitchToThirdCamera()
    {
        mainCamera.enabled = false;
        mainCamera.GetComponent<AudioListener>().enabled = false;
        secondCamera.enabled = false;
        secondCamera.GetComponent<AudioListener>().enabled = false;
        thirdCamera.enabled = true;
        thirdCamera.GetComponent<AudioListener>().enabled = true;
    }

    public void TriggerUFOBeam()
    {
        UFOBeam.Play();
    }

    public void ShowCredits()
    {
        creditsCanvas.SetActive(true);
    }
}
