using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject enemyCarPrefab1;
    public GameObject enemySeagullPrefab;
    public GameObject bombLandPrefab;
    public GameObject bombPrefab;
    public GameObject bombPrefabC;
    public GameObject bombLandHelper;
    public GameObject bombLandHelperC;
    public GameObject explosionRatio;
    public GameObject explosionRatioC;
    public GameObject bum;


    public bool readyToThrowBomb;
    public Vector3 playerPos;
    public Vector3 lBombImpactPoss;
    public Vector3 wBombImpactPoss;



    public float m_Points;
    public float finalPoints;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI bestScore;


    void Start()
    {
        bestScore.text = "Best Score : "  + $"{ MenuManager.Instance.bestScore}";
        readyToThrowBomb = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
        
            if (Input.GetKeyDown("space"))
            {
                if (readyToThrowBomb)
                {
                    readyToThrowBomb = false;

                    StartCoroutine(BombCooldown());

                    bombLandHelperC = Instantiate(bombLandHelper, GameObject.FindGameObjectWithTag("Player").transform.position, transform.rotation);

                    bombLandHelperC.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;

                    lBombImpactPoss = bombLandHelperC.transform.localPosition + Vector3.forward * 21.5f;

                    bombLandHelperC.transform.localPosition = lBombImpactPoss;

                    wBombImpactPoss = bombLandHelperC.transform.position + Vector3.down * 26f + Vector3.forward * 8.3f;

                    bombPrefabC = Instantiate(bombPrefab, GameObject.FindGameObjectWithTag("Player").transform.position, transform.rotation);

                    StartCoroutine(SmoothTranslation(wBombImpactPoss, 2));
                }
            }
        
        
    }




    public void UpdateScore(float scoreToAdd)
    {
        finalPoints += scoreToAdd;
        ScoreText.text = $"Score: {finalPoints}";
    }

    public void GameOver()
    {
        MenuManager.Instance.score = finalPoints;
        CheckBestScore();
        SceneManager.LoadScene(2);
    }




    public void CheckBestScore()
    {
        if (finalPoints > MenuManager.Instance.bestScore)
        {
            Debug.Log("Puntueishon mejoreishon");//kitar

            MenuManager.Instance.bestName = MenuManager.Instance.finalName;
            MenuManager.Instance.bestScore = finalPoints;

            MenuManager.Instance.SaveBestName();
            MenuManager.Instance.SaveBestScore();

        }
    }

    IEnumerator BombCooldown()
    {
        yield return new WaitForSeconds(5);
        readyToThrowBomb = true;

    }

    IEnumerator SmoothTranslation(Vector3 target, float speed)
    {
        while (bombPrefabC.transform.position.y > target.y + 0.8)
        {
            bombPrefabC.transform.position = Vector3.Lerp(bombPrefabC.transform.position, target, Time.deltaTime * speed);
            yield return null;
        }
        Debug.Log("Bomb ase bum");
        explosionRatioC = Instantiate(explosionRatio, bombPrefabC.transform.position, transform.rotation);
        Instantiate(bum, explosionRatioC.transform.position, explosionRatioC.transform.rotation);
        StartCoroutine(ExplosionTime());
        Destroy(bombPrefabC);
    }

    IEnumerator ExplosionTime()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(explosionRatioC);
    }

}