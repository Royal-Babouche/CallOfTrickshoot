using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform[] _listeHits;
    [SerializeField] private bool _hitDetect, _touchPlayerOrEsclave;
    [SerializeField] private int _nbHits;
    [SerializeField] private long _longueur;

    private void Start()
    {

    }

    private void Update()
    {
        if (_hitDetect)
        {
            if (_touchPlayerOrEsclave)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10000, Color.red);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10000, Color.green);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10000, Color.yellow);
        }
    }

    private void FixedUpdate()
    {
        RayCastAll();
    }

    private void RayCastAll()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, Mathf.Infinity, _layerMask);

        if (hits.Length == 0)
        {
            // Debug.Log("RayCastWeapon : Aucune detection");
            _hitDetect = false;
            _listeHits = new Transform[0];
        }
        else
        {
            _hitDetect = true;
            _listeHits = new Transform[hits.Length];
            _longueur = hits.LongLength;
            _nbHits = hits.Length;
        }
        bool verifTouchPlayerEsclave = false;
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            _listeHits.SetValue(hit.transform, i);

            // Debug.Log("Transform Name = " + hit.transform.name + " / hit.point = " + hit.point + " / .hit.collider.contactOffset = " + hit.collider.contactOffset);
            if(hit.transform.gameObject.layer == 10 || hit.transform.gameObject.layer == 11)
            {
                verifTouchPlayerEsclave = true;
            }
        }
        if(verifTouchPlayerEsclave)
        {
            _touchPlayerOrEsclave = true;
        }
        else
        {
            _touchPlayerOrEsclave = false;
        }
    }
}
