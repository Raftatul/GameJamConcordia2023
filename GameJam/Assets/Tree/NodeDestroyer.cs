using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class NodeDestroyer : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (PlayerMouse.currentMode != PlayerMouse.BuildMode.DESTRUCTION)
        {
            return;
        }
        if (!GetComponentInParent<TreeNode>().isCoreNode)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
