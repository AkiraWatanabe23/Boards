using UnityEngine;

public abstract class MovementBase : MonoBehaviour
{
    [SerializeField] private Material _movable;
    [SerializeField] private Material _getable;

    public GameManager Manager { get; set; }
    public PieceManager Piece { get; set; }
    public TestLoad Board { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("Piece").GetComponent<GameManager>();
        Piece = GameObject.Find("Piece").GetComponent<PieceManager>();
        Board = GameObject.Find("Board").GetComponent<TestLoad>();
    }

    /// <summary>
    /// ’Tõ”ÍˆÍ‚Ì•`‰æ
    /// </summary>
    void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (Piece.Movable[i, j] == true)
                {
                    Board.Tiles[i, j].GetComponent<MeshRenderer>().enabled = true;
                }
                else if (Piece.Movable[i, j] == false)
                {
                    Board.Tiles[i, j].GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
    }

    public void GetableRay(int x, int z)
    {
        //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚é
        if (Physics.Raycast(new Vector3(x, 5f, -z), Vector3.down, out RaycastHit hit, 20))
        {
            hit.collider.gameObject.GetComponent<MeshRenderer>().material = _getable;
        }
    }
}
