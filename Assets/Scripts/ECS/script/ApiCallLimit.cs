
    using System.Collections.Generic;
    using UnityEngine;

    public class ApiCallLimit:Singleton<ApiCallLimit>
    {
        
        
        // limit SDK Api Call

        private static Dictionary<string, CallApiState> CallStates = new Dictionary<string, CallApiState>();
        
        public static void AddItemState(string mintAddress, CallApiState callApiState)
        {
            CallStates.Add(mintAddress,callApiState);
        }

        public static string GetStateByAddress(string mintAddress)
        {

            if (CallStates[mintAddress].State == CallState.Listing)
            {
                return "Listing";
                
            }else if(CallStates[mintAddress].State == CallState.Update)
            {
                return "Changing New Price";

            }else if(CallStates[mintAddress].State == CallState.Cancel)
            {

                return "Canceling List";
                
            }else if(CallStates[mintAddress].State == CallState.Transfer)
            {
                return "Transfer";
            }
            
            return "";
            
        }
        
        public static CallApiState GetStateItemByAddress(string mintAddress)
        {
            return CallStates[mintAddress];
        }
        
        

        public static void DeleteItemState(string mintAddress)
        {
            CallStates.Remove(mintAddress);
            
        }
        
        public static bool CallTradeLimit(string mintAddress)
        {
            if (CallStates.ContainsKey(mintAddress))
            {
                return false;
            }
            
            return true;

        }


        
        
        public static bool MintLimit()
        {
            if (Constant.ExecuteMint == PlayerPrefs.GetInt("IsExecuteMint", Constant.StopMint))
            {
                return false;
            }

            return true;
        }


        public static void SetMintApiLimit(int isExecuteMint)
        {
            PlayerPrefs.SetInt("IsExecuteMint", isExecuteMint);
        }
        
        
        
        
        
    }
