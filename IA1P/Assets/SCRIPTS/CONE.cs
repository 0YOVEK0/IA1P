using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONE : MonoBehaviour
{
    [Header("Eye of the Tiger")]
    public float detectionRadius = 10f; // Rango de detección
    [Range(0, 360)] 
    public float fieldOfSight = 45f; // Ángulo del campo de visión
    public LayerMask preyMask; // Máscara para los objetivos
    public LayerMask barrierMask; // Máscara para los obstáculos

    [Header("Chase Instinct")]
    public float chaseSpeed = 5f; // Velocidad de persecución
    public GameObject prey; // Objetivo a detectar

    [Header("Vision Feedback")]
    public bool isVisionVisible = true; // Variable controlada por DebugManager
    public Color idleColor = Color.green; // Color cuando no se detecta nada
    private bool hasLockedTarget = false; // Bandera para saber si se ha detectado un objetivo

    void Update()
    {
        ScanForPrey();
        if (hasLockedTarget)
        {
            EngageChase();
        }
    }

    // Busca si el objetivo está en el campo de visión
    void ScanForPrey()
    {
        Collider[] potentialTargets = Physics.OverlapSphere(transform.position, detectionRadius, preyMask);

        if (potentialTargets.Length != 0)
        {
            Transform targetInSight = potentialTargets[0].transform;
            Vector3 directionToTarget = (targetInSight.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < fieldOfSight / 2)
            {
                float targetDistance = Vector3.Distance(transform.position, targetInSight.position);

                if (!Physics.Raycast(transform.position, directionToTarget, targetDistance, barrierMask))
                {
                    hasLockedTarget = true;
                    idleColor = Color.red; // Cambia a rojo si el objetivo está en la mira
                    prey = targetInSight.gameObject;
                }
                else
                {
                    hasLockedTarget = false;
                    idleColor = Color.green;
                }
            }
            else
            {
                hasLockedTarget = false;
                idleColor = Color.green;
            }
        }
        else
        {
            hasLockedTarget = false;
            idleColor = Color.green;
        }
    }

    // Método para perseguir al objetivo con Steering Behavior
    void EngageChase()
    {
        Vector3 pursuitDirection = (prey.transform.position - transform.position).normalized;
        transform.position += pursuitDirection * chaseSpeed * Time.deltaTime;
    }

    // Dibuja el campo de visión en la escena con Gizmos
    private void OnDrawGizmos()
    {
        if (isVisionVisible)
        {
            Gizmos.color = idleColor;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);

            Vector3 leftEdge = Quaternion.Euler(0, -fieldOfSight / 2, 0) * transform.forward * detectionRadius;
            Vector3 rightEdge = Quaternion.Euler(0, fieldOfSight / 2, 0) * transform.forward * detectionRadius;

            Gizmos.DrawRay(transform.position, leftEdge);
            Gizmos.DrawRay(transform.position, rightEdge);
        }
    }
}
