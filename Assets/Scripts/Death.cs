using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        infinite(collision);
        SceneManager.LoadScene(1);
    }

    void infinite(Collider2D collision)
    {
        var GM = Instantiate(collision.gameObject, new Vector3(0, 0, 0), collision.transform.rotation).gameObject;
        GM.name = collision.gameObject.name;
        GM.GetComponent<Collider2D>().enabled = true;
        GM.GetComponent<BallPhysics>().enabled = true;
        GM.SetActive(true);

    }
}
