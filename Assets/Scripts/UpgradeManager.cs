using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public enum UpgradeType { ExtraTime, PlayerSpeed, PropDamage, TomatoCount, TomatoDamage, TomatoSize, TomatoSpeed };
    public List<Sprite> cardSprites;

    public UpgradeButton card1;
    public UpgradeButton card2;
    public UpgradeButton card3;

    void Start()
    {
        Stats.IncrementStage();

        List<UpgradeType> upgradeTypes = new List<UpgradeType>();
        
        upgradeTypes.Add(UpgradeType.ExtraTime);
        upgradeTypes.Add(UpgradeType.PlayerSpeed);
		upgradeTypes.Add(UpgradeType.PropDamage);
		upgradeTypes.Add(UpgradeType.TomatoCount);
		upgradeTypes.Add(UpgradeType.TomatoDamage);
		upgradeTypes.Add(UpgradeType.TomatoSize);
		upgradeTypes.Add(UpgradeType.TomatoSpeed);

        UpgradeType currentType = PickRandomType(upgradeTypes);
        card1.upgradeType = currentType;
        card1.gameObject.GetComponent<Image>().sprite = cardSprites[(int)currentType];

		currentType = PickRandomType(upgradeTypes);
		card2.upgradeType = currentType;
		card2.gameObject.GetComponent<Image>().sprite = cardSprites[(int)currentType];

		currentType = PickRandomType(upgradeTypes);
		card3.upgradeType = currentType;
		card3.gameObject.GetComponent<Image>().sprite = cardSprites[(int)currentType];
	}

    private UpgradeType PickRandomType(List<UpgradeType> listIn)
    {
        int randomIndex = Random.Range(0, listIn.Count);
        UpgradeType type = listIn[randomIndex];
        listIn.RemoveAt(randomIndex);
        return type;
    }
}
