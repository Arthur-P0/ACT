using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts._Version_1._0.Controllers.RoomController;
using _Scripts._Version_1._0.Services.RoomServices.LiveStreamingRoomService;
using _Scripts._Version_1._0.Services.RoomServices.WoZRoomService;
using TMPro;
using UnityEngine;

public class RoomCreator : MonoBehaviour
{
    [Header("Instances")] [SerializeField] private TMP_InputField[] _inputFieldsTmp;
    
    private string _nameInput = "";
    private string _passwordInput = "";
    private string _confirmPasswordInput = "";

    private void Start()
    {
        ResetInputs();
    }

    #region Listeners

    public void UpdateName(string input)
    {
        _nameInput = input;
    }

    public void UpdatePassword(string input)
    {
        _passwordInput = input;
    }

    public void UpdateConfirmPassword(string input)
    {
        _confirmPasswordInput = input;
    }

    public void TryCreateRoom()
    {
        if (_nameInput == "")
        {
            Debug.Log("Name Input is empty");
            return;
        }
        
        if (_passwordInput == "")
        {
            Debug.Log("password is empty");
            return;
        }

        if (_passwordInput != _confirmPasswordInput)
        {
            Debug.Log("passwords don't match");
            return;
        }
        
        NetworkManager.Instance.CreateWoZRoom(_nameInput, _passwordInput);
        gameObject.AddComponent<WoZRoomService>();
        WoZRoomController woZRoomController = new WoZRoomController(GetComponent<WoZRoomService>());
        
        
        
        ResetInputs();
    }
    
    #endregion

    private void ResetInputs()
    {
        _nameInput = "";
        _passwordInput = "";
        _confirmPasswordInput = "";

        foreach (var input in _inputFieldsTmp)
        {
            input.text = "";
        }
    }
}
