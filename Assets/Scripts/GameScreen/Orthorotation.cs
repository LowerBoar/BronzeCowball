using System;
using System.Security.Cryptography;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class Orthorotation : MonoBehaviour
{
    public enum UpdateState
    {
        Idle,
        Rotating,
    }

    public enum RotationStrategy
    {
        Clockwise,
        CounterClockwise,
        Random,
    }

    private float timer;
    private Quaternion targetRotation;

    public bool Enabled = true;
    public RotationStrategy Strategy;
    public float RotationStep = 1.0f;
    public float RotationTimeInterval = 1.0f;

    public UpdateState State { get; private set; }

    private void Update()
    {
        if (Enabled) {
            UpdateTimer();
            switch (State) {
                case UpdateState.Idle:
                    if (TryStartRotation()) {
                        ResetTimer();
                        State = UpdateState.Rotating;
                    }
                    break;
                case UpdateState.Rotating:
                    if (!TryRotate()) {
                        ResetTimer();
                        State = UpdateState.Idle;
                    }
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void ResetTimer() => timer = default;
    private void UpdateTimer() => timer += Time.deltaTime;

    private void TryChangeState()
    {
        switch (State) {
            case UpdateState.Idle:
                if (TryStartRotation()) {
                    State = UpdateState.Rotating;
                };
                break;
        }
    }

    private bool TryStartRotation()
    {
        if (timer >= RotationTimeInterval) {
            targetRotation = transform.rotation * Quaternion.Euler(0, 0, GetDirection() * 90);
            return true;
        }

        return false;
    }

    private bool TryRotate()
    {
        if (transform.rotation != targetRotation) {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, RotationStep / 100);
            return true;
        }

        transform.rotation = targetRotation;
        return false;
    }

    private int GetDirection()
    {
        return Strategy switch {
            RotationStrategy.Clockwise        => -1,
            RotationStrategy.CounterClockwise => 1,
            RotationStrategy.Random           => Math.Sign(Math.Cos(UnityEngine.Random.Range(0.0f, (float) Math.PI))),
            _                                 => throw new ArgumentOutOfRangeException()
        };
    }
}
