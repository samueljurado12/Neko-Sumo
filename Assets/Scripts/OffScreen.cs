using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OffScreen : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int player = other.GetComponent<CharacterMovement>().PlayerNumber;
            Animator ganador = null;
            int n = 0;
            if (player == 1)
            {
                n = 2;
                Debug.Log(n);
                ganador = GameManager.Instance.player2.GetComponentInChildren<Animator>();
            }
            else if (player == 2)
            {
                n = 1;
                Debug.Log(n);
                ganador = GameManager.Instance.player1.GetComponentInChildren<Animator>();
            }

            GameManager.Instance.player1.GetComponent<Rigidbody2D>().simulated = false;
            GameManager.Instance.player2.GetComponent<Rigidbody2D>().simulated = false;
            PlatformManager.Instance.GetComponent<Rigidbody2D>().simulated = false;

            ganador.SetTrigger("Winner");

            cameraTarget = ganador.transform;
            Camera.main.DOOrthoSize(2, 1);

            StartCoroutine(PantallaVictoria(n));

        }
        else if (other.GetComponent<Furball>())
        {
            Destroy(other.gameObject);
        }
    }

    Transform cameraTarget;

    private void Update()
    {
        if (cameraTarget != null)
        {
            Vector3 target = cameraTarget.position;
            target.z = Camera.main.transform.position.z;
            target.y = Mathf.Clamp(target.y, -3.38f, 3.38f);
            target.x = Mathf.Clamp(target.x, -6.04f, 6.04f);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, target, 2 * Time.deltaTime);
        }
            
    }

    IEnumerator PantallaVictoria(int n)
    {
        yield return new WaitForSeconds(2);
        WinScreen.Instance.Show(n);
        //ScenesManager.Instance.LoadScene(4);
    }
}
