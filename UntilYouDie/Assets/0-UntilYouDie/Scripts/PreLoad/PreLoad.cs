using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreLoad : MonoBehaviour {

    void Start () {
        StartCoroutine(loadFirstScene());
    }

    public IEnumerator loadFirstScene() {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("MainMenu");
    }
}
