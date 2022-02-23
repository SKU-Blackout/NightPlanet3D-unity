using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRendering
{
    private class Segment
    {
        public Vector2 previousPos;
        public Vector2 position;
        public Vector2 velocity;

        public Segment(Vector2 _position)
        {
            previousPos = _position;
            position = _position;
            velocity = Vector2.zero;
        }
    }
    private GameObject rope;
    private LineRenderer lineRenderer;
    private List<Segment> segments = new List<Segment>();

    private readonly int segmentCount = 15;
    private readonly float segmentLength = 0.1f;
    private readonly float ropeWidth = 0.1f;
    private readonly Vector2 gravity = new Vector2(0f, -0.98f);

    public void Init(GameObject rope)
    {
        this.rope = rope;
        lineRenderer = rope.AddComponent<LineRenderer>();
        Vector2 segmentPos = rope.transform.position;
        for (int i = 0; i < segmentCount; ++i)
        {
            segmentPos.y -= segmentLength;
            segments.Add(new Segment(segmentPos));
        }

        lineRenderer.startWidth = ropeWidth;
        lineRenderer.endWidth = ropeWidth;
    }

    public void OnUpdate(Transform endPos)
    {
        UpdateSegment();
        ApplyConstraint(endPos);
        DrawRope();
    }

    private void UpdateSegment()
    {
        for (int i = 0; i < segments.Count; ++i)
        {
            segments[i].velocity = segments[i].position - segments[i].previousPos;
            segments[i].previousPos = segments[i].position;
            segments[i].position += gravity * Time.deltaTime * Time.deltaTime;
            segments[i].position += segments[i].velocity;
        }
    }
    private void ApplyConstraint(Transform endPos)
    {
        segments[0].position = rope.transform.position;
        segments[segments.Count - 1].position = endPos.transform.position;
        for (int i = 0; i < segmentCount - 1; ++i)
        {
            float distance = (segments[i].position - segments[i + 1].position).magnitude;
            float difference = segmentLength - distance;
            Vector2 dir = (segments[i + 1].position - segments[i].position).normalized;

            Vector2 movement = dir * difference;
            if (i == 0)
                segments[i + 1].position += movement;
            else if (i == segments.Count - 2)
                segments[i].position -= movement;
            else
            {
                segments[i].position -= movement * 0.5f;
                segments[i + 1].position += movement * 0.5f;
            }
        }
    }
    private void DrawRope()
    {
        Vector3[] segmentPositions = new Vector3[segments.Count];

        for (int i = 0; i < segments.Count; ++i)
            segmentPositions[i] = segments[i].position;

        lineRenderer.positionCount = segmentPositions.Length;
        lineRenderer.SetPositions(segmentPositions);
    }

}
