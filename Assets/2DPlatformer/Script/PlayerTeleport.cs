using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneSwitchStage))]

public class PlayerTeleport : MonoBehaviour
{

    [SerializeField]                                    //
    private GameObject  _tpCheck; 

    [SerializeField]                                    //
    private LayerMask   _layer;

    [SerializeField]                                    //
    private float       _radiusCircle;

    [SerializeField]
    private string      _cible;

    private bool        _tpAble;
    
    private SceneSwitchStage _switch;

    void Start()
    {
        _switch = new SceneSwitchStage();
    }

    public void FixedUpdate()
    {
        PerformTP();
    }

    private void PerformTP()
    {
        _tpAble = Physics2D.OverlapCircle(_tpCheck.transform.position, _radiusCircle, _layer);

        if (_tpAble) {
            _switch.StageSwitcher(_cible);
        }
    }
}
