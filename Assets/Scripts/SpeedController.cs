using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{

    [SerializeField] PlayerMovement player;

    [SerializeField] Button increaseSpeedBtn;
    [SerializeField] Button decreaseSpeedBtn;

    [SerializeField] Image speedBar;





    private void Start()
    {
        ChangeSpeed(0f);

    }

    public void ChangeSpeed(float changeBy)
    {
        float speed = Mathf.Clamp(player.CurrentMoveSpeed + changeBy, player.SpeedRange.x, player.SpeedRange.y);

        speedBar.fillAmount = Mathf.InverseLerp(player.SpeedRange.x, player.SpeedRange.y, speed);

        player.SetMoveSpeed(speed);


        increaseSpeedBtn.interactable = speed < player.SpeedRange.y;
        decreaseSpeedBtn.interactable= speed > player.SpeedRange.x;

    }

}
