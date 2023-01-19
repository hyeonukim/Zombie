using Photon.Pun;
using UnityEngine;

// Item class: Supplies ammo
public class AmmoPack : MonoBehaviourPun, IItem {
    public int ammo = 30; // Amount of ammo supplies

    public void Use(GameObject target) {

        PlayerShooter playerShooter = target.GetComponent<PlayerShooter>();

        if (playerShooter != null && playerShooter.gun != null)
        {
            playerShooter.gun.photonView.RPC("AddAmmo", RpcTarget.All, ammo);
        }

        PhotonNetwork.Destroy(gameObject);
    }
}