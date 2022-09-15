using UnityEngine;

public class Packageanager : MonoBehaviour
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
       Package.SetActive(true);
       ListViewDataProvider.NFTListView.SetDataProvider(ListViewDataProvider);
     
       
       //ListViewDataProvider.DataSource.Add(nftDataCell);  refresh
   
            
       ListViewDataProvider.NFTListView.OnDataSourceChange();
       PageTurningStateUpdate(true);
   }

  
   public void ClosePackage()
   {
       Package.SetActive(false);
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
