using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        _numSeedsLeft = _numSeeds;
        _numSeedsPlanted = 0;
        _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
    }

    private void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            pos.y += _speed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            pos.y -= _speed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            pos.x += _speed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            pos.x -= _speed * Time.deltaTime;
        }

        transform.position = pos;

        if (Input.GetKeyDown("space"))
        {
            PlantSeed(pos);
        }
    }

    public void PlantSeed (Vector3 pos)
    {
        if( _numSeedsLeft != 0 )
        {
            _numSeedsLeft -= 1;
            _numSeedsPlanted += 1;

            Instantiate(_plantPrefab,pos, _playerTransform.rotation);
            _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);

        }
        
    }
}
