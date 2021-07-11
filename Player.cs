using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float movespeed = 8;
    public float lookspeed = 120;
    public Camera childcam = null;
    public Text txtSpeed = null;
    public Text txtCoord = null;
    private AudioSource snd = null;

    private void Start()
    {
        childcam.transform.localPosition = Vector3.zero;
        Cursor.lockState = CursorLockMode.Locked;
        snd = this.GetComponent<AudioSource>();        
    }
    private void Update()
    {
        //look around
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector2 look = new Vector2(mouseX, mouseY);
        look = Vector2.Scale(look, new Vector2(lookspeed, lookspeed));
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            this.transform.localRotation *= Quaternion.AngleAxis(look.x * Time.deltaTime, Vector3.up);
            childcam.transform.localRotation *= Quaternion.AngleAxis(-look.y * Time.deltaTime, Vector3.right);
        }       

        //speed
        movespeed += Input.mouseScrollDelta.y;

        //move
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.forward * moveZ * movespeed * Time.deltaTime);
        this.transform.Translate(Vector3.right * moveX * movespeed * Time.deltaTime);
        if (Mathf.Approximately(moveX + moveZ, 0) == true)
        {
            if (snd.isPlaying == true)
            {
                snd.Stop();
            }
        }
        else
        {
            if (snd.isPlaying == false)
            {
                snd.Play();
            }
        }

        //cursor
        if (Input.GetButtonDown("Cancel") == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        txtSpeed.text = string.Format("Speed: {0}", movespeed);
        txtCoord.text = string.Format("Coord: {0}", this.transform.position);
    }
}
