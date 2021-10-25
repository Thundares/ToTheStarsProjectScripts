using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DifficultController difficult = null;
    [Header("Managers and Controllers")]
    [SerializeField] private HeightController heightController = null;
    [SerializeField] private BackgroundManager backgroundManager = null;
    [SerializeField] private GameOverManager gameOver = null;
    [SerializeField] private SkyColor skyColor = null;
    [SerializeField] private SoundsManager soundsManager = null;
    [SerializeField] private SpawnImpulse spawnImpulse = null;
    [Header("Eggs")]
    [SerializeField] private Titan titan = null;

    void Start() 
    {
        soundsManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundsManager>();
    }
    

    void Update()
    {
        //###### every frame update ######

        //height controller
        heightController.CalculateHeight();
        heightController.ChangeUIText();
        if (VariablesManager.dRecord < VariablesManager.dHeight)
        {
            VariablesManager.dRecord = VariablesManager.dHeight;
        }

        //background manager
        backgroundManager.BGUpdate();

        //spawnImpulse
        spawnImpulse.CheckSpawn();

        //###### not essential upload ######
        if (Time.frameCount % 10 == 0) 
        {
            //difficult check
            if (VariablesManager.iHitNumber % 5 == 0) 
            {
                difficult.IncrementDif();
            }

            //achiev check
            AchievManager.CheckAchiev();

            //gameover check
            gameOver.CheckGameOver();
            if (VariablesManager.bGameOver) 
            {
                difficult.ResetDif();
            }

            //skycolor
            skyColor.CheckSky();

            //sound managere
            soundsManager.CheckMusic();

            //eggs
            if (VariablesManager.bEggsEnabled) 
            {
                titan.CheckTitan();
            }
        }
    }
}
