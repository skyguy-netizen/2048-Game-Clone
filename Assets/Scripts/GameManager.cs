using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
// using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int _width = 4;
    [SerializeField] private int _height = 4;
    [SerializeField] private SpriteRenderer _boardPrefab;
    [SerializeField] private Node _nodePrefab;
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private List<BlockType> _blocks;
    [SerializeField] private List<Node> _nodes;
    // [SerializeField] private GameState _gameState;
    // private static Random rng = new Random();
    // private GameState _gameState;

   private BlockType GetBlockTypeByValue(int value) => _blocks.First(t => t.value == value);

    void Start()
    {
        GenerateGrid();
        SpawnBlocks(2);
    }
    

    // private void ChangeState(GameState state){
    //     _state = state;
    //     switch (_state)
    //         case(_state == GameState.Generatelevel){
    //             GenerateGrid();
    //         }
    //         case(_state == GameState.)
    // }
    // Update is called once per frame
    // void Update(){
    //     if (_gameState != GameState.waitingInput) {
    //         return;
    //     }
    //     if (Input.GetKeyDown(KeyCode.UpArrow)){
    //         Shift(Vector2.up);
    //         return;
    //     }
    //     if (Input.GetKeyDown(KeyCode.DownArrow)){
    //         Shift(Vector2.down);
    //         return;
    //     }
    //     if (Input.GetKeyDown(KeyCode.LeftArrow)){
    //         Shift(Vector2.left);
    //         return;
    //     }
    //     if (Input.GetKeyDown(KeyCode.RightArrow)){
    //         Shift(Vector2.right);
    //         return;
    //     }
    // }

    void GenerateGrid(){
        _nodes = new List<Node>();
        for (int i = 0; i < _width; i++){
            for (int j = 0; j < _height; j++){
                var node = Instantiate(_nodePrefab, new Vector2(i, j), Quaternion.identity);
                _nodes.Add(node);
            }
        }
        var center = new Vector2((float)_width / 2 - 0.5f, (float)_height / 2 -0.5f);
        var board = Instantiate(_boardPrefab, center, Quaternion.identity);
        board.size = new Vector2(_width, _height);


        Camera.main.transform.position = new Vector3(center.x, center.y, -10);
    }


    void SpawnBlocks(int amount) {
        var freeNodes = _nodes.Where(n => n.OccupiedBlock == null).OrderBy(b => Random.value).ToList();

        foreach (var node in freeNodes.Take(amount)) {
           SpawnBlock(node, Random.value > 0.8f ? 4 : 2);
        }

        if (freeNodes.Count() == 1) {
            // ChangeState(GameState.Lose);
            return;
        }

        // ChangeState(_blocks.Any(b=>b.Value == _winCondition) ? GameState.Win : GameState.WaitingInput);
    }

    void SpawnBlock(Node node, int value) {
        var block = Instantiate(_blockPrefab, node.Position, Quaternion.identity);
        block.Init(GetBlockTypeByValue(value));
        // block.SetBlock(node);
        // _blocks.Add(block);
    }
    

    // public List<Node> GetFreeNodes(List<Node> _nodes){
    //     List<Node> freeNodes = new List<Node>();
    //     int index = 0;
    //     int size = _nodes.Count;
    //     for (int i = 0; i < size; i++){
    //         Node value = _nodes[i];
    //         if (value.OccupiedBlock == null){
    //             freeNodes[index++] = value;
    //         }
    //     }
    //     return freeNodes;
    // }

}


[System.Serializable]
public struct BlockType {
    public int value;
    public Color color;
}