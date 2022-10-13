using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static bool InChurch = false;

    public Transform followTransform;
    public BoxCollider2D worldBounds;

    float xMax;
    float xMin;
    float yMax;
    float yMin;

    float camX;
    float camY;

    float camRatio;
    float camSize;

    Camera mainCamera;

    Vector3 smoothPos;

    public float smoothRate;


    //screenshake
    // Transform of the GameObject you want to shake
    private Transform transform;

    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.1f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 2f;

    
    void Start()
    {
        //audio
        AudioManager.instance.PlayLevelMusic();

        xMin = worldBounds.bounds.min.x;
        xMax = worldBounds.bounds.max.x;
        yMin = worldBounds.bounds.min.y;
        yMax = worldBounds.bounds.max.y;

        mainCamera = gameObject.GetComponent<Camera>();

        camSize = mainCamera.orthographicSize;
        camRatio = (xMax + camSize) / 8.0f;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = transform.position + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (!InChurch) {
            camY = Mathf.Clamp(followTransform.position.y, yMin + camSize, yMax - camSize);
            camX = Mathf.Clamp(followTransform.position.x, xMin + camRatio, xMax - camRatio);

            smoothPos = Vector3.Lerp(gameObject.transform.position, new Vector3(camX, camY, gameObject.transform.position.z), smoothRate);

            gameObject.transform.position = smoothPos;
        } else {
            camY = Mathf.Clamp(followTransform.position.y, yMin + camSize, yMax - camSize);
            camX = Mathf.Clamp(followTransform.position.x, xMin + camRatio, xMax - camRatio);

            smoothPos = Vector3.Lerp(gameObject.transform.position, new Vector3(camX, camY+3, gameObject.transform.position.z), smoothRate);

            gameObject.transform.position = smoothPos;
        }
    }

    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    public void TriggerShake()
    {
        shakeDuration = 0.1f;
    }
}