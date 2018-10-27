using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public float width;
    public float height;

    private static HashSet<Vector2> tileRegistry = new HashSet<Vector2>();


    void Update() {
        CheckNeighbor(Vector2.up);
        CheckNeighbor(Vector2.down);
        CheckNeighbor(Vector2.left);
        CheckNeighbor(Vector2.right);
    }

    private void CheckNeighbor(Vector2 v) {
        v = new Vector2(v.x * width / 2, v.y * height / 2);
        if (HasNeighbor(v)) {
            return;
        }
        if (NeedsNeighbor(v)) {
            CreateNeighbor(v);
        }
    }

    private Vector2 CenterPos(Vector2 v) {
        return new Vector2(transform.position.x + v.x * 2, transform.position.y + v.y * 2);
    }

    private bool HasNeighbor(Vector2 v) {
        return tileRegistry.Contains(CenterPos(v));
    }

    private bool IsEdgeOnScreen(Vector2 v) {
        Vector3 middleOfEdge = transform.position + new Vector3(v.x, v.y, 0f);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(middleOfEdge);

        if (v.x != 0f) {
            // Left or right edge; if x is out of bounds, return false
            if (0f > screenPos.x || screenPos.x > Camera.main.pixelWidth) {
                return false;
            }
            // Else check whole height of edge
            Vector3 topCorner = Camera.main.WorldToScreenPoint(middleOfEdge + Vector3.up * height / 2);
            Vector3 bottomCorner = Camera.main.WorldToScreenPoint(middleOfEdge + Vector3.down * height / 2);
            // If both corners are above or below, return false
            if (topCorner.y > Camera.main.pixelHeight && bottomCorner.y > Camera.main.pixelHeight) {
                return false;
            }
            if (topCorner.y < 0f && bottomCorner.y < 0f) {
                return false;
            }

        } else if (v.y != 0f) {
            // Top or bottom edge; if y is out of bounds, return false
            if (0f > screenPos.y || screenPos.y > Camera.main.pixelHeight) {
                return false;
            }
            // Else check whole width of edge
            Vector3 leftCorner = Camera.main.WorldToScreenPoint(middleOfEdge + Vector3.left * width / 2);
            Vector3 rightCorner = Camera.main.WorldToScreenPoint(middleOfEdge + Vector3.right * width / 2);

            // If both corners are left or right, return false
            if (leftCorner.x < 0f && rightCorner.x < 0f) {
                return false;
            }
            if (leftCorner.x > Camera.main.pixelWidth && rightCorner.x > Camera.main.pixelWidth) {
                return false;
            }
        }
        return true;
    }

    private bool NeedsNeighbor(Vector2 v) {
        return IsEdgeOnScreen(v);
    }

    private void CreateNeighbor(Vector2 v) {
        GameObject neighbor = Instantiate(this.gameObject, transform.position + new Vector3(v.x, v.y, 0f) * 2, transform.rotation);
        Tile tile = neighbor.GetComponent<Tile>();
        SetNeighbor(v);
        tile.SetNeighbor(v * -1);
    }

    public void SetNeighbor(Vector2 v) {
        tileRegistry.Add(CenterPos(v));
    }
}
