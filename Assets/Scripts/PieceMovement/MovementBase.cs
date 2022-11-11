using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementBase : MonoBehaviour
{
    [SerializeField] private Material _movable;
    [SerializeField] private Material _getable;
    public Material Movable { get => _movable; set => _movable = value; }
    public Material Getable { get => _getable; set => _getable = value; }
    public GameManager Manager { get; set; }
    public PieceManager Piece { get; set; }
    public  TestLoad Board { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Piece = GameObject.Find("Piece").GetComponent<PieceManager>();
        Board = GameObject.Find("Board").GetComponent<TestLoad>();
    }

    public void GetableRay(int x, int z)
    {
        //‚»‚Ì‹î‚ğŠl‚ê‚éó‘Ô‚ÉØ‚è‘Ö‚¦‚é
        if (Physics.Raycast(new Vector3(x, 5f, -z), Vector3.down, out RaycastHit hit, 20))
        {
            hit.collider.gameObject.GetComponent<MeshRenderer>().material = Getable;
        }
    }
}
