using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour {

    public GameObject block;
    Vector3 offset;
    Vector3 target;
    float deg;

	void Start ()
    {
        SetTarget(block.transform.localPosition, 60);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 10));

    }

    IEnumerator ThrowBall()
    {
        float b = Mathf.Tan(deg * Mathf.Deg2Rad);
        float a = (target.y - b * target.x) / (target.x * target.x);

        for(float x = 0; x <= this.target.x; x+=0.3f)
        {
            float y = a * x * x + b * x;
            transform.localPosition = new Vector3(x, y, 0) + offset;
            yield return null;
        }
    }

    public void SetTarget(Vector3 target, float deg)
    {
        this.offset = transform.localPosition;
        this.target = target - this.offset;
        this.deg = deg;

        StartCoroutine("ThrowBall");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Esa")
        {
            Destroy(gameObject);
        }
    }
}
