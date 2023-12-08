﻿namespace Poultry.Domain.Entities
{
    public class Chicken : BaseEntity
    {

        public bool Gender { get; set; }
        public byte Age { get; set; }
        public ChickenType ChickenType { get; set; }
        public int Weight { get; set; }
        public byte LayingRate { get; set; }

        public HealthStatus HealthStatus { get; set; }


        //public  Orderby { get; set; }

    }

    #region ChickenTypeEnum
    
    public enum ChickenType : byte
    {
       
        eggy = 0,
        meaty,
        others
    }

    #endregion

    #region OrderBy
    //public enum OrderBy : byte
    //{
    //    None = 0,
    //    Ascending,
    //    Desending,

    //}
    #endregion
}
