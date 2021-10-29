using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer = null;
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
    [SerializeField] private Spider spider = null;
    [SerializeField] private Astral astral = null;
    [Header("Transition Prefab")]
    [SerializeField] private GameObject _transition = null;
    [SerializeField] private float _spawnHeight = 0;

    private bool _spawnedTransition = false;
    private Rigidbody2D _instanceTransitionRB = null;

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
                spider.CheckSpider();
                astral.CheckAstral();
            }

            //transition
            if (!_spawnedTransition && VariablesManager.dHeight >= _spawnHeight)
            {
                var transition = Instantiate<GameObject>(_transition, new Vector3(rbPlayer.position.x, rbPlayer.position.y, 0), Quaternion.identity);
                _instanceTransitionRB = transition.GetComponent<Rigidbody2D>();
                _instanceTransitionRB.velocity = rbPlayer.velocity;
                _spawnedTransition = true;
            }
            else if (_spawnedTransition) 
            {
                _instanceTransitionRB.velocity = rbPlayer.velocity;
            }
        }
    }
}
