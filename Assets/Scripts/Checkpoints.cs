using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoints : MonoBehaviour
{
    public GameObject player;
    public GameObject plane2;

    // Update is called once per frame
    void Update()
    {
        //switch between levels
        if (Input.GetKey("0") && Input.GetKey(KeyCode.LeftShift))
        {
            player.transform.position = new Vector3(0, 0, 0); //start position
        }
        if (Input.GetKey("1") && Input.GetKey(KeyCode.LeftShift))
        {
            player.transform.position = plane2.transform.position;
        }
        if (Input.GetKey("2") && Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Checkpoint in Progress");
        }
        if (Input.GetKey("3") && Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("End checkpoint in Progress");
        }
        if (Input.GetKey("4") && Input.GetKey(KeyCode.LeftShift))
        {
            PlayerPrefs.DeleteKey("Checkpoint");
            Debug.Log("Checkpoints were deleted");
        }

        //pause
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
