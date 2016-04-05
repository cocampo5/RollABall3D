using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
    private Rigidbody rb; //El Rigidbody
    public Text contText;
    public Text winText;
    private int cont;
    public float speed;
    void Start()
    {
        cont = 0;
        rb = GetComponent<Rigidbody>();
        setScoreText();
        winText.text = "";
    }
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal,0.0f,moveVertical);
        rb.AddForce(move*speed);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            cont++;
            setScoreText();
        }
        //Destroy(other.gameObject);
    }

    void setScoreText()
    {
        contText.text = "Score: " + cont.ToString();
        if (cont >= 8)
        {
            winText.text = "YOU WIN";
        }


    }
}
