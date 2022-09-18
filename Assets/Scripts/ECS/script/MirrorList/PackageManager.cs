using System.Collections.Generic;
using UnityEngine;

public class PackageManager : MonoBehaviour
{
    public ListView ListView;
   
   public CanvasGroup LeftPageTurningCanvas;

   public CanvasGroup RightPageTurningCanvas;
   
   public GameObject Package;

   public ListViewDataProvider ListViewDataProvider;

  
   
   public void OnTurningLeft()
   { 
       ListView.ToLeftPage();
      PageTurningStateUpdate(false);
   }

   public void OnTurningRight()
   {   ListView.ToRightPage();
       PageTurningStateUpdate(false);
   }
   
   public void OpenPackage()
   {    
      
       // 刷新逻辑
       ListViewDataProvider.NFTListView.SetDataProvider(ListViewDataProvider);
           
       ListViewDataProvider.DataSource.Clear();
       
       ListViewDataProvider.DataSource.Add(GenerateDefaultCellData());


       if ("false" == PlayerPrefs.GetString("HasMintRandom", "false"))
       {
           ListViewDataProvider.DataSource.Add(GenerateRandomCellData());
       }
      
       
       ListViewDataProvider.NFTListView.OnDataSourceChange();
       PageTurningStateUpdate(true);
       
       Package.SetActive(true);
       
   }


   private NFTCellData GenerateDefaultCellData()
   {
       NFTCellData nftCellData = new NFTCellData();
       DataParsingEntity dataParsingEntity = new DataParsingEntity();
       nftCellData.DataParsingEntity = dataParsingEntity;
      
       // replaced default descripe
       nftCellData.DataParsingEntity.description =
           "Mirror Jump is our tribute to Doodle Jump, powered by Mirror World SDK. We hope that this game will help players to better understand the fun aspects of Web3 games and help developers to better understand how to use the Mirror World SDK.";
       nftCellData.DataParsingEntity.attribute = new List<AttributeItem>();
       AttributeItem attributeItemRare = new AttributeItem();
       attributeItemRare.trait_type = "Rarity";
       AttributeItem attributeItemName = new AttributeItem();
       attributeItemName.trait_type = "Type";
       nftCellData.DataParsingEntity.attribute.Add(attributeItemRare);
       nftCellData.DataParsingEntity.attribute.Add(attributeItemName);
       
       nftCellData.DataParsingEntity.image = "http://metadata-assets.mirrorworld.fun/mirror_jump/images/Rare_Astronaut.png";
       nftCellData.DataParsingEntity.attribute[0].value = "Rare";
       nftCellData.DataParsingEntity.attribute[1].value = "Astronaut";

       return nftCellData;

   }

   private NFTCellData GenerateRandomCellData()
   {


       if ("false" == PlayerPrefs.GetString("HasGenerate", "false"))
       {
           RandomData();
           PlayerPrefs.SetString("HasGenerate","true");
       }
       
      // RandomData();
       
       
       NFTCellData nftCellData = new NFTCellData();
       DataParsingEntity dataParsingEntity = new DataParsingEntity();
       nftCellData.DataParsingEntity = dataParsingEntity;
       
       nftCellData.DataParsingEntity.description =
           "Mirror Jump is our tribute to Doodle Jump, powered by Mirror World SDK. We hope that this game will help players to better understand the fun aspects of Web3 games and help developers to better understand how to use the Mirror World SDK.";
       nftCellData.DataParsingEntity.attribute = new List<AttributeItem>();
       AttributeItem attributeItemRare = new AttributeItem();
       attributeItemRare.trait_type = "Rarity";
       AttributeItem attributeItemName = new AttributeItem();
       attributeItemName.trait_type = "Type";
       nftCellData.DataParsingEntity.attribute.Add(attributeItemRare);
       nftCellData.DataParsingEntity.attribute.Add(attributeItemName);
       
       
       // http://metadata-assets.mirrorworld.fun/mirror_jump/images/Rare_Pirate%20Captain.png
       string imageUrl = Constant.ImagePrefix + PlayerPrefs.GetString("Rarity", "Rare") + "_" +
                         PlayerPrefs.GetString("name", "Pirate Captain") + ".png";
       nftCellData.DataParsingEntity.image = imageUrl;
       nftCellData.DataParsingEntity.attribute[0].value =   PlayerPrefs.GetString("Rarity","Rare");
       nftCellData.DataParsingEntity.attribute[1].value =  PlayerPrefs.GetString("name","Pirate Captain");

       return nftCellData;
       
      
   }

  

   private void RandomData()
   {
       int rate = Random.Range(1, 101);

       if (rate < 40)
       {
           PlayerPrefs.SetString("Rarity","Common");
           
       }else if (rate < 70)
       {
           PlayerPrefs.SetString("Rarity","Rare");
           
       }else if (rate < 85)
       {
           PlayerPrefs.SetString("Rarity","Elite");
           
       }else if (rate < 95)
       {
           PlayerPrefs.SetString("Rarity","Legendary");
       }
       else
       {
           PlayerPrefs.SetString("Rarity","Mythical");
       }
       
       
       int type = Random.Range(1, 6);

       switch (type)
       {
           case 1:
               PlayerPrefs.SetString("name","Cat Maid");
               break;
           case 2:
               PlayerPrefs.SetString("name","Samurai");
               break;
           case 3:
               PlayerPrefs.SetString("name","Zombie");
               break;
           case 4:
               PlayerPrefs.SetString("name","Pirate Captain");
               break;
           case 5:
               PlayerPrefs.SetString("name","Astronaut");
               break;
       }
       
       
   }

  
   public void ClosePackage()
   {
       Package.SetActive(false);
       
       ListView.RecycleAllItems();
   }


   public void RecycleItems()
   {
       ListView.RecycleAllItems();
   }
   
   public void PageTurningStateUpdate(bool IsFirst)
   {
       PageTurningState State = ListView.GetPageTurningState(IsFirst);

       if (State == PageTurningState.Both)
       {
           LeftPageTurningCanvas.alpha = 1;
           RightPageTurningCanvas.alpha = 1;
           
       
           
       }else if (State == PageTurningState.None)
       {
           LeftPageTurningCanvas.alpha = 0;
           RightPageTurningCanvas.alpha = 0;
           
         
           
       }else if (State == PageTurningState.OnlyLeft)
       {
           LeftPageTurningCanvas.alpha = 1;
           RightPageTurningCanvas.alpha = 0.5f;
           
        
           
       }else if (State == PageTurningState.OnlyRight)
       {
           LeftPageTurningCanvas.alpha = 0.5f;
           RightPageTurningCanvas.alpha = 1;
           
       }
      
       
   }
   
}
