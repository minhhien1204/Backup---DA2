namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHUYENMUC")]
    public partial class CHUYENMUC
    {
        [Key]
        public int IDCM { get; set; }

        public int? IDCMCha { get; set; }

        [StringLength(50)]
        public string TenCM { get; set; }

        [StringLength(500)]
        public string Link { get; set; }
    }
}
