using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayreController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI CountText;
    public GameObject WinTextObjct;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
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
        CountText.text = $"Count:{count}";
        if(count >= 12)
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
            other.gameObject.SetActive(false);
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
