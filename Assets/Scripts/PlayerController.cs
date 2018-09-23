using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public GameObject ground;
    public Color groundFlashColor;
    public float groundFlashDuration;
    private Color originalGroundColor;
    private Renderer groundRenderer;
    private Rigidbody rb;
    private int count;
    private AudioSource pickUpAudioSource;

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }

    private void PlayPickUpSound()
    {
        pickUpAudioSource.time = 0.2f;
        pickUpAudioSource.Play();
    }

    private IEnumerator FlashGroundColor()
    {

        groundRenderer.material.color = groundFlashColor;
        yield return new WaitForSeconds(groundFlashDuration);
        groundRenderer.material.color = originalGroundColor;

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickUpAudioSource = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
        winText.text = "";
        groundRenderer = ground.GetComponent<Renderer>();
        originalGroundColor = groundRenderer.material.color;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            PlayPickUpSound();
            StartCoroutine(FlashGroundColor());
        }
    }
}
