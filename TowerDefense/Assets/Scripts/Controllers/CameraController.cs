using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Space(25f)]
    [Header("Stats")]

    [Range(0,100)] public float panSpeed = 30f;
    [Range(0,100)] public float panBorder = 25f;
    [Range(0,25)]  public float scrollSpeed = 5f;
    [Range(0,100)] public float minY = 100f;
    [Range(0,100)] public float maxY = 100f;

    [Space(25f)]
    [Header("Others")]

    private float initialY;
    private bool canMove = true;


    private void Start()
    {
        initialY = transform.position.y;
    }

    private void Update()
    {
        if(GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            canMove = !canMove;
        }
        if (!canMove)
        {
            return;
        }

        //Déplacements de la caméra
        //En haut
        if (Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height - panBorder)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        //En Bas
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorder)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        //A gauche
        if (Input.GetKey(KeyCode.Q) || Input.mousePosition.x <= panBorder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        //A Droite
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, initialY - minY, initialY + maxY);
        transform.position = pos;
        //Debug.Log(scroll);
    }
}
