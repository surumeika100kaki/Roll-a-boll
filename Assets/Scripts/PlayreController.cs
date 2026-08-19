using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayreController : MonoBehaviour
{
    public float speed;
    public Transform player;
    public TextMeshProUGUI CountText;
    public GameObject WinTextObjct;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private int ClireCount = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinTextObjct.SetActive(false);
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        CountText.text = $"ClireCount: {count}/{ClireCount}";
        if(count >= ClireCount)
        {
            WinTextObjct.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX,0.0f,movementY);
        rb.AddForce(movement*speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("teleport"))
        {
            Destroy(other.gameObject);
            while (true)
            {
                float x = Random.Range(0, MazeData.width);
                float z = Random.Range(0, MazeData.height);
                if (MazeData.wall[(int)x, (int)z] == true)
                {
                    player.position = new Vector3(x * 2, 0.5f, z * 2);
                    break;
                }
            }
        }
        count += 1;
        SetCountText();
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            WinTextObjct.SetActive(true);
            WinTextObjct.GetComponent<TextMeshProUGUI>().text = "You lose!";
        }
    }
}
