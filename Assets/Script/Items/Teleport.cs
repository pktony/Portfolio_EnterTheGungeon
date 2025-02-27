using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour, ILootable
{
    private Animator padAnimator;
    private Animator lightAnimator;

    private void Awake()
    {
        padAnimator = transform.GetChild(0).GetComponent<Animator>();
        lightAnimator = transform.GetChild(1).GetComponent<Animator>();
    }

    public void LootAction()
    {
        StartCoroutine(TeleportDepart());
    }

    private IEnumerator TeleportDepart()
    {
        SoundManager.Inst.PlaySound_Item(Clips_Item.Teleport_Depart);
        yield return new WaitForSeconds(0.5f);
        EnemyManager.Inst.ReturnAllEnemies();
        SceneManager.LoadScene("Boss");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SoundManager.Inst.PlaySound_Item(Clips_Item.Teleport_Activate);
            lightAnimator.SetBool("isActivated", true);
            padAnimator.SetBool("isActivated", true);
        }
    }
}
