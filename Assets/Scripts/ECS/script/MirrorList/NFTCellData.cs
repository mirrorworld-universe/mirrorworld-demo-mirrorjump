
using System.Collections.Generic;

public class NFTCellData
{
    public DataParsingEntity DataParsingEntity { get; set; }
    
}

public class Collection
{
    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string family { get; set; }
}
 
public class AttributeItem
{
    /// <summary>
    /// 
    /// </summary>
    public string trait_type { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string value { get; set; }
}
 
public class DataParsingEntity
{
  
    public string name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string symbol { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string description { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string image { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int seller_fee_basis_points { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Collection collection { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List <AttributeItem > attribute { get; set; }
        
        
}






