using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicIdentifier : MonoBehaviour
{
    public Player player;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "music"){

            player.victory = true;
            player.playable = false;
            player.NextLevel();
        }
    }
}
