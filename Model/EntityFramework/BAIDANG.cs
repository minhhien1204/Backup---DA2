namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAIDANG")]
    public partial class BAIDANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BAIDANG()
        {
            LUOTXEMs = new HashSet<LUOTXEM>();
        }

        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDBaiDang { get; set; }

        [StringLength(300)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Tên bài đăng")]
        public string TenBaiDang { get; set; }

        [StringLength(300)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [StringLength(200)]
        public string UrlRequire { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [StringLength(500)]
        [Display(Name = "Ảnh đại diện")]
        public string AnhDaiDien { get; set; }




        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        public int IDTaiKhoan { get; set; }





        [Column(TypeName = "date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayDang { get; set; }

        [StringLength(50)]
        public string TrangThaiBaiDang { get; set; }
        [Display(Name = "Thể loại")]
        public int IDTheLoai { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }

        public virtual THELOAI THELOAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LUOTXEM> LUOTXEMs { get; set; }
    }
}
