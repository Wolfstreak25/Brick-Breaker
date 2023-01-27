using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BallSpawner : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BallPrefab;
    public float ballForce;
    [SerializeField] private int MaxBall;
    private int BallCount;
    public Camera cam;
    Vector3 mouseLoc;
    public TMP_Text tmp;
    private void Start() {
        BallCount = MaxBall;
        tmp.text = BallCount + "";
    }
    // Update is called once per frame
    void Update()
    {
        mouseLoc = cam.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetButtonDown("Fire1") && BallCount > 0)
        {
            spawn();
            tmp.text = (--BallCount) + "";
        }
    }
    private void FixedUpdate() {
        
        Vector2 ShootDir = mouseLoc - transform.position;
        float angle = Mathf.Atan2(ShootDir.y, ShootDir.x) * Mathf.Rad2Deg - 90f;
        if(angle < 90 && angle > -90)
            {transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));}
        Debug.DrawRay(transform.position, mouseLoc - transform.position, Color.cyan);
        
    }
    void spawn()
    {
            GameObject ball = Instantiate(BallPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rball = ball.GetComponent<Rigidbody2D>();
            rball.AddForce(firePoint.up*ballForce, ForceMode2D.Impulse);
    }
}
