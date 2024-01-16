using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeOutAnimation : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    [SerializeField] private bool _range, _out, _dontChange;
    [SerializeField] private PlayerAction01 _playerAction01;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_playerAction01 == null)
        {
            _playerAction01 = animator.GetComponentInParent<PlayerAction01>();
        }
        if (_out)
        {
            _playerAction01.DesactiveAllTape();
            _playerAction01.SetRange(false);
            _playerAction01.ChangeWeaponState();
            _playerAction01.SetOut(true);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
/*    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }*/

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_out)
        {
            _playerAction01.SetOut(false);
        }
        _playerAction01.DesactiveAllTape();
    }

    private void Enter1(Animator animator)
    {
        if (_range)
        {
            Debug.Log("OnStateEnter _range RangeOutAnimation");
        }
        if (_out)
        {
            Debug.Log("OnStateEnter _out RangeOutAnimation");
            animator.SetBool("Range", false);
            _playerAction01.SetRangeState(false);
            animator.SetBool("Out", true);
            _playerAction01.SetOutState(true);
            _playerAction01.ChangeWeaponState();
        }
    }

    private void Exit1(Animator animator)
    {
        if (_range)
        {
            Debug.Log("OnStateExit _range RangeOutAnimation");
        }
        else if (_out)
        {
            Debug.Log("OnStateExit _out RangeOutAnimation");
            animator.SetBool("Out", false);
            _playerAction01.SetOutState(false);
        }
        _playerAction01.SetDesappui(false);
        _playerAction01.SetDesactiveAppuiState(false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
