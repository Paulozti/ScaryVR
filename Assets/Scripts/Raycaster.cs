using UnityEngine;
using UnityEngine.UI;

public class Raycaster : MonoBehaviour
{
    public TextMesh textDebug;
    public GameObject crosshair;
    float counter=2;
    public FPSWalk fpswalk;

    private bool hasKey;
    Clipboard clipboard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects 
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            
            textDebug.text = hit.transform.name;
            crosshair.transform.position = hit.point;
            crosshair.transform.forward = hit.normal;

            if (hit.transform.gameObject.CompareTag("Player"))
            {
                crosshair.GetComponent<Image>().CrossFadeColor(Color.green, .5f, false, false);
                counter -= Time.deltaTime;
                if (counter < 0)
                {
                    hit.transform.gameObject.SendMessage("ButtonAction");

                }
            }
            else if(hit.transform.gameObject.CompareTag("Walkable"))
            {
                crosshair.GetComponent<Image>().CrossFadeColor(Color.blue, .5f, false, false);
                counter -= Time.deltaTime;
                if (counter < 0)
                {
                    fpswalk.positionToGo = hit.transform.position;
                    fpswalk.steps.Play();
                }
            }
            else if (hit.transform.gameObject.CompareTag("Shelf"))
            {
                crosshair.GetComponent<Image>().CrossFadeColor(Color.green, .5f, false, false);
                AudioSource audio = hit.transform.GetComponent<AudioSource>();
                if(hit.transform.position.x < -16.1f)
                {
                    hit.transform.Translate(new Vector3(-0.3f, 0, 0) * Time.deltaTime);
                    if (!audio.isPlaying)
                        audio.Play();
                    
                } 
            }
            else if (hit.transform.gameObject.CompareTag("Key"))
            {
                crosshair.GetComponent<Image>().CrossFadeColor(Color.green, .5f, false, false);
                counter -= Time.deltaTime + 0.02f;
                if (counter < 0)
                {
                    hasKey = true;
                    Destroy(hit.transform.gameObject);
                }

            }
            else if (hit.transform.gameObject.CompareTag("Clipboard"))
            {
                crosshair.GetComponent<Image>().CrossFadeColor(Color.green, .5f, false, false);
                
                counter -= Time.deltaTime + 0.02f;
                if(counter < 1)
                {
                    clipboard = hit.transform.GetComponent<Clipboard>();
                }
                if (counter < 0 && clipboard.canOpen)
                {
                    clipboard.ShowCanvas();
                    counter = 3;
                }

            }
            else if (hit.transform.gameObject.CompareTag("Door"))
            {
                var door = hit.transform.gameObject.GetComponent<Door>();
                if (door != null)
                {
                    if (door.inRange)
                    {
                        crosshair.GetComponent<Image>().CrossFadeColor(Color.green, .5f, false, false);
                        counter -= Time.deltaTime + 0.02f;
                        if (counter < 0)
                        {
                            if (!door.locked)
                                door.DoorInteract();
                            else
                            {
                                if (!door.playingSound)
                                {
                                    door.audio.clip = door.lockedSound;
                                    door.audio.Play();
                                    door.playingSound = true;
                                    StartCoroutine(door.stopSound(2f));
                                }
                                
                            }

                        }
                    }
                }
            }
            else
            {
                counter = 3;
                crosshair.GetComponent<Image>().CrossFadeColor(Color.red, .5f, false, false);
            }
        }

       
    }
}
