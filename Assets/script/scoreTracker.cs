using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//adapted from brackeys "How to make a HIGH SCORE in Unity"
public class scoreTracker : MonoBehaviour
{
    public GameObject player;
    public int score;
    public int highScore;
    public GameObject[] blips;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("boat");
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        //randomly place things
        for(int i = 0; i <= 10; i++){
            SpawnThing(blips[0]);
        }
        for(int i = 0; i <= 5; i++){
            SpawnThing(blips[1]);
        }
        for(int i = 0; i <= 7; i++){
            SpawnThing(blips[2]);
        }

    }

    void Update(){
        if(score >= 10){
            victory();
        }
    }

    public void SpawnThing(GameObject type) {
        GameObject a = Instantiate(type, GenerateSpawnPos(), type.transform.rotation);
    }

    private Vector3 GenerateSpawnPos() {
        Collider2D hit;
        Vector3 location;
        do{
            location = player.transform.position + (new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f,1f), 0f).normalized) * Random.Range(5f, 40f);
            hit = Physics2D.OverlapCircle(location, 1f);
        } while(hit); //forces re-roll of location if would spawn zombie in collision
        
        return location;
    }

    public void endGame()
    {
        if(score>highScore)
        {
            highScore=score;
            PlayerPrefs.SetInt("HighScore",highScore);
        }
        Debug.Log("highscore =" + highScore);
        Debug.Log("score =" + score);
        score = 0;
        SceneManager.LoadScene("GameOver");
    }
   
    public void victory(){
        if(score>highScore)
        {
            highScore=score;
            PlayerPrefs.SetInt("HighScore",highScore);
        }
        Debug.Log("highscore =" + highScore);
        Debug.Log("score =" + score);
        score = 0;
        SceneManager.LoadScene("Victory");
    }

}
