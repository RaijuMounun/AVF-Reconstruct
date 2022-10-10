using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUpgrade : MonoBehaviour
{
    //arada bir bildirim simgesi görünecek
    [SerializeField] GameObject window, star, bonus1, bonus2, bonus3, bonusesParent;
    [SerializeField] float randomTime, timer;
    [SerializeField] bool bonusClaimed;
    public bool isAllBuildingsBought;

    List<GameObject> bonusesList = new List<GameObject>();

    public enum bonusesEnum
    {
        woodSpeed,
        woodIncome,
        ironOreSpeed,
        ironOreIncome,
        timberSpeed,
        timberIncome,
        ironIngotSpeed,
        ironIngotIncome,
        tableSpeed,
        tableIncome,
        nailSpeed,
        nailIncome,
        paintedTableSpeed,
        paintedTableIncome,
        gearSpeed,
        gearIncome
    }

    private void Start()
    {
        randomTime = Random.Range(30,61);

        bonusesList.Add(bonus1);
        bonusesList.Add(bonus2);
        bonusesList.Add(bonus3);
    }

    private void Update()
    {
        if (bonusClaimed == true && isAllBuildingsBought == true)
        {
            timer += Time.deltaTime;

        }
        if (timer >= randomTime)
        {
            star.SetActive(true);
            timer = 0;
            bonusClaimed = false;
        }
    }



    public void RandomUpgradeFunc(int enumParam)
    {
        var som = GameObject.FindGameObjectWithTag("SOManager").GetComponent<SO_Manager>();

        randomTime = Random.Range(30,61);
        bonusClaimed = true;
        //tuþun bonusunu eklemek
        switch ((bonusesEnum)enumParam)
        {
            case bonusesEnum.woodSpeed:
                som.objectsList[0].SpeedUpgrade1();
                break;
            case bonusesEnum.woodIncome:
                som.objectsList[0].IncomeUpgrade1();
                break;
            case bonusesEnum.ironOreSpeed:
                som.objectsList[4].SpeedUpgrade1();
                break;
            case bonusesEnum.ironOreIncome:
                som.objectsList[4].IncomeUpgrade1();
                break;
            case bonusesEnum.timberSpeed:
                som.objectsList[1].SpeedUpgrade1();
                break;
            case bonusesEnum.timberIncome:
                som.objectsList[1].IncomeUpgrade1();
                break;
            case bonusesEnum.ironIngotSpeed:
                som.objectsList[5].SpeedUpgrade1();
                break;
            case bonusesEnum.ironIngotIncome:
                som.objectsList[5].IncomeUpgrade1();
                break;
            case bonusesEnum.tableSpeed:
                som.objectsList[2].SpeedUpgrade1();
                break;
            case bonusesEnum.tableIncome:
                som.objectsList[2].IncomeUpgrade1();
                break;
            case bonusesEnum.nailSpeed:
                som.objectsList[6].SpeedUpgrade1();
                break;
            case bonusesEnum.nailIncome:
                som.objectsList[6].IncomeUpgrade1();
                break;
            case bonusesEnum.paintedTableSpeed:
                som.objectsList[3].SpeedUpgrade1();
                break;
            case bonusesEnum.paintedTableIncome:
                som.objectsList[3].IncomeUpgrade1();
                break;
            case bonusesEnum.gearSpeed:
                som.objectsList[7].SpeedUpgrade1();
                break;
            case bonusesEnum.gearIncome:
                som.objectsList[7].IncomeUpgrade1();
                break;
            default:
                break;
        }
        OpenWindow();
        for (int i = 0; i < 16; i++)
        {
            bonusesParent.transform.GetChild(i).gameObject.SetActive(false);
        }
    }




    public void OpenWindow()
    {
        window.SetActive(!window.activeInHierarchy);

        //bonusesparent'ýn rastgele bir childýný seçip onun transformunu bonuses1'e eþitleyip setactiveini açacak
        for (int i = 0; i < 3; i++)
        {
            ArrangeBonuses(i);
        }
    }

    void ArrangeBonuses(int order)
    {
        var randomIndex = Random.Range(0, 16);
        bonusesParent.transform.GetChild(randomIndex).gameObject.SetActive(true);
        bonusesParent.transform.GetChild(randomIndex).position = bonusesList[order].transform.position;
    }
}
