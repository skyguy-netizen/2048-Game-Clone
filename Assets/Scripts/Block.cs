using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update
    public int value;
    public Node currNode;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private TextMeshPro _mesh;
    
    public void Init(BlockType block) {
        value = block.value;
        _renderer.color = block.color;
        _mesh.text = block.value.ToString();
        // debug.Log(color);
    }

    public void SetNode(Node newNode) {
        if (currNode.OccupiedBlock != null) {}
    }

    public void Merge(BlockType blockToMerge) {

    }
}
